using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC_Hotel_For_Pets.DB.Fluxo_de_Caixa
{
    class FluxoDeCaixaDTO
    {
        public int Id { get; set; }
        public int Descricao { get; set; }
        public decimal Valor { get; set; }
        public decimal SaldoAtual { get; set; }
        public decimal SaldoDia { get; set; }
        public decimal Subtotal { get; set; }
        public int IdPedido { get; set; }

    }
}
