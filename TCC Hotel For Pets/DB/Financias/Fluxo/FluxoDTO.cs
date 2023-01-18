using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC_Hotel_For_Pets.DB.Financias.Fluxo
{
    class FluxoDTO
    {
        public DateTime DataReferencia { get; set; }
        public decimal ValorGanhos { get; set; }
        public decimal ValorDespesas { get; set; }
        public decimal ValorLucros { get; set; }

    }
}
