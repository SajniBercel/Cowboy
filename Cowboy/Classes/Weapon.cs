using Cowboy.Properties;
using Cowboy.Utilities;
using System.Media;
using Timer = System.Windows.Forms.Timer;

namespace Cowboy.Classes
{
    public class Weapon
    {
        private Player OwnerPlayer { get; set; }
        public int BulletSpeed { get; set; }
        private int WeaponDamage { get; set; }
        private bool CanShoot = false;
        private Timer MyTimer;

        /// <summary>
        /// Fegyver ami egy játékoshoz tartozik, ez kezeli közvetlen a lövés, ő hozza létre a töltényt minden tulajdonságával
        /// </summary>
        /// <param name="player">tulajdonos (használó)</param>
        /// <param name="realoadSpeed">idő amennyinek el kell tellnie hogy újra lehessen lőni</param>
        /// <param name="bulletSpeed">a töltény sebessége</param>
        /// <param name="weaponDamage">Sebzés</param>
        public Weapon(Player player, int realoadSpeed, int bulletSpeed, int weaponDamage)
        {
            OwnerPlayer = player;

            BulletSpeed = bulletSpeed;

            WeaponDamage = weaponDamage;

            MyTimer = new Timer();
            MyTimer.Interval = realoadSpeed;
            MyTimer.Tick += new EventHandler(SetShootTrue);
            MyTimer.Start();
        }

        /// <summary>
        /// Elsüti a fegyvert, tud "null"-t visszaadni amikor a fegyver éppen nem tud lőni
        /// </summary>
        /// <returns>Bullet</returns>
        public Bullet? Shoot()
        {
            if (CanShoot)
            {
                SoundPlayer soundPlayer = new SoundPlayer(Resources.shootSound);
                soundPlayer.Play();
                soundPlayer.Dispose();

                Bullet bullet = new Bullet(OwnerPlayer.PlayerID, 
                    Create.pictureBox("Bullet", new Size(30, 30), new Point(0, 0), 
                    Properties.Resources.bullet), BulletSpeed, WeaponDamage);
                Point offset = OwnerPlayer.GetWeaponOffSetPoint();
                offset.Offset(0,-bullet.pictureBox.Height/2);
                bullet.pictureBox.Location = offset;
                CanShoot = false;
                MyTimer.Start();
                return bullet;
            }
            return null;
        }

        private void SetShootTrue(object? sender, EventArgs args)
        {
            CanShoot = true;
            MyTimer.Stop();
        }
    }
}