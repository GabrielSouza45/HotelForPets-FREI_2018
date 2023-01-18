using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCC_Hotel_For_Pets.DB.Animal;
using TCC_Hotel_For_Pets.DB.Animal_Cliente;
using TCC_Hotel_For_Pets.DB.Cliente;
using TCC_Hotel_For_Pets.DB.Funcionário;
using TCC_Hotel_For_Pets.DB.Login;
using TCC_Hotel_For_Pets.DB.Plugin_EMAIL;
using TCC_Hotel_For_Pets.DB.Usuario;
using TCC_Hotel_For_Pets.Telas;
using TCC_Hotel_For_Pets.Telas.Menu_Funcionario;
using TCC_Hotel_For_Pets.Telas.Tela_ADM;

namespace TCC_Hotel_For_Pets
{
    public partial class frmCadastrarCliente : Form
    {
        public frmCadastrarCliente()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UsuarioDTO dto = new UsuarioDTO();

            dto.Nome = txtNome.Text;
            dto.CPF = txtCPF.Text;
            dto.Telefone = txtTelefone.Text;
            dto.EmailUsu = txtEmail.Text;
            dto.SenhaUsu = txtSenha.Text;
            dto.Adiministrador = false;
            dto.Funcionario = false;

            UsuarioBusiness business = new UsuarioBusiness();
            dto.IdUsuario = business.Salvar(dto);



            int IdUsuarioCliente = dto.IdUsuario;
            ClienteDTO cliente = new ClienteDTO();
            cliente.IdUsuario = IdUsuarioCliente;
            cliente.Nome = txtNome.Text;
            cliente.CPF = txtCPF.Text;
            cliente.Bairro = txtBairro.Text;
            cliente.Rua = txtRua.Text;
            cliente.Telefone = txtTelefone.Text;
            cliente.Email = txtEmail.Text;
            cliente.Senha = txtSenha.Text;
            cliente.CEP = Convert.ToInt32(txtCEP.Text.Replace("-", ""));



            ClienteBusiness businesss = new ClienteBusiness();
            cliente.Id = businesss.Salvar(cliente);

            int IdCliente = cliente.Id;
            AniclienteDTO ani = new AniclienteDTO();
            ani.IdCliente = IdCliente;

            DialogResult c = MessageBox.Show($"Enviar automaticamente um Email para o cliente {cliente.Nome}, informando o login, senha e telefone cadastrados?", "Hotel For Pets",
                                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (c == DialogResult.Yes)
            {


                string nome = txtNome.Text;
                string telefone = txtTelefone.Text;
                string senha = txtSenha.Text;
                string emaill = txtEmail.Text;
                string conteudo = string.Empty;




                conteudo = "Olá, " + nome + " seu cadastro foi realizado com sucesso. \n \n Seu Login é: " + emaill + "\n \n Senha: " + senha + " \n \n Telefone: " + telefone;


                Email email = new Email();
                email.Enviar(txtEmail.Text, conteudo);


                MessageBox.Show("Cliente cadastrado com sucesso.");
                MessageBox.Show("Um Email foi enviado para a conta registrada informando seu usuario e senha.");

            }
            MessageBox.Show("Cliente cadastrado com sucesso.");
        }

        private void frmForm1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmCadastrarAnimal tela = new frmCadastrarAnimal();
            tela.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(UserSession.UsuarioLogado == null)
            {
                frmLogin menu = new frmLogin();
                menu.Show();
                this.Hide();
            }
            else if (UserSession.UsuarioLogado.Adiministrador == true)
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
                
            }
               
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }
        private CorreioFunc BuscarAPICorreio(string cep)
        {

            WebClient rest = new WebClient();
            rest.Encoding = Encoding.UTF8;


            string resposta = rest.DownloadString("https://viacep.com.br/ws/" + cep + "/json");


            CorreioFunc correio = JsonConvert.DeserializeObject<CorreioFunc>(resposta);
            return correio;
        }

        private void maskedTextBox1_Leave(object sender, EventArgs e)
        {
            string cep = txtCEP.Text.Trim().Replace("-", "");

            CorreioFunc correio = BuscarAPICorreio(cep);

            txtRua.Text = correio.Logradouro;
            txtBairro.Text = correio.Bairro;
        }

        private void txtCEP_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtSenha.PasswordChar = '\u0000';
               
            }
            else if (checkBox1.Checked == false)
            {
                txtSenha.PasswordChar = '*';

            }
        }

        private void txtCEP_Click(object sender, EventArgs e)
        {
            txtCEP.Select(0, 0);
        }

        private void txtCPF_Click(object sender, EventArgs e)
        {
            txtCPF.Select(0, 0);
        }

        private void txtTelefone_Click(object sender, EventArgs e)
        {
            txtTelefone.Select(0, 0);
        }

        private void txtSenha_Click(object sender, EventArgs e)
        {
            txtSenha.Select(0, 0);
        }
    }
}
