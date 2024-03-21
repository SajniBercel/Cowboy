using Cowboy.Settings;

namespace Cowboy
{
    public partial class MainMenu : Form
    {
        private PlayerSetting[] playerSettings;
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
            // ha nem lett semmi állítva akkor beállít egy default-ot
            if (GetPlayerSettings() == null)
            {
                this.playerSettings = new PlayerSetting[]
                {
                    new PlayerSetting().SetDefaultValues().SetPlayerName("Player1"),
                    new PlayerSetting().SetDefaultValues().SetPlayerName("Player2")
                };
            }

            if (!checkBox1.Checked)
            {
                return new GameSettings(playerSettings, new Size((int)numericUpDown1.Value, (int)numericUpDown2.Value), checkBox2.Checked);
            }
            return new GameSettings(playerSettings, checkBox2.Checked);
        }

        public void SetPlayerSettings(PlayerSetting[] playerSettings)
        {
            this.playerSettings = playerSettings;
        }
        public PlayerSetting[] GetPlayerSettings()
        {
            return playerSettings;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = !checkBox1.Checked;
            numericUpDown2.Enabled = !checkBox1.Checked;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // open advanced setting \\
            AdvancedSettings advancedSettings = new AdvancedSettings(this);

            advancedSettings.LoadData(GetPlayerSettings());
            advancedSettings.SetPlayerClone(playerClone);

            advancedSettings.ShowDialog();

        }
    }
}
