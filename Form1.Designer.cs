namespace VeryLongIntCalculator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            InputInt1 = new TextBox();
            OpBox = new ComboBox();
            InputInt2 = new TextBox();
            button1 = new Button();
            ResultLabel = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // InputInt1
            // 
            InputInt1.Location = new Point(25, 66);
            InputInt1.Name = "InputInt1";
            InputInt1.Size = new Size(125, 27);
            InputInt1.TabIndex = 0;
            // 
            // OpBox
            // 
            OpBox.FormattingEnabled = true;
            OpBox.Items.AddRange(new object[] { "+", "*" });
            OpBox.Location = new Point(185, 65);
            OpBox.Name = "OpBox";
            OpBox.Size = new Size(74, 28);
            OpBox.TabIndex = 1;
            // 
            // InputInt2
            // 
            InputInt2.Location = new Point(311, 66);
            InputInt2.Name = "InputInt2";
            InputInt2.Size = new Size(125, 27);
            InputInt2.TabIndex = 2;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Location = new Point(185, 146);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 3;
            button1.Text = "Calculate";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // ResultLabel
            // 
            ResultLabel.AutoSize = true;
            ResultLabel.Location = new Point(198, 239);
            ResultLabel.Name = "ResultLabel";
            ResultLabel.Size = new Size(0, 20);
            ResultLabel.TabIndex = 4;
            ResultLabel.Click += label1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(204, 228);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(ResultLabel);
            Controls.Add(button1);
            Controls.Add(InputInt2);
            Controls.Add(OpBox);
            Controls.Add(InputInt1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox InputInt1;
        private ComboBox OpBox;
        private TextBox InputInt2;
        private Button button1;
        private Label ResultLabel;
        private Label label1;
    }
}
