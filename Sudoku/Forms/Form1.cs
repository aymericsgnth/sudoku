using System;
using System.CodeDom.Compiler;
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
        private const int GROUPBOX_SIDE_SIZE = 150;
        private const int LABEL_WIDTH = 75;
        private const int LABEL_HEIGHT = 20;
        private const int LABEL_MARGIN_TOP = 10;

        public FrmHome()
        {
            InitializeComponent();
            ShowGrids();
            cmbLevel.SelectedIndex = 0;

        }
        /// <summary>
        /// Fired when btnSignUpOrUpdateData is clicked
        /// Show 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickOnbtnSignUpOrUpdateData(object sender, EventArgs e)
        {
            frmSignUpOrUpdateData = new FrmSignUpOrUpdateData(Globals.Connected ? FrmSignUpOrUpdateData.Types.Update : FrmSignUpOrUpdateData.Types.Insertion);
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
        private void ShowGrids(int? level = null )
        {
            flpnlGrids.Controls.Clear();
            string sqlQuery = "SELECT iGridCode, sGrid, dCreatedAt, iLevel FROM grid ";
            Dictionary<string, string> sqlParams = new Dictionary<string, string>();
            if (level != null)
            {
                sqlQuery += "WHERE iLevel = @level";
                sqlParams.Add("@level", level.ToString());
            }
            sqlQuery += " ORDER BY dCreatedAt DESC";
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
                // output container generation
                GroupBox gbx = new GroupBox
                {
                    Parent = flpnlGrids,
                    Location = new Point(GROUPBOX_SIDE_SIZE * (itemsCount % 3), Math.Max(GROUPBOX_SIDE_SIZE * itemsCount * heightLevel - GROUPBOX_SIDE_SIZE, 0)),
                    Size = new Size(GROUPBOX_SIDE_SIZE, GROUPBOX_SIDE_SIZE),
                    Margin = new Padding(20, 0, 20, 10),
                    Cursor = Cursors.Cross,
                };
                GridView gridPreview = new GridView();
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
                    Parent = gbx,
                    Location = new Point(0,0),
                    Size = new Size(GROUPBOX_SIDE_SIZE, GROUPBOX_SIDE_SIZE - 20),
                    SizeMode = PictureBoxSizeMode.StretchImage,

                };
                
                pictureBox.Click += (s, e) => { ShowBestScores(gridData); };
                // show game view
                pictureBox.DoubleClick += (s, e) => { PlayGame(gridData, outputGrid); };
                string lvl = string.Empty;
                switch (gridData["iLevel"])
                {
                    case "0":
                        lvl = "easy";
                        break;
                    case "1":
                        lvl = "medium";
                        break;
                    case "2":
                        lvl = "hard";
                        break;
                    default:
                        break;
                }
                Label lblDifficult = new Label
                {
                    Text = lvl,
                    Location = new Point(0,GROUPBOX_SIDE_SIZE - 20),
                    Parent = gbx
                };
                


                itemsCount++;
            }

        }
        /// <summary>
        /// Show game view
        /// </summary>
        /// <param name="gridData"></param>
        /// <param name="grid"></param>
        private void PlayGame(Dictionary<string, string> gridData, string[][] grid)
        {
            FrmGame game = new FrmGame(gridData, grid);
            game.ShowDialog();
        }
        /// <summary>
        /// Show best scores
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowBestScores(Dictionary<string, string> gridData)
        {
            gbxBestScores.Controls.Clear();
            string SqlQuery = @"SELECT iResolveTime, sNickname 
                                  FROM result
                            INNER JOIN user
                                    ON result.iUserCode = user.iUserCode
                                 WHERE iGridCode = @gridId
                              ORDER BY iResolveTime ASC";
            Dictionary<string, string> SqlParams = new Dictionary<string, string>
            {
                {"@gridId", gridData["iGridCode"] }
            };
            List<Dictionary<string, string>> results = new DB().Query(SqlQuery, SqlParams);
            int counter = 0;
            foreach (Dictionary<string, string> result in results.Take(3))
            {

                // generate output
                Label lblCount = new Label
                {
                    Text = (counter + 1) + ".".ToString(),
                    Location = new Point(0, counter * LABEL_HEIGHT + LABEL_MARGIN_TOP),
                    AutoSize = false,
                    Width = LABEL_WIDTH,
                    Height = LABEL_HEIGHT
        
                };
                Label lblPlayerName = new Label
                {
                    Text = result["sNickname"],
                    Location = new Point(LABEL_WIDTH + 50, counter * LABEL_HEIGHT + LABEL_MARGIN_TOP),
                    AutoSize = false,
                    Width = LABEL_WIDTH,
                    Height = LABEL_HEIGHT
                };
                Label lblTime = new Label
                {
                    Text = result["iResolveTime"] + "s",
                    Location = new Point(LABEL_WIDTH + LABEL_WIDTH * 2 + 50, counter * LABEL_HEIGHT + LABEL_MARGIN_TOP),
                    AutoSize = false,
                    Width = LABEL_WIDTH,
                    Height = LABEL_HEIGHT
                };
                gbxBestScores.Controls.Add(lblCount);
                gbxBestScores.Controls.Add(lblPlayerName);
                gbxBestScores.Controls.Add(lblTime);
                // incr
                counter++;
            }
        }

        /// <summary>
        /// Fired when selectedValue has changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectedLevelChanged(object sender, EventArgs e)
        {
            // if = all
            if (cmbLevel.SelectedIndex == 0)
            {
                ShowGrids();
            }
            else
            {
                ShowGrids(cmbLevel.SelectedIndex - 1);
            }
        }
    }

}
