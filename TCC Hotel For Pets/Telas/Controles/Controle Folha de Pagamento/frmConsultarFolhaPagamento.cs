using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCC_Hotel_For_Pets.DB.Folha_de_pagamento;
using TCC_Hotel_For_Pets.Telas.Tela_ADM;

namespace TCC_Hotel_For_Pets.Telas.Controles.Controle_Folha_de_Pagamento
{
    public partial class frmConsultarFolhaPagamento : Form
    {
        public frmConsultarFolhaPagamento()
        {
            InitializeComponent();
        }
        public void CarregarGrid()
        {
            try
            {
                FolhaDePagamentoBusiness business = new FolhaDePagamentoBusiness();
                List<FolhadePagamentoView> dto = business.Consultar(txtProduto.Text.Trim());

                dgvProdutos.AutoGenerateColumns = false;
                dgvProdutos.DataSource = dto;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao consultar a folha: " + ex.Message, "Quatro Estações",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error);

            }

        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void dgvProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                FolhadePagamentoView folha = dgvProdutos.CurrentRow.DataBoundItem as FolhadePagamentoView;

                DialogResult r = MessageBox.Show("Deseja excluir a folha?", "Quatro Estações",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {
                    FolhaDePagamentoBusiness business = new FolhaDePagamentoBusiness();
                    business.Remover(folha.IdFolha);
                    CarregarGrid();

                }

            }
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
    }
}
