using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCC_Hotel_For_Pets.DB.Login;
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
using TCC_Hotel_For_Pets.Telas.Estoque;
using TCC_Hotel_For_Pets.Telas.Menu_Funcionario;
using TCC_Hotel_For_Pets.Telas.Tela_ADM;

namespace TCC_Hotel_For_Pets.Telas.Entregaveis
{
    public partial class frmMenuEntregaveis : Form
    {
        public frmMenuEntregaveis()
        {
            InitializeComponent();
        }

        private void frmMenuEntregaveis_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmCadastrarFuncionario tela = new frmCadastrarFuncionario();
            tela.Show();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmConsultarFuncionario tela = new frmConsultarFuncionario();
            tela.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmFolhaPagamento tela = new frmFolhaPagamento();
            tela.Show();
            Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmCadastrarFornecedor tela = new frmCadastrarFornecedor();
            tela.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmConsultarFornecedor tela = new frmConsultarFornecedor();
            tela.Show();
            Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmCadastrarProduto tela = new frmCadastrarProduto();
            tela.Show();
            Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmConsultarProduto tela = new frmConsultarProduto();
            tela.Show();
            Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            frmCadastrarPedidos tela = new frmCadastrarPedidos();
            tela.Show();
            Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frmConsultarPedidos tela = new frmConsultarPedidos();
            tela.Show();
            Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
           

            if (UserSession.UsuarioLogado.Adiministrador == true)
            {
                frmTelaADM menu = new frmTelaADM();
                menu.Show();

            }
            else if (UserSession.UsuarioLogado.Funcionario == true)
            {

                frmMenuFuncionario menu = new frmMenuFuncionario();
                menu.Show();

            }
           

            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            frmConsultarFolhaPagamento d = new frmConsultarFolhaPagamento();
            d.Show();
            Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            frmComprarProduto form = new frmComprarProduto();
            form.Show();
            Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            frmCadastrarCliente f = new frmCadastrarCliente();
            f.Show();
            Hide();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            frmConsultarCliente f = new frmConsultarCliente();
            f.Show();
            Hide();

        }

        private void button16_Click(object sender, EventArgs e)
        {
            frmCadastrarAnimal f = new frmCadastrarAnimal();
            f.Show();
            Hide();

        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            frmConsultarAnimal f = new frmConsultarAnimal();
            f.Show();
            Hide();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            frmCadastrarPedidos f = new frmCadastrarPedidos();
            f.Show();
            Hide();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            frmConsultarPedidos f = new frmConsultarPedidos();
            f.Show();
            Hide();
        }

        private void button22_Click(object sender, EventArgs e)
        {
          
        }

        private void button21_Click(object sender, EventArgs e)
        {
            
        }

        private void button18_Click(object sender, EventArgs e)
        {
           
        }

        private void button17_Click(object sender, EventArgs e)
        {
            
        }

        private void button22_Click_1(object sender, EventArgs e)
        {
            ConsultarEstoque f = new ConsultarEstoque();
            f.Show();
            Hide();
        }

        private void button21_Click_1(object sender, EventArgs e)
        {
             frmCadastrarGastos f = new frmCadastrarGastos();
            f.Show();
            Hide();
        }

        private void button18_Click_1(object sender, EventArgs e)
        {
            frmConsultarGastos f = new frmConsultarGastos();
            f.Show();
            Hide();
        }

        private void button17_Click_1(object sender, EventArgs e)
        {
            frmFluxoDeCaixa f = new frmFluxoDeCaixa();
            f.Show();
            Hide();
        }
    }
}
