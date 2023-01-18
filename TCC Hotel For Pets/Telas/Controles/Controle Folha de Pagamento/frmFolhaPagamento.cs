using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCC_Hotel_For_Pets.DB.Folha_de_pagamento;
using TCC_Hotel_For_Pets.DB.Funcionário;
using TCC_Hotel_For_Pets.Telas.Menu_Funcionario;
using TCC_Hotel_For_Pets.Telas.Tela_ADM;

namespace TCC_Hotel_For_Pets.Telas.Controle_Folha_de_Pagamento
{
    public partial class frmFolhaPagamento : Form
    {
        //public frmFolhaPagamento()
        //{
        //    InitializeComponent();
        //    CarregarCombos();
        //}
        //void CarregarCombos()
        //{
        //    FuncionarioDTO dto = new FuncionarioDTO();
        //    string nome = dto.Nome;

        //    FuncionarioBusiness business = new FuncionarioBusiness();
        //    List<FuncionarioDTO> lista = business.Consultar(nome);

        //    comboBox1.ValueMember = nameof(FuncionarioDTO.Id);
        //    comboBox1.DisplayMember = nameof(FuncionarioDTO.Nome);
        //    comboBox1.DataSource = lista;

        //}
        //private void groupBox1_Enter(object sender, EventArgs e)
        //{

        //}

        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    FuncionarioDTO func = comboBox1.SelectedItem as FuncionarioDTO;


        //    label6.Text = Convert.ToString(func.Id);
        //    label30.Text = Convert.ToString(func.VT);
        //    label20.Text = Convert.ToString(func.SalarioLiquido);
        //    //label32.Text = Convert.ToString(func.ValeAlimentacao);
        //    label34.Text = Convert.ToString(func.VR);
        //    label36.Text = Convert.ToString(func.Convenio);
        //    label27.Text = Convert.ToString(func.SalarioLiquido);


        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    //Horas Trabalhadas

        //    decimal SalarioNominal = Convert.ToDecimal(label27.Text);

        //    int horastrabalhadasdia = 8 * 5;
        //    int HorasTrabalhadasMes = horastrabalhadasdia * 5;

        //    decimal ValorHoraTrabalhada = SalarioNominal / HorasTrabalhadasMes;

        //    //Atrasos 
        //    decimal HorasAtraso = ValorHoraTrabalhada * numericUpDown5.Value;

        //    //Faltas

        //    decimal faltas = SalarioNominal / 30;
        //    decimal valorfaltas = faltas * numericUpDown4.Value;

        //    //Valor Hora Extra Dia
        //    decimal PorcentagemHoraExtra = (ValorHoraTrabalhada * 50) / 100;
        //    decimal ValorHoraExtra = ValorHoraTrabalhada + PorcentagemHoraExtra;
        //    decimal HorasExtras = ValorHoraExtra * numericUpDown1.Value;

        //    if (HorasExtras >= 1)
        //    {
        //        decimal horasextrasdia = HorasExtras;

        //    }
        //    else
        //    {
        //        label29.Text = "0,00";
        //    }


        //    //Horas extras no feriado

        //    decimal PorcentagemHoraExtraferiado = (ValorHoraTrabalhada * 100) / 100;
        //    decimal ValorHoraExtraferiado = ValorHoraTrabalhada + PorcentagemHoraExtraferiado;
        //    decimal HorasExtrasFeriado = ValorHoraExtraferiado * numericUpDown2.Value;


        //    if (HorasExtrasFeriado >= 1)
        //    {
        //        decimal horasextrasdomingo = HorasExtrasFeriado;

        //    }
        //    else
        //    {
        //        label29.Text = "0,00";
        //    }



        //    decimal resultado = HorasExtras + HorasExtrasFeriado;
        //    resultado = Math.Round(resultado, 2);
        //    label29.Text = Convert.ToString(resultado);


        //    //Salario Base do INSS
        //    decimal SalarioBruto = SalarioNominal + HorasExtras - HorasAtraso - valorfaltas;
        //    decimal SalarioBaseINSS = SalarioBruto;

        //    if (SalarioBaseINSS <= 1659.38m)
        //    {
        //        decimal salario = (SalarioBaseINSS * 8) / 100;
        //        salario = Math.Round(salario, 2);
        //        label40.Text = Convert.ToString(salario);
        //    }
        //    else if (SalarioBaseINSS >= 1659.39m && SalarioBaseINSS <= 2765.66m)
        //    {
        //        decimal salario = (SalarioBaseINSS * 9) / 100;
        //        salario = Math.Round(salario, 2);
        //        label40.Text = Convert.ToString(salario);

