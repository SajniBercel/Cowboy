namespace Cowboy.Classes
{
    public class Create
    {
        public static PictureBox pictureBox(string name, Size size, Point loc, Image image)
        {
            PictureBox pic = new PictureBox
            {
                Name = name,
                Size = size,
                Location = loc,
                Image = image,
                SizeMode = PictureBoxSizeMode.StretchImage,
                BorderStyle = BorderStyle.None

            };
            Form.ActiveForm.Controls.Add(pic);
            return pic;
        }

        public static ProgressBar progressBar(string name, Size size, Point loc, int max)
        {
            ProgressBar progBar = new ProgressBar
            {
                Name = name,
                Size = size,
                Location = loc,
                Maximum = max

            };
            Form.ActiveForm.Controls.Add(progBar);
            return progBar;
        }
    }
}
