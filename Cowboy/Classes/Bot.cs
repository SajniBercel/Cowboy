using Cowboy.Settings;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cowboy.Classes
{
    public class Bot : Player
    {
        private Player Target { get; set; }
        private Game GameForm { get; set; }
        public Bot(int playerID, PictureBox _pictureBox, PlayerSetting playerSetting) : base(playerID, _pictureBox, playerSetting)
        {

        }

        public Bot(Player player, Player target, Game gameFrom) : base(player.PlayerID, player.pictureBox, player.PlayerSettings)
        {
            Target = target;
            GameForm = gameFrom;

            player.Hpbar.Dispose();
        }

        public override void Update()
        {
            Think();
            base.Update();
        }

        public void Think()
        {
            if (Target.pictureBox.Location.Y + Target.pictureBox.Height < this.pictureBox.Location.Y)
            {
                Up();
            }
            else if (Target.pictureBox.Location.Y - Target.pictureBox.Height > this.pictureBox.Location.Y)
            {
                Down();
            }
            else if(Target.pictureBox.Location.Y == this.pictureBox.Location.Y)
            {
                Stop();
            }

            if (Target.pictureBox.Location.Y - Target.pictureBox.Height < this.pictureBox.Location.Y && Target.pictureBox.Location.Y + Target.pictureBox.Height > this.pictureBox.Location.Y)
                GameForm.Shoot(this);
        }
        private void Up()
        {
            MoveUp = true;
            MoveDown = false;
        }
        private void Down() 
        {
            MoveUp = false;
            MoveDown = true;
        }
        private void Stop()
        {
            MoveUp = false;
            MoveDown = false;
        }
    }
}
