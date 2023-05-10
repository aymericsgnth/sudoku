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
    public partial class FrmGridCreation : Form
    {
        private const ButtonBorderStyle BORDER_BBS = ButtonBorderStyle.Solid;
        private readonly Color BORDER_COLOR = Color.Black;
        private const int BORDER_THICKNESS = 2;
        private static readonly int[] NUMBERS = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        public FrmGridCreation()
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
        
        /// <summary>
        /// Get grid as array
        /// </summary>
        /// <returns>the grid</returns>
        public string[][] GetGrid()
        {
            // good look for understanding this instruction ;)
            List<NumericTextbox> items =  grbGrid.Controls.OfType<Panel>().Select(panel => panel.Controls.OfType<NumericTextbox>()).ToList().SelectMany(listOfNtxb => listOfNtxb).ToList();
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

        /// <summary>
        /// Show an error message
        /// </summary>
        /// <param name="message"></param>
        public void ShowErrorMessage(string message)
        {
            lblError.Text = message;
            lblError.Visible = true;
        }

        /// <summary>
        /// Hide error message
        /// </summary>
        public void HideErrorMessage()
        {
            lblError.Visible = false;
        }
        /// <summary>
        /// Fired when btnCancel is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickOnBtnCancel(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// Fired when btnOk is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickOnBtnOK(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Check if a value is in a specific row
        /// </summary>
        /// <param name="row"></param>
        /// <param name="value"></param>
        /// <returns>True if value is in row, false otherwise</returns>
        public bool ValueIsInRow(int row, string value)
        {
            string[][] grid = GetGrid();
            return grid[row].Contains(value);
        }

        /// <summary>
        /// Check if a specific value is in a specific column
        /// </summary>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns>True if the value is in the column, false otherwise</returns>
        public bool ValueIsInColumn(int column, string value)
        {
            string[][] grid = GetGrid();
            return grid.Select(gridraw => gridraw.Where(gridCol => Array.IndexOf(gridraw, gridCol) == column).ElementAtOrDefault(0)).ToList().Contains(value);
        }

        /// <summary>
        /// Check if the value is in a specific square
        /// </summary>
        /// <param name="rowOfValue"></param>
        /// <param name="columnOfValue"></param>
        /// <param name="value"></param>
        /// <returns>True if the value is in a specific square, false otherwise</returns>
        public bool ValueInSquare(int rowOfValue, int columnOfValue, string value)
        {
            string[][] grid = GetGrid();
            int[] rowsToGet = NUMBERS.Skip(rowOfValue - rowOfValue % 3).Take(3).ToArray();

            int[] colsToTake = NUMBERS.Skip(columnOfValue - columnOfValue % 3).Take(3).ToArray();
            // check if in the square
            for (int i = 0; i < grid.Length; i++)
            {
                if (rowsToGet.Contains(i))
                {
                    string[] gridRow = grid[i];
                    for (int j = 0; j < gridRow.Length; j++)
                    {
                        if (colsToTake.Contains(j) && grid[i][j] == value)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }


    }
}
