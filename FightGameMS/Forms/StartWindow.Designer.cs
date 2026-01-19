namespace FightGameMS.Forms
{
    partial class StartWindow
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
            Player1ComboBox = new ComboBox();
            Player2ComboBox = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // Player1ComboBox
            // 
            Player1ComboBox.FormattingEnabled = true;
            Player1ComboBox.Location = new Point(65, 193);
            Player1ComboBox.Name = "Player1ComboBox";
            Player1ComboBox.Size = new Size(166, 23);
            Player1ComboBox.TabIndex = 0;
            Player1ComboBox.SelectedIndexChanged += Player1ComboBox_SelectedIndexChanged;
            // 
            // Player2ComboBox
            // 
            Player2ComboBox.FormattingEnabled = true;
            Player2ComboBox.Location = new Point(474, 193);
            Player2ComboBox.Name = "Player2ComboBox";
            Player2ComboBox.Size = new Size(179, 23);
            Player2ComboBox.TabIndex = 1;
            Player2ComboBox.SelectedIndexChanged += Player2ComboBox_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sylfaen", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.Location = new Point(94, 113);
            label1.Name = "label1";
            label1.Size = new Size(108, 35);
            label1.TabIndex = 2;
            label1.Text = "Player1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sylfaen", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label2.Location = new Point(508, 113);
            label2.Name = "label2";
            label2.Size = new Size(108, 35);
            label2.TabIndex = 3;
            label2.Text = "Player2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Sylfaen", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label3.Location = new Point(220, 31);
            label3.Name = "label3";
            label3.Size = new Size(300, 39);
            label3.TabIndex = 4;
            label3.Text = "Wybierz swoją postać";
            // 
            // button1
            // 
            button1.Font = new Font("Sylfaen", 24F, FontStyle.Bold, GraphicsUnit.Point, 238);
            button1.Location = new Point(186, 334);
            button1.Name = "button1";
            button1.Size = new Size(346, 59);
            button1.TabIndex = 5;
            button1.Text = "Zacznij Grę";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // StartWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Player2ComboBox);
            Controls.Add(Player1ComboBox);
            Name = "StartWindow";
            Text = "StartWindow";
            Load += StartWindow_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox Player1ComboBox;
        private ComboBox Player2ComboBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
    }
}