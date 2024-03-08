namespace Cowboy
{
    partial class AdvancedSettings
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
            PlayerClone = new CheckBox();
            txt_PlayerName_1 = new TextBox();
            txt_PlayerName_2 = new TextBox();
            groupBox1 = new GroupBox();
            label9 = new Label();
            label7 = new Label();
            label5 = new Label();
            label3 = new Label();
            label1 = new Label();
            Nu_ReloadSpeed_1 = new NumericUpDown();
            Nu_BulletSpeed_1 = new NumericUpDown();
            Nu_PlayerHP_1 = new NumericUpDown();
            Nu_BulletDamage_1 = new NumericUpDown();
            Nu_PlayerSpeed_1 = new NumericUpDown();
            groupBox2 = new GroupBox();
            label10 = new Label();
            label8 = new Label();
            label6 = new Label();
            label4 = new Label();
            label2 = new Label();
            Nu_ReloadSpeed_2 = new NumericUpDown();
            Nu_BulletDamage_2 = new NumericUpDown();
            Nu_BulletSpeed_2 = new NumericUpDown();
            Nu_PlayerHP_2 = new NumericUpDown();
            Nu_PlayerSpeed_2 = new NumericUpDown();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            Ch_Bot_1 = new CheckBox();
            Ch_Bot_2 = new CheckBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Nu_ReloadSpeed_1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Nu_BulletSpeed_1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Nu_PlayerHP_1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Nu_BulletDamage_1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Nu_PlayerSpeed_1).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Nu_ReloadSpeed_2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Nu_BulletDamage_2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Nu_BulletSpeed_2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Nu_PlayerHP_2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Nu_PlayerSpeed_2).BeginInit();
            SuspendLayout();
            // 
            // PlayerClone
            // 
            PlayerClone.AutoSize = true;
            PlayerClone.Location = new Point(12, 12);
            PlayerClone.Name = "PlayerClone";
            PlayerClone.Size = new Size(103, 19);
            PlayerClone.TabIndex = 0;
            PlayerClone.Text = "Külön beállítás";
            PlayerClone.UseVisualStyleBackColor = true;
            PlayerClone.CheckedChanged += PlayerClone_CheckedChanged;
            // 
            // txt_PlayerName_1
            // 
            txt_PlayerName_1.Location = new Point(12, 37);
            txt_PlayerName_1.Name = "txt_PlayerName_1";
            txt_PlayerName_1.Size = new Size(100, 23);
            txt_PlayerName_1.TabIndex = 1;
            txt_PlayerName_1.TextChanged += txt_Player1Name_TextChanged;
            // 
            // txt_PlayerName_2
            // 
            txt_PlayerName_2.Location = new Point(218, 37);
            txt_PlayerName_2.Name = "txt_PlayerName_2";
            txt_PlayerName_2.Size = new Size(100, 23);
            txt_PlayerName_2.TabIndex = 2;
            txt_PlayerName_2.TextChanged += txt_Player2Name_TextChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(Nu_ReloadSpeed_1);
            groupBox1.Controls.Add(Nu_BulletSpeed_1);
            groupBox1.Controls.Add(Nu_PlayerHP_1);
            groupBox1.Controls.Add(Nu_BulletDamage_1);
            groupBox1.Controls.Add(Nu_PlayerSpeed_1);
            groupBox1.Location = new Point(12, 66);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 165);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 134);
            label9.Name = "label9";
            label9.Size = new Size(85, 15);
            label9.TabIndex = 8;
            label9.Text = "Újratöltés Ideje";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 105);
            label7.Name = "label7";
            label7.Size = new Size(83, 15);
            label7.TabIndex = 7;
            label7.Text = "Töltény Sebzés";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 76);
            label5.Name = "label5";
            label5.Size = new Size(96, 15);
            label5.TabIndex = 6;
            label5.Text = "Töltény Sebesség";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 47);
            label3.Name = "label3";
            label3.Size = new Size(64, 15);
            label3.TabIndex = 5;
            label3.Text = "Játékos HP";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 18);
            label1.Name = "label1";
            label1.Size = new Size(96, 15);
            label1.TabIndex = 4;
            label1.Text = "Játékos Sebesség";
            // 
            // Nu_ReloadSpeed_1
            // 
            Nu_ReloadSpeed_1.Location = new Point(152, 132);
            Nu_ReloadSpeed_1.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            Nu_ReloadSpeed_1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            Nu_ReloadSpeed_1.Name = "Nu_ReloadSpeed_1";
            Nu_ReloadSpeed_1.Size = new Size(42, 23);
            Nu_ReloadSpeed_1.TabIndex = 5;
            Nu_ReloadSpeed_1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // Nu_BulletSpeed_1
            // 
            Nu_BulletSpeed_1.Location = new Point(152, 74);
            Nu_BulletSpeed_1.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            Nu_BulletSpeed_1.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            Nu_BulletSpeed_1.Name = "Nu_BulletSpeed_1";
            Nu_BulletSpeed_1.Size = new Size(42, 23);
            Nu_BulletSpeed_1.TabIndex = 3;
            Nu_BulletSpeed_1.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // Nu_PlayerHP_1
            // 
            Nu_PlayerHP_1.Location = new Point(152, 45);
            Nu_PlayerHP_1.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            Nu_PlayerHP_1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            Nu_PlayerHP_1.Name = "Nu_PlayerHP_1";
            Nu_PlayerHP_1.Size = new Size(42, 23);
            Nu_PlayerHP_1.TabIndex = 2;
            Nu_PlayerHP_1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // Nu_BulletDamage_1
            // 
            Nu_BulletDamage_1.Location = new Point(152, 103);
            Nu_BulletDamage_1.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            Nu_BulletDamage_1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            Nu_BulletDamage_1.Name = "Nu_BulletDamage_1";
            Nu_BulletDamage_1.Size = new Size(42, 23);
            Nu_BulletDamage_1.TabIndex = 4;
            Nu_BulletDamage_1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // Nu_PlayerSpeed_1
            // 
            Nu_PlayerSpeed_1.Location = new Point(152, 16);
            Nu_PlayerSpeed_1.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            Nu_PlayerSpeed_1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            Nu_PlayerSpeed_1.Name = "Nu_PlayerSpeed_1";
            Nu_PlayerSpeed_1.Size = new Size(42, 23);
            Nu_PlayerSpeed_1.TabIndex = 1;
            Nu_PlayerSpeed_1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(Nu_ReloadSpeed_2);
            groupBox2.Controls.Add(Nu_BulletDamage_2);
            groupBox2.Controls.Add(Nu_BulletSpeed_2);
            groupBox2.Controls.Add(Nu_PlayerHP_2);
            groupBox2.Controls.Add(Nu_PlayerSpeed_2);
            groupBox2.Location = new Point(218, 66);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(200, 165);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "groupBox2";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(6, 134);
            label10.Name = "label10";
            label10.Size = new Size(85, 15);
            label10.TabIndex = 9;
            label10.Text = "Újratöltés Ideje";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 105);
            label8.Name = "label8";
            label8.Size = new Size(83, 15);
            label8.TabIndex = 8;
            label8.Text = "Töltény Sebzés";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 76);
            label6.Name = "label6";
            label6.Size = new Size(96, 15);
            label6.TabIndex = 7;
            label6.Text = "Töltény Sebesség";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 47);
            label4.Name = "label4";
            label4.Size = new Size(64, 15);
            label4.TabIndex = 6;
            label4.Text = "Játékos HP";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 18);
            label2.Name = "label2";
            label2.Size = new Size(96, 15);
            label2.TabIndex = 5;
            label2.Text = "Játékos Sebesség";
            // 
            // Nu_ReloadSpeed_2
            // 
            Nu_ReloadSpeed_2.Location = new Point(152, 132);
            Nu_ReloadSpeed_2.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            Nu_ReloadSpeed_2.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            Nu_ReloadSpeed_2.Name = "Nu_ReloadSpeed_2";
            Nu_ReloadSpeed_2.Size = new Size(42, 23);
            Nu_ReloadSpeed_2.TabIndex = 5;
            Nu_ReloadSpeed_2.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // Nu_BulletDamage_2
            // 
            Nu_BulletDamage_2.Location = new Point(152, 103);
            Nu_BulletDamage_2.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            Nu_BulletDamage_2.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            Nu_BulletDamage_2.Name = "Nu_BulletDamage_2";
            Nu_BulletDamage_2.Size = new Size(42, 23);
            Nu_BulletDamage_2.TabIndex = 4;
            Nu_BulletDamage_2.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // Nu_BulletSpeed_2
            // 
            Nu_BulletSpeed_2.Location = new Point(152, 74);
            Nu_BulletSpeed_2.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            Nu_BulletSpeed_2.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            Nu_BulletSpeed_2.Name = "Nu_BulletSpeed_2";
            Nu_BulletSpeed_2.Size = new Size(42, 23);
            Nu_BulletSpeed_2.TabIndex = 3;
            Nu_BulletSpeed_2.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // Nu_PlayerHP_2
            // 
            Nu_PlayerHP_2.Location = new Point(152, 45);
            Nu_PlayerHP_2.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            Nu_PlayerHP_2.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            Nu_PlayerHP_2.Name = "Nu_PlayerHP_2";
            Nu_PlayerHP_2.Size = new Size(42, 23);
            Nu_PlayerHP_2.TabIndex = 2;
            Nu_PlayerHP_2.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // Nu_PlayerSpeed_2
            // 
            Nu_PlayerSpeed_2.Location = new Point(152, 16);
            Nu_PlayerSpeed_2.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            Nu_PlayerSpeed_2.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            Nu_PlayerSpeed_2.Name = "Nu_PlayerSpeed_2";
            Nu_PlayerSpeed_2.Size = new Size(42, 23);
            Nu_PlayerSpeed_2.TabIndex = 1;
            Nu_PlayerSpeed_2.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // button1
            // 
            button1.Location = new Point(180, 237);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 6;
            button1.Text = "Mentés";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btn_AdvsSave_Click;
            // 
            // button2
            // 
            button2.Location = new Point(180, 266);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 7;
            button2.Text = "Reset";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btn_advsReset_Click;
            // 
            // button3
            // 
            button3.Location = new Point(180, 295);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 8;
            button3.Text = "Vissza";
            button3.UseVisualStyleBackColor = true;
            button3.Click += btn_AdvsBack_Click;
            // 
            // Ch_Bot_1
            // 
            Ch_Bot_1.AutoSize = true;
            Ch_Bot_1.Location = new Point(118, 39);
            Ch_Bot_1.Name = "Ch_Bot_1";
            Ch_Bot_1.Size = new Size(44, 19);
            Ch_Bot_1.TabIndex = 9;
            Ch_Bot_1.Text = "Bot";
            Ch_Bot_1.UseVisualStyleBackColor = true;
            // 
            // Ch_Bot_2
            // 
            Ch_Bot_2.AutoSize = true;
            Ch_Bot_2.Location = new Point(324, 39);
            Ch_Bot_2.Name = "Ch_Bot_2";
            Ch_Bot_2.Size = new Size(44, 19);
            Ch_Bot_2.TabIndex = 10;
            Ch_Bot_2.Text = "Bot";
            Ch_Bot_2.UseVisualStyleBackColor = true;
            // 
            // AdvancedSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(428, 334);
            Controls.Add(Ch_Bot_2);
            Controls.Add(Ch_Bot_1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(txt_PlayerName_2);
            Controls.Add(txt_PlayerName_1);
            Controls.Add(PlayerClone);
            Name = "AdvancedSettings";
            Text = "AdvancedSettings";
            Load += AdvancedSettings_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Nu_ReloadSpeed_1).EndInit();
            ((System.ComponentModel.ISupportInitialize)Nu_BulletSpeed_1).EndInit();
            ((System.ComponentModel.ISupportInitialize)Nu_PlayerHP_1).EndInit();
            ((System.ComponentModel.ISupportInitialize)Nu_BulletDamage_1).EndInit();
            ((System.ComponentModel.ISupportInitialize)Nu_PlayerSpeed_1).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Nu_ReloadSpeed_2).EndInit();
            ((System.ComponentModel.ISupportInitialize)Nu_BulletDamage_2).EndInit();
            ((System.ComponentModel.ISupportInitialize)Nu_BulletSpeed_2).EndInit();
            ((System.ComponentModel.ISupportInitialize)Nu_PlayerHP_2).EndInit();
            ((System.ComponentModel.ISupportInitialize)Nu_PlayerSpeed_2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox PlayerClone;
        private TextBox txt_PlayerName_1;
        private TextBox txt_PlayerName_2;
        private GroupBox groupBox1;
        private NumericUpDown Nu_ReloadSpeed_1;
        private NumericUpDown Nu_BulletSpeed_1;
        private NumericUpDown Nu_PlayerHP_1;
        private NumericUpDown Nu_BulletDamage_1;
        private NumericUpDown Nu_PlayerSpeed_1;
        private GroupBox groupBox2;
        private NumericUpDown Nu_ReloadSpeed_2;
        private NumericUpDown Nu_BulletDamage_2;
        private NumericUpDown Nu_BulletSpeed_2;
        private NumericUpDown Nu_PlayerHP_2;
        private NumericUpDown Nu_PlayerSpeed_2;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label label3;
        private Label label1;
        private Label label4;
        private Label label2;
        private Label label9;
        private Label label7;
        private Label label5;
        private Label label10;
        private Label label8;
        private Label label6;
        private CheckBox Ch_Bot_1;
        private CheckBox Ch_Bot_2;
    }
}