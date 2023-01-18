using System;
using System.Windows.Forms;
using TCC_Hotel_For_Pets.DB.Login;
using TCC_Hotel_For_Pets.Telas.Cadastrar_Funcionário;
using TCC_Hotel_For_Pets.Telas.Menu_Funcionario;
using TCC_Hotel_For_Pets.Telas.Menu_inicial;
using TCC_Hotel_For_Pets.Telas.Tela_ADM;

namespace TCC_Hotel_For_Pets.Telas
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtCPF_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblnome_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            LoginBusiness business = new LoginBusiness();
            UsuarioDTO usuario = business.Logar(txtLogin.Text, txtSenha.Text);

            if (usuario != null)
            {
                UserSession.UsuarioLogado = usuario;

                if (usuario.Adiministrador == true)
                {
                    frmTelaADM menu = new frmTelaADM();
                    menu.Show();

                }
                else if (usuario.Funcionario == true)
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
            else
            {
                MessageBox.Show("Credenciais inválidas.", "Hotel For Pets", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            frmCadastrarCliente tela = new frmCadastrarCliente();
            tela.Show();
            Hide();
        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtSenha.UseSystemPasswordChar = false;

            }
            else if (checkBox1.Checked == false)
            {
                txtSenha.UseSystemPasswordChar = true;

            }
        }
    }
    
}
