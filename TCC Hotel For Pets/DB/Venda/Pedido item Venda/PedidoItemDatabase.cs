using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC_Hotel_For_Pets.DB.BASE;

namespace TCC_Hotel_For_Pets.DB.Pedido_item
{
    class PedidoItemDatabase
    {
        public int Salvar(PedidoItemDTO dto)
        {
            string script = @"INSERT INTO tb_venda_item (fk_produto_venda, fk_pedido_venda) VALUES (@fk_produto_venda, @fk_pedido_venda)";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("fk_produto_venda", dto.IdProduto));
            parms.Add(new MySqlParameter("fk_pedido_venda", dto.IdPedido));

            Database db = new Database();
            return db.ExecuteInsertScriptWithPk(script, parms);
        }
        public void Remover(int id)
        {
            string script = @"DELETE FROM tb_venda_item WHERE id_venda_item = @id_venda_item";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_venda_item", id));

            Database db = new Database();
            db.ExecuteInsertScript(script, parms);
        }
        public List<PedidoItemDTO> ConsultarPorPedido(int idPedido)
        {
            string script = @"SELECT * FROM tb_venda_item WHERE fk_pedido_venda = @fk_pedido_venda";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("fk_pedido_venda", idPedido));

            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            List<PedidoItemDTO> lista = new List<PedidoItemDTO>();
            while (reader.Read())
            {
                PedidoItemDTO dto = new PedidoItemDTO();
                dto.Id = reader.GetInt32("id_venda_item");
                dto.IdPedido = reader.GetInt32("fk_pedido_venda");
                dto.IdProduto = reader.GetInt32("fk_produto_venda");

                lista.Add(dto);
            }
            reader.Close();

            return lista;
        }
    }
}
