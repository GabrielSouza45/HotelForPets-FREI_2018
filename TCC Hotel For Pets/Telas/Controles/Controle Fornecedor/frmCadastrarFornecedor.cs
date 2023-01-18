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
using TCC_Hotel_For_Pets.DB.Fornecedor;
using TCC_Hotel_For_Pets.DB.Funcionário;
using TCC_Hotel_For_Pets.Telas.Menu_Funcionario;
using TCC_Hotel_For_Pets.Telas.Tela_ADM;

namespace TCC_Hotel_For_Pets.Telas.Controle_Fornecedor
{
    public partial class frmCadastrarFornecedor : Form
    {
        public frmCadastrarFornecedor()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmCadastrarFornecedor_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FornecedorDTO dto = new FornecedorDTO();
            dto.Nome = txtNome.Text;
            dto.Telefone = txtTelefone.Text;
            dto.Cidade = txtCidade.Text;
            dto.Estado = txtEstado.Text;
            dto.Bairro = txtBairro.Text;
            dto.Rua = txtRua.Text;
            dto.Numero = txtNumero.Text;
            dto.Cep = txtCep.Text;

            FornecedorBusiness business = new FornecedorBusiness();
            business.Salvar(dto);
            MessageBox.Show("Fornecedor cadastrado com sucesso!", "Hotel For Pets");
        }

        private void btnConsultar_Click(object sender, EventArgs e)
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

        private void txtNumero_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEstado_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCidade_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCep_TextChanged(object sender, EventArgs e)
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
        private void txtCep_Leave(object sender, EventArgs e)
        {
         
        }

        private void txtCep_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtCep_Leave_1(object sender, EventArgs e)
        {
            string cep = txtCep.Text.Trim().Replace("-", "");

            CorreioFunc correio = BuscarAPICorreio(cep);

            txtRua.Text = correio.Logradouro;
            txtBairro.Text = correio.Bairro;
            txtCidade.Text = correio.Localidade;
            txtEstado.Text = correio.UF;
        }

        private void txtCep_Click(object sender, EventArgs e)
        {
            txtCep.Select(0, 0);
        }

        private void txtTelefone_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtTelefone_Click(object sender, EventArgs e)
        {
            txtTelefone.Select(0, 0);
        }
    }
}
