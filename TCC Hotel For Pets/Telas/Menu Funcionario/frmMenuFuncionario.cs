using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCC_Hotel_For_Pets.Telas.Controle_Cliente_Animal.Animais;
using TCC_Hotel_For_Pets.Telas.Controle_Cliente_Animal.Cliente;
using TCC_Hotel_For_Pets.Telas.Controle_Fornecedor;
using TCC_Hotel_For_Pets.Telas.Controle_Funcionário;
using TCC_Hotel_For_Pets.Telas.Controle_Pedidos;
using TCC_Hotel_For_Pets.Telas.Controle_Produto;
using TCC_Hotel_For_Pets.Telas.Controles.Finaceiro;
using TCC_Hotel_For_Pets.Telas.Estoque;

namespace TCC_Hotel_For_Pets.Telas.Menu_Funcionario
{
    public partial class frmMenuFuncionario : Form
    {
        public frmMenuFuncionario()
        {
            InitializeComponent();
        }

        private void logOfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin tela = new frmLogin();
            tela.Show();
            Hide();
        }

        

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            frmConsultarProduto tela = new frmConsultarProduto();
            tela.Show();
            Hide();
        }

        private void btnFornecedores_Click(object sender, EventArgs e)
        {
            frmConsultarFornecedor tela = new frmConsultarFornecedor();
            tela.Show();
            Hide();
        }

        private void btnEstoque_Click(object sender, EventArgs e)
        {
            
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            frmConsultarCliente tela = new frmConsultarCliente();
            tela.Show();
            Hide();
        }

        private void btnAnimais_Click(object sender, EventArgs e)
        {
            frmConsultarAnimal tela = new frmConsultarAnimal();
            tela.Show();
            Hide();
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            frmCadastrarPedidos tela = new frmCadastrarPedidos();
            tela.Show();
            Hide();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            frmConsultarFornecedor tela = new frmConsultarFornecedor();
            tela.Show();
            Hide();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmConsultarProduto tela = new frmConsultarProduto();
            tela.Show();
            Hide();
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            frmConsultarPedidos tela = new frmConsultarPedidos();
            tela.Show();
            Hide();
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            frmConsultarFuncionario tela = new frmConsultarFuncionario();
            tela.Show();
            Hide();
        }

        private void toolStripMenuItem24_Click(object sender, EventArgs e)
        {
            frmLogin tela = new frmLogin();
            tela.Show();
            Hide();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            frmConsultarAnimal f = new frmConsultarAnimal();
            f.Show();
            Hide();
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastrarPedidos t = new frmCadastrarPedidos();
            t.Show();
            Hide();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            frmCadastrarCliente f = new frmCadastrarCliente();
            f.Show();
            Hide();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            frmConsultarCliente f = new frmConsultarCliente();
            f.Show();
            Hide();
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            ConsultarEstoque f = new ConsultarEstoque();
            f.Show();
            Hide();
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {

        }

        private void cadsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastrarGastos f = new frmCadastrarGastos();
            f.Show();
            Hide();
        }

        private void cadastrarAnimaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastrarAnimal f = new frmCadastrarAnimal();
            f.Show();
            Hide();
        }
    }
}
