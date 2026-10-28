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
            this.SuspendLayout();
            // 
            // LmainHub
            // 
            this.LmainHub.Location = new System.Drawing.Point(713, 252);
            this.LmainHub.Name = "LmainHub";
            this.LmainHub.Size = new System.Drawing.Size(75, 23);
            this.LmainHub.TabIndex = 0;
            this.LmainHub.Text = "Main Hub";
            this.LmainHub.UseVisualStyleBackColor = true;
            this.LmainHub.Click += new System.EventHandler(this.btnLmainHub_Click);
            // 
            // LogsHub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LmainHub);
            this.Name = "LogsHub";
            this.Text = "Logs Hub";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LmainHub;
    }
}