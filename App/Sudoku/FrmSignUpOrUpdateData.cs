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
     * Sign up or update data form
     * V1
     */
    public partial class FrmSignUpOrUpdateData : Form
    {
        public FrmSignUpOrUpdateData()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This method is fired when btnCancel is clicked
        /// Close the modal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickOnbtnCancel(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// This method is fired when the value of any of the textboxs changed
        /// Checks that all the textboxs have a value and that the two passwords are the same. If it's the case, the btnConfirm is enabled, otherwise the btnConfirm is disabled
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTextChangedOnTextboxs(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tbxPseudo.Text) || String.IsNullOrWhiteSpace(tbxPassword.Text) || String.IsNullOrWhiteSpace(tbxPasswordConfirm.Text))
            {
                btnConfirm.Enabled = false;
                return;
            }
            if(tbxPassword.Text != tbxPasswordConfirm.Text)
            {
                lblPasswordsAreDifferents.Visible = true;
                btnConfirm.Enabled = false;
                return;
            }
            lblPasswordsAreDifferents.Visible = false;
            btnConfirm.Enabled = true;

        }
    }
}
