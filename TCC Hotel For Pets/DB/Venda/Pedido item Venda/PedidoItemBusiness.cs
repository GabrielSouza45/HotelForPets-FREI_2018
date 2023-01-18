using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC_Hotel_For_Pets.DB.Pedido_item
{
    class PedidoItemBusiness
    {
        public int Salvar(PedidoItemDTO dto)
        {
            PedidoItemDatabase db = new PedidoItemDatabase();
            return db.Salvar(dto);
        }
        public void Remover(int id)
        {
            PedidoItemDatabase db = new PedidoItemDatabase();
            db.Remover(id);
        }
        public List<PedidoItemDTO> ConsultarPorPedido(int Id)
        {
            PedidoItemDatabase db = new PedidoItemDatabase();
            return db.ConsultarPorPedido(Id);
        }
    }
}
