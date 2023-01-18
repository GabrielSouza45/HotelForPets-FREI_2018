using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC_Hotel_For_Pets.DB.BASE;
using TCC_Hotel_For_Pets.DB.Fornecedor;

namespace TCC_Hotel_For_Pets.DB.Produto
{
    class ProdutoDatabase
    {
        public int Salvar(ProdutoDTO produto)
        {
            string script =
            @"INSERT INTO tb_produto_compra (id_produto , nm_produto , vl_preco_compra, vl_preco_venda, id_fornecedor)
                VALUES (@id_produto , @nm_produto , @vl_preco_compra, @vl_preco_venda, @id_fornecedor)";
            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_produto", produto.Id));
            parms.Add(new MySqlParameter("nm_produto", produto.Nome));
            parms.Add(new MySqlParameter("vl_preco_compra", produto.PrecoCompra));
            parms.Add(new MySqlParameter("vl_preco_venda", produto.PrecoVenda));
            parms.Add(new MySqlParameter("id_fornecedor", produto.IdFornecedor));

            Database db = new Database();
            int pk = db.ExecuteInsertScriptWithPk(script, parms);
            return pk;
        }
        public void Alterar(ProdutoConsultarView produto)
        {
            string script =
            @"UPDATE tb_produto_compra SET nm_produto = @nm_produto,
                vl_preco_compra = @vl_preco_compra,
                vl_preco_venda = @vl_preco_venda,
                id_fornecedor = @id_fornecedor
                WHERE id_produto = @id_produto";
            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_produto", produto.Id));
            parms.Add(new MySqlParameter("nm_produto", produto.Nome));
            parms.Add(new MySqlParameter("vl_preco_compra", produto.PrecoCompra));
            parms.Add(new MySqlParameter("vl_preco_venda", produto.PrecoVenda));
            parms.Add(new MySqlParameter("id_fornecedor", produto.IdFornecedor));
            Database db = new Database();
            db.ExecuteInsertScript(script, parms);
        }
        public void Remover(int idproduto)
        {
            string script =
            @"DELETE FROM tb_produto_compra WHERE id_produto = @id_produto";
            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_produto", idproduto));
            Database db = new Database();
            db.ExecuteInsertScript(script, parms);
        }
        public List<ProdutoDTO> Listar()
        {
            string script =
            @"SELECT * FROM tb_produto_compra";
            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, null);
            List<ProdutoDTO> produtos = new List<ProdutoDTO>();
            while (reader.Read())
            {
                ProdutoDTO produto = new ProdutoDTO();
                produto.Id = reader.GetInt32("id_produto");
                produto.Nome = reader.GetString("nm_produto");
                produto.PrecoCompra = reader.GetDecimal("vl_preco_compra");
                produto.PrecoVenda = reader.GetDecimal("vl_preco_venda");
                produto.IdFornecedor = reader.GetInt32("id_fornecedor");

                produtos.Add(produto);
            }
            reader.Close();
            return produtos;
        }
        public List<ProdutoConsultarView> Consultar(string produto)
        {
            string script = @"SELECT * FROM VW_PRODUTO_CONSULTA WHERE nm_produto like @nm_produto";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("nm_produto", "%" + produto + "%"));

            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            List<ProdutoConsultarView> lista = new List<ProdutoConsultarView>();
            while (reader.Read())
            {
                ProdutoConsultarView dto = new ProdutoConsultarView();
                dto.Id = reader.GetInt32("id_produto");
                dto.Nome = reader.GetString("nm_produto");
                dto.PrecoCompra = reader.GetDecimal("vl_preco_compra");
                dto.PrecoVenda = reader.GetDecimal("vl_preco_venda");
                dto.Fornecedor = reader.GetString("nm_nome");
               
                FornecedorDTO forn = new FornecedorDTO();
                dto.IdFornecedor = forn.Id;


                lista.Add(dto);
            }
            reader.Close();

            return lista;
        }
        public List<ProdutoConsultarView> ConsultarPorFornecedor(string fornecedor)
        {
            string script = @"SELECT * FROM vw_consultar_produto_compra WHERE nm_nome like @nm_nome";


            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("nm_nome", fornecedor + "%"));

            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            List<ProdutoConsultarView> lista = new List<ProdutoConsultarView>();
            while (reader.Read())
            {
                ProdutoConsultarView dto = new ProdutoConsultarView();
                dto.Id = reader.GetInt32("id_produto");
                dto.Nome = reader.GetString("nm_produto");
                dto.PrecoCompra = reader.GetDecimal("vl_preco_compra");
                dto.PrecoVenda = reader.GetDecimal("vl_preco_venda");
                dto.Fornecedor = reader.GetString("nm_nome");

                lista.Add(dto);
            }
            reader.Close();

            return lista;
        }
    }
}
