using Cowboy.Settings;
using System.Diagnostics;

namespace Cowboy.Forms
{
    public partial class InputSettings : Form
    {
        private MainMenu mainMenu;
        private Dictionary<Button, Keys> AllButtons = new Dictionary<Button, Keys>();
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
            AllButtons.Add(button1, Keys.W);
            AllButtons.Add(button2, Keys.S);
            AllButtons.Add(button3, Keys.D);
            AllButtons.Add(button4, Keys.Up);
            AllButtons.Add(button5, Keys.Down);
            AllButtons.Add(button6, Keys.Left);

            Coloring();
        }

        public void LoadData(InputSetting[]? _inputsettings)
        {
            if (inputSettings == null)
            {
                Debug.WriteLine("hiba lépett fel a játékos input beállítások belállításánal (null)");
                LoadDefaultValues();
                inputSettings = GenerateInputSettings();
            }

            button1.Text = _inputsettings[0].UpKey.ToString();
            button2.Text = _inputsettings[0].DownKey.ToString();
            button3.Text = _inputsettings[0].ShootKey.ToString();

            button4.Text = _inputsettings[1].UpKey.ToString();
            button5.Text = _inputsettings[1].DownKey.ToString();
            button6.Text = _inputsettings[1].ShootKey.ToString();

            AllButtons.Clear();
            AllButtons.Add(button1, _inputsettings[0].UpKey);
            AllButtons.Add(button2, _inputsettings[0].DownKey);
            AllButtons.Add(button3, _inputsettings[0].ShootKey);
            AllButtons.Add(button4, _inputsettings[1].UpKey);
            AllButtons.Add(button5, _inputsettings[1].DownKey);
            AllButtons.Add(button6, _inputsettings[1].ShootKey);

            groupBox1.Text = mainMenu.GetGameSettings().PlayerSettings[0].PlayerName.ToString();
            groupBox2.Text = mainMenu.GetGameSettings().PlayerSettings[1].PlayerName.ToString();

            Coloring();
        }

        private void Set_Input(object sender, EventArgs e)
        {
            DisableButtons(sender as Button);
        }

        private void ActivateAllButtons()
        {
            for (int i = 0; i < AllButtons.Keys.Count; i++)
            {
                AllButtons.ElementAt(i).Key.Enabled = true;
            }
        }
        private void DisableButtons(Button button)
        {
            this.Focus();
            for (int i = 0; i < AllButtons.Count; i++)
            {
                AllButtons.ElementAt(i).Key.Enabled = AllButtons.Keys.ElementAt(i).Equals(button);
            }
            WaitForInput = true;
        }

        private int GetActiveButtonIndex()
        {
            int index = -1;
            short db = 0;
            for (int i = 0; i < AllButtons.Count; i++)
            {
                if (AllButtons.ElementAt(i).Key.Enabled)
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
                item.Key.ForeColor = Color.Black;
                foreach (var item1 in AllButtons)
                {
                    if (item.Value == item1.Value)
                        db++;
                }
                if (db > 1)
                    item.Key.BackColor = Color.Red;
                else
                    item.Key.BackColor = SystemColors.Control;
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
                new InputSetting(AllButtons[button1], AllButtons[button2], AllButtons[button3]),
                new InputSetting(AllButtons[button4], AllButtons[button5], AllButtons[button6])
            };

            return _inputSetting;
        }

        private void Key_Down(object sender, KeyEventArgs e)
        {
            if (WaitForInput)
            {
                Button button = AllButtons.ElementAt(GetActiveButtonIndex()).Key;
                if (button != null)
                {
                    if (e.KeyCode != Keys.Space && e.KeyCode != Keys.Escape)
                    {
                        button.Text = e.KeyCode.ToString();
                        AllButtons[button] = e.KeyCode;

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
