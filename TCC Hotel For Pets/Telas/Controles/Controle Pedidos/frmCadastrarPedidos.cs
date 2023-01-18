using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCC_Hotel_For_Pets.DB.Cliente;
using TCC_Hotel_For_Pets.DB.Estoque;
using TCC_Hotel_For_Pets.DB.Login;
using TCC_Hotel_For_Pets.DB.Pedido;
using TCC_Hotel_For_Pets.DB.Plugin_EMAIL;
using TCC_Hotel_For_Pets.DB.Produto;
using TCC_Hotel_For_Pets.Telas.Menu_Funcionario;
using TCC_Hotel_For_Pets.Telas.Menu_inicial;
using TCC_Hotel_For_Pets.Telas.Tela_ADM;

namespace TCC_Hotel_For_Pets.Telas.Controle_Pedidos
{
    public partial class frmCadastrarPedidos : Form
    {

        BindingList<EstoqueConsultarView> produtosCarrinho = new BindingList<EstoqueConsultarView>();




        public frmCadastrarPedidos()
        {
            InitializeComponent();
            CarregarCombos();
            ConfigurarGrid();
        }
        void CarregarCombos()
        {

            EstoqueBusiness business2 = new EstoqueBusiness();
            List<EstoqueConsultarView> lista2 = business2.Listar();

            cboProduto.ValueMember = nameof(EstoqueConsultarView.Id);
            cboProduto.DisplayMember = nameof(EstoqueConsultarView.Produto);
            cboProduto.DataSource = lista2;
        }


        void ConfigurarGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = produtosCarrinho;
        }

       

    

        private void frmCadastrarPedidos_Load(object sender, EventArgs e)
        {
            
        }

        private void btnEmitir_Click_1(object sender, EventArgs e)
        {
            //try
            //{
            //        PedidoDTO dto = new PedidoDTO();
            //        dto.IdUsuario = UserSession.UsuarioLogado.IdUsuario;
            //        dto.Venda = DateTime.Now;

            //        PedidoBusiness business = new PedidoBusiness();
            //        business.Salvar(dto, produtosCarrinho.ToList());

            //        MessageBox.Show("Pedido salvo com sucesso.", "Hotel For Pets.", MessageBoxButtons.OK, MessageBoxIcon.Information);


            Email email = new Email();
            email.Enviar(txtEmail.Text, "Pedido realizado com sucesso.");



            PedidoDTO dto = new PedidoDTO();
            dto.IdUsuario = UserSession.UsuarioLogado.IdUsuario;
            dto.Venda = DateTime.Now;

            PedidoBusiness business = new PedidoBusiness();
            int idPedido = business.Salvar(dto, produtosCarrinho.ToList());

            EstoqueBusiness business2 = new EstoqueBusiness();
            List<PedidoConsultarView> lista = business.ConsultarPorId(idPedido);
            List<EstoqueDTO> estoque = business2.Listar2();

            foreach (PedidoConsultarView item in lista)
            {
                foreach (EstoqueDTO item2 in estoque)
                {
                    if (item.IdProduto == item2.IdProduto)
                    {
                        item2.QtdProduto = item2.QtdProduto - item.QtdItens;
                    }
                }
            }

            foreach (EstoqueDTO item in estoque)
            {
                EstoqueDTO estoquedto = new EstoqueDTO();

                estoquedto.Id = item.Id;
                estoquedto.IdProduto = item.IdProduto;
                estoquedto.QtdProduto = item.QtdProduto;

                business2.Alterar2(estoquedto);
            }

            MessageBox.Show("Pedido Salvo com sucesso", "Quatro estações", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Ocorreu um erro ao cadastrar o pedido: " + ex.Message, "Quatro estações",
            //          MessageBoxButtons.OK,
            //          MessageBoxIcon.Error);

            //}



        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    ProdutoDTO dto = cboProduto.SelectedItem as ProdutoDTO;

            //    int qtd = Convert.ToInt32(txtQuantidade.Text);

            //    for (int i = 0; i < qtd; i++)
            //    {
            //        produtosCarrinho.Add(dto);
            //    }
            //}
            //catch (ArgumentException ex)
            //{
            //    MessageBox.Show(ex.Message, "The Closet",
            //        MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Ocorreru um erro, tente mais tarde.", "The CLoset",
            //        MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            EstoqueBusiness estoquebussiness = new EstoqueBusiness();

            List<EstoqueConsultarView> estoquedto = estoquebussiness.Listar();


            EstoqueConsultarView dto = cboProduto.SelectedItem as EstoqueConsultarView;
            int produtoid = Convert.ToInt32(cboProduto.SelectedValue);
            int qtd = Convert.ToInt32(nudQuantidade.Value);

            int i = 10;

            foreach (EstoqueConsultarView item in estoquedto)
            {
                if (dto.ProdutoId == produtoid)
                {
                    if (i == 0)
                    {
                        if (dto.Quantidade < qtd)
                        {
                            MessageBox.Show("Quantidade de " + dto.Produto + " não é suficiente,atualmente temos em estoque: " + dto.Quantidade, "Hotel For Pets");
                        }
                        else if (dto.Quantidade == qtd)
                        {
                            for (i = 0; i < qtd; i++)

                            {
                                produtosCarrinho.Add(dto);

                            }

                            dto.Quantidade = dto.Quantidade - qtd;

                            dataGridView1.AutoGenerateColumns = false;
                            dataGridView1.DataSource = produtosCarrinho;
                            i = 0;


                        }

                        else
                        {

                            for (i = 0; i < qtd; i++)

                            {
                                produtosCarrinho.Add(dto);

                            }

                            dto.Quantidade = dto.Quantidade - qtd;

                            dataGridView1.AutoGenerateColumns = false;
                            dataGridView1.DataSource = produtosCarrinho;
                            i = 0;
                        }
                    }
                    else
                    {
                        if (dto.Quantidade < qtd)
                        {
                            MessageBox.Show("Quantidade de " + dto.Produto + " não é suficiente,atualmente temos em estoque: " + dto.Quantidade, "Quatro estações");
                        }
                        else
                        {

                            for (i = 0; i < qtd; i++)

                            {
                                produtosCarrinho.Add(dto);

                            }

                            dto.Quantidade = dto.Quantidade - qtd;

                            dataGridView1.AutoGenerateColumns = false;
                            dataGridView1.DataSource = produtosCarrinho;
                            i = 0;
                        }
                    }
                }
            }
        }
        

        private void cboProduto_SelectedIndexChanged(object sender, EventArgs e)
        {

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

                frmMenuFuncionario menu = new frmMenuFuncionario();
                menu.Show();

            }
            else
            {
                frmMenuCliente tela = new frmMenuCliente();
                tela.Show();


            }

            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
