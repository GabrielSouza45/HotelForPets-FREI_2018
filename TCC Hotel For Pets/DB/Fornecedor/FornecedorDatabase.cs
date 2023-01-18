using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC_Hotel_For_Pets.DB.BASE;

namespace TCC_Hotel_For_Pets.DB.Fornecedor
{
    class FornecedorDatabase
    {
        public int Salvar(FornecedorDTO fornecedor)
        {
            string script =
            @"INSERT INTO tb_fornecedor ( nm_nome , ds_telefone, ds_cidade, ds_estado, ds_bairro, ds_rua, nr_numero, ds_cep)
                VALUES ( @nm_nome , @ds_telefone, @ds_cidade, @ds_estado, @ds_bairro, @ds_rua, @nr_numero, @ds_cep)";
            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("nm_nome", fornecedor.Nome));
            parms.Add(new MySqlParameter("ds_telefone", fornecedor.Telefone));
            parms.Add(new MySqlParameter("ds_cidade", fornecedor.Cidade));
            parms.Add(new MySqlParameter("ds_estado", fornecedor.Estado));
            parms.Add(new MySqlParameter("ds_bairro", fornecedor.Bairro));
            parms.Add(new MySqlParameter("ds_rua", fornecedor.Rua));
            parms.Add(new MySqlParameter("nr_numero", fornecedor.Numero));
            parms.Add(new MySqlParameter("ds_cep", fornecedor.Cep));
            Database db = new Database();
            int pk = db.ExecuteInsertScriptWithPk(script, parms);
            return pk;
        }

        public List<FornecedorDTO> consultar(string Nome)
        {
            string script =
            @"SELECT * FROM tb_fornecedor WHERE nm_nome LIKE @nm_nome";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("nm_nome", "%" + Nome + "%"));

            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            List<FornecedorDTO> lista = new List<FornecedorDTO>();
            while (reader.Read())
            {
                FornecedorDTO dto = new FornecedorDTO();
                dto.Id = reader.GetInt32("id_fornecedor");
                dto.Nome = reader.GetString("nm_nome");
                dto.Telefone = reader.GetString("ds_telefone");
                dto.Cidade = reader.GetString("ds_cidade");
                dto.Estado = reader.GetString("ds_estado");
                dto.Bairro = reader.GetString("ds_bairro");
                dto.Rua = reader.GetString("ds_rua");
                dto.Numero = reader.GetString("nr_numero");
                dto.Cep = reader.GetString("ds_cep");

                lista.Add(dto);
            }
            reader.Close();
            return lista;
        }
        public void Alterar(FornecedorDTO fornecedor)
        {
            string script =
            @"UPDATE tb_fornecedor SET nm_nome = @nm_nome,
                ds_telefone = @ds_telefone,
                ds_cidade = @ds_cidade,
                ds_estado = @ds_estado,
                ds_bairro = @ds_bairro,
                ds_rua = @ds_rua,
                nr_numero = @nr_numero,
                ds_cep = @ds_cep
                WHERE id_fornecedor = @id_fornecedor";
            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_fornecedor", fornecedor.Id));
            parms.Add(new MySqlParameter("nm_nome", fornecedor.Nome));
            parms.Add(new MySqlParameter("ds_telefone", fornecedor.Telefone));
            parms.Add(new MySqlParameter("ds_cidade", fornecedor.Cidade));
            parms.Add(new MySqlParameter("ds_estado", fornecedor.Estado));
            parms.Add(new MySqlParameter("ds_bairro", fornecedor.Bairro));
            parms.Add(new MySqlParameter("ds_rua", fornecedor.Rua));
            parms.Add(new MySqlParameter("nr_numero", fornecedor.Numero));
            parms.Add(new MySqlParameter("ds_cep", fornecedor.Cep));
            Database db = new Database();
            db.ExecuteInsertScript(script, parms);
        }
        public void Remover(int idfornecedor)
        {
            string script =
            @"DELETE FROM tb_fornecedor WHERE id_fornecedor = @id_fornecedor";
            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_fornecedor", idfornecedor));
            Database db = new Database();
            db.ExecuteInsertScript(script, parms);
        }

        public List<FornecedorDTO> Listar()
        {
            string script = @"SELECT * FROM tb_fornecedor";

            List<MySqlParameter> parms = new List<MySqlParameter>();

            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            List<FornecedorDTO> lista = new List<FornecedorDTO>();
            while (reader.Read())
            {
                FornecedorDTO dto = new FornecedorDTO();
                dto.Id = reader.GetInt32("id_fornecedor");
                dto.Nome = reader.GetString("nm_nome");
                dto.Telefone = reader.GetString("ds_telefone");
                dto.Cidade = reader.GetString("ds_cidade");
                dto.Estado = reader.GetString("ds_estado");
                dto.Bairro = reader.GetString("ds_bairro");
                dto.Rua = reader.GetString("ds_rua");
                dto.Numero = reader.GetString("nr_numero");
                dto.Cep = reader.GetString("ds_cep");

                lista.Add(dto);
            }
            reader.Close();

            return lista;
        }


    }
}
