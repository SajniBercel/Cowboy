namespace Cowboy.Utilities
{
    public class Create
    {

        /// <summary>
        /// Létrehoz egy PictureBox-ot
        /// </summary>
        /// <param name="name">Neve</param>
        /// <param name="size">Méret</param>
        /// <param name="location">Hely</param>
        /// <param name="image">Kép</param>
        public static PictureBox pictureBox(string name, Size size, Point location, Image image)
        {
            PictureBox pic = new PictureBox
            {
                Name = name,
                Size = size,
                Location = location,
                Image = image,
                SizeMode = PictureBoxSizeMode.StretchImage,
                BorderStyle = BorderStyle.None

            };
            Form.ActiveForm.Controls.Add(pic);
            return pic;
        }

        /// <summary>
        /// Létrehoz egy ProgressBar-ot
        /// </summary>
        /// <param name="name">Neve</param>
        /// <param name="size">Méret</param>
        /// <param name="location">Hely</param>
        /// <param name="max">Hány egységre oszlik</param>
        public static ProgressBar progressBar(string name, Size size, Point location, int max)
        {
            ProgressBar progBar = new ProgressBar
            {
                Name = name,
                Size = size,
                Location = location,
                Maximum = max

            };
            Form.ActiveForm.Controls.Add(progBar);
            return progBar;
        }

        /// <summary>
        /// Feliratot/(label)-t hoz létre
        /// </summary>
        /// <param name="name">Neve</param>
        /// <param name="text">Felirat</param>
        /// <param name="location">Hely</param>
        public static Label label(string name, string text, Point location)
        {
            Label label = new Label
            {
                Name = name,
                Text = text,
                BackColor = Color.Transparent,
                Location = location
            };
            Form.ActiveForm.Controls.Add(label);
            return label;
        }
    }
}
