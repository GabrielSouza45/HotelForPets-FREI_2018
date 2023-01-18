using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC_Hotel_For_Pets.DB.BASE;

namespace TCC_Hotel_For_Pets.DB.Estoque
{
    class EstoqueDatabase
    {
        public int Salvar(EstoqueDTO dto)
        {
                string script = @"INSERT INTO tb_estoque (qt_produto, produto_id_produto) VALUES(@qt_produto, @produto_id_produto)";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("qt_produto", dto.QtdProduto));
            parms.Add(new MySqlParameter("produto_id_produto", dto.IdProduto));

            Database db = new Database();
            return db.ExecuteInsertScriptWithPk(script, parms);

        }
        public List<EstoqueDTO> Listar2()
        {
            string script = @"SELECT * FROM tb_estoque";

            List<MySqlParameter> parms = new List<MySqlParameter>();

            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            List<EstoqueDTO> lista = new List<EstoqueDTO>();
            while (reader.Read())
            {
                EstoqueDTO dto = new EstoqueDTO();
                dto.Id = reader.GetInt32("id_estoque");
                dto.QtdProduto = reader.GetInt32("qt_produto");
                dto.IdProduto = reader.GetInt32("produto_id_produto");

                lista.Add(dto);
            }
            reader.Close();

            return lista;

        }

        public List<EstoqueConsultarView> Consultar(string produto)
        {
            string script = @"SELECT * FROM vw_consultar_estoque WHERE nm_produto like @nm_produto";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("nm_produto","%" + produto + "%"));

            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            List<EstoqueConsultarView> lista = new List<EstoqueConsultarView>();
            while (reader.Read())
            {
                EstoqueConsultarView dto = new EstoqueConsultarView();
                dto.Id = reader.GetInt32("id_estoque");
                dto.Produto = reader.GetString("nm_produto");
                dto.Quantidade = reader.GetInt32("qt_produto");
                dto.Fornecedor = reader.GetString("nm_nome");
                dto.ValorVenda = reader.GetDecimal("vl_preco_venda");
                dto.ProdutoId = reader.GetInt32("id_produto");

                lista.Add(dto);
            }
            reader.Close();

            return lista;
        }

        public List<EstoqueConsultarView> Listar()
        {
            string script = @"SELECT * FROM vw_consultar_estoque";

            List<MySqlParameter> parms = new List<MySqlParameter>();

            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            List<EstoqueConsultarView> lista = new List<EstoqueConsultarView>();
            while (reader.Read())
            {
                EstoqueConsultarView dto = new EstoqueConsultarView();
                dto.Id = reader.GetInt32("id_estoque");
                dto.Produto = reader.GetString("nm_produto");
                dto.Quantidade = reader.GetInt32("qt_produto");
                dto.Fornecedor = reader.GetString("nm_nome");
                dto.ValorVenda = reader.GetDecimal("vl_preco_venda");
                dto.ProdutoId = reader.GetInt32("id_produto");

                lista.Add(dto);
            }
            reader.Close();

            return lista;
        }

        public void Alterar(EstoqueDTO dto)
        {
            string script = @"UPDATE tb_estoque
                                 SET id_estoque = @id_estoque,
                                qt_produto = @qt_produto
                  WHERE produto_id_produto  = @produto_id_produto";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_estoque", dto.Id));
            parms.Add(new MySqlParameter("qt_produto", dto.QtdProduto));
            parms.Add(new MySqlParameter("produto_id_produto", dto.IdProduto));

            Database db = new Database();
            db.ExecuteInsertScript(script, parms);

        }

        public void Alterar2(EstoqueDTO dto)
        {
            string script = @"UPDATE tb_estoque
                                 SET id_estoque = @id_estoque,
                                     qt_produto = @qt_produto
                  WHERE produto_id_produto = @produto_id_produto";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_estoque", dto.Id));
            parms.Add(new MySqlParameter("qt_produto", dto.QtdProduto));
            parms.Add(new MySqlParameter("produto_id_produto", dto.IdProduto));

            Database db = new Database();
            db.ExecuteInsertScript(script, parms);

        }



        public void AdicionarNoEstoque(int qtd, int idProduto)
        {
            string script = @"UPDATE tb_estoque
                                 SET qt_produto = qt_produto + @qt_produto
                               WHERE produto_id_produto = @produto_id_produto";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("qt_produto", qtd));
            parms.Add(new MySqlParameter("produto_id_produto", idProduto));

            Database db = new Database();
            db.ExecuteInsertScript(script, parms);
        }

        public void RetiraNoEstoque(int qtd, int idProduto)
        {
            string script = @"UPDATE tb_estoque
                                 SET qt_produto = qt_produto - @qt_produto
                               WHERE produto_id_produto = @produto_id_produto";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("qt_produto", qtd));
            parms.Add(new MySqlParameter("produto_id_produto", idProduto));

            Database db = new Database();
            db.ExecuteInsertScript(script, parms);
        }

    }
}
