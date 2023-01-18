using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCC_Hotel_For_Pets.Telas.Menu_inicial;

namespace TCC_Hotel_For_Pets.Telas.Cameras
{
    public partial class frmCameras : Form
    {
        public frmCameras()
        {
            InitializeComponent();
        }

        private void sobreNósToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin f = new frmLogin();
            f.Show();
            Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMenuCliente f = new frmMenuCliente();
            f.Show();
            Hide();
        }
    }
}
