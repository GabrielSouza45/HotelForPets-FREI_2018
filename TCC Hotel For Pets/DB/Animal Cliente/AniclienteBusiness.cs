using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC_Hotel_For_Pets.DB.Animal_Cliente
{
    class AniclienteBusiness
    {
        AniclienteDatabase db = new AniclienteDatabase();
        public int Salvar(AniclienteDTO animal)
        {

            int id = db.Salvar(animal);
            return id;
        }
        public void Alterar(AniclienteDTO animal)
        {

            db.Alterar(animal);
        }

        public void Remover(int Id)
        {

            db.Remover(Id);

        }
        public List<ViewConsultarAnimal> Consultar(string animal)
        {

            return db.Consultar(animal);
        }
        public List<AniclienteDTO> Listar()
        {

            return db.Listar();
        }
    }
}
