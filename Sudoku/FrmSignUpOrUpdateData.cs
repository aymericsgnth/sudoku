using MySqlConnector;
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
     * 3B
     * 03.05.2023
     * Sign up or update data form
     * V1
     */
    public partial class FrmSignUpOrUpdateData : Form
    {
        public FrmSignUpOrUpdateData(Types type)
        {
            InitializeComponent();
            this.type = type;
            if (type == Types.Update)
            {
                lblTitle.Text = "Update data";
            }
        }
         public enum Types
        {
            Insertion, 
            Update
        };

        private Types type;

        private List<string> unavailableNicknames = new List<string>();



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

        private void OnClickOnbtnOK(object sender, EventArgs e)
        {
            if (type == Types.Insertion)
            {
                insertUser(e);
            }
            else
            {
                UpdateUser();
            }
        }

        /// <summary>
        /// This method is fired when the value of any of the textboxs changed
        /// Checks that all the textboxs have a value and that the two passwords are the same. If it's the case, the btnConfirm is enabled, otherwise the btnConfirm is disabled
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTextChangedOnTextboxs(object sender, EventArgs e)
        {
            string nickname = tbxPseudo.Text;
            if (String.IsNullOrWhiteSpace(tbxPseudo.Text) || String.IsNullOrWhiteSpace(tbxPassword.Text) || String.IsNullOrWhiteSpace(tbxPasswordConfirm.Text))
            {
                btnConfirm.Enabled = false;
                return;
            }
            // password are not the same
            if(tbxPassword.Text != tbxPasswordConfirm.Text)
            {
                ShowErrorMessage("Passwords are differents");
                btnConfirm.Enabled = false;
                return;
            }
            if (unavailableNicknames.Contains(nickname))
            {
                ShowErrorMessage("The nickname is already taken");
                btnConfirm.Enabled = false;
                return;
            }
            lblError.Visible = false;
            btnConfirm.Enabled = true;

        }
        /// <summary>
        /// Insert user to database
        /// </summary>
        private void insertUser(EventArgs ev)
        {
            string nickname = tbxPseudo.Text;
            string password = tbxPassword.Text;
            string query = "INSERT INTO user(sNickname, sPassword) VALUES(@nickname, @password)";
            Dictionary<string, string> sqlParams = new Dictionary<string, string>
            {
                {
                    "@nickname", 
                    nickname 
                },
                {
                    "@password",
                    // hash password
                    SecretHasher.Hash(password)
                }
            };
            DB db = new DB();
            try {
                db.Query(query, sqlParams, true);
                Globals.UserId = Convert.ToInt32(db.Query("SELECT LAST_INSERT_ID() as userId")[0]["userId"]);
                Globals.Connected = true;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch(MySqlException e)
            {
                // nickname already exists
                if(e.ErrorCode.ToString() == "DuplicateKeyEntry")
                {
                    ShowErrorMessage("The nickname is already took");
                    unavailableNicknames.Add(nickname);
                    return;
                }
                // throw exception
                throw;

            }

        }

        private void UpdateUser()
        {
            string nickname = tbxPseudo.Text;
            string password = tbxPassword.Text;
            string sqlQuery = @"UPDATE user
                                SET sNickname = @pseudo,
                                    sPassword = @password
                              WHERE iUserCode = @userId";
            Dictionary<string, string> sqlParams = new Dictionary<string, string>
            {
                {"@pseudo", nickname },
                {"@password", SecretHasher.Hash(password) },
                {"@userId", Globals.UserId.ToString() }
            };
            try
            {
                new DB().Query(sqlQuery, sqlParams);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (MySqlException e)
            {
                // nickname already exists
                if (e.ErrorCode.ToString() == "DuplicateKeyEntry")
                {
                    ShowErrorMessage("The nickname is already took");
                    unavailableNicknames.Add(nickname);
                    return;
                }
                // throw exception
                throw;
            }
        }

        /// <summary>
        /// Show an error message
        /// </summary>
        /// <param name="message"></param>
        private void ShowErrorMessage(string message)
        {
            lblError.Text = message;
            lblError.Visible = true;
        }
    }
}
