using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCC_Hotel_For_Pets.Telas.Cameras;
using TCC_Hotel_For_Pets.Telas.Controle_Cliente_Animal.Animais;
using TCC_Hotel_For_Pets.Telas.Controle_Funcionário;
using TCC_Hotel_For_Pets.Telas.Controle_Pedidos;
using TCC_Hotel_For_Pets.Telas.Controle_Produto;
using TCC_Hotel_For_Pets.Telas.Controles.Controle_Funcionário;

namespace TCC_Hotel_For_Pets.Telas.Menu_inicial
{
    public partial class frmMenuCliente : Form
    {
        public frmMenuCliente()
        {
            InitializeComponent();
        }

        private void frmMenuInicial_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void logOfToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmCadastrarAnimal t = new frmCadastrarAnimal();
            t.Show();
            Hide();
        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastrarAnimal t = new frmCadastrarAnimal();
            t.Show();
            Hide();
        }

        private void consultarPetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultarAnimal t = new frmConsultarAnimal();
            t.Show();
            Hide();
        }

        private void verificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCameras t = new frmCameras();
            t.Show();
            Hide();
        }

        private void fazerPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastrarPedidos t = new frmCadastrarPedidos();
            t.Show();
            Hide();
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultarProduto t = new frmConsultarProduto();
            t.Show();
            Hide();
        }

        private void consultarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmConsultarADMCliente t = new frmConsultarADMCliente();
            t.Show();
            Hide();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin f = new frmLogin();
            f.Show();
            Hide();
        }

        private void câmerasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nossosProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
