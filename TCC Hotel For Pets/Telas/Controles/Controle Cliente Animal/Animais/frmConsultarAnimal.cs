using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCC_Hotel_For_Pets.DB.Animal;
using TCC_Hotel_For_Pets.DB.Animal_Cliente;
using TCC_Hotel_For_Pets.Telas.Menu_Funcionario;
using TCC_Hotel_For_Pets.Telas.Menu_inicial;
using TCC_Hotel_For_Pets.Telas.Tela_ADM;

namespace TCC_Hotel_For_Pets.Telas.Controle_Cliente_Animal.Animais
{
    public partial class frmConsultarAnimal : Form
    {
        public frmConsultarAnimal()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                if(UserSession.UsuarioLogado.Adiministrador == false && UserSession.UsuarioLogado.Funcionario == false)
                {
                    MessageBox.Show("Por motivos de segurança aos outros usuários cadastrados, clientes não tem permissão de alterar os dados cadastrados. \n \n Por favor, contate um de nossos administradores. ", "Hotel For Pets", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                ViewConsultarAnimal animal = dgvAnimais.Rows[e.RowIndex].DataBoundItem as ViewConsultarAnimal;

                DialogResult r = MessageBox.Show($"Deseja realmente excluir o Animal {animal.Id}?", "Hotel For Pets",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {

                    AnimalBusiness business = new AnimalBusiness();
                    business.Remover(animal.Id);

                    button1_Click(null, null);
                }
            }
            else if (e.ColumnIndex == 10)
            {
                if (UserSession.UsuarioLogado.Adiministrador == false && UserSession.UsuarioLogado.Funcionario == false)
                {
                    MessageBox.Show("Por motivos de segurança aos outros usuários cadastrados, clientes não tem permissão de excluir os dados cadastrados. \n \n Por favor, contate um de nossos administradores. ", "Hotel For Pets", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                ViewConsultarAnimal animal = dgvAnimais.CurrentRow.DataBoundItem as ViewConsultarAnimal;

                frmAlterarAnimal tela = new frmAlterarAnimal();
                tela.LoadScreen(animal);
                tela.Show();
                Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            AniclienteBusiness business = new AniclienteBusiness();
            List<ViewConsultarAnimal> lista = business.Consultar(txtConsultaAnimal.Text.Trim());

            dgvAnimais.AutoGenerateColumns = false;
            dgvAnimais.DataSource = lista;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (UserSession.UsuarioLogado.Adiministrador == true)
            {
                frmTelaADM menu = new frmTelaADM();
                menu.Show();
                Hide();
            }
            else if (UserSession.UsuarioLogado.Funcionario == true)
            {

                frmMenuFuncionario menu = new frmMenuFuncionario();
                menu.Show();
                Hide();
            }
            else
            {

                frmMenuCliente f = new frmMenuCliente();
                f.Show();
                Hide();
            }

            
        }
    }
}
