using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC_Hotel_For_Pets.DB.Animal_Cliente
{
    public class ViewConsultarAnimal
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdAnimal { get; set; }
        public string Nome { get; set; }
        public string Especie { get; set; }
        public string Pelagem { get; set; }
        public string Porte { get; set; }
        public string Raca { get; set; }
        public string Cor { get; set; }
        public string Castracao { get; set; }
        public string Carteira { get; set; }
        public string Cliente { get; set; }
    }
}
