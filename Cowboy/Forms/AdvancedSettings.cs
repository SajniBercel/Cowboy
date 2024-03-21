using Cowboy.Settings;

namespace Cowboy
{
    public partial class AdvancedSettings : Form
    {
        public PlayerSetting[] playerSettings = new PlayerSetting[2];
        private MainMenu mainMenu;
        public AdvancedSettings(MainMenu mainMenu)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ShowIcon = false;

            this.mainMenu = mainMenu;
        }
        public void LoadData(PlayerSetting[]? playerS)
        {
            // átveszi vagy load-oldja az alap beállításokat \\
            if (playerS == null)
            {
                playerS = new PlayerSetting[2];
                playerS[0] = new PlayerSetting().SetDefaultValues().SetPlayerName("Player1");
                playerS[1] = new PlayerSetting().SetDefaultValues().SetPlayerName("Player2");
            }

            playerSettings = playerS;

            // Player1 \\
            txt_PlayerName_1.Text = playerS[0].PlayerName;

            Nu_PlayerSpeed_1.Value = playerS[0].PlayerSpeed;
            Nu_PlayerHP_1.Value = playerS[0].PlayerHP;
            Nu_BulletSpeed_1.Value = playerS[0].BulletSpeed;
            Nu_BulletDamage_1.Value = playerS[0].BulletDamage;
            Nu_ReloadSpeed_1.Value = playerS[0].ReloadSpeed;
            Ch_Bot_1.Checked = playerS[0].Bot;

            // Player2 \\
            txt_PlayerName_2.Text = playerS[1].PlayerName;

            Nu_PlayerSpeed_2.Value = playerS[1].PlayerSpeed;
            Nu_PlayerHP_2.Value = playerS[1].PlayerHP;
            Nu_BulletSpeed_2.Value = playerS[1].BulletSpeed;
            Nu_BulletDamage_2.Value = playerS[1].BulletDamage;
            Nu_ReloadSpeed_2.Value = playerS[1].ReloadSpeed;
            Ch_Bot_2.Checked = playerS[1].Bot;
        }

        private void AdvancedSettings_Load(object sender, EventArgs e)
        {
            PlayerClone.Checked = mainMenu.GetPlayerClone();
        }

        public void SetPlayerClone(bool value)
        {
            PlayerClone.Checked = value;
            PlayerClone_CheckedChanged(null, null);
        }

        private void btn_advsReset_Click(object sender, EventArgs e)
        {
            LoadData(null);
        }

        private void btn_AdvsSave_Click(object sender, EventArgs e)
        {
            // validálás? (nem sok értelme van)
            if (txt_PlayerName_1.Text == txt_PlayerName_2.Text)
            {
                MessageBox.Show("!A két játékosnak nem lehet ugyan az a neve!");
            }

            // player 1
            playerSettings[0] = new PlayerSetting(txt_PlayerName_1.Text, (int)Nu_PlayerSpeed_1.Value, (int)Nu_PlayerHP_1.Value,
                    (int)Nu_BulletSpeed_1.Value, (int)Nu_BulletDamage_1.Value, (int)Nu_ReloadSpeed_1.Value, Ch_Bot_1.Checked);

            // player 2 (ha más akkor azt kapja meg ha ugyan az akkor másolja)
            if (PlayerClone.Checked)
            {
                playerSettings[1] = new PlayerSetting(txt_PlayerName_2.Text, (int)Nu_PlayerSpeed_2.Value, (int)Nu_PlayerHP_2.Value,
                    (int)Nu_BulletSpeed_2.Value, (int)Nu_BulletDamage_2.Value, (int)Nu_ReloadSpeed_2.Value, Ch_Bot_2.Checked);
            }
            else
            {
                playerSettings[1] = new PlayerSetting(playerSettings[0]);
                playerSettings[1].PlayerName = txt_PlayerName_2.Text;
                playerSettings[1].Bot = Ch_Bot_2.Checked;
            }

            //adat visszaadás a main-re
            mainMenu.SetPlayerSettings(playerSettings);
            mainMenu.SetPlayerClone(PlayerClone.Checked);
        }

        private void btn_AdvsBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txt_Player1Name_TextChanged(object sender, EventArgs e)
        {
            groupBox1.Text = txt_PlayerName_1.Text;
        }

        private void txt_Player2Name_TextChanged(object sender, EventArgs e)
        {
            groupBox2.Text = txt_PlayerName_2.Text;
        }

        private void PlayerClone_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Visible = PlayerClone.Checked;
        }
    }
}