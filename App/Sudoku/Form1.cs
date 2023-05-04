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
    /*
     * Aymeric Siegenthaler
     * 3B
     * 03.05.2023
     * Home form
     * V1
     */
    public partial class FrmHome : Form
    {
        FrmSignUpOrUpdateData frmSignUpOrUpdateData = null;
        public FrmHome()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Fired when btnSignUpOrUpdateData is clicked
        /// Show 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickOnbtnSignUpOrUpdateData(object sender, EventArgs e)
        {
            frmSignUpOrUpdateData = new FrmSignUpOrUpdateData();
            frmSignUpOrUpdateData.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }

}
