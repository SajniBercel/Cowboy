using MySqlConnector;

namespace Cowboy.Utilities
{
    public class DbManager
    {
        private static readonly DbManager instance = new DbManager();
        public static DbManager Instance { get { return instance; } }

        private string MyConnectionString;
        bool connected = false;
        private MySqlConnection MyConnection;

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
                    MySqlConnection tempconn = new MySqlConnection($"server={server};uid={user};pwd={password};");
                    MySqlCommand command = new MySqlCommand($"CREATE DATABASE IF NOT EXISTS {db};", tempconn);
                    tempconn.Open();
                    command.ExecuteNonQuery();
                    tempconn.Close();

                    tempconn.Open();
                    command = new MySqlCommand($"USE {db}; CREATE TABLE IF NOT EXISTS games (" +
                        "gyoztes varchar(20), vesztes varchar(20), time float" +
                        ")",
                        tempconn);
                    command.ExecuteNonQuery();
                    tempconn.Close();

                    MyConnection = new MySqlConnection(MyConnectionString);
                    MyConnection.Open();
                    connected = true;
                }
                if (ex.ErrorCode == MySqlErrorCode.UnableToConnectToHost)
                {
                    MessageBox.Show("Sikertelen adatbázis kapcsolat, ellenörízze a szolgáltatást\n" +
                        "(minden müködni fog de nem fog adatbázisba menteni, fájlba történik a mentés és legközelebbi sikeres kapcsolatkor átíródik az adatbázisba)");
                }
            }
        }

        public void Save(string sor)
        {
            if (!connected)
            {
                return;
            }

            try
            {

                MySqlCommand cmd = new MySqlCommand("select * from games", MyConnection);
                MySqlDataReader data = cmd.ExecuteReader();
                while (data.Read())
                {
                    //MessageBox.Show(data["ads"]);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ez:"+ex.ErrorCode.ToString());
            }
        }

        public void Close()
        {
            MyConnection.Close();
        }
    }
}
