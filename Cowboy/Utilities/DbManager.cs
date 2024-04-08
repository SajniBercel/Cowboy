﻿using MySqlConnector;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Schema;

namespace Cowboy.Utilities
{
    public class DbManager
    {
        private static readonly DbManager instance = new DbManager();
        public static DbManager Instance { get { return instance; } }

        private string MyConnectionString;
        bool connected = false;
        private MySqlConnection MyConnection;

        /// <summary>
        /// Ide ment ha nincs adatbázis kapcsolat (ha lesz kapcsolatm akkor feltölti)
        /// </summary>
        private string FilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Cowboy";

        private DbManager() 
        {
            Open("localhost", "root", "", "cowboy");
        }

        /// <summary>
        /// Megnyitja az adatbázis kapcsolatot
        /// </summary>
        /// <param name="server">Elérhetőség (Domain)</param>
        /// <param name="user">Felhasználó név</param>
        /// <param name="password">Jelszó</param>
        /// <param name="db">Adatbázis neve</param>
        private void Open(string server, string user, string password, string db)
        {
            try
            {
                MyConnectionString = $"server={server};port=3306;uid={user};pwd={password};database={db}";
                MyConnection = new MySqlConnection(MyConnectionString);

                MyConnection.Open();

                connected = true;
            }
            catch (MySqlException ex)
            {
                if (ex.ErrorCode == MySqlErrorCode.UnknownDatabase)
                {
                    MySqlConnection MyConnection = new MySqlConnection($"server={server};uid={user};pwd={password};");
                    MyConnection.Open();

                    MySqlCommand command = new MySqlCommand($"CREATE DATABASE IF NOT EXISTS {db};", MyConnection);
                    command.ExecuteNonQuery();

                    command = new MySqlCommand($"USE {db}; CREATE TABLE IF NOT EXISTS games (" +
                        "win varchar(20), lose varchar(20), time float" +
                        ")",
                        MyConnection);
                    command.ExecuteNonQuery();
                    command.Dispose();

                    MyConnection = new MySqlConnection(MyConnectionString);

                    connected = true;
                }

                if (ex.ErrorCode == MySqlErrorCode.UnableToConnectToHost)
                {
                    MessageBox.Show("Sikertelen adatbázis kapcsolat, ellenörízze a szolgáltatást\n" +
                        "(minden müködni fog de nem fog adatbázisba menteni, fájlba történik a mentés és legközelebbi sikeres kapcsolatkor átíródik az adatbázisba)");
                }
            }
            MyConnection.Close();
        }

        /// <summary>
        /// Menti az adatokat az adatbázisba (!nem ellenőriz arra hogy az adat létezik-e már az adatbázisban!)
        /// </summary>
        /// <param name="win">Gyöztes játékos neve</param>
        /// <param name="lose">Vesztes játékos neve</param>
        /// <param name="time">a játék időtartama</param>
        public void Save(string win, string lose, float time)
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            if (!connected)
            {
                FileManager.Instance.SaveToFile($"{win};{lose};{time}");
                return;
            }
            try
            {
                MyConnection.Open();

                string sql = $"INSERT INTO games (win, lose, time) VALUES ('{win}', '{lose}', {time});";
                MySqlCommand command = new MySqlCommand(sql, MyConnection);

                command.ExecuteNonQuery();
                command.Dispose();
                
                MyConnection.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Save error:"+ex.ErrorCode.ToString());
            }

            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
        }

        /// <summary>
        /// Ha van adatbázis kapcsolat akkor az adatbázisból szedi le az adatokat (indításkor és mentéskor szinkronizál)
        /// vagy ha nincs akkor a fájlból olvassa be az ideiglenesen tárolt adatokat
        /// </summary>
        /// <returns>";"-vel tagolva visszaadja a mentett adatokat soronként egy string tömbbe</returns>
        public string[] GetScoreBoard()
        {
            List<string> output = new List<string>();

            if (!connected)
            {
                output.AddRange(FileManager.Instance.ReadGameLogs());
                return output.ToArray();
            }
            
            MyConnection = new MySqlConnection(MyConnectionString);
            MyConnection.Open();
            MySqlCommand command = new MySqlCommand("SELECT * FROM games", MyConnection);
            MySqlDataReader reader = command.ExecuteReader();
            while(reader.Read()) 
            {
                output.Add($"{reader[0]};{reader[1]};{reader[2]}");
            }

            MyConnection.Close();

            return output.ToArray();
        }

        public void SyncDb()
        {
            if (connected)
            {
                string[] GameLogs = FileManager.Instance.ReadGameLogs();
                if (GameLogs != null)
                {
                    for (int i = 0; i < GameLogs.Length; i++)
                    {
                        string row = GameLogs[i];
                        string[] parts = row.Split(";");
                        Save(parts[0], parts[1], float.Parse(parts[2]));
                    }
                }
            }
        }
    }
}
