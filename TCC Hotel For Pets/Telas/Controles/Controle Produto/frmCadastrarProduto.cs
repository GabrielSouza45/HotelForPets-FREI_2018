using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCC_Hotel_For_Pets.DB.Estoque;
using TCC_Hotel_For_Pets.DB.Fornecedor;
using TCC_Hotel_For_Pets.DB.Produto;
using TCC_Hotel_For_Pets.Telas.Menu_Funcionario;
using TCC_Hotel_For_Pets.Telas.Tela_ADM;

namespace TCC_Hotel_For_Pets.Telas.Controle_Produto
{
    public partial class frmCadastrarProduto : Form
    {
        BindingList<EstoqueConsultarView> estoque = new BindingList<EstoqueConsultarView>();
        public frmCadastrarProduto()
        {
            InitializeComponent();
            CarregarCombos();
        }
        void CarregarCombos()
        {
            FornecedorBusiness busca = new FornecedorBusiness();
            List<FornecedorDTO> lista = busca.Listar();

            cboFornecedorProduto.ValueMember = nameof(FornecedorDTO.Id);
            cboFornecedorProduto.DisplayMember = nameof(FornecedorDTO.Nome);
            cboFornecedorProduto.DataSource = lista;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            


            //try
            //{
                FornecedorDTO fornecedor = cboFornecedorProduto.SelectedItem as FornecedorDTO;

                ProdutoDTO dto = new ProdutoDTO();
                dto.Nome = txtNomeProduto.Text.Trim();
                dto.PrecoCompra = nudPreçoProduto.Value;
                dto.PrecoVenda = nudPrecoVenda.Value;
                dto.IdFornecedor = fornecedor.Id;

                ProdutoBusiness Business = new ProdutoBusiness();
                Business.Salvar(dto, estoque.ToList());

                MessageBox.Show("Produto salvo com sucesso.", "Hotel For Pets",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

            //}
            //catch (ArgumentException ex)
            //{
            //    MessageBox.Show(ex.Message, "Hotel For Pets",
            //        MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Ocorreru um erro, tente mais tarde.", "Hotel For Pets",
            //        MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnVoltarMenuADMFornecedores_Click(object sender, EventArgs e)
        {

            if (UserSession.UsuarioLogado.Adiministrador == true)
            {
                frmTelaADM menu = new frmTelaADM();
                menu.Show();

            }
            else if (UserSession.UsuarioLogado.Funcionario == true)
            {

                MessageBox.Show("Você não deveria ter acesso a essa tela, isso será relatado aos administradores do sistema!", "Hotel For Pets", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {

                MessageBox.Show("Você não deveria ter acesso a essa tela, isso será relatado aos administradores do sistema!", "Hotel For Pets", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            Hide();
        }

        private void frmCadastrarProduto_Load(object sender, EventArgs e)
        {

        }

        private void lblTotal_Click(object sender, EventArgs e)
        {
           
        }

        private void nudQtd_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
