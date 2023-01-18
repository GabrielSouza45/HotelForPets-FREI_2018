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
using TCC_Hotel_For_Pets.DB.Usuario;
using TCC_Hotel_For_Pets.Telas.Cadastrar_Funcionário;
using TCC_Hotel_For_Pets.Telas.Menu_Funcionario;
using TCC_Hotel_For_Pets.Telas.Tela_ADM;

namespace TCC_Hotel_For_Pets.Telas.Controle_Funcionário
{
    public partial class frmConsultarFuncionario : Form
    {
        public frmConsultarFuncionario()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10)
            {
                FuncionarioDTO funcionario = dgvFuncionario.Rows[e.RowIndex].DataBoundItem as FuncionarioDTO;

                DialogResult r = MessageBox.Show($"Deseja realmente excluir o funcionario {funcionario.Id}?", "Hotel For Pets",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {
                   
                    FuncionarioBusiness business = new FuncionarioBusiness();
                    business.Remover(funcionario.Id);

                    UsuarioBusiness busines = new UsuarioBusiness();
                    busines.Remover(funcionario.Id);

                    btnPesquisar_Click(null, null);
                }
            }
            else if(e.ColumnIndex == 11)
            {
                 

                FuncionarioDTO funcionario = dgvFuncionario.CurrentRow.DataBoundItem as FuncionarioDTO;

                frmAlterarFuncionario tela = new frmAlterarFuncionario();
                tela.LoadScreen(funcionario);
                tela.Show();
                Hide();
            }


        }

        private void frmConsultarFuncionario_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            FuncionarioBusiness business = new FuncionarioBusiness();
            List<FuncionarioDTO> lista = business.Consultar(txtNomFunc.Text.Trim());

            dgvFuncionario.AutoGenerateColumns = false;
            dgvFuncionario.DataSource = lista;
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
           

           
        }
    }
}
