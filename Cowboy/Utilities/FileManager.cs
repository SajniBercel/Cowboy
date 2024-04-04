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
        private string layerSettingsPath;


        private FileManager()
        {
            inputSettingsPath = folder + "/InputSettings.txt";
            layerSettingsPath = folder + "/PlayerSettings.txt";

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            if (!File.Exists(inputSettingsPath))
                File.Create(inputSettingsPath);

            if (!File.Exists(layerSettingsPath))
                File.Create(layerSettingsPath);
        }

        public void SaveToFile(InputSetting[] inputSettings)
        {
            if (!File.Exists(inputSettingsPath))
            {
                MessageBox.Show("Hiba nem létezik a file (i)");
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

        public void SaveToFile(PlayerSetting[] playerSettings)
        {
            if (!File.Exists(layerSettingsPath))
            {
                MessageBox.Show("Hiba nem létezik a file (i)");
            }

            if (playerSettings.Length != 2)
            {
                MessageBox.Show("Hiba a file-ba mentés közben \n(a beállítások müködni fognak de nem újraindításokor elvesznek)");
                return;
            }

            using (StreamWriter sw = new StreamWriter(layerSettingsPath))
            {

                sw.WriteLine(playerSettings[0].FileFormat());
                sw.WriteLine(playerSettings[1].FileFormat());
                sw.Close();
            }
        }

        public InputSetting[]? ReadInputSettingsFromFile()
        {
            if (File.Exists(inputSettingsPath))
            {
                using (StreamReader sr = new StreamReader(inputSettingsPath))
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
                    if (lines.Length == 2 && lines[0] != null && lines[1] != null)
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

        public PlayerSetting[]? ReadPlayerSettingsFromFile()
        {
            if (File.Exists(layerSettingsPath))
            {
                using (StreamReader sr = new StreamReader(layerSettingsPath))
                {
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

                    string[] parts1 = lines[0].Split(";");
                    string[] parts2 = lines[1].Split(";");

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
    }
}
