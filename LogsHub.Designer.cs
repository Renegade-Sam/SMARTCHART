namespace SMARTCHART
{
    partial class LogsHub
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LmainHub = new System.Windows.Forms.Button();
            this.LogsGrid = new System.Windows.Forms.DataGridView();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.LogsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // LmainHub
            // 
            this.LmainHub.Location = new System.Drawing.Point(713, 386);
            this.LmainHub.Name = "LmainHub";
            this.LmainHub.Size = new System.Drawing.Size(75, 23);
            this.LmainHub.TabIndex = 0;
            this.LmainHub.Text = "Main Hub";
            this.LmainHub.UseVisualStyleBackColor = true;
            this.LmainHub.Click += new System.EventHandler(this.btnLmainHub_Click);
            // 
            // LogsGrid
            // 
            this.LogsGrid.AllowUserToAddRows = false;
            this.LogsGrid.AllowUserToDeleteRows = false;
            this.LogsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LogsGrid.Location = new System.Drawing.Point(12, 56);
            this.LogsGrid.Name = "LogsGrid";
            this.LogsGrid.ReadOnly = true;
            this.LogsGrid.Size = new System.Drawing.Size(613, 312);
            this.LogsGrid.TabIndex = 1;
            this.LogsGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LogsGrid_CellContentClick);
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.Location = new System.Drawing.Point(267, 25);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(71, 13);
            this.lblCurrentUser.TabIndex = 2;
            this.lblCurrentUser.Text = "Logged in as:";
            this.lblCurrentUser.Click += new System.EventHandler(this.lblCurrentUser_Click);
            // 
            // LogsHub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblCurrentUser);
            this.Controls.Add(this.LogsGrid);
            this.Controls.Add(this.LmainHub);
            this.Name = "LogsHub";
            this.Text = "Logs Hub";
            ((System.ComponentModel.ISupportInitialize)(this.LogsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LmainHub;
        private System.Windows.Forms.DataGridView LogsGrid;
        private System.Windows.Forms.Label lblCurrentUser;
    }
}