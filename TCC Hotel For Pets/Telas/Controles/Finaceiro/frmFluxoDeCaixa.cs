using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCC_Hotel_For_Pets.DB.Financias.Fluxo;
using TCC_Hotel_For_Pets.Telas.Tela_ADM;

namespace TCC_Hotel_For_Pets.Telas.Controles.Finaceiro
{
    public partial class frmFluxoDeCaixa : Form
    {
        public frmFluxoDeCaixa()
        {
            InitializeComponent();
        }
        void CarregarGrid()
        {
            FluxoBusiness business = new FluxoBusiness();
            List<FluxoDTO> lista = business.Consultar(dateTimePicker1.Value, dateTimePicker2.Value);

            dgvFluxo.AutoGenerateColumns = false;
            dgvFluxo.DataSource = lista;

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
          
        }

        private void dgvFluxo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnVoltarMenuADMFornecedores_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void button1_Click(object sender, EventArgs e)
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
