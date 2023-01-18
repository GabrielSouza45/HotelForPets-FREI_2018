using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC_Hotel_For_Pets.DB.BASE;

namespace TCC_Hotel_For_Pets.DB.Cliente
{
    class ClienteDatabase
    {
        public int Salvar(ClienteDTO cliente)
        {
            string script =
                @"INSERT INTO tb_cliente (id_cliente, nm_nome, ds_cpf, ds_bairro, ds_cep, ds_rua, ds_telefone, ds_email_cliente, ds_senha_cliente, id_usuario)
                    VALUES(@id_cliente, @nm_nome, @ds_cpf, @ds_bairro, @ds_cep, @ds_rua, @ds_telefone, @ds_email_cliente, @ds_senha_cliente, @id_usuario)";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_cliente", cliente.Id));
            parms.Add(new MySqlParameter("nm_nome", cliente.Nome));
            parms.Add(new MySqlParameter("ds_cpf", cliente.CPF));
            parms.Add(new MySqlParameter("ds_bairro", cliente.Bairro));
            parms.Add(new MySqlParameter("ds_cep", cliente.CEP));
            parms.Add(new MySqlParameter("ds_rua", cliente.Rua));
            parms.Add(new MySqlParameter("ds_telefone", cliente.Telefone));
            parms.Add(new MySqlParameter("ds_email_cliente", cliente.Email));
            parms.Add(new MySqlParameter("ds_senha_cliente", cliente.Senha));
            parms.Add(new MySqlParameter("id_usuario", cliente.IdUsuario));

            Database db = new Database();
            int pk = db.ExecuteInsertScriptWithPk(script, parms);
            return pk;

            
        }
        public void Alterar (ClienteDTO cliente)
        {
            string script =
            @"UPDATE tb_cliente 
                 SET nm_nome = @nm_nome,
                     ds_cpf = @ds_cpf,
                     ds_bairro = @ds_bairro, 
                     ds_cep = @ds_cep, 
                     ds_rua = @ds_rua, 
                     ds_telefone = @ds_telefone,
                     ds_email_cliente = @ds_email_cliente, 
                     ds_senha_cliente = @ds_senha_cliente,
                     id_usuario = @id_usuario

               WHERE id_cliente = @id_cliente";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_cliente", cliente.Id));
            parms.Add(new MySqlParameter("nm_nome", cliente.Nome));
            parms.Add(new MySqlParameter("ds_cpf", cliente.CPF));
            parms.Add(new MySqlParameter("ds_bairro", cliente.Bairro));
            parms.Add(new MySqlParameter("ds_cep", cliente.CEP));
            parms.Add(new MySqlParameter("ds_rua", cliente.Rua));
            parms.Add(new MySqlParameter("ds_telefone", cliente.Telefone));
            parms.Add(new MySqlParameter("ds_email_cliente", cliente.Email));
            parms.Add(new MySqlParameter("ds_senha_cliente", cliente.Senha));
            parms.Add(new MySqlParameter("id_usuario", cliente.IdUsuario));
            Database db = new Database();
            db.ExecuteInsertScript(script, parms);


        }
        public void Remover(int idcli)
        {
            string script =
            @"DELETE FROM tb_cliente WHERE id_cliente = @id_cliente";


            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_cliente", idcli));

            Database db = new Database();
            db.ExecuteInsertScript(script, parms);
        }
        public List<ClienteDTO> Listar()
        {
            string script = @"SELECT * FROM tb_cliente";

            List<MySqlParameter> parms = new List<MySqlParameter>();

            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            List<ClienteDTO> lista = new List<ClienteDTO>();
            while (reader.Read())
            {
                ClienteDTO cliente = new ClienteDTO();
                cliente.Id = reader.GetInt32("id_cliente");
                cliente.Nome = reader.GetString("nm_nome");
                cliente.CPF = reader.GetString("ds_cpf");
                cliente.Bairro = reader.GetString("ds_bairro");
                cliente.CEP = reader.GetInt32("ds_cep");
                cliente.Rua = reader.GetString("ds_rua");
                cliente.Telefone = reader.GetString("ds_telefone");
                cliente.Email = reader.GetString("ds_email_cliente");
                cliente.Senha = reader.GetString("ds_senha_cliente");
                cliente.IdUsuario = reader.GetInt32("id_usuario");


                lista.Add(cliente);
            }
            reader.Close();
            return lista;
        }
        public List<ClienteDTO> Consultar(string cliente)
        {
            string script = @"SELECT * FROM tb_cliente WHERE nm_nome like @nm_nome";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("nm_nome", "%" + cliente + "%"));

            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            List<ClienteDTO> lista = new List<ClienteDTO>();
            while (reader.Read())
            {
                ClienteDTO dto = new ClienteDTO();
                dto.Id = reader.GetInt32("id_cliente");
                dto.Nome = reader.GetString("nm_nome");
                dto.CPF = reader.GetString("ds_cpf");
                dto.Bairro = reader.GetString("ds_bairro");
                dto.CEP = reader.GetInt32("ds_cep");
                dto.Rua = reader.GetString("ds_rua");
                dto.Telefone = reader.GetString("ds_telefone");
                dto.Email = reader.GetString("ds_email_cliente");
                dto.Senha = reader.GetString("ds_senha_cliente");
                dto.IdUsuario = reader.GetInt32("id_usuario");

                lista.Add(dto);
            }
            reader.Close();

            return lista;

        }
    }
}
