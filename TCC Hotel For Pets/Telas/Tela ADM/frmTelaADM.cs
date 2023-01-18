using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCC_Hotel_For_Pets.Telas.Cadastrar_Funcionário;
using TCC_Hotel_For_Pets.Telas.Controle_Cliente_Animal.Animais;
using TCC_Hotel_For_Pets.Telas.Controle_Cliente_Animal.Cliente;
using TCC_Hotel_For_Pets.Telas.Controle_Folha_de_Pagamento;
using TCC_Hotel_For_Pets.Telas.Controle_Fornecedor;
using TCC_Hotel_For_Pets.Telas.Controle_Funcionário;
using TCC_Hotel_For_Pets.Telas.Controle_Pedidos;
using TCC_Hotel_For_Pets.Telas.Controle_Produto;
using TCC_Hotel_For_Pets.Telas.Controles.Controle_Folha_de_Pagamento;
using TCC_Hotel_For_Pets.Telas.Controles.Controle_Produto;
using TCC_Hotel_For_Pets.Telas.Controles.Finaceiro;
using TCC_Hotel_For_Pets.Telas.Controles.Ponto;
using TCC_Hotel_For_Pets.Telas.Entregaveis;
using TCC_Hotel_For_Pets.Telas.Estoque;

namespace TCC_Hotel_For_Pets.Telas.Tela_ADM
{
    public partial class frmTelaADM : Form
    {
        public frmTelaADM()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void logOfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin tela = new frmLogin();
            tela.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmCadastrarProduto tela = new frmCadastrarProduto();
            tela.Show();
            Hide();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmConsultarProduto tela = new frmConsultarProduto();
            tela.Show();
            Hide();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            frmCadastrarFornecedor tela = new frmCadastrarFornecedor();
            tela.Show();
            Hide();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            frmConsultarFornecedor tela = new frmConsultarFornecedor();
            tela.Show();
            Hide();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            frmCadastrarCliente t = new frmCadastrarCliente();
            t.Show();
            Hide();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            frmCadastrarPedidos tela = new frmCadastrarPedidos();
            tela.Show();
            Hide();
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            frmConsultarPedidos tela = new frmConsultarPedidos();
            tela.Show();
            Hide();
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            frmCadastrarFuncionario tela = new frmCadastrarFuncionario();
            tela.Show();
            Hide();
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            frmConsultarFuncionario tela = new frmConsultarFuncionario();
            tela.Show();
            Hide();
        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem22_Click(object sender, EventArgs e)
        {
            frmFolhaPagamento tela = new frmFolhaPagamento();
            tela.Show();
            Hide();
        }

        private void toolStripMenuItem24_Click(object sender, EventArgs e)
        {
            frmLogin tela = new frmLogin();
            tela.Show();
            Hide();
        }

        private void eNTREGÁVEISToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMenuEntregaveis t = new frmMenuEntregaveis();
            t.Show();
            Hide();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            frmConsultarCliente t = new frmConsultarCliente();
            t.Show();
            Hide();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            frmConsultarAnimal t = new frmConsultarAnimal();
            t.Show();
            Hide();
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            ConsultarEstoque frm = new ConsultarEstoque();
            frm.Show();
            Hide();
        }

        private void comprarProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmComprarProduto f = new frmComprarProduto();
            f.Show();
            Hide();

        }

        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {
            frmFluxoDeCaixa n = new frmFluxoDeCaixa();
            n.Show();
            Hide();
        }

        private void cadastrarGastosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastrarGastos d = new frmCadastrarGastos();
            d.Show();
            Hide();
        }

        private void consultarGastosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultarGastos f = new frmConsultarGastos();
            f.Show();
            Hide();
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {

        }

        private void consultarFolhasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultarFolhaPagamento f = new frmConsultarFolhaPagamento();
            f.Show();
            Hide();
        }

        private void efetuarPontoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPonto f = new frmPonto();
            f.Show();
            Hide();
        }

        private void consultarPontoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultarPonto f = new frmConsultarPonto();
            f.Show();
            Hide();
        }
    }
}
