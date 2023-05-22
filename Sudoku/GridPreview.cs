using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class GridView : UserControl
    {
        private const ButtonBorderStyle BORDER_BBS = ButtonBorderStyle.Solid;
        private readonly Color BORDER_COLOR = Color.Black;
        private const int BORDER_THICKNESS = 4;
        public GridView()
        {
            InitializeComponent();
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

        public void ShowGrid(string[][] grid)
        {

            List<NumericTextbox> items = grbGrid.Controls.OfType<Panel>().Select(panel => panel.Controls.OfType<NumericTextbox>()).ToList().SelectMany(listOfNtxb => listOfNtxb).ToList();
            foreach (NumericTextbox ntbx in items)
            {
                ntbx.Text = grid[ntbx.Row][ntbx.Col];
            }
        }

        public string[][] GetGrid()
        {
            // good look for understanding this instruction ;)
            List<NumericTextbox> items = grbGrid.Controls.OfType<Panel>().Select(panel => panel.Controls.OfType<NumericTextbox>()).SelectMany(listOfNtxb => listOfNtxb).ToList();
            string[][] grid = new string[9][];
            foreach (NumericTextbox ntbx in items)
            {
                if (grid[ntbx.Row] == null)
                {
                    grid[ntbx.Row] = new string[9];
                }
                grid[ntbx.Row][ntbx.Col] = ntbx.Text;
            }
           
            return grid;
        }
        public ControlCollection GetControls()
        {
            return grbGrid.Controls;
        }

        


    }
}
