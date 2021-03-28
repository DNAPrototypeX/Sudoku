using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class Menu : Form
    {
        public int difficulty;
        public int puzzleNum;
        frmMain game = new frmMain();
        Puzzle puzzle = new Puzzle();
        public Menu()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (radEasy.Checked)
                difficulty = 1;
            else if (radMedium.Checked)
                difficulty = 2;
            else
                difficulty = 3;
            puzzleNum = (int)nudPuzzleNum.Value;
            game.Visible = true;
            game.menu = this;
            puzzle.initializePuzzle(this, game);
            this.Hide();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
        }
    }
}
