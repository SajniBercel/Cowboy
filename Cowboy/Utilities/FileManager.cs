using Cowboy.Settings;

namespace Cowboy.Utilities
{
    public class FileManager
    {
        private static readonly FileManager instance = new FileManager();
        public static FileManager Instance { get { return instance; } }
        public string Folder { get { return folder; } }

        private string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Cowboy";

        private string inputSettingsPath;
        private string playerSettingsPath;
        private string gameLogsPath;

        private FileManager()
        {
            inputSettingsPath = folder + @"\InputSettings.txt";
            playerSettingsPath = folder + @"\PlayerSettings.txt";
            gameLogsPath = folder + @"\GamesLog.txt";

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            if (!File.Exists(inputSettingsPath))
                File.Create(inputSettingsPath);

            if (!File.Exists(playerSettingsPath))
                File.Create(playerSettingsPath);

            if (!File.Exists(gameLogsPath))
                File.Create(gameLogsPath);
        }

        /// <summary>
        /// Menti a billentyű beállításokat fájlba
        /// </summary>
        /// <param name="inputSettings"></param>
        public void SaveToFile(InputSetting[] inputSettings)
        {
            if (!File.Exists(inputSettingsPath))
            {
                MessageBox.Show("Hiba, nem létezik a:" + inputSettingsPath + " fájl");
            }

            if (inputSettings.Length != 2)
            {
                MessageBox.Show("Hiba a file-ba mentés közben \n(a beállítások müködni fognak de nem újraindításokor elvesznek)");
                return;
            }

            using (StreamWriter sw = new StreamWriter(inputSettingsPath))
            {
                sw.WriteLine($"{inputSettings[0].UpKey};{inputSettings[0].DownKey};{inputSettings[0].ShootKey}");
                sw.WriteLine($"{inputSettings[1].UpKey};{inputSettings[1].DownKey};{inputSettings[1].ShootKey}");
                sw.Close();
            }
        }

        /// <summary>
        /// Menti a játékos beállításokat fájlba
        /// </summary>
        /// <param name="playerSettings"></param>
        public void SaveToFile(PlayerSetting[] playerSettings)
        {
            if (!File.Exists(playerSettingsPath))
            {
                MessageBox.Show("Hiba, nem létezik a:" + playerSettingsPath + " fájl");
            }

            if (playerSettings.Length != 2)
            {
                MessageBox.Show("Hiba a file-ba mentés közben \n(a beállítások müködni fognak de újraindításokor elvesznek)");
                return;
            }

            using (StreamWriter sw = new StreamWriter(playerSettingsPath))
            {

                sw.WriteLine(playerSettings[0].FileFormat());
                sw.WriteLine(playerSettings[1].FileFormat());
                sw.Close();
            }
        }

        /// <summary>
        /// Menti a lejátszott meccs adatait ideiglenes fájlba ahonnan majd fel lesz töltve az adatbázisba
        /// </summary>
        /// <param name="game">*gyöztes játékos neve*;*vesztes játékos neve*;játék időtartama</param>
        public void SaveToFile(string game)
        {
            if (!File.Exists(gameLogsPath))
            {
                MessageBox.Show("Hiba, nem létezik a:" + gameLogsPath + " fájl");
            }

            using (StreamWriter sw = new StreamWriter(gameLogsPath, append:true))
            {
                sw.WriteLine(game);
                sw.Close();
            }
        }

        /// <summary>
        /// Visszaadja a GameLogs fájl tartalmát
        /// </summary>
        /// <returns>null-t ad vissza ha üres a file, egyébként a tartalmát, soronként elválasztott string tömbben</returns>
        public string[]? ReadGameLogs()
        {
            if (File.Exists(gameLogsPath))
            {
                using (StreamReader sr = new StreamReader(gameLogsPath))
                {
                    if (sr.EndOfStream)
                        return null;

                    List<string> output = new List<string>();
                    while (!sr.EndOfStream)
                    {
                        output.Add(sr.ReadLine());
                    }
                    sr.Close();

                    return output.ToArray();
                }
            }
            return null;
        }

        /// <summary>
        /// Visszaadja a InputSettings fájl tartalmát
        /// </summary>
        /// <returns>null-t ad vissza ha üres a file, egyébként a tartalmát, soronként elválasztott string tömbben</returns>
        public InputSetting[]? ReadInputSettingsFromFile()
        {
            if (File.Exists(inputSettingsPath))
            {
                using (StreamReader sr = new StreamReader(inputSettingsPath))
                {
                    if (sr.EndOfStream)
                        return null;

                    string[] lines = new string[2];
                    int index = 0;
                    while (!sr.EndOfStream)
                    { 
                        string line = sr.ReadLine();
                        if (line != null && line.Length>1)
                        {
                            lines[index] = line;
                            index++;
                        }
                    }

                    string[] parts1;
                    string[] parts2;
                    if (lines.Length == 2)
                    {
                        parts1 = lines[0].Split(";");
                        parts2 = lines[1].Split(";");
                    }
                    else
                    {
                        return null;
                    }

                    sr.Close();

                    InputSetting[] inputSettings = new InputSetting[]
                    {
                        new InputSetting(
                            (Keys)Enum.Parse(typeof(Keys), parts1[0], true),
                            (Keys)Enum.Parse(typeof(Keys), parts1[1], true),
                            (Keys)Enum.Parse(typeof(Keys), parts1[2], true)
                            ),
                        new InputSetting(
                            (Keys)Enum.Parse(typeof(Keys), parts2[0], true),
                            (Keys)Enum.Parse(typeof(Keys), parts2[1], true),
                            (Keys)Enum.Parse(typeof(Keys), parts2[2], true)
                            )
                    };

                    return inputSettings;
                }
            }
            return null;
        }

        /// <summary>
        /// Visszaadja a PlayerSettings fájl tartalmát
        /// </summary>
        /// <returns>null-t ad vissza ha üres a file, egyébként a tartalmát, soronként elválasztott string tömbben</returns>
        public PlayerSetting[]? ReadPlayerSettingsFromFile()
        {
            if (File.Exists(playerSettingsPath))
            {
                using (StreamReader sr = new StreamReader(playerSettingsPath))
                {
                    if (sr.EndOfStream)
                        return null;

                    string[] lines = new string[2];
                    int index = 0;
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        if (line != null && line.Length > 1)
                        {
                            lines[index] = line;
                            index++;
                        }
                    }
                    sr.Close();

                    string[] parts1 = lines[0].Split(";");
                    string[] parts2 = lines[1].Split(";");
;

                    PlayerSetting[] inputSettings = new PlayerSetting[]
                    {
                        new PlayerSetting(
                            parts1[0],
                            int.Parse(parts1[1]),
                            int.Parse(parts1[2]),
                            int.Parse(parts1[3]),
                            int.Parse(parts1[4]),
                            int.Parse(parts1[5]),
                            parts1[6] == "True"
                            ),
                        new PlayerSetting(
                            parts2[0],
                            int.Parse(parts2[1]),
                            int.Parse(parts2[2]),
                            int.Parse(parts2[3]),
                            int.Parse(parts2[4]),
                            int.Parse(parts2[5]),
                            parts2[6] == "True"
                            ),
                    };

                    return inputSettings;
                }
            }
            return null;
        }

        public void RmGameLogs()
        {
            if (File.Exists(gameLogsPath))
            {
                using (StreamWriter sw = new StreamWriter(gameLogsPath))
                {
                    sw.Write("");
                    sw.Close();
                }
            }
        }
    }
}
