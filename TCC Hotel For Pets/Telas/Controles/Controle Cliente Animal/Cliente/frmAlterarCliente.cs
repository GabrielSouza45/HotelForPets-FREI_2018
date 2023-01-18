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
using TCC_Hotel_For_Pets.DB.Cliente;
using TCC_Hotel_For_Pets.DB.Funcionário;
using TCC_Hotel_For_Pets.DB.Login;
using TCC_Hotel_For_Pets.DB.Usuario;

namespace TCC_Hotel_For_Pets.Telas.Controle_Cliente_Animal.Cliente
{
    public partial class frmAlterarCliente : Form
    {
        public frmAlterarCliente()
        {
            InitializeComponent();
        }

        ClienteDTO cliente;
        public void LoadScreen(ClienteDTO cliente)
        {
            this.cliente = cliente;

            lblId.Text = cliente.Id.ToString();
            txtNome.Text = cliente.Nome;
            txtCpf.Text = cliente.CPF;
            txtBairro.Text = cliente.Bairro;
            txtRua.Text = cliente.Rua;
            txtTelefone.Text = cliente.Telefone;
            txtCEP.Text = cliente.CEP.ToString();
            txtEmail.Text = cliente.Email;
            txtSenha.Text = cliente.Senha;
        }

        private void frmAlterarCliente_Load(object sender, EventArgs e)
        {

        }

        private void btnCadastrarAnimal_Click(object sender, EventArgs e)
        {
            UsuarioDTO dto = new UsuarioDTO();
            dto.Nome = txtNome.Text;
            dto.CPF = txtCpf.Text;
            dto.Telefone = txtTelefone.Text;
            dto.EmailUsu = txtEmail.Text;
            dto.SenhaUsu = txtSenha.Text;

            //UsuarioBusiness busines = new UsuarioBusiness();
            //busines.Alterar(dto);


            
            
            cliente.Nome = txtNome.Text;
            cliente.CPF = txtCpf.Text;
            cliente.Bairro = txtBairro.Text;
            cliente.Rua = txtRua.Text;
            cliente.Telefone = txtTelefone.Text;
            cliente.CEP = Convert.ToInt32(txtCEP.Text.Replace("-", ""));
            cliente.Email = txtEmail.Text;
            cliente.Senha = txtSenha.Text;

            ClienteBusiness business = new ClienteBusiness();
            business.Alterar(cliente, dto);

            MessageBox.Show("Cliente alterado com sucesso");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmConsultarCliente t = new frmConsultarCliente();
            t.Show();
            Hide();
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
        private CorreioFunc BuscarAPICorreio(string cep)
        {

            WebClient rest = new WebClient();
            rest.Encoding = Encoding.UTF8;


            string resposta = rest.DownloadString("https://viacep.com.br/ws/" + cep + "/json");


            CorreioFunc correio = JsonConvert.DeserializeObject<CorreioFunc>(resposta);
            return correio;
        }
        private void txtCEP_Leave(object sender, EventArgs e)
        {
            string cep = txtCEP.Text.Trim().Replace("-", "");

            CorreioFunc correio = BuscarAPICorreio(cep);

            txtRua.Text = correio.Logradouro;
            txtBairro.Text = correio.Bairro;
        }
        private void txtCEP_Click(object sender, EventArgs e)
        {
            txtCEP.Select(0, 0);
        }

        private void txtCpf_Click(object sender, EventArgs e)
        {
            txtCpf.Select(0, 0);
        }

        private void txtTelefone_Click(object sender, EventArgs e)
        {
            txtTelefone.Select(0, 0);
        }

        private void txtSenha_Click(object sender, EventArgs e)
        {
            txtSenha.Select(0, 0);
        }

        private void txtCpf_ChangeUICues(object sender, UICuesEventArgs e)
        {

        }
    }
}
