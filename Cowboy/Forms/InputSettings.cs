using Cowboy.Settings;

namespace Cowboy.Forms
{
    public partial class InputSettings : Form
    {
        private MainMenu mainMenu;
        private Dictionary<Button, Keys> AllButtons = new Dictionary<Button, Keys>();
        private InputSetting[] inputSettings;
        private bool WaitForInput;

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
            LoadDefaultValues();

            GenerateInputSettings();

            LoadData(inputSettings);
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
        }

        public void LoadData(InputSetting[]? inputsettings)
        {
            if (inputSettings == null)
            {
                LoadDefaultValues();
                GenerateInputSettings();
                inputsettings = this.inputSettings;
            }

            button1.Text = inputsettings[0].UpKey.ToString();
            button2.Text = inputsettings[0].DownKey.ToString();
            button3.Text = inputsettings[0].ShootKey.ToString();

            button4.Text = inputsettings[1].UpKey.ToString();
            button5.Text = inputsettings[1].DownKey.ToString();
            button6.Text = inputsettings[1].ShootKey.ToString();
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
                foreach (var item1 in AllButtons)
                {
                    if (item.Value == item1.Value)
                        db++;
                }
                if(db>1)
                    item.Key.BackColor = Color.Red;
            }
        }

        private void GenerateInputSettings()
        {
            inputSettings = new []{
                new InputSetting(AllButtons[button1], AllButtons[button2], AllButtons[button3]),
                new InputSetting(AllButtons[button4], AllButtons[button5], AllButtons[button6])
            };
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

                        WaitForInput = false;
                        ActivateAllButtons();
                        Coloring();
                    }
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            mainMenu.SetInputSettings(inputSettings);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            LoadDefaultValues();
            LoadData(this.inputSettings);
            ActivateAllButtons();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
