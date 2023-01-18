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
using TCC_Hotel_For_Pets.DB.Cliente;
using TCC_Hotel_For_Pets.DB.Login;
using TCC_Hotel_For_Pets.Telas.Menu_inicial;

namespace TCC_Hotel_For_Pets.Telas
{
    public partial class frmCadastrarAnimal : Form
    {
        public frmCadastrarAnimal()
        {
            InitializeComponent();
            CarregarCombos();
        }
        void CarregarCombos()
        {
            
            ClienteBusiness business = new ClienteBusiness();
            List<ClienteDTO> lista = business.Listar();

            cboCliente.ValueMember = nameof(ClienteDTO.Id);
            cboCliente.DisplayMember = nameof(ClienteDTO.Nome);
            cboCliente.DataSource = lista;
        }

        private void frmForm2_Load(object sender, EventArgs e)
        {
         

        }

        private void btnCadastrarAnimal_Click(object sender, EventArgs e)
        {
              ClienteDTO cliente = cboCliente.SelectedItem as ClienteDTO;

            AnimalDTO animal = new AnimalDTO();
            
            animal.Nome = txtnome.Text;
            animal.Especie = txtespecie.Text;
            animal.Pelagem = txtpelagem.Text;
            animal.Porte = cboporte.Text;
            animal.Raca = txtraca.Text;
            animal.Cor = txtcor.Text;
            animal.Carteira = txtcarteira.Text;
            if(rbnCasNao.Checked)
            {
                animal.Castracao = "Não";
                
            }
            else if(rbnCasSim.Checked)
            {
                animal.Castracao = "Sim";
            }

            AnimalBusiness businesss = new AnimalBusiness();
            animal.Id = businesss.Salvar(animal, cliente);

            MessageBox.Show("Animal cadasrado com suceso!", "Hotel For Pets", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmMenuCliente t = new frmMenuCliente();
            t.Show();
            Hide();
        }

        private void rbnCasSim_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
