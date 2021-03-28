
namespace Sudoku
{
    partial class Menu
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
            this.btnStart = new System.Windows.Forms.Button();
            this.grpDifficulty = new System.Windows.Forms.GroupBox();
            this.radHard = new System.Windows.Forms.RadioButton();
            this.radMedium = new System.Windows.Forms.RadioButton();
            this.radEasy = new System.Windows.Forms.RadioButton();
            this.nudPuzzleNum = new System.Windows.Forms.NumericUpDown();
            this.lblPuzzleNum = new System.Windows.Forms.Label();
            this.grpDifficulty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPuzzleNum)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(269, 35);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(109, 46);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // grpDifficulty
            // 
            this.grpDifficulty.Controls.Add(this.radHard);
            this.grpDifficulty.Controls.Add(this.radMedium);
            this.grpDifficulty.Controls.Add(this.radEasy);
            this.grpDifficulty.Location = new System.Drawing.Point(12, 12);
            this.grpDifficulty.Name = "grpDifficulty";
            this.grpDifficulty.Size = new System.Drawing.Size(93, 100);
            this.grpDifficulty.TabIndex = 1;
            this.grpDifficulty.TabStop = false;
            this.grpDifficulty.Text = "Difficulty:";
            // 
            // radHard
            // 
            this.radHard.AutoSize = true;
            this.radHard.Location = new System.Drawing.Point(6, 75);
            this.radHard.Name = "radHard";
            this.radHard.Size = new System.Drawing.Size(60, 21);
            this.radHard.TabIndex = 2;
            this.radHard.TabStop = true;
            this.radHard.Text = "Hard";
            this.radHard.UseVisualStyleBackColor = true;
            // 
            // radMedium
            // 
            this.radMedium.AutoSize = true;
            this.radMedium.Location = new System.Drawing.Point(6, 48);
            this.radMedium.Name = "radMedium";
            this.radMedium.Size = new System.Drawing.Size(78, 21);
            this.radMedium.TabIndex = 1;
            this.radMedium.TabStop = true;
            this.radMedium.Text = "Medium";
            this.radMedium.UseVisualStyleBackColor = true;
            // 
            // radEasy
            // 
            this.radEasy.AutoSize = true;
            this.radEasy.Checked = true;
            this.radEasy.Location = new System.Drawing.Point(6, 21);
            this.radEasy.Name = "radEasy";
            this.radEasy.Size = new System.Drawing.Size(60, 21);
            this.radEasy.TabIndex = 0;
            this.radEasy.TabStop = true;
            this.radEasy.Text = "Easy";
            this.radEasy.UseVisualStyleBackColor = true;
            // 
            // nudPuzzleNum
            // 
            this.nudPuzzleNum.Location = new System.Drawing.Point(126, 35);
            this.nudPuzzleNum.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudPuzzleNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPuzzleNum.Name = "nudPuzzleNum";
            this.nudPuzzleNum.Size = new System.Drawing.Size(48, 22);
            this.nudPuzzleNum.TabIndex = 3;
            this.nudPuzzleNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblPuzzleNum
            // 
            this.lblPuzzleNum.AutoSize = true;
            this.lblPuzzleNum.Location = new System.Drawing.Point(123, 12);
            this.lblPuzzleNum.Name = "lblPuzzleNum";
            this.lblPuzzleNum.Size = new System.Drawing.Size(66, 17);
            this.lblPuzzleNum.TabIndex = 4;
            this.lblPuzzleNum.Text = "Puzzle #:";
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 370);
            this.Controls.Add(this.lblPuzzleNum);
            this.Controls.Add(this.nudPuzzleNum);
            this.Controls.Add(this.grpDifficulty);
            this.Controls.Add(this.btnStart);
            this.Name = "Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.grpDifficulty.ResumeLayout(false);
            this.grpDifficulty.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPuzzleNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox grpDifficulty;
        private System.Windows.Forms.RadioButton radHard;
        private System.Windows.Forms.RadioButton radMedium;
        private System.Windows.Forms.RadioButton radEasy;
        private System.Windows.Forms.NumericUpDown nudPuzzleNum;
        private System.Windows.Forms.Label lblPuzzleNum;
    }
}