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
using TCC_Hotel_For_Pets.DB.Plugin_EMAIL;
using TCC_Hotel_For_Pets.DB.Usuario;
using TCC_Hotel_For_Pets.Telas.Controle_Funcionário;
using TCC_Hotel_For_Pets.Telas.Tela_ADM;

namespace TCC_Hotel_For_Pets.Telas.Cadastrar_Funcionário
{
    public partial class frmCadastrarFuncionario : Form
    {
        public frmCadastrarFuncionario()
        {
            InitializeComponent();
        }


        private CorreioFunc BuscarAPICorreio(string cep)
        {

            WebClient rest = new WebClient();
            rest.Encoding = Encoding.UTF8;


            string resposta = rest.DownloadString("https://viacep.com.br/ws/" + cep + "/json");


            CorreioFunc correio = JsonConvert.DeserializeObject<CorreioFunc>(resposta);
            return correio;
        }


        private void label15_Click(object sender, EventArgs e)
        {

        }
        public UsuarioDTO ConsultarPorUsuario(string usuario)
        {
            UsuarioDatabase db = new UsuarioDatabase();
            return db.ConsultarPorUsuario(usuario);
        }

        private void btnCadastrarFuncionario_Click(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(dtpNasc.Value).AddYears(18) < DateTime.Now)
            {
                UsuarioDTO dto = new UsuarioDTO();

                dto.Nome = txtNome.Text;
                dto.CPF = txtCPF.Text;
                dto.Telefone = txtTelefone.Text;
                dto.Celular = txtCelular1.Text;
                dto.EmailUsu = txtEmail.Text;
                dto.SenhaUsu = txtSenha.Text;
                dto.Funcionario = rdbFuncionario.Checked;
                dto.Adiministrador = rdbADM.Checked;

                UsuarioDTO usuario = this.ConsultarPorUsuario(dto.Nome);
                if (usuario != null)
                {

                    DialogResult d = MessageBox.Show($"Usuario já cadastrado no sistema. \n Deseja cadastrar novamente?", "Hotel For Pets",
                                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d == DialogResult.Yes)
                    {
                        UsuarioBusiness business = new UsuarioBusiness();
                        dto.IdUsuario = business.Salvar(dto);
                        int IdUsuarioFun = dto.IdUsuario;

                        FuncionarioDTO funci = new FuncionarioDTO();
                        funci.Id = IdUsuarioFun;
                        funci.Nome = txtNome.Text;
                        funci.CPF = txtCPF.Text;
                        funci.Cargo = txtCargo.Text;
                        funci.Celular = txtCelular1.Text;
                        funci.Senha = txtSenha.Text;
                        funci.DataNasc = dtpNasc.Value;
                        funci.Telefone = txtTelefone.Text;
                        funci.Email = txtEmail.Text;
                        funci.Rua = txtRua.Text;
                        funci.Bairro = txtBairro.Text;
                        funci.CEP = Convert.ToInt32(txtCEP.Text.Replace("-", ""));
                        funci.Numero = txtNumero.Text;
                        funci.Cidade = txtCidade.Text;
                        funci.Estado = txtEstado.Text;
                        funci.ADM = rdbADM.Checked;
                        funci.Funcionario = rdbFuncionario.Checked;
                        funci.VT = Convert.ToDecimal(txtVT.Text);
                        funci.VR = Convert.ToDecimal(txtVR.Text);
                        funci.Convenio = Convert.ToDecimal(txtCM.Text);
                        funci.SalarioLiquido = Convert.ToDecimal(txtSalario.Text);



                        FuncionarioBusiness busine = new FuncionarioBusiness();
                        funci.Id = busine.Salvar(funci);

                        MessageBox.Show("Funcionário cadastrado com sucesso.");


                        DialogResult c = MessageBox.Show($"Enviar automaticamente um Email para o funcionário {funci.Nome}, informando o login, senha, cargo e telefone cadastrados?", "Hotel For Pets",
                                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (c == DialogResult.Yes)
                        {

                            string nome = txtNome.Text;
                            string telefone = txtTelefone.Text;
                            string senha = txtSenha.Text;
                            string emaill = txtEmail.Text;
                            string cargo = txtCargo.Text;
                            string conteudo = string.Empty;


                            conteudo = "Olá, " + nome + " seu cadastro foi realizado com sucesso. \n \n Seu Login é: " + emaill + "\n \n Senha: " + senha + "\n \n Cargo: " + cargo + " \n \n Telefone: " + telefone;


                            Email email = new Email();
                            email.Enviar(txtEmail.Text, conteudo);

                            MessageBox.Show("Email enviado com sucesso!", "Hotel For Pets");
                        }






                    }

                }
                else
                {
                    UsuarioBusiness busi = new UsuarioBusiness();
                    dto.IdUsuario = busi.Salvar(dto);
                    int IdUsuarioFunc = dto.IdUsuario;

                    FuncionarioDTO func = new FuncionarioDTO();
                    func.Id = IdUsuarioFunc;
                    func.Nome = txtNome.Text;
                    func.CPF = txtCPF.Text;
                    func.Cargo = txtCargo.Text;
                    func.Celular = txtCelular1.Text;
                    func.Senha = txtSenha.Text;
                    func.DataNasc = dtpNasc.Value;
                    func.Telefone = txtTelefone.Text;
                    func.Email = txtEmail.Text;
                    func.Rua = txtRua.Text;
                    func.Bairro = txtBairro.Text;
                    func.CEP = Convert.ToInt32(txtCEP.Text.Replace("-", ""));
                    func.Numero = txtNumero.Text;
                    func.Cidade = txtCidade.Text;
                    func.Estado = txtEstado.Text;
                    func.ADM = rdbADM.Checked;
                    func.Funcionario = rdbFuncionario.Checked;
                    func.VT = Convert.ToDecimal(txtVT.Text);
                    func.VR = Convert.ToDecimal(txtVR.Text);
                    func.Convenio = Convert.ToDecimal(txtCM.Text);
                    func.SalarioLiquido = Convert.ToDecimal(txtSalario.Text);



                    FuncionarioBusiness businesss = new FuncionarioBusiness();
                    func.Id = businesss.Salvar(func);

                    MessageBox.Show("Funcionário cadastrado com sucesso.");


                    DialogResult r = MessageBox.Show($"Enviar automaticamente um Email para o funcionário {func.Nome}, informando o login, senha, cargo e telefone cadastrados?", "Hotel For Pets",
                                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {

                        string nome = txtNome.Text;
                        string telefone = txtTelefone.Text;
                        string senha = txtSenha.Text;
                        string emaill = txtEmail.Text;
                        string cargo = txtCargo.Text;
                        string conteudo = string.Empty;


                        conteudo = "Olá, " + nome + " seu cadastro foi realizado com sucesso. \n \n Seu Login é: " + emaill + "\n \n Senha: " + senha + "\n \n Cargo: " + cargo + " \n \n Telefone: " + telefone;


                        Email email = new Email();
                        email.Enviar(txtEmail.Text, conteudo);

                        MessageBox.Show("Email enviado com sucesso!", "Hotel For Pets");
                    }
                }


            }
            else
            {
                MessageBox.Show("Funcionário deve ter mais de 18 anos.", "Hotel For pets", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }



        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail == null)
            {
                MessageBox.Show("Email não pode estar vazio.");
            }
            //Verifica se tem @ e . no e-mail
            if (txtEmail.Text.Contains("@") && txtEmail.Text.Contains("."))
            {
                //Divide em antes e depois do @
                string[] campos = txtEmail.Text.Split('@');

                //se tiver mais que 1 arroba, não é valido
                if (campos.Length != 2)
                {
                    MessageBox.Show("Esse Email parece estar incorreto.");
                }
                //se for menor que 4 caracteres, tá errado
                if (campos[0].Length < 3)
                {
                    MessageBox.Show("Esse Email parece estar incorreto.");
                }
                //Agora eu pego depois do arroba e divido os pontos
                if (!campos[1].Contains("."))
                {
                    MessageBox.Show("Esse Email parece estar incorreto.");

                    campos = campos[1].Split('.');
                }
                //se for menor que 4, é falso
                if (campos[0].Length < 3)
                {
                    MessageBox.Show("Esse Email parece estar incorreto.");

                }
            }
        }

        private void frmCadastrarFuncionario_Load(object sender, EventArgs e)
        {

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (UserSession.UsuarioLogado != null && UserSession.UsuarioLogado.Adiministrador == true)
            {
                frmTelaADM menu = new frmTelaADM();
                menu.Show();
            }
            else
            {
                frmLogin t = new frmLogin();
                t.Show();

            }


            this.Hide();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCargo_TextChanged(object sender, EventArgs e)
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

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRua_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBairro_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtCEP_Leave(object sender, EventArgs e)
        {
            string cep = txtCEP.Text.Trim().Replace("-", "");

            CorreioFunc correio = BuscarAPICorreio(cep);

            txtRua.Text = correio.Logradouro;
            txtBairro.Text = correio.Bairro;
            txtCidade.Text = correio.Localidade;
            txtEstado.Text = correio.UF;
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

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

        private void txtCelular1_Click(object sender, EventArgs e)
        {
            txtCelular1.Select(0, 0);
        }

        private void txtCPF_Click(object sender, EventArgs e)
        {
            txtCPF.Select(0, 0);
        }

        private void txtTelefone_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtTelefone_Click(object sender, EventArgs e)
        {
            txtTelefone.Select(0, 0);
        }

        private void txtCEP_Click(object sender, EventArgs e)
        {
            txtCEP.Select(0, 0);
        }
    }
}
