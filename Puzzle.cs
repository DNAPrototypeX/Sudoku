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
        string[,] puzzle = new string[9, 9];
        string[,] solution = new string[9, 9];
        string puzzlesFile;
        public void initializePuzzle(Menu menu, frmMain game)
        {
            switch (menu.difficulty)
            {
                case 1:
                    puzzlesFile = "puzzles_easy.txt";
                    break;
                case 2:
                    puzzlesFile = "puzzles_medium.txt";
                    break;
                case 3:
                    puzzlesFile = "puzzles_hard.txt";
                    break;
            }
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    puzzle[i, j] = File.ReadLines(puzzlesFile).ElementAt(j).ElementAt(i).ToString();
                    solution[i, j] = File.ReadLines(puzzlesFile).ElementAt(j + (menu.puzzleNum * 10)).ElementAt(i).ToString();
                    if (puzzle[i, j] != "0")
                    {
                        game.tiles[i, j].Text = puzzle[i, j];
                        game.tiles[i, j].given = true;
                        game.tiles[i, j].ForeColor = Color.Black;
                    }
                }
            game.solution = solution;
        }
    }
}
