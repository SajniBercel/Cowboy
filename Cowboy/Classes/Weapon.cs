using System;
using System.Drawing;
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
                Bullet bullet = new Bullet(OwnerPlayer.PlayerID, 
                    Create.pictureBox("Bullet", new Size(40, 40), new Point(0, 0), 
                    Properties.Resources.bulletBeta), BulletSpeed, WeaponDamage);

                bullet.pictureBox.Location = OwnerPlayer.GetWeaponOffSetPoint();
                CanShoot = false;
                MyTimer.Start();
                return bullet;
            }
            return null;
        }

        public void SetShootTrue(object? sender, EventArgs args)
        {
            CanShoot = true;
            MyTimer.Stop();
        }
    }
}