        //    }
        //    else if (SalarioBaseINSS >= 2765.67m)
        //    {
        //        decimal salario = (SalarioBaseINSS * 11) / 100;
        //        salario = Math.Round(salario, 2);
        //        label40.Text = Convert.ToString(salario);
        //    }

        //    //Imposto de Renda 
        //    decimal BaseCalculoIR = SalarioBaseINSS - Convert.ToDecimal(label40.Text);

        //    if (BaseCalculoIR <= 1903.98m)
        //    {
        //        label42.Text = "0,00";

        //    }
        //    else if (BaseCalculoIR >= 1903.99m && BaseCalculoIR <= 2826.65m)
        //    {
        //        decimal imposto = (BaseCalculoIR * 7.5m) / 100;
        //        decimal reduzir = 142.80m;
        //        reduzir = Math.Round(reduzir, 2);
        //        label42.Text = Convert.ToString(reduzir);

        //    }
        //    else if (BaseCalculoIR >= 2826.66m && BaseCalculoIR <= 3751.05m)
        //    {
        //        decimal imposto = (BaseCalculoIR * 15) / 100;
        //        decimal reduzir = 354.80m;
        //        reduzir = Math.Round(reduzir, 2);
        //        label42.Text = Convert.ToString(reduzir);

        //    }
        //    else if (BaseCalculoIR >= 3751.06m && BaseCalculoIR <= 4664.68m)
        //    {
        //        decimal imposto = (BaseCalculoIR * 22.5m) / 100;
        //        decimal reduzir = 636.13m;
        //        reduzir = Math.Round(reduzir, 2);
        //        label42.Text = Convert.ToString(reduzir);
        //    }
        //    else if (BaseCalculoIR >= 4664.88m)
        //    {
        //        decimal imposto = (BaseCalculoIR * 27.5m) / 100;
        //        decimal reduzir = 869.36m;
        //        reduzir = Math.Round(reduzir, 2);
        //        label42.Text = Convert.ToString(reduzir);
        //    }

        //    //FGTS
        //    decimal fgts = (SalarioBaseINSS * 8) / 100;
        //    fgts = Math.Round(fgts, 2);
        //    label38.Text = Convert.ToString(fgts);


        //    //Salario Liquido
        //    decimal salarioliquido = SalarioNominal + Convert.ToDecimal(label29.Text) - HorasAtraso - valorfaltas - Convert.ToDecimal(label40.Text)
        //                                            - Convert.ToDecimal(label42.Text) - Convert.ToDecimal(label30.Text);
        //    salarioliquido = Math.Round(salarioliquido, 2);
        //    label23.Text = Convert.ToString(salarioliquido);
        //}

        //private void btnSalvar_Click(object sender, EventArgs e)
        //{
        //    FolhaDePagamentoDTO dto = new FolhaDePagamentoDTO();
        //    dto.IdFuncionario = Convert.ToInt32(label6.Text);
        //    dto.Salario = Convert.ToDecimal(label27.Text);
        //    dto.HorasExtras = Convert.ToDecimal(label29.Text);
        //    dto.ValeTransporte = Convert.ToDecimal(label30.Text);
        //    dto.ValeAlimentacao = Convert.ToDecimal(label32.Text);
        //    dto.ValeRefeicao = Convert.ToDecimal(label34.Text);
        //    dto.Convenio = Convert.ToDecimal(label36.Text);
        //    dto.FGTS = Convert.ToDecimal(label38.Text);
        //    dto.INSS = Convert.ToDecimal(label40.Text);
        //    dto.IR = Convert.ToDecimal(label42.Text);

        //    dto.SalarioBruto = Convert.ToDecimal(label20.Text);
        //    dto.SalarioLiquido = Convert.ToDecimal(label23.Text);
        //    dto.DataReferencia = dateTimePicker1.Value;

        //    FolhaDePagamentoBusiness business = new FolhaDePagamentoBusiness();
        //    business.Salvar(dto);

        //   MessageBox.Show("Folha cadastrada com sucesso.");

        //}

        //private void panel2_Paint(object sender, PaintEventArgs e)
        //{

        //}

