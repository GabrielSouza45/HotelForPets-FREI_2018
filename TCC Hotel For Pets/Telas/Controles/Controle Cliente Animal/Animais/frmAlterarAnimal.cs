using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCC_Hotel_For_Pets.DB.Animal;
using TCC_Hotel_For_Pets.DB.Animal_Cliente;

namespace TCC_Hotel_For_Pets.Telas.Controle_Cliente_Animal.Animais
{
    public partial class frmAlterarAnimal : Form
    {
        public frmAlterarAnimal()
        {
            InitializeComponent();
        }

        ViewConsultarAnimal animal;
        public void LoadScreen(ViewConsultarAnimal animal)
        {
            this.animal = animal;

            lblId.Text = animal.Id.ToString();
            txtnome.Text = animal.Nome;
            txtespecie.Text = animal.Especie;
            txtpelagem.Text = animal.Pelagem;
            cboporte.Text = animal.Porte;
            txtraca.Text = animal.Raca;
            txtcor.Text = animal.Cor;
            txtCarteira.Text = animal.Carteira;
            if (rbnCastNao.Checked)
            {
                animal.Castracao = "Não";
            }
            else if (rbnCasSim.Checked)
            {
                animal.Castracao = "Sim";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
           
            animal.Nome = txtnome.Text;
            animal.Especie = txtespecie.Text;
            animal.Pelagem = txtpelagem.Text;
            animal.Porte = cboporte.Text;
            animal.Raca = txtraca.Text;
            animal.Cor = txtcor.Text;
            animal.Carteira = txtCarteira.Text;
            if (rbnCastNao.Checked)
            {
                animal.Castracao = "Não";
            }
            else if (rbnCasSim.Checked)
            {
                animal.Castracao = "Sim";
            }

            AnimalBusiness businesss = new AnimalBusiness();
            businesss.Alterar(animal);
            MessageBox.Show("Animal alterado com sucesso!", "Hotel For Pets");
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            frmConsultarAnimal f = new frmConsultarAnimal();
            f.Show();
            Hide();
        }
    }
}
