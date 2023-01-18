using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC_Hotel_For_Pets.DB.Funcionário.Ponto
{
    class PontoBusiness
    {
        public int Salvar(PontoDTO dto)
        {
            PontoDatabase db = new PontoDatabase();
            return db.Salvar(dto);
        }

        public List<PontoConsultarView> Consultar(string nome)
        {
            PontoDatabase db = new PontoDatabase();
            return db.Consultar(nome);

        }
    }
}