        //private void label23_Click(object sender, EventArgs e)
        //{

        //}

        //private void label22_Click(object sender, EventArgs e)
        //{

        //}

        //private void label21_Click(object sender, EventArgs e)
        //{

        //}

        //private void label20_Click(object sender, EventArgs e)
        //{

        //}

        //private void label19_Click(object sender, EventArgs e)
        //{

        //}

        //private void label18_Click(object sender, EventArgs e)
        //{

        //}

        //private void groupBox3_Enter(object sender, EventArgs e)
        //{

        //}

        //private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        //{

        //}

        //private void label47_Click(object sender, EventArgs e)
        //{

        //}

        //private void groupBox4_Enter(object sender, EventArgs e)
        //{

        //}

        //private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        //{

        //}

        //private void label50_Click(object sender, EventArgs e)
        //{

        //}

        //private void label44_Click(object sender, EventArgs e)
        //{

        //}

        //private void groupBox2_Enter(object sender, EventArgs e)
        //{

        //}

        //private void label5_Click(object sender, EventArgs e)
        //{

        //}

        //private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        //{

        //}

        //private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        //{

        //}

        //private void label4_Click(object sender, EventArgs e)
        //{

        //}

        //private void label43_Click(object sender, EventArgs e)
        //{

        //}

        //private void label42_Click(object sender, EventArgs e)
        //{

        //}

        //private void label41_Click(object sender, EventArgs e)
        //{

        //}

        //private void label40_Click(object sender, EventArgs e)
        //{

        //}

        //private void groupBox5_Enter(object sender, EventArgs e)
        //{

        //}

        //private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        //{

        //}

        //private void label52_Click(object sender, EventArgs e)
        //{

        //}

        //private void label39_Click(object sender, EventArgs e)
        //{

        //}

        //private void label38_Click(object sender, EventArgs e)
        //{

        //}

        //private void label37_Click(object sender, EventArgs e)
        //{

        //}

        //private void label36_Click(object sender, EventArgs e)
        //{

        //}

        //private void label35_Click(object sender, EventArgs e)
        //{

        //}

        //private void label34_Click(object sender, EventArgs e)
        //{

        //}

        //private void label33_Click(object sender, EventArgs e)
        //{

        //}

        //private void label32_Click(object sender, EventArgs e)
        //{

        //}

        //private void label31_Click(object sender, EventArgs e)
        //{

        //}

        //private void label30_Click(object sender, EventArgs e)
        //{

        //}

        //private void label29_Click(object sender, EventArgs e)
        //{

        //}

        //private void label28_Click(object sender, EventArgs e)
        //{

        //}

        //private void label27_Click(object sender, EventArgs e)
        //{

        //}

        //private void label26_Click(object sender, EventArgs e)
        //{

        //}

        //private void label25_Click(object sender, EventArgs e)
        //{

        //}

        //private void label24_Click(object sender, EventArgs e)
        //{

        //}

        //private void label17_Click(object sender, EventArgs e)
        //{

        //}

        //private void label16_Click(object sender, EventArgs e)
        //{

        //}

        //private void label15_Click(object sender, EventArgs e)
        //{

        //}

        //private void label14_Click(object sender, EventArgs e)
        //{

        //}

        //private void label13_Click(object sender, EventArgs e)
        //{

        //}

        //private void label12_Click(object sender, EventArgs e)
        //{

        //}

        //private void label11_Click(object sender, EventArgs e)
        //{

        //}

        //private void label10_Click(object sender, EventArgs e)
        //{

        //}

        //private void label9_Click(object sender, EventArgs e)
        //{

        //}

        //private void label8_Click(object sender, EventArgs e)
        //{

        //}

        //private void label7_Click(object sender, EventArgs e)
        //{

        //}

        //private void label45_Click(object sender, EventArgs e)
        //{

        //}

        //private void label6_Click(object sender, EventArgs e)
        //{

        //}

        //private void label3_Click(object sender, EventArgs e)
        //{

        //}

        //private void panel1_Paint(object sender, PaintEventArgs e)
        //{

        //}

        //private void label46_Click(object sender, EventArgs e)
        //{

        //}

        //private void label1_Click(object sender, EventArgs e)
        //{

        //}

        //private void frmFolhaPagamento_Load(object sender, EventArgs e)
        //{

        //}

        //private void label2_Click(object sender, EventArgs e)
        //{

        //}

