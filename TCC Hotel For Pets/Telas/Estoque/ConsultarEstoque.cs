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
using TCC_Hotel_For_Pets.Telas.Menu_Funcionario;
using TCC_Hotel_For_Pets.Telas.Tela_ADM;

namespace TCC_Hotel_For_Pets.Telas.Estoque
{
    public partial class ConsultarEstoque : Form
    {
        public ConsultarEstoque()
        {
            InitializeComponent();
        }
      

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            EstoqueBusiness business = new EstoqueBusiness();
            List<EstoqueConsultarView> lista = business.Consultar(txtProduto.Text.Trim());

            dgvEstoque.AutoGenerateColumns = false;
            dgvEstoque.DataSource = lista;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

                frmMenuFuncionario f = new frmMenuFuncionario();
                f.Show();
                Hide();
            }
            else
            {

                MessageBox.Show("Você não deveria ter acesso a essa tela, isso será relatado aos administradores do sistema!", "Hotel For Pets", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            Hide();
        }
    }
}
