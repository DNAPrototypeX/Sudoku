using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    class TileLabel: Label
    {
        private bool[] hintsBool;
        public Label[] hintsLabel;
        private bool selected;
        public TileLabel(int x, int y, Form board) : base()
        {            
            this.Location = new Point(5 + (55 * x), 5 + (55 * y));
            this.Size = new Size(50, 50);
            selected = false;
            hintsBool = new bool[9];
            hintsLabel = new Label[9];            
            for (int i = 0; i < 9; i++)
            {
                hintsLabel[i] = new Label();
                board.Controls.Add(hintsLabel[i]);
                hintsLabel[i].Location = new Point((i % 3) * 17 + this.Location.X + 5
                    , (i / 3) * 17 + this.Location.Y + 5);
                hintsLabel[i].BackColor = Color.Red;
                hintsLabel[i].Size = new Size(5, 5);
                hintsLabel[i].Visible = false;
            }                       
        }
    }
}
