using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC_Hotel_For_Pets.DB.BASE;

namespace TCC_Hotel_For_Pets.DB.Compra.Pedido_item_Compra
{
    class PedidoItemCompraDatabase
    {
        public int Salvar(PedidoItemCompraDTO dto)
        {
            string script = @"INSERT into tb_compra_item (fk_produto_compra,fk_pedido_compra) VALUES(@fk_produto_compra,@fk_pedido_compra)";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("fk_produto_compra", dto.IdProduto));
            parms.Add(new MySqlParameter("fk_pedido_compra", dto.IdPedido));

            Database db = new Database();
            return db.ExecuteInsertScriptWithPk(script, parms);

        }

        public List<PedidoItemCompraDTO> ConsultarPorPedido(int idPedido)
        {
            string script = @"SELECT * FROM tb_compra_item WHERE fk_pedido_compra = @fk_pedido_compra";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("fk_pedido_compra", idPedido));

            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            List<PedidoItemCompraDTO> lista = new List<PedidoItemCompraDTO>();
            while (reader.Read())
            {
                PedidoItemCompraDTO dto = new PedidoItemCompraDTO();
                dto.Id = reader.GetInt32("id_compra_item");
                dto.IdPedido = reader.GetInt32("fk_pedido_compra");
                dto.IdProduto = reader.GetInt32("fk_produto_compra");

                lista.Add(dto);
            }
            reader.Close();

            return lista;
        }

        public void Remover(int id)
        {
            string script = @"DELETE FROM tb_compra_item WHERE id_compra_item = @id_compra_item";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_compra_item", id));

            Database db = new Database();
            db.ExecuteInsertScript(script, parms);
        }
    }
}
