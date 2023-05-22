namespace Sudoku
{
    partial class FrmHome
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnSignIn = new System.Windows.Forms.Button();
            this.btnSignUpOrUpdateData = new System.Windows.Forms.Button();
            this.btnCreateGrid = new System.Windows.Forms.Button();
            this.flpnlGrids = new System.Windows.Forms.FlowLayoutPanel();
            this.gbxBestScores = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbLevel = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome !";
            // 
            // btnSignIn
            // 
            this.btnSignIn.Location = new System.Drawing.Point(317, 37);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(98, 23);
            this.btnSignIn.TabIndex = 2;
            this.btnSignIn.Text = "Sign in";
            this.btnSignIn.UseVisualStyleBackColor = true;
            this.btnSignIn.Click += new System.EventHandler(this.OnClickOnbtnSignIn);
            // 
            // btnSignUpOrUpdateData
            // 
            this.btnSignUpOrUpdateData.Location = new System.Drawing.Point(460, 37);
            this.btnSignUpOrUpdateData.Name = "btnSignUpOrUpdateData";
            this.btnSignUpOrUpdateData.Size = new System.Drawing.Size(160, 23);
            this.btnSignUpOrUpdateData.TabIndex = 3;
            this.btnSignUpOrUpdateData.Text = "Sign up";
            this.btnSignUpOrUpdateData.UseVisualStyleBackColor = true;
            this.btnSignUpOrUpdateData.Click += new System.EventHandler(this.OnClickOnbtnSignUpOrUpdateData);
            // 
            // btnCreateGrid
            // 
            this.btnCreateGrid.Location = new System.Drawing.Point(640, 37);
            this.btnCreateGrid.Name = "btnCreateGrid";
            this.btnCreateGrid.Size = new System.Drawing.Size(75, 23);
            this.btnCreateGrid.TabIndex = 4;
            this.btnCreateGrid.Text = "Create grid";
            this.btnCreateGrid.UseVisualStyleBackColor = true;
            this.btnCreateGrid.Visible = false;
            this.btnCreateGrid.Click += new System.EventHandler(this.OnClickOnbtnCreateGrid);
            // 
            // flpnlGrids
            // 
            this.flpnlGrids.AutoScroll = true;
            this.flpnlGrids.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpnlGrids.Location = new System.Drawing.Point(31, 102);
            this.flpnlGrids.MinimumSize = new System.Drawing.Size(700, 342);
            this.flpnlGrids.Name = "flpnlGrids";
            this.flpnlGrids.Size = new System.Drawing.Size(700, 342);
            this.flpnlGrids.TabIndex = 5;
            // 
            // gbxBestScores
            // 
            this.gbxBestScores.Location = new System.Drawing.Point(21, 474);
            this.gbxBestScores.Name = "gbxBestScores";
            this.gbxBestScores.Size = new System.Drawing.Size(767, 140);
            this.gbxBestScores.TabIndex = 6;
            this.gbxBestScores.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 447);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Best Scores";
            // 
            // cmbLevel
            // 
            this.cmbLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLevel.FormattingEnabled = true;
            this.cmbLevel.Items.AddRange(new object[] {
            "All",
            "Easy",
            "Medium",
            "Hard"});
            this.cmbLevel.Location = new System.Drawing.Point(31, 69);
            this.cmbLevel.Name = "cmbLevel";
            this.cmbLevel.Size = new System.Drawing.Size(121, 21);
            this.cmbLevel.TabIndex = 7;
            this.cmbLevel.SelectedValueChanged += new System.EventHandler(this.SelectedLevelChanged);
            // 
            // FrmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 657);
            this.Controls.Add(this.cmbLevel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gbxBestScores);
            this.Controls.Add(this.flpnlGrids);
            this.Controls.Add(this.btnCreateGrid);
            this.Controls.Add(this.btnSignUpOrUpdateData);
            this.Controls.Add(this.btnSignIn);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmHome";
            this.Text = "Home";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSignIn;
        private System.Windows.Forms.Button btnSignUpOrUpdateData;
        private System.Windows.Forms.Button btnCreateGrid;
        private System.Windows.Forms.FlowLayoutPanel flpnlGrids;
        private System.Windows.Forms.GroupBox gbxBestScores;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbLevel;
    }
}