        //private void button2_Click(object sender, EventArgs e)
        //{

        //    if (UserSession.UsuarioLogado.Adiministrador == true)
        //    {
        //        frmTelaADM menu = new frmTelaADM();
        //        menu.Show();
        //        Hide();

        //    }
        //    else if (UserSession.UsuarioLogado.Funcionario == true)
        //    {

        //        frmMenuFuncionario menu = new frmMenuFuncionario();
        //        menu.Show();
        //        Hide();
        //    }

        //}

        //private void groupBox1_Enter_1(object sender, EventArgs e)
        //{

        //}

        public frmFolhaPagamento()
        {
            InitializeComponent();
            CarregarCombos();
        }

        void CarregarCombos()
        {
            FuncionarioDTO dto = new FuncionarioDTO();
            string nome = dto.Nome;


            FuncionarioBusiness business = new FuncionarioBusiness();
            List<FuncionarioDTO> lista = business.Consultar(nome);


            comboBox1.ValueMember = nameof(FuncionarioDTO.Id);
            comboBox1.DisplayMember = nameof(FuncionarioDTO.Nome);
            comboBox1.DataSource = lista;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label46_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmTelaADM tela = new frmTelaADM();
            tela.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           
        }

        

        private void btnSalvar_Click(object sender, EventArgs e)
        {
           
        }

        private void EnviarMensagem(string mensagem)
        {
            MessageBox.Show(mensagem, "Quatro Estações",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Information);
        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void CadastrarFolhaDePagamento_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Horas Trabalhadas

            decimal SalarioNominal = Convert.ToDecimal(label27.Text);

            int horastrabalhadasdia = 9 * 4;
            int horastrabalhadasultimodia = horastrabalhadasdia + 8;
            int HorasTrabalhadasMes = horastrabalhadasultimodia * 5;


            decimal ValorHoraTrabalhada = SalarioNominal / HorasTrabalhadasMes;
            ValorHoraTrabalhada = Math.Round(ValorHoraTrabalhada, 2);

            //Atrasos 
            decimal HorasAtraso = ValorHoraTrabalhada * numericUpDown5.Value;

            //Faltas

            decimal faltas = SalarioNominal / 30;
            decimal valorfaltas = faltas * numericUpDown4.Value;

            //Valor Hora Extra Dia
            decimal PorcentagemHoraExtra = (ValorHoraTrabalhada * 50) / 100;
            decimal ValorHoraExtra = ValorHoraTrabalhada + PorcentagemHoraExtra;
            decimal HorasExtras = ValorHoraExtra * numericUpDown1.Value;

            if (HorasExtras >= 1)
            {
                decimal horasextrasdia = HorasExtras;

            }
            else
            {
                label29.Text = "0,00";
            }


            //Horas extras no feriado

            decimal PorcentagemHoraExtraferiado = (ValorHoraTrabalhada * 100) / 100;
            decimal ValorHoraExtraferiado = ValorHoraTrabalhada + PorcentagemHoraExtraferiado;
            decimal HorasExtrasFeriado = ValorHoraExtraferiado * numericUpDown2.Value;


            if (HorasExtrasFeriado >= 1)
            {
                decimal horasextrasdomingo = HorasExtrasFeriado;

            }
            else
            {
                label29.Text = "0,00";
            }



            decimal resultado = HorasExtras + HorasExtrasFeriado;
            resultado = Math.Round(resultado, 2);
            label29.Text = Convert.ToString(resultado);


            //Salario Base do INSS
            decimal SalarioBruto = SalarioNominal + HorasExtras - HorasAtraso - valorfaltas;
            decimal SalarioBaseINSS = SalarioBruto;

            if (SalarioBaseINSS <= 1659.38m)
            {
                decimal salario = (SalarioBaseINSS * 8) / 100;
                salario = Math.Round(salario, 2);
                label40.Text = Convert.ToString(salario);
            }
            else if (SalarioBaseINSS >= 1659.39m && SalarioBaseINSS <= 2765.66m)
            {
                decimal salario = (SalarioBaseINSS * 9) / 100;
                salario = Math.Round(salario, 2);
                label40.Text = Convert.ToString(salario);

            }
            else if (SalarioBaseINSS >= 2765.67m)
            {
                decimal salario = (SalarioBaseINSS * 11) / 100;
                salario = Math.Round(salario, 2);
                label40.Text = Convert.ToString(salario);
            }

            //Imposto de Renda 
            decimal BaseCalculoIR = SalarioBaseINSS - Convert.ToDecimal(label40.Text);

            if (BaseCalculoIR <= 1903.98m)
            {
                label42.Text = "0,00";

            }
            else if (BaseCalculoIR >= 1903.99m && BaseCalculoIR <= 2826.65m)
            {
                decimal imposto = (BaseCalculoIR * 7.5m) / 100;
                decimal reduzir = 142.80m;
                reduzir = Math.Round(reduzir, 2);
                label42.Text = Convert.ToString(reduzir);

            }
            else if (BaseCalculoIR >= 2826.66m && BaseCalculoIR <= 3751.05m)
            {
                decimal imposto = (BaseCalculoIR * 15) / 100;
                decimal reduzir = 354.80m;
                reduzir = Math.Round(reduzir, 2);
                label42.Text = Convert.ToString(reduzir);

            }
            else if (BaseCalculoIR >= 3751.06m && BaseCalculoIR <= 4664.68m)
            {
                decimal imposto = (BaseCalculoIR * 22.5m) / 100;
                decimal reduzir = 636.13m;
                reduzir = Math.Round(reduzir, 2);
                label42.Text = Convert.ToString(reduzir);
            }
            else if (BaseCalculoIR >= 4664.88m)
            {
                decimal imposto = (BaseCalculoIR * 27.5m) / 100;
                decimal reduzir = 869.36m;
                reduzir = Math.Round(reduzir, 2);
                label42.Text = Convert.ToString(reduzir);
            }

            //FGTS
            decimal fgts = (SalarioBaseINSS * 8) / 100;
            fgts = Math.Round(fgts, 2);
            label38.Text = Convert.ToString(fgts);


            //Salario Liquido
            decimal salarioliquido = SalarioNominal + Convert.ToDecimal(label29.Text) - HorasAtraso - valorfaltas - Convert.ToDecimal(label40.Text)
                                                    - Convert.ToDecimal(label42.Text) - Convert.ToDecimal(label30.Text) - Convert.ToDecimal(label38.Text);
            salarioliquido = Math.Round(salarioliquido, 2);
            label23.Text = Convert.ToString(salarioliquido);
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            FuncionarioDTO func = comboBox1.SelectedItem as FuncionarioDTO;

            label6.Text = Convert.ToString(func.Id);
            label30.Text = Convert.ToString(func.VT);
            label20.Text = Convert.ToString(func.SalarioLiquido);
            label34.Text = Convert.ToString(func.VR);
            label36.Text = Convert.ToString(func.Convenio);
            label27.Text = Convert.ToString(func.SalarioLiquido);

        }

