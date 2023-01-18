using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC_Hotel_For_Pets.DB.BASE;

namespace TCC_Hotel_For_Pets.DB.Pedido
{
    class PedidoDatabase
    {
        public int Salvar(PedidoDTO dto)
        {
            string script = @"INSERT INTO tb_pedido_venda (fk_usuario, dt_venda) VALUES (@fk_usuario, @dt_venda)";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("fk_usuario", dto.IdUsuario));
            parms.Add(new MySqlParameter("dt_venda", dto.Venda));

            Database db = new Database();
            return db.ExecuteInsertScriptWithPk(script, parms);
        }

        public void Remover(int id)
        {
            string script = @"DELETE FROM tb_pedido_venda WHERE id_pedido_venda = @id_pedido_venda";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_pedido_venda", id));

            Database db = new Database();
            db.ExecuteInsertScript(script, parms);
        }
        public List<PedidoConsultarView> Consultar(string cliente)
        {
            string script = @"SELECT * FROM vw_pedido_venda_consultar WHERE nm_usuario like @nm_usuario";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("nm_usuario", "%" + cliente + "%"));

            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            List<PedidoConsultarView> lista = new List<PedidoConsultarView>();
            while (reader.Read())
            {
                PedidoConsultarView dto = new PedidoConsultarView();
                dto.Id = reader.GetInt32("id_pedido_venda");
                dto.Cliente = reader.GetString("nm_usuario");
                dto.QtdItens = reader.GetInt32("qtd_itens");
                dto.Data = reader.GetDateTime("dt_venda");
                dto.Total = reader.GetDecimal("vl_total");


                lista.Add(dto);
            }
            reader.Close();

            return lista;
        }
        public List<PedidoConsultarView> ConsultarPorId(int idVenda)
        {
            string script = @"SELECT * FROM vw_pedido_venda_consultar
                                      Where id_pedido_venda = @id_pedido_venda";


            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_pedido_venda", idVenda));


            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            List<PedidoConsultarView> lista = new List<PedidoConsultarView>();
            while (reader.Read())
            {
                PedidoConsultarView dto = new PedidoConsultarView();
                dto.Id = reader.GetInt32("id_pedido_venda");
                dto.Cliente = reader.GetString("nm_usuario");
                dto.QtdItens = reader.GetInt32("qtd_itens");
                dto.Data = reader.GetDateTime("dt_venda");
                dto.Total = reader.GetDecimal("vl_total");
                dto.IdProduto = reader.GetInt32("id_produto");


                lista.Add(dto);
            }
            reader.Close();

            return lista;
        }


    }


}
