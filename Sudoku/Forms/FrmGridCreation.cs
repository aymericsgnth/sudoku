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
    public partial class FrmGridCreation : Form, IErrorMessager
    {
        private enum Level
        {
            Easy = 0, 
            Medium = 1,
            Hard = 2,
        }
        public FrmGridCreation()
        {
            InitializeComponent();
            cmbLevel.SelectedIndex = 0;
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
            string[][] grid = userCtrlGrid.GetGrid();
            for (int i = 0; i < grid.Length; i++)
            {
                // if line empty
                if (grid[i].All(el => el == ""))
                {
                    ShowErrorMessage($"Please put at least one number on row {i+1}");
                    return;
                }
                // if column empty
                if (grid.Select(gridRow => gridRow[i]).All(el => el == ""))
                {
                    ShowErrorMessage($"Please put at least one number on column {i+1}");
                    return;
                }
            }

            string sqlQuery = "INSERT INTO grid(sGrid, iCreatorCode, iLevel) VALUES(@grid, @creatorCode, @level)";
            int level = (int)Enum.Parse(typeof(Level), cmbLevel.Text);
            // create SQL params
            Dictionary<string, string> sqlParams = new Dictionary<string, string>
            {
                {"@grid",  String.Join(String.Empty, grid.SelectMany(gridRow => gridRow.Select(gridCol => gridCol == "" ? " " : gridCol)))},
                {"@creatorCode", Globals.UserId.ToString()},
                {"@level", level.ToString() }
            };
           
            DB db = new DB();
            try
            {
                db.Query(sqlQuery, sqlParams);
            }
            catch (MySqlException exception)
            {
                // the grid already exists
                if (exception.ErrorCode.ToString() == "DuplicateKeyEntry")
                {
                    ShowErrorMessage("The grid already exists");
                    return;
                }
                throw;
                
            }
            DialogResult = DialogResult.OK;
            Close();
            

        }

        


    }
}
