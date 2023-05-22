using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class FrmGame : Form, IErrorMessager
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="gridData"></param>
        /// <param name="grid">The grid of the sudoku</param>
        public FrmGame(Dictionary<string, string> gridData, string[][] grid)
        {
            InitializeComponent();
            userCtrlGridPreview.ShowGrid(grid);
            userCtrlGridPreview.GetControls().OfType<Panel>().ToList().ForEach(pnl => pnl.Controls.OfType<NumericTextbox>().ToList().ForEach(nmtbx => nmtbx.TextChanged += NumericTextboxTextChanged));
        }

        public void HideErrorMessage()
        {
            lblError.Visible = false;
        }

        public void ShowErrorMessage(string message)
        {
            lblError.Text = message;
            lblError.Visible = true;
        }
        /// <summary>
        /// Fired when a numericTextbox has changed (text prop)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void NumericTextboxTextChanged(object sender, EventArgs e)
        {
            btnDone.Enabled = !userCtrlGridPreview.GetControls().OfType<Panel>().SelectMany(pnl => pnl.Controls.OfType<NumericTextbox>().Select(nmtbx => nmtbx.Text)).Intersect(new string[] { "", " " }).Any();
        }


    }
}
