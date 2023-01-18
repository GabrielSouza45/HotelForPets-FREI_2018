using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCC_Hotel_For_Pets.DB.Financias.Gastos;
using TCC_Hotel_For_Pets.Telas.Menu_Funcionario;
using TCC_Hotel_For_Pets.Telas.Tela_ADM;

namespace TCC_Hotel_For_Pets.Telas.Controles.Finaceiro
{
    public partial class frmConsultarGastos : Form
    {
        public frmConsultarGastos()
        {
            InitializeComponent();
        }
        void CarregarGrid()
        {
            GastosBusiness business = new GastosBusiness();
            List<GastosDTO> lista = business.Consultar(dateTimePicker1.Value, dateTimePicker2.Value);

            dgvPedidos.AutoGenerateColumns = false;
            dgvPedidos.DataSource = lista;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            CarregarGrid();
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


            this.Hide();
        }
    }
}
