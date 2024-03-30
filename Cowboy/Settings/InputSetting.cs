namespace Cowboy.Settings
{
    public class InputSetting
    {
        public Keys UpKey { get; set; }
        public Keys DownKey { get; set; }
        public Keys ShootKey { get; set; }
        /// <summary>
        /// Tárolja a billentyű beállításokat
        /// </summary>
        /// <param name="up">Mozgás felfelé</param>
        /// <param name="down">Mozgás lefelé</param>
        /// <param name="shoot">Lövés</param>
        public InputSetting(Keys up, Keys down, Keys shoot)
        {
            UpKey = up;
            DownKey = down;
            ShootKey = shoot;
        }

        public override string ToString()
        {
            return $"UpKey: {UpKey}; DownKey: {DownKey}; ShootKey: {ShootKey}";
        }
    }
}
