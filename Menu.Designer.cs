
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.btnStart = new System.Windows.Forms.Button();
            this.grpDifficulty = new System.Windows.Forms.GroupBox();
            this.radHard = new System.Windows.Forms.RadioButton();
            this.radMedium = new System.Windows.Forms.RadioButton();
            this.radEasy = new System.Windows.Forms.RadioButton();
            this.nudPuzzleNum = new System.Windows.Forms.NumericUpDown();
            this.lblPuzzleNum = new System.Windows.Forms.Label();
            this.tmrInterval = new System.Windows.Forms.Timer(this.components);
            this.tmrFade = new System.Windows.Forms.Timer(this.components);
            this.lblTitle = new System.Windows.Forms.Label();
            this.tmrTitleColours = new System.Windows.Forms.Timer(this.components);
            this.ttpHowToPlay = new System.Windows.Forms.ToolTip(this.components);
            this.lblHowToPlay = new System.Windows.Forms.Label();
            this.chkToggleMistakeHighlighting = new System.Windows.Forms.CheckBox();
            this.grpDifficulty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPuzzleNum)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Lime;
            this.btnStart.Font = new System.Drawing.Font("Comic Sans MS", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(208, 459);
            this.btnStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnStart.Size = new System.Drawing.Size(253, 102);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // grpDifficulty
            // 
            this.grpDifficulty.Controls.Add(this.radHard);
            this.grpDifficulty.Controls.Add(this.radMedium);
            this.grpDifficulty.Controls.Add(this.radEasy);
            this.grpDifficulty.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDifficulty.Location = new System.Drawing.Point(93, 176);
            this.grpDifficulty.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpDifficulty.Name = "grpDifficulty";
            this.grpDifficulty.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpDifficulty.Size = new System.Drawing.Size(205, 204);
            this.grpDifficulty.TabIndex = 1;
            this.grpDifficulty.TabStop = false;
            this.grpDifficulty.Text = "Difficulty:";
            // 
            // radHard
            // 
            this.radHard.AutoSize = true;
            this.radHard.Location = new System.Drawing.Point(0, 148);
            this.radHard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radHard.Name = "radHard";
            this.radHard.Size = new System.Drawing.Size(108, 46);
            this.radHard.TabIndex = 2;
            this.radHard.TabStop = true;
            this.radHard.Text = "Hard";
            this.radHard.UseVisualStyleBackColor = true;
            this.radHard.CheckedChanged += new System.EventHandler(this.radHard_CheckedChanged);
            // 
            // radMedium
            // 
            this.radMedium.AutoSize = true;
            this.radMedium.Location = new System.Drawing.Point(0, 97);
            this.radMedium.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radMedium.Name = "radMedium";
            this.radMedium.Size = new System.Drawing.Size(144, 46);
            this.radMedium.TabIndex = 1;
            this.radMedium.TabStop = true;
            this.radMedium.Text = "Medium";
            this.radMedium.UseVisualStyleBackColor = true;
            this.radMedium.CheckedChanged += new System.EventHandler(this.radMedium_CheckedChanged);
            // 
            // radEasy
            // 
            this.radEasy.AutoSize = true;
            this.radEasy.Checked = true;
            this.radEasy.Location = new System.Drawing.Point(0, 47);
            this.radEasy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radEasy.Name = "radEasy";
            this.radEasy.Size = new System.Drawing.Size(104, 46);
            this.radEasy.TabIndex = 0;
            this.radEasy.TabStop = true;
            this.radEasy.Text = "Easy";
            this.radEasy.UseVisualStyleBackColor = true;
            this.radEasy.CheckedChanged += new System.EventHandler(this.radEasy_CheckedChanged);
            // 
            // nudPuzzleNum
            // 
            this.nudPuzzleNum.Font = new System.Drawing.Font("Comic Sans MS", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudPuzzleNum.Location = new System.Drawing.Point(451, 239);
            this.nudPuzzleNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.nudPuzzleNum.Size = new System.Drawing.Size(55, 58);
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
            this.lblPuzzleNum.Font = new System.Drawing.Font("Comic Sans MS", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPuzzleNum.Location = new System.Drawing.Point(385, 176);
            this.lblPuzzleNum.Name = "lblPuzzleNum";
            this.lblPuzzleNum.Size = new System.Drawing.Size(184, 52);
            this.lblPuzzleNum.TabIndex = 4;
            this.lblPuzzleNum.Text = "Puzzle #:";
            // 
            // tmrInterval
            // 
            this.tmrInterval.Enabled = true;
            this.tmrInterval.Interval = 10;
            this.tmrInterval.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tmrFade
            // 
            this.tmrFade.Interval = 1;
            this.tmrFade.Tick += new System.EventHandler(this.tmrFade_Tick);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Comic Sans MS", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(41, 27);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(559, 112);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Paul\'s Sudoku";
            // 
            // tmrTitleColours
            // 
            this.tmrTitleColours.Enabled = true;
            this.tmrTitleColours.Interval = 1;
            this.tmrTitleColours.Tick += new System.EventHandler(this.tmrTitleColours_Tick);
            // 
            // ttpHowToPlay
            // 
            this.ttpHowToPlay.AutomaticDelay = 0;
            this.ttpHowToPlay.AutoPopDelay = 500000000;
            this.ttpHowToPlay.InitialDelay = 0;
            this.ttpHowToPlay.ReshowDelay = 0;
            this.ttpHowToPlay.ToolTipTitle = "How to play";
            // 
            // lblHowToPlay
            // 
            this.lblHowToPlay.AutoSize = true;
            this.lblHowToPlay.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHowToPlay.Location = new System.Drawing.Point(620, 11);
            this.lblHowToPlay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHowToPlay.Name = "lblHowToPlay";
            this.lblHowToPlay.Size = new System.Drawing.Size(32, 38);
            this.lblHowToPlay.TabIndex = 6;
            this.lblHowToPlay.Text = "?";
            // 
            // chkToggleMistakeHighlighting
            // 
            this.chkToggleMistakeHighlighting.AutoSize = true;
            this.chkToggleMistakeHighlighting.Checked = true;
            this.chkToggleMistakeHighlighting.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkToggleMistakeHighlighting.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkToggleMistakeHighlighting.Location = new System.Drawing.Point(16, 567);
            this.chkToggleMistakeHighlighting.Margin = new System.Windows.Forms.Padding(4);
            this.chkToggleMistakeHighlighting.Name = "chkToggleMistakeHighlighting";
            this.chkToggleMistakeHighlighting.Size = new System.Drawing.Size(224, 32);
            this.chkToggleMistakeHighlighting.TabIndex = 7;
            this.chkToggleMistakeHighlighting.Text = "Mistake highlighting";
            this.chkToggleMistakeHighlighting.UseVisualStyleBackColor = true;
            this.chkToggleMistakeHighlighting.CheckedChanged += new System.EventHandler(this.chkToggleMistakeHighlighting_CheckedChanged);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Sudoku.Properties.Resources.sudoku_0;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(669, 615);
            this.Controls.Add(this.chkToggleMistakeHighlighting);
            this.Controls.Add(this.lblHowToPlay);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblPuzzleNum);
            this.Controls.Add(this.nudPuzzleNum);
            this.Controls.Add(this.grpDifficulty);
            this.Controls.Add(this.btnStart);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.VisibleChanged += new System.EventHandler(this.Menu_VisibleChanged);
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
        private System.Windows.Forms.Timer tmrInterval;
        private System.Windows.Forms.Timer tmrFade;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Timer tmrTitleColours;
        private System.Windows.Forms.ToolTip ttpHowToPlay;
        private System.Windows.Forms.Label lblHowToPlay;
        private System.Windows.Forms.CheckBox chkToggleMistakeHighlighting;
    }
}