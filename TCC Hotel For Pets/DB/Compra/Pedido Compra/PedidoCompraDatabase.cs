using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC_Hotel_For_Pets.DB.BASE;

namespace TCC_Hotel_For_Pets.DB.Compra.Pedido_Compra
{
    class PedidoCompraDatabase
    {
        public int Salvar(PedidoCompraDTO dto)
        {
            string script = @"INSERT INTO tb_pedido_compra (dt_compra,fk_fornecedor) VALUES (@dt_compra,@fk_fornecedor)";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("dt_compra", dto.Data));
            parms.Add(new MySqlParameter("fk_fornecedor", dto.IdFornecedor));

            Database db = new Database();
            return db.ExecuteInsertScriptWithPk(script, parms);
        }

        public List<PedidoCompraConsultarView> Consultar(DateTime inicio, DateTime fim)
        {
            string script = @"SELECT * FROM vw_pedido_consultar
                                      Where dt_compra >= @inicio and dt_compra <= @fim";
            ;

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("inicio", inicio));
            parms.Add(new MySqlParameter("fim", fim));

            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            List<PedidoCompraConsultarView> lista = new List<PedidoCompraConsultarView>();
            while (reader.Read())
            {
                PedidoCompraConsultarView dto = new PedidoCompraConsultarView();
                dto.Id = reader.GetInt32("id_pedido_compra");
                dto.Fornecedor = reader.GetString("nm_nome");
                dto.Quantidade = reader.GetInt32("qtd_itens");
                dto.Data = reader.GetDateTime("dt_compra");
                dto.ValorTotal = reader.GetDecimal("vl_total");


                lista.Add(dto);
            }
            reader.Close();

            return lista;
        }


        public void Remover(int id)
        {
            string script = @"DELETE FROM tb_pedido_compra WHERE id_pedido_compra = @id_pedido_compra";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_pedido_compra", id));

            Database db = new Database();
            db.ExecuteInsertScript(script, parms);
        }

        public void Alterar(PedidoCompraDTO dto)
        {
            string script = @"UPDATE tb_pedido_compra 
                                 SET dt_compra = @dt_compra,
                                     vl_total = @vl_total,
                                     id_produto = @id_produto
                              WHERE id_pedido_compra= @id_pedido_compra";
            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_pedido_compra", dto.Id));

            Database db = new Database();
            db.ExecuteInsertScript(script, parms);
        }

        public List<PedidoCompraConsultarView> ConsultarPorId(int idCompra)
        {
            string script = @"SELECT * FROM vw_pedido_consultar
                                      Where id_pedido_compra = @id_pedido_compra";


            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_pedido_compra", idCompra));


            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            List<PedidoCompraConsultarView> lista = new List<PedidoCompraConsultarView>();
            while (reader.Read())
            {
                PedidoCompraConsultarView dto = new PedidoCompraConsultarView();
                dto.Id = reader.GetInt32("id_pedido_compra");
                dto.Fornecedor = reader.GetString("nm_nome");
                dto.Quantidade = reader.GetInt32("qtd_itens");
                dto.Data = reader.GetDateTime("dt_compra");
                dto.ValorTotal = reader.GetDecimal("vl_total");
                dto.IdProduto = reader.GetInt32("id_produto");


                lista.Add(dto);
            }
            reader.Close();

            return lista;
        }
    }
}
