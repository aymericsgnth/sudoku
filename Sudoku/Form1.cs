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
        private const int GRID_ONE_DIMENSION_LENGTH = 9;
        private const int PICTURE_BOX_SIDE_SIZE = 150;
        public FrmHome()
        {
            InitializeComponent();
            ShowGrids();

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
            if (gridCreation.ShowDialog() == DialogResult.OK)
            {
                ShowGrids();
            }
        }
        /// <summary>
        /// This function is called when user is connected
        /// </summary>
        private void UserIsNowConnected()
        {
            btnSignIn.Visible = false;
            btnSignUpOrUpdateData.Text = "Modify my account";
            btnCreateGrid.Visible = true;

        }
        /// <summary>
        /// Show grids with a custom "pagination"
        /// </summary>
        /// <param name="limit">The max number of rows to get</param>
        /// <param name="offset">The rows to ignore</param>
        private void ShowGrids(int limit = 10, int offset = 0)
        {
            flpnlGrids.Controls.Clear();
            //                                                                                                      limit & offset => pagination
            string sqlQuery = "SELECT iGridCode, sGrid, dCreatedAt, iLevel FROM grid order by dCreatedAt DESC LIMIT @limit OFFSET @offset";
            Dictionary<string, string> sqlParams = new Dictionary<string, string>
            {
                {"@limit", limit.ToString() },
                {"@offset", offset.ToString() }
            };
            List<Dictionary<string, string>> grids = new DB().Query(sqlQuery, sqlParams);
            int itemsCount = 0, heightLevel = 1;
            foreach (Dictionary<string, string> gridData in grids)
            {
                string[][] outputGrid = new string[GRID_ONE_DIMENSION_LENGTH][];
                string charGrid = gridData["sGrid"];
                int count = 0, rowCount = 0;
                // create multidimensional grid
                foreach (char value in charGrid)
                {
                    // if we have 9 elements
                    if (count == 0)
                    {
                        outputGrid[rowCount] = new string[GRID_ONE_DIMENSION_LENGTH];
                    }
                    outputGrid[rowCount][count] = value.ToString();
                    count++;
                    if (count == 9)
                    {
                        count = 0;
                        rowCount++;
                    }
                }
                GridPreview gridPreview = new GridPreview();
                gridPreview.ShowGrid(outputGrid);
                Bitmap img = new Bitmap(gridPreview.Width, gridPreview.Height);
                // draw gridpreview => img
                gridPreview.DrawToBitmap(img, gridPreview.ClientRectangle);
                if (itemsCount % 3 == 0 && itemsCount != 0)
                {
                    heightLevel++;
                }
                PictureBox pictureBox = new PictureBox
                {
                    Image = img,
                    Parent = flpnlGrids,
                    Location = new Point(PICTURE_BOX_SIDE_SIZE * (itemsCount % 3), Math.Max(PICTURE_BOX_SIDE_SIZE * itemsCount * heightLevel - PICTURE_BOX_SIDE_SIZE, 0)),
                    Size = new Size(PICTURE_BOX_SIDE_SIZE, PICTURE_BOX_SIDE_SIZE),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Margin = new Padding(20, 0, 20, 10),
                    Cursor = Cursors.Cross,
              
                };
                // show game view
                pictureBox.Click += (s, e) => { PlayGame(gridData, outputGrid); };
               

                itemsCount++;
            }

        }
        /// <summary>
        /// Show game view
        /// </summary>
        /// <param name="gridData"></param>
        /// <param name="grid"></param>
        private void PlayGame(Dictionary<string,string> gridData, string[][] grid)
        {
            FrmGame game = new FrmGame(gridData, grid);
            game.ShowDialog();
        }




    }

}
