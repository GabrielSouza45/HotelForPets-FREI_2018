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
using TCC_Hotel_For_Pets.DB.Fornecedor;
using TCC_Hotel_For_Pets.DB.Funcionário;

namespace TCC_Hotel_For_Pets.Telas.Controle_Fornecedor
{
    public partial class frmAlterarFornecedor : Form
    {
        public frmAlterarFornecedor()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        FornecedorDTO fornecedor;


        public void LoadScreen(FornecedorDTO fornecedor)
        {
            this.fornecedor = fornecedor;

            lblId.Text = fornecedor.Id.ToString();
            txtNome.Text = fornecedor.Nome;
            txtTelefone.Text = fornecedor.Telefone;
            txtRua.Text = fornecedor.Rua;
            txtNumero.Text = fornecedor.Numero;
            txtEstado.Text = fornecedor.Estado;
            txtCidade.Text = fornecedor.Cidade;
            txtCep.Text = fornecedor.Cep;
            txtBairro.Text = fornecedor.Bairro;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            
            
                
                fornecedor.Nome = txtNome.Text;
                fornecedor.Telefone = txtTelefone.Text;
                fornecedor.Cidade = txtCidade.Text;
                fornecedor.Estado = txtEstado.Text;
                fornecedor.Bairro = txtBairro.Text;
                fornecedor.Rua = txtRua.Text;
                fornecedor.Numero = txtNumero.Text;
                fornecedor.Cep = txtCep.Text;

                FornecedorBusiness business = new FornecedorBusiness();
                business.Alterar(fornecedor);


                MessageBox.Show("Fornecedor alterado com sucesso.");
            
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmConsultarFornecedor tela = new frmConsultarFornecedor();
            tela.Show();
            Hide();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
       
        }

        private void txtCep_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
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
            string cep = txtCep.Text.Trim().Replace("-", "");

            CorreioFunc correio = BuscarAPICorreio(cep);

            txtRua.Text = correio.Logradouro;
            txtBairro.Text = correio.Bairro;
        }

        private void txtTelefone_Click(object sender, EventArgs e)
        {
            txtTelefone.Select(0, 0);
        }

        private void txtCep_Click(object sender, EventArgs e)
        {
            txtCep.Select(0, 0);
        }
    }
}
