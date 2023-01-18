using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC_Hotel_For_Pets.DB.Compra.Pedido_item_Compra
{
    class PedidoItemCompraBusiness
    {
        public int Salvar(PedidoItemCompraDTO dto)
        {
            PedidoItemCompraDatabase db = new PedidoItemCompraDatabase();
            return db.Salvar(dto);
        }

        public List<PedidoItemCompraDTO> ConsultarPorPedido(int idPedido)
        {
            PedidoItemCompraDatabase db = new PedidoItemCompraDatabase();
            return db.ConsultarPorPedido(idPedido);
        }
        public void Remover(int id)
        {
            PedidoItemCompraDatabase db = new PedidoItemCompraDatabase();
            db.Remover(id);
        }
    }
}
