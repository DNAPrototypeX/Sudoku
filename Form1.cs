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
    public partial class frmMain : Form
    {
        TileLabel[,] tiles = new TileLabel[9, 9];         
        public frmMain()
        {
            InitializeComponent();
        }

        private void tile_MouseEnter(object sender, System.EventArgs e)
        {
            var tile = (TileLabel)sender;
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (tiles[i, j] == tile)
                    {
                        for (int k = 0; k < 9; k++)
                        {
                            tiles[i, k].BackColor = Color.Yellow;
                            tiles[k, j].BackColor = Color.Yellow;
                        }
                        for (int l = 0; l < 9; l++)
                            for (int m = 0; m < 9; m++)
                            {
                                if (l / 3 == i / 3 & m / 3 == j / 3)
                                    tiles[l, m].BackColor = Color.Yellow;
                            }
                    }
                }
            
        }
        private void tile_MouseLeave(object sender, System.EventArgs e)
        {
            var tile = (TileLabel)sender;
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (tiles[i, j] == tile)
                    {
                        for (int k = 0; k < 9; k++)
                        {
                            tiles[i, k].BackColor = Color.White;
                            tiles[k, j].BackColor = Color.White;
                        }
                        for (int l = 0; l < 9; l++)
                            for (int m = 0; m < 9; m++)
                            {
                                if (l / 3 == i / 3 & m / 3 == j / 3)
                                    tiles[l, m].BackColor = Color.White;
                            }
                    }
                }
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    tiles[i, j] = new TileLabel(i, j, this);
                    this.Controls.Add(tiles[i, j]);
                    tiles[i, j].MouseEnter += new EventHandler(tile_MouseEnter);
                    tiles[i, j].MouseLeave += new EventHandler(tile_MouseLeave);
                }
        }
    }
}
