namespace SMARTCHART
{
    partial class MainHub
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
            this.btnPatientHub = new System.Windows.Forms.Button();
            this.btnLogsHub = new System.Windows.Forms.Button();
            this.Quit = new System.Windows.Forms.Button();
            this.Tutorial = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPatientHub
            // 
            this.btnPatientHub.Location = new System.Drawing.Point(689, 241);
            this.btnPatientHub.Name = "btnPatientHub";
            this.btnPatientHub.Size = new System.Drawing.Size(75, 23);
            this.btnPatientHub.TabIndex = 0;
            this.btnPatientHub.Text = "Patient Hub";
            this.btnPatientHub.UseVisualStyleBackColor = true;
            this.btnPatientHub.Click += new System.EventHandler(this.btnPatientHub_Click);
            // 
            // btnLogsHub
            // 
            this.btnLogsHub.Location = new System.Drawing.Point(689, 297);
            this.btnLogsHub.Name = "btnLogsHub";
            this.btnLogsHub.Size = new System.Drawing.Size(75, 23);
            this.btnLogsHub.TabIndex = 1;
            this.btnLogsHub.Text = "Logs Hub";
            this.btnLogsHub.UseVisualStyleBackColor = true;
            this.btnLogsHub.Click += new System.EventHandler(this.btnLogsHub_Click);
            // 
            // Quit
            // 
            this.Quit.Location = new System.Drawing.Point(689, 356);
            this.Quit.Name = "Quit";
            this.Quit.Size = new System.Drawing.Size(75, 23);
            this.Quit.TabIndex = 2;
            this.Quit.Text = "Quit";
            this.Quit.UseVisualStyleBackColor = true;
            this.Quit.Click += new System.EventHandler(this.Quit_Click);
            // 
            // Tutorial
            // 
            this.Tutorial.Location = new System.Drawing.Point(12, 356);
            this.Tutorial.Name = "Tutorial";
            this.Tutorial.Size = new System.Drawing.Size(75, 23);
            this.Tutorial.TabIndex = 3;
            this.Tutorial.Text = "Tutorial";
            this.Tutorial.UseVisualStyleBackColor = true;
            this.Tutorial.Click += new System.EventHandler(this.Tutorial_Click);
            // 
            // MainHub
            // 
            this.ClientSize = new System.Drawing.Size(776, 446);
            this.Controls.Add(this.Tutorial);
            this.Controls.Add(this.Quit);
            this.Controls.Add(this.btnLogsHub);
            this.Controls.Add(this.btnPatientHub);
            this.Name = "MainHub";
            this.Text = "Main Hub";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPatientHub;
        private System.Windows.Forms.Button btnLogsHub;
        private System.Windows.Forms.Button Quit;
        private System.Windows.Forms.Button Tutorial;
    }
}

