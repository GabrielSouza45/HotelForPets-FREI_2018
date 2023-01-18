using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC_Hotel_For_Pets.DB.Animal_Cliente;
using TCC_Hotel_For_Pets.DB.Cliente;
using TCC_Hotel_For_Pets.DB.Pedido_item;

namespace TCC_Hotel_For_Pets.DB.Animal
{
    class AnimalBusiness
    {
        AnimalDatabase db = new AnimalDatabase();

        
            

        public int Salvar(AnimalDTO animal, ClienteDTO cliente)
        {

            int id = db.Salvar(animal);

            AniclienteBusiness aniBusiness = new AniclienteBusiness();

            AniclienteDTO anicli = new AniclienteDTO();
            anicli.IdAnimal = id;
            anicli.IdCliente = cliente.Id;

            aniBusiness.Salvar(anicli);

            return id;
        }
        public void Alterar(ViewConsultarAnimal animal)
        {

            db.Alterar(animal);
        }

        public void Remover(int Id)
        {

            db.Remover(Id);

        }
        public List<ViewConsultarAnimal> Consultar(string animal)
        {
            AniclienteDatabase op = new AniclienteDatabase();
            return op.Consultar(animal);
        }
        public List<AnimalDTO> Listar()
        {

            return db.Listar();
        }
    }
}
