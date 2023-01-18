using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCC_Hotel_For_Pets.DB.Funcionário;
using TCC_Hotel_For_Pets.Telas.Menu_Funcionario;
using TCC_Hotel_For_Pets.Telas.Menu_inicial;
using TCC_Hotel_For_Pets.Telas.Tela_ADM;

namespace TCC_Hotel_For_Pets.Telas.Controles.Controle_Funcionário
{
    public partial class frmConsultarADMCliente : Form
    {
        public frmConsultarADMCliente()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {

            if (UserSession.UsuarioLogado.Adiministrador == true)
            {
                frmTelaADM menu = new frmTelaADM();
                menu.Show();
                this.Hide();
            }
            else if (UserSession.UsuarioLogado.Funcionario == true)
            {

                frmMenuFuncionario menu = new frmMenuFuncionario();
                menu.Show();
                this.Hide();
            }
            else
            {
                frmMenuCliente menu = new frmMenuCliente();
                menu.Show();
                this.Hide();
            }

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            FuncionarioBusiness business = new FuncionarioBusiness();
            List<FuncionarioDTO> lista = business.ConsultarADM(txtNomFunc.Text.Trim());

            dgvFuncionario.AutoGenerateColumns = false;
            dgvFuncionario.DataSource = lista;
        }
    }
}
