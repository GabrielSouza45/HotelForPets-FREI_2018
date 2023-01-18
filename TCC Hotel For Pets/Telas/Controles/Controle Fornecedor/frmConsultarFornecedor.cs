using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCC_Hotel_For_Pets.DB.Fornecedor;
using TCC_Hotel_For_Pets.Telas.Menu_Funcionario;
using TCC_Hotel_For_Pets.Telas.Tela_ADM;

namespace TCC_Hotel_For_Pets.Telas.Controle_Fornecedor
{
    public partial class frmConsultarFornecedor : Form
    {
        public frmConsultarFornecedor()
        {
            InitializeComponent();
        }

        private void frmConsultarFornecedor_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FornecedorBusiness business = new FornecedorBusiness();
            List<FornecedorDTO> lista = business.Consultar(txtnome.Text.Trim());

            dgvFornecedor.AutoGenerateColumns = false;
            dgvFornecedor.DataSource = lista;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
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
            else
            {
                MessageBox.Show("Você não tem permissão para acessar essa tela.", "Hotel For Pets", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


            }

            this.Hide();

        }

        private void dgvFornecedor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10)
            {
                FornecedorDTO funcionario = dgvFornecedor.Rows[e.RowIndex].DataBoundItem as FornecedorDTO;

                DialogResult r = MessageBox.Show($"Deseja realmente excluir o Fornecedor {funcionario.Id}?" +
                    $" Excluir um fornecedor cadastrado, excluirá todos os registros de Produtos cadastrados no nome do mesmo!", "Hotel For Pets",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {

                    FornecedorBusiness business = new FornecedorBusiness();
                    business.Remover(funcionario.Id);

                    button1_Click(null, null);
                }
            }
            else if (e.ColumnIndex == 9)
            {
                

                FornecedorDTO fornecedor = dgvFornecedor.CurrentRow.DataBoundItem as FornecedorDTO;

                frmAlterarFornecedor tela = new frmAlterarFornecedor();
                tela.LoadScreen(fornecedor);
                tela.Show();

                //frmInicial.Atual.OpenScreen(tela);

            }
        }
    }
}
