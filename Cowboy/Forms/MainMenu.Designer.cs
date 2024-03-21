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
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            btn_Start = new Button();
            btn_AdvancedSettings = new Button();
            btn_InputSettings = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(113, 15);
            label1.TabIndex = 0;
            label1.Text = "Játékablak Szélesség";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 38);
            label2.Name = "label2";
            label2.Size = new Size(117, 15);
            label2.TabIndex = 1;
            label2.Text = "Játékablak Magasság";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(179, 7);
            numericUpDown1.Maximum = new decimal(new int[] { 1900, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 200, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(87, 23);
            numericUpDown1.TabIndex = 1;
            numericUpDown1.Value = new decimal(new int[] { 600, 0, 0, 0 });
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(179, 36);
            numericUpDown2.Maximum = new decimal(new int[] { 1900, 0, 0, 0 });
            numericUpDown2.Minimum = new decimal(new int[] { 200, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(87, 23);
            numericUpDown2.TabIndex = 2;
            numericUpDown2.Value = new decimal(new int[] { 600, 0, 0, 0 });
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(12, 65);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(80, 19);
            checkBox1.TabIndex = 3;
            checkBox1.Text = "FullScreen";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(98, 65);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(105, 19);
            checkBox2.TabIndex = 4;
            checkBox2.Text = "Bullet Collision";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // btn_Start
            // 
            btn_Start.Location = new Point(12, 147);
            btn_Start.Name = "btn_Start";
            btn_Start.Size = new Size(254, 23);
            btn_Start.TabIndex = 6;
            btn_Start.Text = "Start";
            btn_Start.UseVisualStyleBackColor = true;
            btn_Start.Click += btn_Start_Click;
            // 
            // btn_AdvancedSettings
            // 
            btn_AdvancedSettings.Location = new Point(12, 89);
            btn_AdvancedSettings.Name = "btn_AdvancedSettings";
            btn_AdvancedSettings.Size = new Size(254, 23);
            btn_AdvancedSettings.TabIndex = 5;
            btn_AdvancedSettings.Text = "Adavanced Settings";
            btn_AdvancedSettings.UseVisualStyleBackColor = true;
            btn_AdvancedSettings.Click += btn_Advnaced_Click;
            // 
            // btn_InputSettings
            // 
            btn_InputSettings.Location = new Point(12, 118);
            btn_InputSettings.Name = "btn_InputSettings";
            btn_InputSettings.Size = new Size(254, 23);
            btn_InputSettings.TabIndex = 7;
            btn_InputSettings.Text = "Input Settings";
            btn_InputSettings.UseVisualStyleBackColor = true;
            btn_InputSettings.Click += btn_InputSettings_Click;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(278, 178);
            Controls.Add(btn_InputSettings);
            Controls.Add(btn_AdvancedSettings);
            Controls.Add(btn_Start);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(numericUpDown2);
            Controls.Add(numericUpDown1);
            Controls.Add(label2);
            Controls.Add(label1);
            MinimumSize = new Size(294, 192);
            Name = "MainMenu";
            Text = "MainMenu";
            Load += MainMenu_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private Button btn_Start;
        private Button btn_AdvancedSettings;
        private Button btn_InputSettings;
    }
}