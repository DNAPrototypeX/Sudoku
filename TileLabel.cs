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
        public Label[] hintsLabel;
        public bool selected;
        public TileLabel(int x, int y, Form board) : base()
        {            
            this.Location = new Point(5 + (55 * x), 5 + (55 * y));
            this.Size = new Size(50, 50);
            this.AutoSize = false;
            this.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Font = new Font("Microsoft Sans Serif", 28, FontStyle.Regular);
            this.ForeColor = Color.FromArgb(64, 64, 64);
            selected = false;
            hintsLabel = new Label[9];            
            for (int i = 0; i < 9; i++)
            {
                hintsLabel[i] = new Label();
                board.Controls.Add(hintsLabel[i]);
                hintsLabel[i].Location = new Point((i % 3) * 17 + this.Location.X
                    , (i / 3) * 17 + this.Location.Y);
                hintsLabel[i].Size = new Size(17, 17);
                hintsLabel[i].Visible = false;
                hintsLabel[i].Enabled = false;
                hintsLabel[i].AutoSize = false;
                hintsLabel[i].Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
                hintsLabel[i].ForeColor = Color.Black;
            }                       
        }
    }
}
