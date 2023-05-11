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
            this.flpnlGrids.Location = new System.Drawing.Point(21, 96);
            this.flpnlGrids.Name = "flpnlGrids";
            this.flpnlGrids.Size = new System.Drawing.Size(767, 342);
            this.flpnlGrids.TabIndex = 5;
            // 
            // FrmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}

