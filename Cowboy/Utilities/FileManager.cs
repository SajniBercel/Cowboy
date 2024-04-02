using Cowboy.Settings;

namespace Cowboy.Utilities
{
    public class FileManager
    {
        private static readonly FileManager instance = new FileManager();
        public static FileManager Instance { get { return instance; } }


        private string Folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Cowboy";

        private string InputSettingsPath;
        private string PlayerSettingsPath;


        private FileManager()
        {
            InputSettingsPath = Folder + "/InputSettings.txt";
            PlayerSettingsPath = Folder + "/PlayerSettings.txt";

            if (!Directory.Exists(Folder))
                Directory.CreateDirectory(Folder);

            if (!File.Exists(InputSettingsPath))
                File.Create(InputSettingsPath);

            if (!File.Exists(PlayerSettingsPath))
                File.Create(PlayerSettingsPath);
        }

        public void SaveToFile(InputSetting[] inputSettings)
        {
            if (!File.Exists(InputSettingsPath))
            {
                MessageBox.Show("Hiba nem létezik a file (i)");
            }

            if (inputSettings.Length != 2)
            {
                MessageBox.Show("Hiba a file-ba mentés közben \n(a beállítások müködni fognak de nem újraindításokor elvesznek)");
                return;
            }

            using (StreamWriter sw = new StreamWriter(InputSettingsPath))
            {

                sw.WriteLine($"{inputSettings[0].UpKey};{inputSettings[0].DownKey};{inputSettings[0].ShootKey}");
                sw.WriteLine($"{inputSettings[1].UpKey};{inputSettings[0].DownKey};{inputSettings[0].ShootKey}");
                sw.Close();
            }
        }

        public void SaveToFile(PlayerSetting[] playerSettings)
        {
            if (!File.Exists(PlayerSettingsPath))
            {
                MessageBox.Show("Hiba nem létezik a file (i)");
            }

            if (playerSettings.Length != 2)
            {
                MessageBox.Show("Hiba a file-ba mentés közben \n(a beállítások müködni fognak de nem újraindításokor elvesznek)");
                return;
            }

            using (StreamWriter sw = new StreamWriter(PlayerSettingsPath))
            {

                sw.WriteLine(playerSettings[0].FileFormat());
                sw.WriteLine(playerSettings[1].FileFormat());
                sw.Close();
            }
        }

        public InputSetting[]? ReadInputSettingsFromFile()
        {
            if (File.Exists(InputSettingsPath))
            {
                using (StreamReader sr = new StreamReader(InputSettingsPath))
                {
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
                            ),
                    };

                    return inputSettings;
                }
            }
            return null;
        }

        public PlayerSetting[]? ReadPlayerSettingsFromFile()
        {
            if (File.Exists(PlayerSettingsPath))
            {
                using (StreamReader sr = new StreamReader(PlayerSettingsPath))
                {
                    string data = sr.ReadToEnd();
                    string[] lines = data.Split("\r\n");
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

                    PlayerSetting[] inputSettings = new PlayerSetting[]
                    {
                        new PlayerSetting(
                            parts1[0],
                            int.Parse(parts1[1]),
                            int.Parse(parts1[2]),
                            int.Parse(parts1[3]),
                            int.Parse(parts1[4]),
                            int.Parse(parts1[5]),
                            parts1[5] == "True"
                            ),
                        new PlayerSetting(
                            parts1[0],
                            int.Parse(parts2[1]),
                            int.Parse(parts2[2]),
                            int.Parse(parts2[3]),
                            int.Parse(parts2[4]),
                            int.Parse(parts2[5]),
                            parts1[5] == "True"
                            ),
                    };

                    return inputSettings;
                }
            }
            return null;
        }
    }
}
