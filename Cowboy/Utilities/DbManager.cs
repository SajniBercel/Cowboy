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

                    command = new MySqlCommand($"USE {db} CREATE TABLE IF NOT EXISTS rounds (" +
                        "player1_name varchar(20), player2_name varchar(20), game_time float" +
                        ")",
                        tempconn);
                    command.ExecuteNonQuery();

                    tempconn.Close();

                    Open(server, user, password, db);
                    connected = true;
                }
                if (ex.ErrorCode == MySqlErrorCode.UnableToConnectToHost)
                {
                    MessageBox.Show("Sikertelen adatbázis kapcsolat, ellenörízze a szolgáltatást\n" +
                        "(minden müködni fog de nem fog adatbázisba menteni, fájlba történik a mentés és legközelebbi sikeres kapcsolatkor átíródik az adatbázisba)");
                }
            }
        }

        public void Save()
        {
            if (!connected)
            {
                return;
            }
            try
            {

                MySqlCommand cmd = new MySqlCommand("select * from games", MyConnection);
                MySqlDataReader data = cmd.ExecuteReader();
                //MessageBox.Show(data.Read().ToString());
            }
            catch (MySqlException ex)
            {
                //MessageBox.Show("ez:"+ex.ErrorCode.ToString());
            }
        }

        public void Close()
        {
            MyConnection.Close();
        }
    }
}
