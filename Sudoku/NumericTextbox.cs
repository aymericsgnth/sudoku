using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    internal class NumericTextbox : TextBox
    {
        public NumericTextbox()
        {
            Size = new System.Drawing.Size(58, 58);
            MaxLength = 1;
            Font = new System.Drawing.Font(Font.FontFamily, 34);
            KeyPress += OnKeyPressOnNumericTextbox;
            GotFocus += OnFocus;
        }
        private int _row;
        private int _col;

        public int Row { get => _row; set => _row = value; }
        public int Col { get => _col; set => _col = value; }


        /// <summary>
        /// Fired when a key is pressed in an input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnKeyPressOnNumericTextbox(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ((char)Keys.Back))
            {
                // prevent
                e.Handled = true;
                return;
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                return;
            }
            int numberEnter = Convert.ToInt32(e.KeyChar.ToString());
            if (numberEnter < 0 || numberEnter > 10)
            {
                e.Handled = true;
                return;
            }

            NumericTextbox numericTextbox = (NumericTextbox)sender;

            int row = numericTextbox.Row;
            int col = numericTextbox.Col;
            // get parent frm
            GridPreview gridView = GetGridView();
            IErrorMessager parentFrm = (IErrorMessager)gridView.Parent;

            if (GridChecker.ValueIsInRow(gridView.GetGrid(), row, numberEnter.ToString()))
            {
                e.Handled = true;
                parentFrm.ShowErrorMessage($"The number {numberEnter} is already in the row");
                return;
            }
            // if the number is in column
            if (GridChecker.ValueIsInColumn(gridView.GetGrid(), col, numberEnter.ToString()))
            {
                e.Handled = true;
                parentFrm.ShowErrorMessage($"The number {numberEnter} is already in the column");
                return;
            }
            // check if in the square
            if (GridChecker.ValueInSquare(gridView.GetGrid(), row, col, numberEnter.ToString()))
            {
                e.Handled = true;
                parentFrm.ShowErrorMessage($"The number {numberEnter} is already in the square");
                return;
            }
            parentFrm.HideErrorMessage();
        }

        /// <summary>
        /// Fired when NumericTextbox has focus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFocus(object sender, EventArgs e)
        {
            NumericTextbox numericTextbox = (NumericTextbox)sender;
            if (numericTextbox.Text == " ")
            {
                numericTextbox.Text = "";
            }
        }

        private GridPreview GetGridView()
        {
            return (GridPreview)Parent.Parent.Parent;
        }

        


    }
}
