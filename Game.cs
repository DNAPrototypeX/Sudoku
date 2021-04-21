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
        TileLabel[,] tiles = new TileLabel[9, 9];
        string[] numButtons = new string[10];
        string[,] solution = new string[9, 9];
        string[,] puzzle = new string[9, 9];
        string[] puzzleToSave = new string[10];
        string[] gameToSave = new string[9];
        string[,] gameToLoad = new string[9, 9];
        string[] solutionToSave = new string[10];
        Menu menu;
        bool mistakeHighlighting;
        Color playerColor = Color.Blue;

        public TileLabel[,] getTilesArray()
        {
            return tiles;
        }
        private void clearAllTiles()
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (!tiles[i, j].given)
                    {
                        tiles[i, j].Text = "";
                        tiles[i, j].ForeColor = playerColor;
                    }
                    else
                        tiles[i, j].ForeColor = Color.Black;
                }
        }
        private void selectTile(TileLabel tile)
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

        private void matchHintandTileColor()
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    for (int k = 0; k < 9; k++)
                    {
                        tiles[i, j].hintsLabel[k].BackColor = tiles[i, j].BackColor;
                    }
                }
        }

        private void higlightTiles(object sender, Color color)
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
                                    tiles[i, k].BackColor = color;
                                    for (int a = 0; a < 9; a++)
                                        tiles[i, k].hintsLabel[a].BackColor = color;
                                }
                                if (!tiles[k, j].selected)
                                {
                                    tiles[k, j].BackColor = color;
                                    for (int a = 0; a < 9; a++)
                                        tiles[k, j].hintsLabel[a].BackColor = color;
                                }
                            }
                            for (int l = 0; l < 9; l++)
                                for (int m = 0; m < 9; m++)
                                {
                                    if (l / 3 == i / 3 & m / 3 == j / 3 & !tiles[l, m].selected)
                                    {
                                        tiles[l, m].BackColor = color;
                                        for (int a = 0; a < 9; a++)
                                            tiles[l, m].hintsLabel[a].BackColor = color;
                                    }
                                }
                        }
                    }
            }
            else
                counter = 0;
        }

        private void handleMistakeHighlighting(int i, int j, bool isHighlighting)
        {
            if (mistakeHighlighting)
            {
                Color givenNumColor = Color.Black;
                Color playerNumColor = Color.Black;
                switch (isHighlighting)
                {
                    case true:
                        givenNumColor = Color.DarkRed;
                        playerNumColor = Color.Red;
                        break;
                    case false:
                        givenNumColor = Color.Black;
                        playerNumColor = playerColor;
                        break;
                }

                for (int k = 0; k < 9; k++)
                {
                    if (tiles[i, j].Text == tiles[i, k].Text & tiles[i, k].Text != "" & j != k)
                    {
                        tiles[i, j].ForeColor = playerNumColor;
                        if (tiles[i, k].given)
                            tiles[i, k].ForeColor = givenNumColor;
                        else
                            tiles[i, k].ForeColor = playerNumColor;
                    }

                    if (tiles[i, j].Text == tiles[k, j].Text & tiles[k, j].Text != "" & i != k)
                    {
                        tiles[i, j].ForeColor = playerNumColor;
                        if (tiles[k, j].given)
                            tiles[k, j].ForeColor = givenNumColor;
                        else
                            tiles[k, j].ForeColor = playerNumColor;
                    }
                }

                for (int l = 0; l < 9; l++)
                    for (int m = 0; m < 9; m++)
                    {
                        if (l / 3 == i / 3 & m / 3 == j / 3 & tiles[i, j].Text == tiles[l, m].Text & tiles[l, m].Text != "" & l != i & m != j)
                        {
                            if (tiles[l, m].given)
                                tiles[l, m].ForeColor = givenNumColor;
                            else
                                tiles[l, m].ForeColor = playerNumColor;
                            tiles[i, j].ForeColor = playerNumColor;
                        }
                    }
            }
            
        }

        private void toggleHint(string key, int i, int j, int k)
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

        private void checkForWin()
        {
            int counter = 0;
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    if (tiles[i, j].Text != solution[i, j])
                        counter += 1;

            if (counter == 0)
                for (int i = 0; i < 9; i++)
                    for (int j = 0; j < 9; j++)
                    {
                        tiles[i, j].BackColor = Color.Green;
                        tiles[i, j].Enabled = false;
                    }
        }
        private void saveGame()
        {
            solutionToSave[0] = "";
            puzzleToSave[0] = "";
            File.WriteAllText("saved_game.txt", "");
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    solutionToSave[i + 1] += solution[j, i];
                    gameToSave[i] += tiles[j, i].Text;
                    if (tiles[j, i].Text == "")
                        gameToSave[i] += "0";
                    if (tiles[j, i].given)
                        puzzleToSave[i + 1] += tiles[j, i].Text;
                    else
                        puzzleToSave[i + 1] += "0";
                }
            }
            File.AppendAllLines("saved_game.txt", gameToSave);
            File.AppendAllLines("saved_game.txt", puzzleToSave);
            File.AppendAllLines("saved_game.txt", solutionToSave);
        }
        private void loadGame()
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    tiles[i, j].given = false;
                    gameToLoad[i, j] = File.ReadLines("saved_game.txt").ElementAt(j).ElementAt(i).ToString();
                    puzzle[i, j] = File.ReadLines("saved_game.txt").ElementAt(j + 10).ElementAt(i).ToString();
                    solution[i, j] = File.ReadLines("saved_game.txt").ElementAt(j + 20).ElementAt(i).ToString();
                    if (puzzle[i, j] != "0")
                    {
                        tiles[i, j].Text = puzzle[i, j];
                        tiles[i, j].given = true;
                        tiles[i, j].ForeColor = Color.Black;
                    }
                    else
                        tiles[i, j].Text = "";
                    if (!tiles[i, j].given & gameToLoad[i, j] != "0")
                        tiles[i, j].Text = gameToLoad[i, j];
                }
        }

        private void resetSaveArrays()
        {
            for (int i = 0; i < 9; i++)
            {
                gameToSave[i] = "";
                puzzleToSave[i + 1] = "";
                solutionToSave[i + 1] = "";
            }
        }

        public frmMain(Menu frmMenu, string[,] puzzleSolution, bool toggleMistakeHighlighting)
        {
            InitializeComponent();
            mistakeHighlighting = toggleMistakeHighlighting;
            menu = frmMenu;
            solution = puzzleSolution;
        }

        private void tile_MouseEnter(object sender, System.EventArgs e)
        {
            higlightTiles(sender, Color.Yellow);
        }
        private void tile_MouseLeave(object sender, System.EventArgs e)
        {
            higlightTiles(sender, Color.White);
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
                selectTile(tile);
            }
            else
            {
                tile.selected = false;
                tile.BackColor = Color.Yellow;
            }
            matchHintandTileColor();
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
            if (File.ReadAllText("saved_game.txt") != "")
                btnLoad.Enabled = true;
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            string key = e.KeyCode.ToString();
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
                                    toggleHint(key, i, j, k);
                                }
                                else if (key == numButtons[9] & !tiles[i, j].given)
                                {
                                    handleMistakeHighlighting(i, j, false);
                                    tiles[i, j].Text = "";
                                    for (int l = 0; l < 9; l++)
                                        tiles[i, j].hintsLabel[l].Visible = true;
                                }
                                else if (!tiles[i, j].given)
                                {
                                    handleMistakeHighlighting(i, j, false);
                                    tiles[i, j].Text = key.Remove(0, 1);
                                    handleMistakeHighlighting(i, j, true);
                                    for (int l = 0; l < 9; l++)
                                        tiles[i, j].hintsLabel[l].Visible = false;
                                }
                            }
                    }
                }                     
            checkForWin();      
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            menu.Visible = true;          
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clearAllTiles();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            resetSaveArrays();
            saveGame();
            btnLoad.Enabled = true;
            btnDelSave.Enabled = true;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            loadGame();
        }

        private void btnDelSave_Click(object sender, EventArgs e)
        {
            File.WriteAllText("saved_game.txt", "");
            btnLoad.Enabled = false;
            btnDelSave.Enabled = false;
        }

        private void btnApplyColour_Click(object sender, EventArgs e)
        {
            playerColor = Color.FromArgb(trkR.Value, trkG.Value, trkB.Value);
            for (int i = 0; i < 9; i++)
                for(int j = 0; j < 9; j++)
                {
                    if (!tiles[i, j].given)
                        tiles[i, j].ForeColor = playerColor;
                }
        }

        private void trkR_ValueChanged(object sender, EventArgs e)
        {
            btnApplyColour.BackColor = Color.FromArgb(trkR.Value, trkG.Value, trkB.Value);
        }

        private void trkG_ValueChanged(object sender, EventArgs e)
        {
            btnApplyColour.BackColor = Color.FromArgb(trkR.Value, trkG.Value, trkB.Value);
        }

        private void trkB_ValueChanged(object sender, EventArgs e)
        {
            btnApplyColour.BackColor = Color.FromArgb(trkR.Value, trkG.Value, trkB.Value);
        }
    }
}
