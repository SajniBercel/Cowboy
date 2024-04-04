using Cowboy.Settings;
using System.Diagnostics;

namespace Cowboy.Forms
{
    public partial class InputSettings : Form
    {
        private MainMenu mainMenu;
        private List<Button> AllButtons = new List<Button>();
        private InputSetting[] inputSettings;
        private bool WaitForInput;
        private List<Button> ChangedKeys = new List<Button>();

        public InputSettings(MainMenu mainmenu)
        {
            InitializeComponent();

            mainMenu = mainmenu;

            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ShowIcon = false;
        }

        private void InputSettings_Load(object sender, EventArgs e)
        {

        }

        private void LoadDefaultValues()
        {
            AllButtons.Clear();
            AllButtons.Add(button1);
            AllButtons.Add(button2);
            AllButtons.Add(button3);
            AllButtons.Add(button4);
            AllButtons.Add(button5);
            AllButtons.Add(button6);

            button1.Text = Keys.W.ToString();
            button2.Text = Keys.S.ToString();
            button3.Text = Keys.D.ToString();
            button4.Text = Keys.Up.ToString();
            button5.Text = Keys.Down.ToString();
            button6.Text = Keys.Left.ToString();

            Coloring();
        }

        public void LoadData(InputSetting[]? _inputsettings)
        {
            if (_inputsettings == null)
            {
                LoadDefaultValues();
                inputSettings = GenerateInputSettings();
            }
            else
            {
                this.inputSettings = _inputsettings;
            }

            button1.Text = inputSettings[0].UpKey.ToString();
            button2.Text = inputSettings[0].DownKey.ToString();
            button3.Text = inputSettings[0].ShootKey.ToString();

            button4.Text = inputSettings[1].UpKey.ToString();
            button5.Text = inputSettings[1].DownKey.ToString();
            button6.Text = inputSettings[1].ShootKey.ToString();

            groupBox1.Text = mainMenu.GetGameSettings().PlayerSettings[0].PlayerName.ToString();
            groupBox2.Text = mainMenu.GetGameSettings().PlayerSettings[1].PlayerName.ToString();

        }

        private void Set_Input(object sender, EventArgs e)
        {
            DisableButtons(sender as Button);
        }

        private void ActivateAllButtons()
        {
            for (int i = 0; i < AllButtons.Count; i++)
            {
                AllButtons[i].Enabled = true;
            }
        }
        private void DisableButtons(Button button)
        {
            this.Focus();
            for (int i = 0; i < AllButtons.Count; i++)
            {
                AllButtons[i].Enabled = AllButtons[i].Equals(button);
            }
            WaitForInput = true;
        }

        private int GetActiveButtonIndex()
        {
            int index = -1;
            short db = 0;
            for (int i = 0; i < AllButtons.Count; i++)
            {
                if (AllButtons[i].Enabled)
                {
                    db++;
                    index = i;
                }
            }

            if (db == 1)
                return index;

            return -1;
        }

        private void Coloring()
        {
            foreach (var item in AllButtons)
            {
                int db = 0;
                item.ForeColor = Color.Black;
                foreach (var item1 in AllButtons)
                {
                    if (item.Text == item1.Text)
                        db++;
                }
                if (db > 1)
                    item.BackColor = Color.Red;
                else
                    item.BackColor = SystemColors.Control;
            }

            for (int i = 0; i < ChangedKeys.Count; i++)
            {
                ChangedKeys[i].ForeColor = Color.FromArgb(0, 150, 100);
            }
        }

        private InputSetting[] GenerateInputSettings()
        {
            InputSetting[] _inputSetting = new InputSetting[]
            {
                new InputSetting(
                    (Keys)Enum.Parse(typeof(Keys), button1.Text),
                    (Keys)Enum.Parse(typeof(Keys), button2.Text),
                    (Keys)Enum.Parse(typeof(Keys), button3.Text)
                    ),
                new InputSetting(
                    (Keys)Enum.Parse(typeof(Keys), button4.Text),
                    (Keys)Enum.Parse(typeof(Keys), button5.Text),
                    (Keys)Enum.Parse(typeof(Keys), button6.Text)
                    )
            };

            return _inputSetting;
        }

        private void Key_Down(object sender, KeyEventArgs e)
        {
            if (WaitForInput)
            {
                Button button = AllButtons[GetActiveButtonIndex()];
                if (button != null)
                {
                    if (e.KeyCode != Keys.Space && e.KeyCode != Keys.Escape)
                    {
                        button.Text = e.KeyCode.ToString();

                        ChangedKeys.Add(button);

                        WaitForInput = false;
                        ActivateAllButtons();
                        Coloring();
                    }
                }
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            inputSettings = GenerateInputSettings();
            mainMenu.SetInputSettings(GenerateInputSettings());
            ChangedKeys.Clear();
            Coloring();
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            LoadDefaultValues();
            inputSettings = GenerateInputSettings();
            LoadData(this.inputSettings);
            ActivateAllButtons();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Preview_KeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (WaitForInput)
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                    case Keys.Down:
                    case Keys.Left:
                    case Keys.Right:
                    case Keys.Tab:
                        e.IsInputKey = true;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
