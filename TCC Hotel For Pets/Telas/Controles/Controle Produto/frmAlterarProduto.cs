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
using TCC_Hotel_For_Pets.DB.Funcionário;
using TCC_Hotel_For_Pets.DB.Produto;

namespace TCC_Hotel_For_Pets.Telas.Controle_Produto
{
    public partial class frmAlterarProduto : Form
    {
        public frmAlterarProduto()
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

        ProdutoConsultarView produto;


        public void LoadScreen(ProdutoConsultarView produto)
        {
            this.produto = produto;

            lblId.Text = produto.Id.ToString();
            txtNomeProduto.Text = produto.Nome;
            nudPreçoProduto.Value = produto.PrecoCompra;
            nudPrecoVenda.Value = produto.PrecoVenda;
            cboFornecedorProduto.SelectedItem = produto.Fornecedor;

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            //produto.Nome = txtNomeProduto.Text;
            //produto.Preco = Convert.ToDecimal(txtPrecoProduto.Text);
            //produto.Fornecedor = cboFornecedorProduto.SelectedText;          

            //ProdutoBusiness business = new ProdutoBusiness();
            //business.Alterar(produto);

            FornecedorDTO fornecedor = cboFornecedorProduto.SelectedItem as FornecedorDTO;


            produto.Nome = txtNomeProduto.Text.Trim();
            produto.PrecoCompra = nudPreçoProduto.Value;
            produto.PrecoVenda = nudPrecoVenda.Value;
            produto.Fornecedor = cboFornecedorProduto.SelectedItem.ToString();
            produto.IdFornecedor = fornecedor.Id;



            ProdutoBusiness Business = new ProdutoBusiness();
            Business.Alterar(produto);

            MessageBox.Show("Produto alterado com sucesso.");
        }

        private void frmAlterarProduto_Load(object sender, EventArgs e)
        {

        }

        private void cboFornecedorProduto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnVoltarMenuADMFornecedores_Click(object sender, EventArgs e)
        {


            frmConsultarProduto menu = new frmConsultarProduto();
            menu.Show();
            this.Hide();
        }
    }
}
