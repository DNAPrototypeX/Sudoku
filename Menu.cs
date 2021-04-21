using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace Sudoku
{
    enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }
    public partial class Menu : Form
    {        
        static Bitmap SetAlpha(Bitmap bmpIn, int alpha)             //Mehtod I stole from stack overflow to change the alpha/transparency of a bitmap.
        {
            Bitmap bmpOut = new Bitmap(bmpIn.Width, bmpIn.Height);
            Rectangle rect = new Rectangle(0, 0, bmpIn.Width, bmpIn.Height);

            float[][] matrixItems = {
        new float[] {1, 0, 0, 0, 0},
        new float[] {0, 1, 0, 0, 0},
        new float[] {0, 0, 1, 0, 0},
        new float[] {0, 0, 0, alpha / 255f, 0},
        new float[] {0, 0, 0, 0, 1}};

            ColorMatrix colorMatrix = new ColorMatrix(matrixItems);

            ImageAttributes imageAtt = new ImageAttributes();
            imageAtt.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            using (Graphics graphics = Graphics.FromImage(bmpOut))
                graphics.DrawImage(bmpIn, rect, rect.X, rect.Y, rect.Width, rect.Height, GraphicsUnit.Pixel, imageAtt);

            return bmpOut;
        }

        int currentImageCounter = 0;
        int nextImageCounter = 0;
        List<Bitmap> menuImages = new List<Bitmap>
        {
            Properties.Resources.sudoku_0,
            Properties.Resources.sudoku_1,
            Properties.Resources.sudoku_2,
            Properties.Resources.sudoku_3,
            Properties.Resources.sudoku_4,
            Properties.Resources.sudoku_5,
        };
        Bitmap currentImage;
        Bitmap nextImage;
        int r = 255;
        int g = 0;
        int b = 0;
        Difficulty difficulty;
        string[,] solution = new string[9, 9];
        bool mistakeHighlighting;

        public Menu()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)         //Starts the game
        {
            tmrInterval.Enabled = false;
            tmrFade.Enabled = false;
            tmrTitleColours.Enabled = false;
            if (radEasy.Checked)
                difficulty = Difficulty.Easy;
            else if (radMedium.Checked)
                difficulty = Difficulty.Medium;
            else
                difficulty = Difficulty.Hard;
            Puzzle puzzle = new Puzzle();
            frmMain game = new frmMain(this, puzzle.getSolution(), mistakeHighlighting);
            game.Visible = true;
            puzzle.initializePuzzle(this, game, difficulty, (int)nudPuzzleNum.Value - 1);           
            this.Hide();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            nudPuzzleNum.Maximum = File.ReadLines("puzzles_easy.txt").ToArray().Length / 19;
            mistakeHighlighting = true;
            currentImage = menuImages[0];
            nextImage = menuImages[1];
            ttpHowToPlay.SetToolTip(lblHowToPlay, "Fill in the blank tiles such that each row,\n" +
                " collumn and 3x3 square (all highlighted in yellow),\n " +
                "have one of each number from 1-9.\n\n" +
                "Controls:\n Left or right click a tile to select it.\n When a tile is selected," +
                " the user can change the number in the square by presing the corresponding \n number " +
                "on the keyboard. If you would like to add a \"note\", hold shift when typing a number,\n" +
                " and it will appear as a small number.");
        }

        private void timer1_Tick(object sender, EventArgs e)        //I don't know why this is called timer1, it should say tmrInterval
        {                                                           //Waits 5 seconds between fading to the next image.
            currentImageCounter += 1;
            if (currentImageCounter == 500)
            {
                tmrFade.Enabled = true;
                tmrInterval.Enabled = false;
                currentImageCounter = 0;                
            }
        }

        private void tmrFade_Tick(object sender, EventArgs e)       //uses the SetAlpha method to fade in/out of the title screen images.
        {
            currentImageCounter += 1; 
            if (currentImageCounter <= 255)
                this.BackgroundImage = SetAlpha(currentImage, 255 - (currentImageCounter));
            else
            {
                nextImageCounter += 1;
                if (nextImageCounter <= 255)
                    this.BackgroundImage = SetAlpha(nextImage, nextImageCounter);
                else
                {
                    currentImageCounter = 0;
                    nextImageCounter = 0;
                    tmrFade.Enabled = false;
                    tmrInterval.Enabled = true;
                    if (currentImage == menuImages[4])
                    {
                        currentImage = menuImages[5];
                        nextImage = menuImages[0];
                    }
                    else if (currentImage == menuImages[5])
                    {
                        currentImage = menuImages[0];
                        nextImage = menuImages[1];
                    }
                    else
                    {
                        currentImage = menuImages[menuImages.IndexOf(currentImage) + 1];
                        nextImage = menuImages[menuImages.IndexOf(currentImage) + 1];
                    }
                }
            }

        }

        private void tmrTitleColours_Tick(object sender, EventArgs e)       //Funny colour fade button
        {
            if (r > 0 & b == 0)
            {
                r--;
                g++;
            }    
            else if (g > 0 & r == 0)
            {
                g--;
                b++;
            }
            else if (b > 0 & g == 0)
            {
                r++;
                b--;
            }
            lblTitle.ForeColor = Color.FromArgb(r, g, b);
            btnStart.BackColor = Color.FromArgb(r, g, b);
        }

        private void Menu_VisibleChanged(object sender, EventArgs e)    //re-activates the image fade when the player exits the puzzle.
        {
            tmrInterval.Enabled = true;
            tmrTitleColours.Enabled = true;
            currentImageCounter = 0;
            nextImageCounter = 0;
        }

        private void chkToggleMistakeHighlighting_CheckedChanged(object sender, EventArgs e)        //toggle the mistake highlighting feature.
        {
            switch (chkToggleMistakeHighlighting.Checked)
            {
                case true:
                    mistakeHighlighting = true;
                    break;
                case false:
                    mistakeHighlighting = false;
                    break;
            }
        }

        private void radEasy_CheckedChanged(object sender, EventArgs e)     //Makes it so I can easily add new puzzles in the future by automatically setting the max value
        {                                                                   // of nudPuzzleNum
            if (radEasy.Checked)
            {
                nudPuzzleNum.Maximum = File.ReadLines("puzzles_easy.txt").ToArray().Length / 19;
            }
        }

        private void radMedium_CheckedChanged(object sender, EventArgs e)
        {
            if (radMedium.Checked)
            {
                nudPuzzleNum.Maximum = File.ReadLines("puzzles_medium.txt").ToArray().Length / 19;
            }
        }

        private void radHard_CheckedChanged(object sender, EventArgs e)
        {
            if (radHard.Checked)
            {
                nudPuzzleNum.Maximum = File.ReadLines("puzzles_hard.txt").ToArray().Length / 19;
            }
        }
    }
}
