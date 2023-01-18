using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC_Hotel_For_Pets.DB.Financias.Fluxo
{
    class FluxoBusiness
    {
        public List<FluxoDTO> Consultar(DateTime inicio, DateTime fim)
        {
            FluxoDatabase db = new FluxoDatabase();
            return db.Consultar(inicio, fim);

        }
    }
}
