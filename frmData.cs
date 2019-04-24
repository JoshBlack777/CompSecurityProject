using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyPacketCapture
{
    public partial class frmData : Form
    {
        internal static int instantiations = 0;

        public frmData()
        {
            InitializeComponent();
            instantiations++;
        }

        private void frmData_Load(object sender, EventArgs e)
        {

        }

        private void txtAnalyzer_TextChanged(object sender, EventArgs e)
        {

        }

        private void pieData_Click(object sender, EventArgs e)
        {

        }

        private void frmData_FormClosed(object sender, EventArgs e)
        {
            instantiations--;
        }
    }
}
