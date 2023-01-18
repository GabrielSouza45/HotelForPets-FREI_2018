using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC_Hotel_For_Pets.DB.Estoque;
using TCC_Hotel_For_Pets.DB.Pedido_item;
using TCC_Hotel_For_Pets.DB.Produto;

namespace TCC_Hotel_For_Pets.DB.Pedido
{
    class PedidoBusiness
    {
        public int Salvar(PedidoDTO pedido, List<EstoqueConsultarView> produtos)
        {
            PedidoDatabase pedidoDatabase = new PedidoDatabase();
            int idPedido = pedidoDatabase.Salvar(pedido);

            PedidoItemBusiness itemBusiness = new PedidoItemBusiness();
            foreach (EstoqueConsultarView item in produtos)
            {
                PedidoItemDTO dto = new PedidoItemDTO();
                dto.IdPedido = idPedido;
                dto.IdProduto = item.Id;

                itemBusiness.Salvar(dto);
            }

            return idPedido;
        }

        public void Remover(int id)
        {
            ProdutoDatabase db = new ProdutoDatabase();
            db.Remover(id);
        }
        public List<PedidoConsultarView> Consultar(string cliente)
        {
            PedidoDatabase bd = new PedidoDatabase();
            return bd.Consultar(cliente);
        }
        public List<PedidoConsultarView> ConsultarPorId(int idCompra)
        {
            PedidoDatabase db = new PedidoDatabase();
            return db.ConsultarPorId(idCompra);

        }
    }
}
