using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCC_Hotel_For_Pets.DB.Compra.Pedido_Compra;
using TCC_Hotel_For_Pets.DB.Fornecedor;
using TCC_Hotel_For_Pets.DB.Pedido;
using TCC_Hotel_For_Pets.DB.Produto;
using TCC_Hotel_For_Pets.Telas.Tela_ADM;

namespace TCC_Hotel_For_Pets.Telas.Controles.Controle_Produto
{
    public partial class frmComprarProduto : Form
    {
        BindingList<ProdutoConsultarView> produtosCarrinho = new BindingList<ProdutoConsultarView>();

        public frmComprarProduto()
        {
            InitializeComponent();
            CarregarCombos();
            ConfigurarGrid();
        }
        void CarregarCombos()
        {
            FornecedorBusiness business = new FornecedorBusiness();
            List<FornecedorDTO> lista = business.Listar();

            comboBox1.ValueMember = nameof(FornecedorDTO.Id);
            comboBox1.DisplayMember = nameof(FornecedorDTO.Nome);
            comboBox1.DataSource = lista;
        }
        void ConfigurarGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = produtosCarrinho;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ProdutoConsultarView dto = cboProduto.SelectedItem as ProdutoConsultarView;

            int qtd = Convert.ToInt32(nudQtd.Value);

            for (int i = 0; i < qtd; i++)
            {
                produtosCarrinho.Add(dto);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            FornecedorDTO dto2 = comboBox1.SelectedItem as FornecedorDTO;

            PedidoCompraDTO dto = new PedidoCompraDTO();
            dto.IdFornecedor = dto2.Id;
            dto.Data = DateTime.Now;

            PedidoCompraBusiness business = new PedidoCompraBusiness();
            int idPedido = business.Salvar(dto, produtosCarrinho.ToList());

            MessageBox.Show("Pedido Salvo com sucesso", "Hotel For Pets", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FornecedorDTO dto = comboBox1.SelectedItem as FornecedorDTO;
            string nome = dto.Nome;

            ProdutoBusiness business = new ProdutoBusiness();
            List<ProdutoConsultarView> lista = business.ConsultarPorFornecedor(nome);

            cboProduto.ValueMember = nameof(ProdutoConsultarView.Id);
            cboProduto.DisplayMember = nameof(ProdutoConsultarView.Nome);
            cboProduto.DataSource = lista;
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);

            }
        }
    }
}
