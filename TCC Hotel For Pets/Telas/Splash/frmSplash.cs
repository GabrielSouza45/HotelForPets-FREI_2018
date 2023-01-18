using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCC_Hotel_For_Pets.Telas.Splash
{
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pbSplash.Value < 100)
            {
                pbSplash.Value = pbSplash.Value + 2;
            }
            else
            {

                timer1.Enabled = false;
                frmLogin frm = new frmLogin();
                frm.Show();
                Hide();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
