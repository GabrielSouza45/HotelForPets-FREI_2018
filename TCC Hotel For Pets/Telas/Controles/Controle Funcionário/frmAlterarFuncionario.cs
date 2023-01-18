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
using TCC_Hotel_For_Pets.DB.Funcionário;
using TCC_Hotel_For_Pets.DB.Login;
using TCC_Hotel_For_Pets.DB.Usuario;
using TCC_Hotel_For_Pets.Telas.Cadastrar_Funcionário;
using TCC_Hotel_For_Pets.Telas.Menu_Funcionario;
using TCC_Hotel_For_Pets.Telas.Tela_ADM;

namespace TCC_Hotel_For_Pets.Telas.Controle_Funcionário
{
    public partial class frmAlterarFuncionario : Form
    {
        public frmAlterarFuncionario()
        {
            InitializeComponent();
        }

        FuncionarioDTO func;


        public void LoadScreen(FuncionarioDTO func)
        {
            this.func = func;

            lblId.Text = func.Id.ToString();
            txtNome.Text = func.Nome;
            dtpNasc.Value = func.DataNasc;
            txtCPF.Text = func.CPF;
            txtTelefone.Text = func.Telefone;
            txtCelular1.Text = func.Celular;
            txtCargo.Text = func.Cargo;
            txtEmail.Text = func.Email;
            txtSenha.Text = func.Senha;
            txtRua.Text = func.Rua;
            txtNumero.Text = func.Numero;
            txtBairro.Text = func.Bairro;
            txtCidade.Text = func.Cidade;
            txtCEP.Text = Convert.ToString(func.CEP);
            txtEstado.Text = func.Estado;
            txtVR.Text = Convert.ToString(func.VR);
            txtVT.Text = Convert.ToString(func.VT);
            txtCM.Text = Convert.ToString(func.Convenio);
            txtSalario.Text = Convert.ToString(func.SalarioLiquido);
            rdbADM.Checked = func.ADM;
            rdbFuncionario.Checked = func.Funcionario;

        }

        private void btnCadastrarAnimal_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void frmAlterarFuncionario_Load(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {

            frmCadastrarFuncionario tela = new frmCadastrarFuncionario();
            tela.Show();
            Hide();
        }





        private void btnConsultar_Click(object sender, EventArgs e)
        {
            frmConsultarFuncionario tela = new frmConsultarFuncionario();
            tela.Show();
            Hide();
        }

        private void btnCadastrar_Click_1(object sender, EventArgs e)
        {


            frmConsultarFuncionario tela = new frmConsultarFuncionario();
            tela.Show();
            Hide();



        }

        private void txtSenhaConf_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {
            if (txtSenha.Text.Equals(txtSenhaConfi.Text))
            {
                txtSenhaConfi.BackColor = Color.MediumSpringGreen;
            }

            else
            {
                txtSenhaConfi.BackColor = Color.Red;
            }
        }

        private void btnCadastrarFuncionario_Click(object sender, EventArgs e)
        {
            
        }

        private void txtSenha_Leave(object sender, EventArgs e)
        {

        }

        private void txtSenhaConfi_TextChanged(object sender, EventArgs e)
        {
            if (txtSenhaConfi.Text.Equals(txtSenha.Text))
            {
                txtSenhaConfi.BackColor = Color.MediumSpringGreen;
            }

            else
            {
                txtSenhaConfi.BackColor = Color.Red;
            }
        }

        private void btnConsultar_Click_1(object sender, EventArgs e)
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
        private void txtCEP_Leave(object sender, EventArgs e)
        {
            string cep = txtCEP.Text.Trim().Replace("-", "");

            CorreioFunc correio = BuscarAPICorreio(cep);

            txtRua.Text = correio.Logradouro;
            txtBairro.Text = correio.Bairro;
        }

        private void txtCEP_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void btnCadastrarFuncionario_Click_1(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(dtpNasc.Value).AddYears(18) < DateTime.Now)
            {
            }
            else
            {
                MessageBox.Show("Funcionário deve ter mais de 18 anos.", "Hotel For pets", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            UsuarioDTO dto = new UsuarioDTO();

            dto.Nome = txtNome.Text;
            dto.CPF = txtCPF.Text;
            dto.Telefone = txtTelefone.Text;
            dto.EmailUsu = txtEmail.Text;
            dto.SenhaUsu = txtSenha.Text;


            UsuarioBusiness busines = new UsuarioBusiness();
            busines.Alterar(dto);

            func.Nome = txtNome.Text;
            func.DataNasc = dtpNasc.Value;
            func.CPF = txtCPF.Text;
            func.Telefone = txtTelefone.Text;
            func.Celular = txtCelular1.Text;
            func.Cargo = txtCargo.Text;
            func.Email = txtEmail.Text;
            func.Senha = txtSenha.Text;
            func.Rua = txtRua.Text;
            func.Numero = txtNumero.Text;
            func.Bairro = txtBairro.Text;
            func.Cidade = txtCidade.Text;
            func.CEP = Convert.ToInt32(txtCEP.Text.Replace("-", ""));
            func.Estado = txtEstado.Text;
            func.VR = Convert.ToDecimal(txtVR.Text);
            func.VT = Convert.ToDecimal(txtVT.Text);
            func.Convenio = Convert.ToDecimal(txtCM.Text);
            func.SalarioLiquido = Convert.ToDecimal(txtSalario.Text);
            func.ADM = rdbADM.Checked;
            func.Funcionario = rdbFuncionario.Checked;

            FuncionarioBusiness business = new FuncionarioBusiness();
            business.Alterar(func);




            MessageBox.Show("Funcionario alterado com sucesso.");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtSenha.PasswordChar = '\u0000';
                txtSenhaConfi.PasswordChar = '\u0000';
            }
            else if (checkBox1.Checked == false)
            {
                txtSenha.PasswordChar = '*';
                txtSenhaConfi.PasswordChar = '*';
            }
        }

        private void txtCEP_Click(object sender, EventArgs e)
        {
            txtCEP.Select(0, 0);
        }

        private void txtCelular1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtCelular1_Click(object sender, EventArgs e)
        {
            txtCelular1.Select(0, 0);
        }

        private void txtCPF_Click(object sender, EventArgs e)
        {
            txtCPF.Select(0, 0);
        }

        private void txtTelefone_Click(object sender, EventArgs e)
        {
            txtTelefone.Select(0, 0);
        }
    }
}

