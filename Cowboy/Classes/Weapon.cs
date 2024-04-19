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
        private int BulletDamage { get; set; }
        private bool CanShoot = false;
        private Timer MyTimer;

        /// <summary>
        /// Fegyver ami egy játékoshoz tartozik, ez kezeli közvetlen a lövés, ő hozza létre a töltényt minden tulajdonságával
        /// </summary>
        /// <param name="player">"Tulajdonos" Player (használó)</param>
        public Weapon(Player player)
        {
            OwnerPlayer = player;

            BulletSpeed = player.PlayerSettings.BulletSpeed;

            BulletDamage = player.PlayerSettings.BulletDamage;

            MyTimer = new Timer();
            MyTimer.Interval = player.PlayerSettings.ReloadSpeed*100;
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
                    Properties.Resources.bullet), BulletSpeed, BulletDamage);
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