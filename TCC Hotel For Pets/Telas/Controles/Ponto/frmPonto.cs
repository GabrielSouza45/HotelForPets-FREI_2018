using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCC_Hotel_For_Pets.DB.Funcionário.Ponto;
using TCC_Hotel_For_Pets.Telas.Menu_Funcionario;
using TCC_Hotel_For_Pets.Telas.Tela_ADM;

namespace TCC_Hotel_For_Pets.Telas.Controles.Ponto
{
    public partial class frmPonto : Form
    {
        public frmPonto()
        {
            InitializeComponent();
            lblDiaAtual.Text = DateTime.Now.ToShortDateString();
            label4.Text = UserSession.UsuarioLogado.Nome;
            label5.Text = Convert.ToString(UserSession.UsuarioLogado.IdUsuario);
        }

        PontoDTO dto = new PontoDTO();
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (lblDiaAtual.Text == Convert.ToString(dto.Data) && label4.Text == UserSession.UsuarioLogado.Nome)
            {
                MessageBox.Show("Esse funcionário já cadastrou o ponto");
            }
            else
            {
                int horas = dateTimePicker4.Value.Hour - dateTimePicker1.Value.Hour;
                int totalhoras = horas;
                TimeSpan horasalmoco = (dateTimePicker3.Value - dateTimePicker2.Value);
                int totalhorasalmoco = Convert.ToInt32(horasalmoco.TotalHours);
                PontoDTO ponto = new PontoDTO();
                ponto.Data = Convert.ToDateTime(lblDiaAtual.Text);
                ponto.Entrada = dateTimePicker1.Value;
                ponto.IdaAlmoco = dateTimePicker2.Value;
                ponto.VoltaAlmoco = dateTimePicker3.Value;
                ponto.Saida = dateTimePicker4.Value;
                ponto.HorasTrabalhadasDia = totalhoras - totalhorasalmoco;
                ponto.IdFuncionario = Convert.ToInt32(label5.Text);

                PontoBusiness business = new PontoBusiness();
                business.Salvar(ponto);

                EnviarMensagem("Ponto cadastrado com sucesso.");

            }

            this.Hide();
            frmTelaADM tela = new frmTelaADM();
            tela.Show();

        }

        private void EnviarMensagem(string mensagem)
        {
            MessageBox.Show(mensagem, "Hotel For Pets",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Information);
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
            Hide();
        }
    }

}
