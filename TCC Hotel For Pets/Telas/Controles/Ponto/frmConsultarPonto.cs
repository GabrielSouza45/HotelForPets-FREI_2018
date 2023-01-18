using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCC_Hotel_For_Pets.DB.Funcionário.Ponto;
using TCC_Hotel_For_Pets.Telas.Menu_Funcionario;
using TCC_Hotel_For_Pets.Telas.Tela_ADM;

namespace TCC_Hotel_For_Pets.Telas.Controles.Ponto
{
    public partial class frmConsultarPonto : Form
    {
        public frmConsultarPonto()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
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
                MessageBox.Show("Você não deveria ter acesso a essa tela, isso será relatado aos administradores do sistema!", "Hotel For Pets", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            }
            Hide();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            PontoBusiness business = new PontoBusiness();
            List<PontoConsultarView> dto = business.Consultar(txtFuncionario.Text.Trim());


            dgvPontos.AutoGenerateColumns = false;
            dgvPontos.DataSource = dto;
        }
    }
}
