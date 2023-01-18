using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCC_Hotel_For_Pets.DB.Financias.Gastos;
using TCC_Hotel_For_Pets.Telas.Menu_Funcionario;
using TCC_Hotel_For_Pets.Telas.Tela_ADM;

namespace TCC_Hotel_For_Pets.Telas.Controles.Finaceiro
{
    public partial class frmCadastrarGastos : Form
    {
        public frmCadastrarGastos()
        {
            InitializeComponent();
        }

        private void btnEmitir_Click(object sender, EventArgs e)
        {
            GastosDTO dto = new GastosDTO();
            dto.Nome = textBox1.Text.Trim();
            dto.Data = dateTimePicker1.Value;
            dto.Valor = numericUpDown1.Value;
            dto.Tipo = comboBox1.Text;

            GastosBusiness business = new GastosBusiness();
            business.Salvar(dto);

            MessageBox.Show("Gasto cadastrado com sucesso", "Hotel For Pets");

        }

        private void btnVoltarMenuADMFornecedores_Click(object sender, EventArgs e)
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

                MessageBox.Show("Você não deveria ter acesso a essa tela, isso será relatado aos administradores do sistema!", "Hotel For Pets", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            }


            this.Hide();
        }

        private void frmCadastrarGastos_Load(object sender, EventArgs e)
        {

        }
    }
}
