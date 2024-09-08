using Cowboy.Settings;
using Cowboy.Utilities;
using System.Drawing;
using System.Xml.Linq;

namespace Cowboy
{
    public partial class AdvancedSettings : Form
    {
        public PlayerSetting[] playerSettings = new PlayerSetting[2];
        private MainMenu mainMenu;

        private string PlayerName1;
        private string PlayerName2;

        public AdvancedSettings(MainMenu mainMenu)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ShowIcon = false;

            this.mainMenu = mainMenu;
        }

        /// <summary>
        /// A kapott PlayerSetting alapján betölti az adatokat
        /// </summary>
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

            // GFX 
            Image player1Img = Properties.Resources.player;
            Image player2Img = Properties.Resources.player;

            if (playerS[0].PlayerImgPath.Length > 1)
                player1Img = Image.FromFile(playerS[0].PlayerImgPath);
            if (playerS[1].PlayerImgPath.Length > 1)
                player2Img = Image.FromFile(playerS[1].PlayerImgPath);

            player2Img.RotateFlip(RotateFlipType.RotateNoneFlipX);

            Player1Pic.Image = player1Img;
            Player2Pic.Image = player2Img;
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
            // validálás
            if (txt_PlayerName_1.Text == txt_PlayerName_2.Text && !(txt_PlayerName_1.Text == "Bot" && txt_PlayerName_2.Text == "Bot"))
            {
                MessageBox.Show("A két játékosnak nem lehet ugyan az a neve");
            }

            // player 1 --TODO--
            playerSettings[0] = new PlayerSetting(txt_PlayerName_1.Text, (int)Nu_PlayerSpeed_1.Value, (int)Nu_PlayerHP_1.Value,
                    (int)Nu_BulletSpeed_1.Value, (int)Nu_BulletDamage_1.Value, (int)Nu_ReloadSpeed_1.Value, Ch_Bot_1.Checked, "");

            // player 2 (ha más akkor azt kapja meg ha ugyan az akkor másolja) --TODO--
            if (PlayerClone.Checked)
            {
                playerSettings[1] = new PlayerSetting(txt_PlayerName_2.Text, (int)Nu_PlayerSpeed_2.Value, (int)Nu_PlayerHP_2.Value,
                    (int)Nu_BulletSpeed_2.Value, (int)Nu_BulletDamage_2.Value, (int)Nu_ReloadSpeed_2.Value, Ch_Bot_2.Checked, "");
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
            FileManager.Instance.SaveToFile(playerSettings);
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
            Player2Pic.Visible = PlayerClone.Checked;
        }

        private void Ch_Bot_1_CheckedChanged(object sender, EventArgs e)
        {
            if (txt_PlayerName_1.Enabled)
                PlayerName1 = txt_PlayerName_1.Text;

            txt_PlayerName_1.Enabled = !Ch_Bot_1.Checked;


            if (txt_PlayerName_1.Enabled && PlayerName1 != "Bot")
                txt_PlayerName_1.Text = PlayerName1;
            else if (txt_PlayerName_1.Enabled && PlayerName1 == "Bot")
                txt_PlayerName_1.Text = "Player1";
            else
                txt_PlayerName_1.Text = "Bot";
        }

        private void Ch_Bot_2_CheckedChanged(object sender, EventArgs e)
        {
            if (txt_PlayerName_2.Enabled)
                PlayerName2 = txt_PlayerName_2.Text;

            txt_PlayerName_2.Enabled = !Ch_Bot_2.Checked;

            if (txt_PlayerName_2.Enabled && PlayerName2 != "Bot")
                txt_PlayerName_2.Text = PlayerName2;
            else if (txt_PlayerName_2.Enabled && PlayerName2 == "Bot")
                txt_PlayerName_2.Text = "Player2";
            else
                txt_PlayerName_2.Text = "Bot";
        }

        private void Player1PicChange_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Player1Pic.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void Player2PicChange_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Image temp = Image.FromFile(openFileDialog.FileName);
                temp.RotateFlip(RotateFlipType.RotateNoneFlipX);

                Player2Pic.Image = temp;
            }
        }

        private void Player1PicReset_Click(object sender, EventArgs e)
        {
            Player1Pic.Image = Properties.Resources.player;
        }

        private void Player2PicReset_Click(object sender, EventArgs e)
        {
            Image temp = Properties.Resources.player;
            temp.RotateFlip(RotateFlipType.RotateNoneFlipX);

            Player2Pic.Image = temp;
        }

        private void Player1PicFlip_Click(object sender, EventArgs e)
        {
            Image temp = Player1Pic.Image;
            temp.RotateFlip(RotateFlipType.RotateNoneFlipX);
            Player1Pic.Image = temp;
        }

        private void Player2PicFlip_Click(object sender, EventArgs e)
        {
            Image temp = Player2Pic.Image;
            temp.RotateFlip(RotateFlipType.RotateNoneFlipX);
            Player2Pic.Image = temp;
        }
    }
}