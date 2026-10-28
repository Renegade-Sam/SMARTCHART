using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMARTCHART
{
    public partial class PatientHub : Form
    {
        public PatientHub()
        {
            InitializeComponent();
        }

        private void btnMainHub_Click(object sender, EventArgs e)
        {
            var mainHub = Application.OpenForms.OfType<MainHub>().FirstOrDefault();
            if (mainHub != null)
            {
                mainHub.Show();
                this.Close();
            }
        }
    }
}
