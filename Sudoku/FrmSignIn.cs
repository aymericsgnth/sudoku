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
    /*
     * Aymeric Siegenthaler
     * 2b
     * 04.05.2023
     * FrmSignIn
     * V1
     */
    public partial class FrmSignIn : Form
    {
        public FrmSignIn()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Fired onclick on button cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickOnbtnCancel(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// Fired on textChanged on any textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTextChangedOnTextboxs(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tbxNickname.Text) || String.IsNullOrWhiteSpace(tbxPassword.Text))
            {
                btnOK.Enabled = false;
                return;
            }
            btnOK.Enabled = true;
        }
        /// <summary>
        /// fired when btnOK is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickOnbtnOK(object sender, EventArgs e)
        {
            string nickname = tbxNickname.Text;
            string password = tbxPassword.Text;
            CredentialsAreCorrects(nickname, password);
        }
        /// <summary>
        /// Check if credentials are valid
        /// </summary>
        /// <param name="nickname"></param>
        /// <param name="password"></param>
        /// <returns>bool</returns>
        private bool CredentialsAreCorrects(string nickname, string password)
        {
            string query = "SELECT sNickname, sPassword from user where sNickname = @nickname";
            Dictionary<string, string> sqlParams = new Dictionary<string, string>
            {
                {"@nickname", nickname},
            };
            DB db = new DB();
            List<Dictionary<string, string>> output = db.Query(query, sqlParams);
            if (output.Count == 0)
            {
                return false;
            }

            Dictionary<string, string> user = output[0];
            return SecretHasher.Verify(password, user["sPassword"]);
            
        }
    }
}
