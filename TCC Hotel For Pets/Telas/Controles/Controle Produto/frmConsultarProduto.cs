using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCC_Hotel_For_Pets.DB.Produto;
using TCC_Hotel_For_Pets.Telas.Menu_Funcionario;
using TCC_Hotel_For_Pets.Telas.Menu_inicial;
using TCC_Hotel_For_Pets.Telas.Tela_ADM;

namespace TCC_Hotel_For_Pets.Telas.Controle_Produto
{
    public partial class frmConsultarProduto : Form
    {
        public frmConsultarProduto()
        {
            InitializeComponent();
        }

        private void dgvProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                if (UserSession.UsuarioLogado.Adiministrador == false && UserSession.UsuarioLogado.Funcionario == false)
                {
                    MessageBox.Show("Por motivos de segurança, clientes não tem permissão de excluir os dados cadastrados.", "Hotel For Pets", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                ProdutoConsultarView produto = dgvProdutos.Rows[e.RowIndex].DataBoundItem as ProdutoConsultarView;

                DialogResult r = MessageBox.Show($"Deseja realmente excluir o produto {produto.Id}?", "Hotel For Pets.",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {

                    ProdutoBusiness business = new ProdutoBusiness();
                    business.Remover(produto.Id);

                    btnBuscar_Click(null, null);
                }
            }
            else if (e.ColumnIndex == 4)
            {
                if (UserSession.UsuarioLogado.Adiministrador == false && UserSession.UsuarioLogado.Funcionario == false)
                {
                    MessageBox.Show("Por motivos de segurança, clientes não tem permissão de alterar os dados cadastrados.", "Hotel For Pets", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ProdutoConsultarView produto = dgvProdutos.CurrentRow.DataBoundItem as ProdutoConsultarView;

                frmAlterarProduto tela = new frmAlterarProduto();
                tela.LoadScreen(produto);
                tela.Show();

            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ProdutoBusiness business = new ProdutoBusiness();
            List<ProdutoConsultarView> lista = business.Consultar(txtProduto.Text.Trim());

            dgvProdutos.AutoGenerateColumns = false;
            dgvProdutos.DataSource = lista;
        }

        private void btnVoltarMenuADMFornecedores_Click(object sender, EventArgs e)
        {

            if (UserSession.UsuarioLogado.Adiministrador == true)
            {
                frmTelaADM menu = new frmTelaADM();
                menu.Show();
                Hide();
            }
            else if (UserSession.UsuarioLogado.Funcionario == true)
            {

                frmMenuFuncionario menu = new frmMenuFuncionario();
                menu.Show();
                Hide();
            }
            else
            {
                frmMenuCliente tela = new frmMenuCliente();
                tela.Show();
                Hide();

            }

         
        }
    }
}
