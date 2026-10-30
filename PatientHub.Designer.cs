namespace SMARTCHART
{
    partial class PatientHub
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
            this.MainHub = new System.Windows.Forms.Button();
            this.RegPatient = new System.Windows.Forms.Button();
            this.UpdPatient = new System.Windows.Forms.Button();
            this.PatientGrid = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnDeletePatient = new System.Windows.Forms.Button();
            this.txtSearchPatient = new System.Windows.Forms.TextBox();
            this.btnSearchPatient = new System.Windows.Forms.Button();
            this.btnClearSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PatientGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // MainHub
            // 
            this.MainHub.Location = new System.Drawing.Point(698, 248);
            this.MainHub.Name = "MainHub";
            this.MainHub.Size = new System.Drawing.Size(90, 23);
            this.MainHub.TabIndex = 0;
            this.MainHub.Text = "Main Hub";
            this.MainHub.UseVisualStyleBackColor = true;
            this.MainHub.Click += new System.EventHandler(this.btnMainHub_Click);
            // 
            // RegPatient
            // 
            this.RegPatient.Location = new System.Drawing.Point(698, 288);
            this.RegPatient.Name = "RegPatient";
            this.RegPatient.Size = new System.Drawing.Size(90, 23);
            this.RegPatient.TabIndex = 1;
            this.RegPatient.Text = "Register Patient";
            this.RegPatient.UseVisualStyleBackColor = true;
            this.RegPatient.Click += new System.EventHandler(this.btnRegPatient_Click);
            // 
            // UpdPatient
            // 
            this.UpdPatient.Location = new System.Drawing.Point(698, 331);
            this.UpdPatient.Name = "UpdPatient";
            this.UpdPatient.Size = new System.Drawing.Size(90, 23);
            this.UpdPatient.TabIndex = 2;
            this.UpdPatient.Text = "Edit Patient";
            this.UpdPatient.UseVisualStyleBackColor = true;
            this.UpdPatient.Click += new System.EventHandler(this.btnUpdPatient_Click);
            // 
            // PatientGrid
            // 
            this.PatientGrid.AllowUserToAddRows = false;
            this.PatientGrid.AllowUserToDeleteRows = false;
            this.PatientGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PatientGrid.Location = new System.Drawing.Point(12, 12);
            this.PatientGrid.Name = "PatientGrid";
            this.PatientGrid.ReadOnly = true;
            this.PatientGrid.Size = new System.Drawing.Size(475, 259);
            this.PatientGrid.TabIndex = 3;
            // 
            // btnDeletePatient
            // 
            this.btnDeletePatient.Location = new System.Drawing.Point(698, 373);
            this.btnDeletePatient.Name = "btnDeletePatient";
            this.btnDeletePatient.Size = new System.Drawing.Size(90, 23);
            this.btnDeletePatient.TabIndex = 4;
            this.btnDeletePatient.Text = "Delete Patient";
            this.btnDeletePatient.UseVisualStyleBackColor = true;
            this.btnDeletePatient.Click += new System.EventHandler(this.btnDeletePatient_Click);
            // 
            // txtSearchPatient
            // 
            this.txtSearchPatient.Location = new System.Drawing.Point(12, 288);
            this.txtSearchPatient.Name = "txtSearchPatient";
            this.txtSearchPatient.Size = new System.Drawing.Size(475, 20);
            this.txtSearchPatient.TabIndex = 5;
            // 
            // btnSearchPatient
            // 
            this.btnSearchPatient.Location = new System.Drawing.Point(12, 314);
            this.btnSearchPatient.Name = "btnSearchPatient";
            this.btnSearchPatient.Size = new System.Drawing.Size(75, 23);
            this.btnSearchPatient.TabIndex = 6;
            this.btnSearchPatient.Text = "Search";
            this.btnSearchPatient.UseVisualStyleBackColor = true;
            this.btnSearchPatient.Click += new System.EventHandler(this.btnSearchPatient_Click);
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.Location = new System.Drawing.Point(118, 314);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(75, 23);
            this.btnClearSearch.TabIndex = 7;
            this.btnClearSearch.Text = "Clear";
            this.btnClearSearch.UseVisualStyleBackColor = true;
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
            // 
            // PatientHub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClearSearch);
            this.Controls.Add(this.btnSearchPatient);
            this.Controls.Add(this.txtSearchPatient);
            this.Controls.Add(this.btnDeletePatient);
            this.Controls.Add(this.PatientGrid);
            this.Controls.Add(this.UpdPatient);
            this.Controls.Add(this.RegPatient);
            this.Controls.Add(this.MainHub);
            this.Name = "PatientHub";
            this.Text = "Patient Hub";
            ((System.ComponentModel.ISupportInitialize)(this.PatientGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button MainHub;
        private System.Windows.Forms.Button RegPatient;
        private System.Windows.Forms.Button UpdPatient;
        private System.Windows.Forms.DataGridView PatientGrid;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnDeletePatient;
        private System.Windows.Forms.TextBox txtSearchPatient;
        private System.Windows.Forms.Button btnSearchPatient;
        private System.Windows.Forms.Button btnClearSearch;
    }
}