using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class GridPreview : UserControl
    {
        private const ButtonBorderStyle BORDER_BBS = ButtonBorderStyle.Solid;
        private readonly Color BORDER_COLOR = Color.Black;
        private const int BORDER_THICKNESS = 4;
        private const int ARRAY_LENGTH = 9;
        public GridPreview(string[][] grid)
        {
            InitializeComponent();
            ShowGrid(grid);
        }

        /// <summary>
        /// Paint the border on square
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPaintOnPanels(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            ControlPaint.DrawBorder(e.Graphics, panel.ClientRectangle,
                BORDER_COLOR, BORDER_THICKNESS, BORDER_BBS,
                BORDER_COLOR, BORDER_THICKNESS, BORDER_BBS,
                BORDER_COLOR, BORDER_THICKNESS, BORDER_BBS,
                BORDER_COLOR, BORDER_THICKNESS, BORDER_BBS
                );
        }

        private void ShowGrid(string[][] grid)
        {

            List<NumericTextbox> items = grbGrid.Controls.OfType<Panel>().Select(panel => panel.Controls.OfType<NumericTextbox>()).ToList().SelectMany(listOfNtxb => listOfNtxb).ToList();
            foreach (NumericTextbox ntbx in items)
            {
                ntbx.Text = grid[ntbx.Row][ntbx.Col];
            }
        }


    }
}
