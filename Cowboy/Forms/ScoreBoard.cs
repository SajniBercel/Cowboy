
namespace Cowboy.Forms
{
    public partial class ScoreBoard : Form
    {
        private string[] data;
        /// <summary>
        /// A kapott adatok alapján csinál egy táblázatot az adatokból
        /// </summary>
        /// <param name="data">szeparátor karakter ";"</param>
        public ScoreBoard(string[] data)
        {
            InitializeComponent();
            this.data = data;
        }

        private void ScoreBoard_Load(object sender, EventArgs e)
        {
            LoadDataToListBox(data);
        }

        private void LoadDataToListBox(string[] _rows)
        {
            string[] rows = new string[_rows.Length + 1];

            rows[0] = "Győztes;Vesztes;Idő(mp)";

            for (int i = 0; i < _rows.Length; i++)
            {
                rows[i + 1] = _rows[i];
            }

            listBox1.Items.Clear();

            List<int> spaces = new List<int>();
            for (int i = 0; i < rows[0].Split(";").Length; i++)
            {
                spaces.Add(0);
            }

            for (int i = 0; i < rows.Length; i++)
            {
                string[] cols = rows[i].Split(";");
                for (int j = 0; j < cols.Length; j++)
                {
                    if (spaces[j] < cols[j].Length)
                    {
                        spaces[j] = cols[j].Length;
                    }
                }
            }

            for (int i = 0; i < rows.Length; i++)
            {
                string[] cols = rows[i].Split(";");
                string rowOutput = string.Empty;
                for (int j = 0; j < cols.Length; j++)
                {
                    rowOutput += cols[j];
                    int reqSpaces = spaces[j] - cols[j].Length;

                    for (int k = 0; k <= reqSpaces + 1; k++)
                    {

                        rowOutput += " ";
                    }
                }
                listBox1.Items.Add(rowOutput);
            }

        }

        private void ScoreBoard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
