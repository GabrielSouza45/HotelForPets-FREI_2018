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
using TCC_Hotel_For_Pets.DB.Usuario;
using TCC_Hotel_For_Pets.Telas.Menu_Funcionario;
using TCC_Hotel_For_Pets.Telas.Tela_ADM;

namespace TCC_Hotel_For_Pets.Telas.Controle_Cliente_Animal.Cliente
{
    public partial class frmConsultarCliente : Form
    {
        public frmConsultarCliente()
        {
            InitializeComponent();
        }

        private void frmConsultarCliente_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
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
                MessageBox.Show("Você não tem permissão para acessar essa tela.", "Hotel For Pets", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


            }

            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                ClienteDTO cliente = dgvCliente.Rows[e.RowIndex].DataBoundItem as ClienteDTO;


                DialogResult r = MessageBox.Show($"Deseja realmente excluir o cliente {cliente.Id}?", "Hotel For Pets",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {

                    UsuarioBusiness bus = new UsuarioBusiness();
                    bus.Remover(cliente.IdUsuario);
                    ClienteBusiness business = new ClienteBusiness();
                    business.Remover(cliente.Id);
                    button1_Click(null, null);
                }
            }
            else if (e.ColumnIndex == 7)
            {


                ClienteDTO cliente = dgvCliente.CurrentRow.DataBoundItem as ClienteDTO;

                frmAlterarCliente tela = new frmAlterarCliente();
                tela.LoadScreen(cliente);
                tela.Show();
                Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClienteBusiness business = new ClienteBusiness();
            List<ClienteDTO> lista = business.Consultar(txtCliente.Text.Trim());

            dgvCliente.AutoGenerateColumns = false;
            dgvCliente.DataSource = lista;
        }
    }
}
