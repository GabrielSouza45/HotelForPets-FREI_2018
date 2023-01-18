using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC_Hotel_For_Pets.DB.Compra.Pedido_item_Compra;
using TCC_Hotel_For_Pets.DB.Estoque;
using TCC_Hotel_For_Pets.DB.Produto;

namespace TCC_Hotel_For_Pets.DB.Compra.Pedido_Compra
{
    class PedidoCompraBusiness
    {
        public int Salvar(PedidoCompraDTO pedido, List<ProdutoConsultarView> produtos)
        {
            PedidoCompraDatabase pedidoDatabase = new PedidoCompraDatabase();
            int idPedido = pedidoDatabase.Salvar(pedido);

            EstoqueBusiness estoqueBusiness = new EstoqueBusiness();
            PedidoItemCompraBusiness itemBusiness = new PedidoItemCompraBusiness();
            foreach (ProdutoConsultarView item in produtos)
            {
                PedidoItemCompraDTO itemDto = new PedidoItemCompraDTO();
                itemDto.IdPedido = idPedido;
                itemDto.IdProduto = item.Id;

                itemBusiness.Salvar(itemDto);
                estoqueBusiness.AdicionarNoEstoque(1, item.Id);
            }

            return idPedido;
        }

        public List<PedidoCompraConsultarView> Consultar(DateTime inicio, DateTime fim)
        {
            PedidoCompraDatabase db = new PedidoCompraDatabase();
            return db.Consultar(inicio, fim);

        }
        public List<PedidoCompraConsultarView> ConsultarPorId(int idCompra)
        {
            PedidoCompraDatabase db = new PedidoCompraDatabase();
            return db.ConsultarPorId(idCompra);

        }

        public void Remover(int pedidoId)
        {
            PedidoItemCompraBusiness itemBusiness = new PedidoItemCompraBusiness();
            List<PedidoItemCompraDTO> itens = itemBusiness.ConsultarPorPedido(pedidoId);

            foreach (PedidoItemCompraDTO item in itens)
            {
                itemBusiness.Remover(item.Id);
            }

            PedidoCompraDatabase pedidoDatabase = new PedidoCompraDatabase();
            pedidoDatabase.Remover(pedidoId);

        }

        public void Alterar(PedidoCompraDTO dto)
        {
            PedidoCompraDatabase db = new PedidoCompraDatabase();
            db.Alterar(dto);

        }
    }
}
