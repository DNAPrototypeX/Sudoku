using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Sudoku
{
    public partial class frmMain : Form
    {
        public TileLabel[,] tiles = new TileLabel[9, 9];
        string[] numButtons = new string[10];
        public string[,] solution = new string[9, 9];
        public Menu menu;
        public frmMain()
        {
            InitializeComponent();
        }

        private void tile_MouseEnter(object sender, System.EventArgs e)
        {
            var tile = (TileLabel)sender;
            int counter = 0;
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (tiles[i, j].selected)
                        counter += 1;
                }
            if (counter == 0)
            {
                for (int i = 0; i < 9; i++)
                    for (int j = 0; j < 9; j++)
                    {
                        if (tiles[i, j] == tile)
                        {
                            for (int k = 0; k < 9; k++)
                            {
                                if (!tiles[i, k].selected)
                                {
                                    tiles[i, k].BackColor = Color.Yellow;
                                    for (int a = 0; a < 9; a++)
                                        tiles[i, k].hintsLabel[a].BackColor = Color.Yellow;
                                }
                                if (!tiles[k, j].selected)
                                {
                                    tiles[k, j].BackColor = Color.Yellow;
                                    for (int a = 0; a < 9; a++)
                                        tiles[k, j].hintsLabel[a].BackColor = Color.Yellow;
                                }
                            }
                            for (int l = 0; l < 9; l++)
                                for (int m = 0; m < 9; m++)
                                {
                                    if (l / 3 == i / 3 & m / 3 == j / 3 & !tiles[l, m].selected)
                                    {
                                        tiles[l, m].BackColor = Color.Yellow;
                                        for (int a = 0; a < 9; a++)
                                            tiles[l, m].hintsLabel[a].BackColor = Color.Yellow;
                                    }
                                }
                        }
                    }
            }
            else
                counter = 0;
        }
        private void tile_MouseLeave(object sender, System.EventArgs e)
        {
            var tile = (TileLabel)sender;
            int counter = 0;
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (tiles[i, j].selected)
                        counter += 1;
                }
            if (counter == 0)
            {
                for (int i = 0; i < 9; i++)
                    for (int j = 0; j < 9; j++)
                    {
                        if (tiles[i, j] == tile)
                        {
                            for (int k = 0; k < 9; k++)
                            {
                                if (!tiles[i, k].selected)
                                {
                                    tiles[i, k].BackColor = Color.White;
                                    for (int a = 0; a < 9; a++)
                                        tiles[i, k].hintsLabel[a].BackColor = Color.White;
                                }
                                if (!tiles[k, j].selected)
                                {
                                    tiles[k, j].BackColor = Color.White;
                                    for (int a = 0; a < 9; a++)
                                        tiles[k, j].hintsLabel[a].BackColor = Color.White;
                                }
                            }
                            for (int l = 0; l < 9; l++)
                                for (int m = 0; m < 9; m++)
                                {
                                    if (l / 3 == i / 3 & m / 3 == j / 3 & !tiles[l, m].selected)
                                    {
                                        tiles[l, m].BackColor = Color.White;
                                        for (int a = 0; a < 9; a++)
                                            tiles[l, m].hintsLabel[a].BackColor = Color.White;
                                    }
                                }
                        }
                    }
            }
            else
                counter = 0;
        }
        private void tile_Click(object sender, System.EventArgs e)
        {
            var tile = (TileLabel)sender;
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    tiles[i, j].BackColor = Color.White;
                    if (tiles[i, j] != tile)
                    {
                        if (tiles[i, j].selected)
                        {
                            tiles[i, j].selected = false;
                        }                     
                    }

                }
            if (!tile.selected)
            {
                tile.selected = true;
                tile.BackColor = Color.Orange;
                for (int i = 0; i < 9; i++)
                    for (int j = 0; j < 9; j++)
                    {
                        if (tiles[i, j] == tile)
                        {
                            for (int k = 0; k < 9; k++)
                            {
                                if (!tiles[i, k].selected)
                                {
                                    tiles[i, k].BackColor = Color.Yellow;
                                }
                                if (!tiles[k, j].selected)
                                {
                                    tiles[k, j].BackColor = Color.Yellow;
                                }
                            }
                            for (int l = 0; l < 9; l++)
                                for (int m = 0; m < 9; m++)
                                {
                                    if (l / 3 == i / 3 & m / 3 == j / 3 & !tiles[l, m].selected)
                                    {
                                        tiles[l, m].BackColor = Color.Yellow;
                                    }

                                }
                        }
                    }
            }
            else
            {
                tile.selected = false;
                tile.BackColor = Color.Yellow;
            }    
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    for (int k = 0; k < 9; k++)
                    {
                        tiles[i, j].hintsLabel[k].BackColor = tiles[i, j].BackColor;
                    }
                }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                numButtons[i] = $"D{i + 1}";
                for (int j = 0; j < 9; j++)
                {
                    tiles[i, j] = new TileLabel(i, j, this);
                    this.Controls.Add(tiles[i, j]);
                    tiles[i, j].MouseEnter += new EventHandler(tile_MouseEnter);
                    tiles[i, j].MouseLeave += new EventHandler(tile_MouseLeave);
                    tiles[i, j].Click += new EventHandler(tile_Click);

                }
            }
            numButtons[9] = "Back";
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            string key = e.KeyCode.ToString();
            int counter = 0;
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (tiles[i, j].selected)
                    {
                        for (int k = 0; k < 10; k++)
                            if (numButtons[k] == key)
                            {
                                if (Control.ModifierKeys == Keys.Shift)
                                {
                                    if (tiles[i, j].Text == "")
                                    {
                                        if (tiles[i, j].hintsLabel[k].Text != key.Remove(0, 1))
                                        {
                                            tiles[i, j].hintsLabel[k].Visible = true;
                                            tiles[i, j].hintsLabel[k].Text = key.Remove(0, 1);
                                        }
                                        else
                                        {
                                            tiles[i, j].hintsLabel[k].Visible = false;
                                            tiles[i, j].hintsLabel[k].Text = "";
                                        }
                                    }
                                    else
                                        tiles[i, j].hintsLabel[k].Visible = false;
                                }
                                else if (key == numButtons[9] & !tiles[i, j].given)
                                {
                                    for (int a = 0; a < 9; a++)
                                        for (int b = 0; b < 9; b++)
                                            for (int c = b + 1; c < 9; c++)
                                            {
                                                if (tiles[a, b].Text == tiles[a, c].Text)
                                                {
                                                    tiles[a, b].ForeColor = Color.Black;
                                                    tiles[a, c].ForeColor = Color.Black;
                                                }
                                                if (tiles[b, a].Text == tiles[c, a].Text)
                                                {
                                                    tiles[b, a].ForeColor = Color.Black;
                                                    tiles[c, a].ForeColor = Color.Black;
                                                }
                                            }
                                    tiles[i, j].Text = "";
                                    for (int l = 0; l < 9; l++)
                                        tiles[i, j].hintsLabel[l].Visible = true;
                                }
                                else if (!tiles[i, j].given)
                                {
                                    tiles[i, j].Text = key.Remove(0, 1);
                                    for (int l = 0; l < 9; l++)
                                        tiles[i, j].hintsLabel[l].Visible = false;
                                }
                            }
                    }
                    

                    if (tiles[i, j].Text != solution[i, j])
                        counter += 1;
                }
            if (counter == 0)
                for (int i = 0; i < 9; i++)
                    for (int j = 0; j < 9; j++)
                    {
                        tiles[i, j].BackColor = Color.Green;
                        tiles[i, j].Enabled = false;
                    }
            else
                counter = 0;
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    for (int k = j + 1; k < 9; k++)
                    {
                        if (tiles[i, j].Text == tiles[i, k].Text & tiles[i, k].Text != "")
                        {
                            tiles[i, j].ForeColor = Color.Red;
                            tiles[i, k].ForeColor = Color.Red;
                        }
                        if (tiles[j, i].Text == tiles[k, i].Text & tiles[k, i].Text != "")
                        {
                            tiles[j, i].ForeColor = Color.Red;
                            tiles[k, i].ForeColor = Color.Red;
                        }
                    }

        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            menu.Visible = true;           
        }
    }
}
