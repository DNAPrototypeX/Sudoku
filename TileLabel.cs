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
        public bool given;
        private void hintLabel_MouseEnter(object sender, System.EventArgs e)
        {
            OnMouseEnter(e);
        }

        private void hintLabel_MouseLeave(object sender, System.EventArgs e)
        {
            OnMouseLeave(e);
        }

        private void hintLabel_Click(object sender, System.EventArgs e)
        {
            OnClick(e);
        }
        public TileLabel(int x, int y, Form board) : base()
        {            
            Location = new Point(5 + (55 * x), 5 + (55 * y));
            Size = new Size(50, 50);
            AutoSize = false;
            TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Font = new Font("Microsoft Sans Serif", 28, FontStyle.Regular);
            ForeColor = Color.FromArgb(64, 64, 64);
            selected = false;
            given = false;
            hintsLabel = new Label[9];            
            for (int i = 0; i < 9; i++)
            {               
                hintsLabel[i] = new Label();
                board.Controls.Add(hintsLabel[i]);
                hintsLabel[i].Parent = this;
                hintsLabel[i].Location = new Point((i % 3) * 17, (i / 3) * 17);
                hintsLabel[i].Size = new Size(17, 17);
                hintsLabel[i].Visible = false;
                hintsLabel[i].AutoSize = false;
                hintsLabel[i].Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
                hintsLabel[i].ForeColor = Color.Black;
                hintsLabel[i].MouseEnter += new EventHandler(hintLabel_MouseEnter);
                hintsLabel[i].MouseLeave += new EventHandler(hintLabel_MouseLeave);
                hintsLabel[i].Click += new EventHandler(hintLabel_Click);
            }                       
        }
    }
}
