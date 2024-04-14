namespace Cowboy.Forms
{
    partial class InputSettings
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
            groupBox1 = new GroupBox();
            label3 = new Label();
            button3 = new Button();
            button2 = new Button();
            label2 = new Label();
            button1 = new Button();
            label1 = new Label();
            groupBox2 = new GroupBox();
            label4 = new Label();
            button4 = new Button();
            button5 = new Button();
            label5 = new Label();
            button6 = new Button();
            label6 = new Label();
            btn_Save = new Button();
            btn_Reset = new Button();
            btn_Back = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(204, 108);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 77);
            label3.Name = "label3";
            label3.Size = new Size(37, 15);
            label3.TabIndex = 5;
            label3.Text = "Lövés";
            // 
            // button3
            // 
            button3.Location = new Point(123, 73);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 3;
            button3.UseVisualStyleBackColor = true;
            button3.Click += Set_Input;
            button3.KeyDown += Key_Down;
            button3.PreviewKeyDown += Preview_KeyDown;
            // 
            // button2
            // 
            button2.Location = new Point(123, 44);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 2;
            button2.UseVisualStyleBackColor = true;
            button2.Click += Set_Input;
            button2.KeyDown += Key_Down;
            button2.PreviewKeyDown += Preview_KeyDown;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 48);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 2;
            label2.Text = "Mozgás Le";
            // 
            // button1
            // 
            button1.Location = new Point(123, 15);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.UseVisualStyleBackColor = true;
            button1.Click += Set_Input;
            button1.KeyDown += Key_Down;
            button1.PreviewKeyDown += Preview_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(66, 15);
            label1.TabIndex = 0;
            label1.Text = "Mozgás Fel";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(button4);
            groupBox2.Controls.Add(button5);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(button6);
            groupBox2.Controls.Add(label6);
            groupBox2.Location = new Point(222, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(204, 108);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "groupBox2";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 77);
            label4.Name = "label4";
            label4.Size = new Size(37, 15);
            label4.TabIndex = 5;
            label4.Text = "Lövés";
            // 
            // button4
            // 
            button4.Location = new Point(123, 15);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 1;
            button4.UseVisualStyleBackColor = true;
            button4.Click += Set_Input;
            button4.KeyDown += Key_Down;
            button4.PreviewKeyDown += Preview_KeyDown;
            // 
            // button5
            // 
            button5.Location = new Point(123, 44);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 2;
            button5.UseVisualStyleBackColor = true;
            button5.Click += Set_Input;
            button5.KeyDown += Key_Down;
            button5.PreviewKeyDown += Preview_KeyDown;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 48);
            label5.Name = "label5";
            label5.Size = new Size(63, 15);
            label5.TabIndex = 2;
            label5.Text = "Mozgás Le";
            // 
            // button6
            // 
            button6.Location = new Point(123, 73);
            button6.Name = "button6";
            button6.Size = new Size(75, 23);
            button6.TabIndex = 3;
            button6.UseVisualStyleBackColor = true;
            button6.Click += Set_Input;
            button6.KeyDown += Key_Down;
            button6.PreviewKeyDown += Preview_KeyDown;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 19);
            label6.Name = "label6";
            label6.Size = new Size(66, 15);
            label6.TabIndex = 0;
            label6.Text = "Mozgás Fel";
            // 
            // btn_Save
            // 
            btn_Save.Location = new Point(179, 126);
            btn_Save.Name = "btn_Save";
            btn_Save.Size = new Size(80, 25);
            btn_Save.TabIndex = 3;
            btn_Save.Text = "Mentés";
            btn_Save.UseVisualStyleBackColor = true;
            btn_Save.Click += Save_Click;
            // 
            // btn_Reset
            // 
            btn_Reset.Location = new Point(179, 157);
            btn_Reset.Name = "btn_Reset";
            btn_Reset.Size = new Size(80, 25);
            btn_Reset.TabIndex = 4;
            btn_Reset.Text = "Reset";
            btn_Reset.UseVisualStyleBackColor = true;
            btn_Reset.Click += Reset_Click;
            // 
            // btn_Back
            // 
            btn_Back.Location = new Point(179, 188);
            btn_Back.Name = "btn_Back";
            btn_Back.Size = new Size(80, 25);
            btn_Back.TabIndex = 5;
            btn_Back.Text = "Vissza";
            btn_Back.UseVisualStyleBackColor = true;
            btn_Back.Click += Back_Click;
            // 
            // InputSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 219);
            Controls.Add(btn_Back);
            Controls.Add(btn_Reset);
            Controls.Add(btn_Save);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "InputSettings";
            Text = "Billentyűzet Beállítások";
            Load += InputSettings_Load;
            KeyDown += Key_Down;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox1;
        private Label label3;
        private Button button3;
        private Button button2;
        private Label label2;
        private Button button1;
        private Label label1;
        private GroupBox groupBox2;
        private Label label4;
        private Button button4;
        private Button button5;
        private Label label5;
        private Button button6;
        private Label label6;
        private Button btn_Save;
        private Button btn_Reset;
        private Button btn_Back;
    }
}