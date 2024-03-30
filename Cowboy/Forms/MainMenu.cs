using Cowboy.Classes;
using Cowboy.Forms;
using Cowboy.Settings;
using System.Diagnostics;

namespace Cowboy
{
    public partial class MainMenu : Form
    {
        private PlayerSetting[]? playerSettings;
        private InputSetting[]? inputSettings;
        private bool playerClone;
        
        
        public MainMenu()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ShowIcon = false;

        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            playerSettings = FileManager.Instance.ReadPlayerSettingsFromFile();
            inputSettings = FileManager.Instance.ReadInputSettingsFromFile();

            // player setting alapbeállítások
            if (inputSettings == null)
            {
                MessageBox.Show("baj");
                playerSettings = new PlayerSetting[2];
                playerSettings[0] = new PlayerSetting().SetDefaultValues().SetPlayerName("Player1");
                playerSettings[1] = new PlayerSetting().SetDefaultValues().SetPlayerName("Player2");
            }

            // input setting alapbeállítások
            if (inputSettings == null)
            {
                inputSettings = new InputSetting[2];
                inputSettings[0] = new InputSetting(Keys.W, Keys.S, Keys.D);
                inputSettings[1] = new InputSetting(Keys.NumPad8, Keys.NumPad5, Keys.NumPad4);
            }

            playerClone = true;
        }
        private void btn_Start_Click(object sender, EventArgs e)
        {
            // open game \\
            Game Game = new Game(GetGameSettings());

            Game.Visible = true;
            Game.SetMainMenu(this);

            this.Hide();
            Game.Setup();
        }

        // player clone
        public void SetPlayerClone(bool value)
        {
            playerClone = value;
        }
        public bool GetPlayerClone()
        {
            return playerClone;
        }

        private GameSettings GetGameSettings()
        {
            // ha nem valami hiba folytán null lenne valami akkor kap alap értékeket
            if (GetPlayerSettings() == null)
            {
                Debug.WriteLine("hiba lépett fel a játékos beállítások belállításánal (null)");
                this.playerSettings = new PlayerSetting[]
                {
                    new PlayerSetting().SetDefaultValues().SetPlayerName("Player1"),
                    new PlayerSetting().SetDefaultValues().SetPlayerName("Player2")
                };
            }

            if (GetInputSettings() == null)
            {
                Debug.WriteLine("hiba lépett fel a bemeneti billenytűk belállításánal (null)");
                this.inputSettings = new InputSetting[]
                {
                    new InputSetting(Keys.W, Keys.S, Keys.D),
                    new InputSetting(Keys.Up, Keys.Down, Keys.Left)
                };
            }

            if (!chb_FullScreen.Checked)
            {
                return new GameSettings(playerSettings, inputSettings, new Size((int)numericUpDown1.Value, (int)numericUpDown2.Value), chb_BulletCollision.Checked);
            }
            return new GameSettings(playerSettings, inputSettings, chb_BulletCollision.Checked);
        }

        // player settings
        public void SetPlayerSettings(PlayerSetting[] playerSettings)
        {
            this.playerSettings = playerSettings;
            FileManager.Instance.SaveToFile(playerSettings);
        }
        public PlayerSetting[]? GetPlayerSettings()
        {
            return playerSettings;
        }

        // input settings
        public void SetInputSettings(InputSetting[] inputSettings)
        {
            this.inputSettings = inputSettings;
            FileManager.Instance.SaveToFile(inputSettings);
        }
        public InputSetting[]? GetInputSettings()
        {
            return this.inputSettings;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = !chb_FullScreen.Checked;
            numericUpDown2.Enabled = !chb_FullScreen.Checked;
        }

        private void btn_Advnaced_Click(object sender, EventArgs e)
        {
            // open advanced setting \\
            AdvancedSettings advancedSettings = new AdvancedSettings(this);

            advancedSettings.LoadData(GetPlayerSettings());
            advancedSettings.SetPlayerClone(playerClone);

            advancedSettings.ShowDialog();

        }

        private void btn_InputSettings_Click(object sender, EventArgs e)
        {
            InputSettings inputSettingsForm = new InputSettings(this);
            inputSettingsForm.LoadData(GetInputSettings());

            inputSettingsForm.ShowDialog();
        }
    }
}
