using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace Sudoku
{
    class Puzzle
    {
        string[,] puzzle;
        string[,] solution;
        string puzzlesFile;
        TileLabel[,] tiles;
        public Puzzle()
        {
            puzzle = new string[9, 9];
            solution = new string[9, 9];           
        }


        public void initializePuzzle(Menu menu, frmMain game, Difficulty difficulty, int puzzleNum)
        {
            tiles  = game.getTilesArray();

            switch (difficulty)
            {
                case Difficulty.Easy:
                    puzzlesFile = "puzzles_easy.txt";
                    break;
                case Difficulty.Medium:
                    puzzlesFile = "puzzles_medium.txt";
                    break;
                case Difficulty.Hard:
                    puzzlesFile = "puzzles_hard.txt";
                    break;
            }

            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    puzzle[i, j] = File.ReadLines(puzzlesFile).ElementAt(j + (puzzleNum * 20)).ElementAt(i).ToString();
                    solution[i, j] = File.ReadLines(puzzlesFile).ElementAt(j + (puzzleNum * 20) + 10).ElementAt(i).ToString();
                    if (puzzle[i, j] != "0")
                    {
                        tiles[i, j].Text = puzzle[i, j];
                        tiles[i, j].given = true;
                        tiles[i, j].ForeColor = Color.Black;
                    }
                    else
                        tiles[i, j].Text = "";
                }
        }

        public string[,] getSolution()
        {
            return solution;
        } 
    }
}
