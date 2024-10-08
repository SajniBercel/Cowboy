﻿namespace Cowboy
{
    partial class Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            MainGameTimer = new System.Windows.Forms.Timer(components);
            StopWatch = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // MainGameTimer
            // 
            MainGameTimer.Interval = 10;
            MainGameTimer.Tick += MainGame_Update;
            // 
            // StopWatch
            // 
            StopWatch.Tick += StopWatch_tick;
            // 
            // Game
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 261);
            Name = "Game";
            Text = "Game";
            FormClosed += Game_FormClosed;
            Load += Game_Load;
            KeyDown += Game_KeyDown;
            KeyUp += Game_KeyUp;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer MainGameTimer;
        private System.Windows.Forms.Timer StopWatch;
    }
}