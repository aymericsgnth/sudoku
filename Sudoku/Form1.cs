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
        FrmSignIn FrmSignIn = null;
        FrmGridCreation gridCreation = null;
        bool connected = false;
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
            frmSignUpOrUpdateData = new FrmSignUpOrUpdateData(FrmSignUpOrUpdateData.Types.Insertion);
            if (frmSignUpOrUpdateData.ShowDialog() == DialogResult.OK)
            {
                UserIsNowConnected();
            }

        }
        /// <summary>
        /// Fired when btnSignIn is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickOnbtnSignIn(object sender, EventArgs e)
        {
            FrmSignIn = new FrmSignIn();
            if (FrmSignIn.ShowDialog() == DialogResult.OK)
            {
                UserIsNowConnected();
            }
        }
        /// <summary>
        /// Fired when btnCreateGrid is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickOnbtnCreateGrid(object sender, EventArgs e)
        {
            gridCreation = new FrmGridCreation();
            gridCreation.ShowDialog();
        }
        /// <summary>
        /// This function is called when user is connected
        /// </summary>
        private void UserIsNowConnected()
        {
            connected = true;
            btnCreateGrid.Visible = true;

        }
       

        
    }

}
