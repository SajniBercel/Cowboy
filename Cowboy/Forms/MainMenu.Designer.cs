namespace Cowboy
{
    partial class MainMenu
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
            label1 = new Label();
            label2 = new Label();
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            chb_FullScreen = new CheckBox();
            chb_BulletCollision = new CheckBox();
            btn_Start = new Button();
            btn_AdvancedSettings = new Button();
            btn_InputSettings = new Button();
            menuStrip1 = new MenuStrip();
            tsm_MenuFile = new ToolStripMenuItem();
            tsm_OpenConfigFolder = new ToolStripMenuItem();
            projektToolStripMenuItem = new ToolStripMenuItem();
            tsm_Info = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 36);
            label1.Name = "label1";
            label1.Size = new Size(113, 15);
            label1.TabIndex = 0;
            label1.Text = "Játékablak Szélesség";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 65);
            label2.Name = "label2";
            label2.Size = new Size(117, 15);
            label2.TabIndex = 1;
            label2.Text = "Játékablak Magasság";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(179, 34);
            numericUpDown1.Maximum = new decimal(new int[] { 1900, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 200, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(87, 23);
            numericUpDown1.TabIndex = 1;
            numericUpDown1.Value = new decimal(new int[] { 600, 0, 0, 0 });
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(179, 63);
            numericUpDown2.Maximum = new decimal(new int[] { 1900, 0, 0, 0 });
            numericUpDown2.Minimum = new decimal(new int[] { 200, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(87, 23);
            numericUpDown2.TabIndex = 2;
            numericUpDown2.Value = new decimal(new int[] { 600, 0, 0, 0 });
            // 
            // chb_FullScreen
            // 
            chb_FullScreen.AutoSize = true;
            chb_FullScreen.Location = new Point(159, 92);
            chb_FullScreen.Name = "chb_FullScreen";
            chb_FullScreen.Size = new Size(107, 19);
            chb_FullScreen.TabIndex = 3;
            chb_FullScreen.Text = "Teljes Képernyő";
            chb_FullScreen.UseVisualStyleBackColor = true;
            chb_FullScreen.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // chb_BulletCollision
            // 
            chb_BulletCollision.AutoSize = true;
            chb_BulletCollision.Location = new Point(12, 92);
            chb_BulletCollision.Name = "chb_BulletCollision";
            chb_BulletCollision.Size = new Size(108, 19);
            chb_BulletCollision.TabIndex = 4;
            chb_BulletCollision.Text = "Töltény Ütközés";
            chb_BulletCollision.UseVisualStyleBackColor = true;
            // 
            // btn_Start
            // 
            btn_Start.Location = new Point(12, 174);
            btn_Start.Name = "btn_Start";
            btn_Start.Size = new Size(254, 23);
            btn_Start.TabIndex = 7;
            btn_Start.Text = "Start";
            btn_Start.UseVisualStyleBackColor = true;
            btn_Start.Click += btn_Start_Click;
            // 
            // btn_AdvancedSettings
            // 
            btn_AdvancedSettings.Location = new Point(12, 116);
            btn_AdvancedSettings.Name = "btn_AdvancedSettings";
            btn_AdvancedSettings.Size = new Size(254, 23);
            btn_AdvancedSettings.TabIndex = 5;
            btn_AdvancedSettings.Text = "További Beállítások";
            btn_AdvancedSettings.UseVisualStyleBackColor = true;
            btn_AdvancedSettings.Click += btn_Advnaced_Click;
            // 
            // btn_InputSettings
            // 
            btn_InputSettings.Location = new Point(12, 145);
            btn_InputSettings.Name = "btn_InputSettings";
            btn_InputSettings.Size = new Size(254, 23);
            btn_InputSettings.TabIndex = 6;
            btn_InputSettings.Text = "Irányítás";
            btn_InputSettings.UseVisualStyleBackColor = true;
            btn_InputSettings.Click += btn_InputSettings_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.ControlLight;
            menuStrip1.Items.AddRange(new ToolStripItem[] { tsm_MenuFile, projektToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(278, 24);
            menuStrip1.TabIndex = 8;
            menuStrip1.Text = "menuStrip1";
            // 
            // tsm_MenuFile
            // 
            tsm_MenuFile.DropDownItems.AddRange(new ToolStripItem[] { tsm_OpenConfigFolder });
            tsm_MenuFile.Name = "tsm_MenuFile";
            tsm_MenuFile.Size = new Size(37, 20);
            tsm_MenuFile.Text = "Fájl";
            // 
            // tsm_OpenConfigFolder
            // 
            tsm_OpenConfigFolder.Name = "tsm_OpenConfigFolder";
            tsm_OpenConfigFolder.Size = new Size(214, 22);
            tsm_OpenConfigFolder.Text = "Config Mappa Megnyitása";
            tsm_OpenConfigFolder.Click += tsm_OpenConfigFolder_Click;
            // 
            // projektToolStripMenuItem
            // 
            projektToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tsm_Info });
            projektToolStripMenuItem.Name = "projektToolStripMenuItem";
            projektToolStripMenuItem.Size = new Size(56, 20);
            projektToolStripMenuItem.Text = "Projekt";
            // 
            // tsm_Info
            // 
            tsm_Info.Name = "tsm_Info";
            tsm_Info.Size = new Size(180, 22);
            tsm_Info.Text = "Info";
            tsm_Info.Click += tsm_Info_Click;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(278, 205);
            Controls.Add(btn_InputSettings);
            Controls.Add(btn_AdvancedSettings);
            Controls.Add(btn_Start);
            Controls.Add(chb_BulletCollision);
            Controls.Add(chb_FullScreen);
            Controls.Add(numericUpDown2);
            Controls.Add(numericUpDown1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(294, 192);
            Name = "MainMenu";
            Text = "MainMenu";
            Load += MainMenu_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private CheckBox chb_FullScreen;
        private CheckBox chb_BulletCollision;
        private Button btn_Start;
        private Button btn_AdvancedSettings;
        private Button btn_InputSettings;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem tsm_MenuFile;
        private ToolStripMenuItem tsm_OpenConfigFolder;
        private ToolStripMenuItem projektToolStripMenuItem;
        private ToolStripMenuItem tsm_Info;
    }
}