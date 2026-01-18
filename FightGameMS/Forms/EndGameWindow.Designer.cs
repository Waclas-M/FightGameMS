namespace FightGameMS.Forms
{
    partial class EndGameWindow
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
            Wgrywasz = new Label();
            Winner = new Label();
            SuspendLayout();
            // 
            // Wgrywasz
            // 
            Wgrywasz.AutoSize = true;
            Wgrywasz.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point, 238);
            Wgrywasz.Location = new Point(248, 54);
            Wgrywasz.Name = "Wgrywasz";
            Wgrywasz.Size = new Size(271, 86);
            Wgrywasz.TabIndex = 0;
            Wgrywasz.Text = "Wgrany";
            // 
            // Winner
            // 
            Winner.AutoSize = true;
            Winner.Font = new Font("Segoe UI Semibold", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            Winner.ForeColor = SystemColors.Highlight;
            Winner.Location = new Point(323, 187);
            Winner.Name = "Winner";
            Winner.Size = new Size(92, 40);
            Winner.TabIndex = 1;
            Winner.Text = "label1";
            // 
            // EndGameWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Winner);
            Controls.Add(Wgrywasz);
            Name = "EndGameWindow";
            Text = "EndGameWindow";
            FormClosed += EndGameWindow_FormClosed;
            Load += EndGameWindow_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Wgrywasz;
        private Label Winner;
    }
}