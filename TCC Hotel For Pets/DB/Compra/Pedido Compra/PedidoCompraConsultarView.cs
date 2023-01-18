using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC_Hotel_For_Pets.DB.Compra.Pedido_Compra
{
    class PedidoCompraConsultarView
    {
        public int Id { get; set; }
        public string Fornecedor { get; set; }
        public int Quantidade { get; set; }
        public DateTime Data { get; set; }
        public decimal ValorTotal { get; set; }
        public int IdProduto { get; set; }

    }
}