        private void btnSalvar_Click_1(object sender, EventArgs e)
        {
            FolhaDePagamentoDTO dto = new FolhaDePagamentoDTO();
            dto.IdFuncionario = Convert.ToInt32(label6.Text);
            dto.Salario = Convert.ToDecimal(label27.Text);
            dto.HorasExtras = Convert.ToDecimal(label29.Text);
            dto.ValeTransporte = Convert.ToDecimal(label30.Text);
            dto.ValeRefeicao = Convert.ToDecimal(label34.Text);
            dto.Convenio = Convert.ToDecimal(label36.Text);
            dto.FGTS = Convert.ToDecimal(label38.Text);
            dto.INSS = Convert.ToDecimal(label40.Text);
            dto.IR = Convert.ToDecimal(label42.Text);
            dto.SalarioBruto = Convert.ToDecimal(label20.Text);
            dto.DataReferencia = dateTimePicker1.Value;
            dto.SalarioLiquido = Convert.ToDecimal(label23.Text);

            FolhaDePagamentoBusiness business = new FolhaDePagamentoBusiness();
            business.Salvar(dto);

            EnviarMensagem("Folha cadastrada com sucesso.");

            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (UserSession.UsuarioLogado.Adiministrador == true)
            {
                frmTelaADM menu = new frmTelaADM();
                menu.Show();

            }
            else if (UserSession.UsuarioLogado.Funcionario == true)
            {

                MessageBox.Show("Você não deveria ter acesso a essa tela, isso será relatado aos administradores do sistema!", "Hotel For Pets", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {

                MessageBox.Show("Você não deveria ter acesso a essa tela, isso será relatado aos administradores do sistema!", "Hotel For Pets", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            Hide();
        }
    }
}
