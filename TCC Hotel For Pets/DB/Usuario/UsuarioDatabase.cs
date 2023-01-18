using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC_Hotel_For_Pets.DB.BASE;
using TCC_Hotel_For_Pets.DB.Login;

namespace TCC_Hotel_For_Pets.DB.Usuario
{
    class UsuarioDatabase
    {
        public int Salvar(UsuarioDTO dto)
        {
            string script = @"INSERT INTO tb_usuario (nm_usuario, ds_cpf, ds_telefone, ds_celular, ds_email_usuario, ds_senha_usuario, bt_adm, bt_funcionario) 
                                   VALUES (@nm_usuario, @ds_cpf, @ds_telefone, @ds_celular, @ds_email_usuario, @ds_senha_usuario, @bt_adm, @bt_funcionario)";

            List<MySqlParameter> parms = new List<MySqlParameter>();

            parms.Add(new MySqlParameter("nm_usuario", dto.Nome));
            parms.Add(new MySqlParameter("ds_cpf", dto.CPF));
            parms.Add(new MySqlParameter("ds_telefone", dto.Telefone));
            parms.Add(new MySqlParameter("ds_celular", dto.Celular));
            parms.Add(new MySqlParameter("ds_email_usuario", dto.EmailUsu));
            parms.Add(new MySqlParameter("ds_senha_usuario", dto.SenhaUsu));
            parms.Add(new MySqlParameter("bt_adm", dto.Adiministrador));
            parms.Add(new MySqlParameter("bt_funcionario", dto.Funcionario));

            Database db = new Database();
            return db.ExecuteInsertScriptWithPk(script, parms);
        }

        public void Alterar(UsuarioDTO dto)
        {
            string script = @"UPDATE tb_usuario 
                                 SET nm_usuario = @nm_usuario,
                                     ds_cpf = @ds_cpf,
                                     ds_telefone = @ds_telefone,
                                     ds_celular = @ds_celular,
                                     ds_email_usuario = @ds_email_usuario,
                                     ds_senha_usuario = @ds_senha_usuario

                               WHERE id_usuario = @id_usuario";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_usuario", dto.IdUsuario));
            parms.Add(new MySqlParameter("nm_usuario", dto.Nome));
            parms.Add(new MySqlParameter("ds_cpf", dto.CPF));
            parms.Add(new MySqlParameter("ds_telefone", dto.Telefone));
            parms.Add(new MySqlParameter("ds_celular", dto.Celular));
            parms.Add(new MySqlParameter("ds_email_usuario", dto.EmailUsu));
            parms.Add(new MySqlParameter("ds_senha_usuario", dto.SenhaUsu));

            Database db = new Database();
            db.ExecuteInsertScript(script, parms);

        }

        public void Remover(int id)
        {
            string script = @"DELETE FROM tb_usuario WHERE id_usuario = @id_usuario";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_usuario", id));

            Database db = new Database();
            db.ExecuteInsertScript(script, parms);
        }

        public List<UsuarioDTO> Consultar(string usuario)
        {
            string script = @"SELECT * FROM tb_usuario WHERE nm_usuario like @nm_usuario";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("nm_usuario", usuario + "%"));

            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            List<UsuarioDTO> lista = new List<UsuarioDTO>();
            while (reader.Read())
            {
                UsuarioDTO dto = new UsuarioDTO();
               
                dto.IdUsuario = reader.GetInt32("id_usuario");
                dto.Nome = reader.GetString("nm_usuario");
                dto.CPF = reader.GetString("ds_cpf");
                dto.Telefone = reader.GetString("ds_telefone");
                dto.Celular = reader.GetString("ds_celular");
                dto.EmailUsu = reader.GetString("ds_email_usuario");
                dto.SenhaUsu = reader.GetString("ds_senha_usuario");
                dto.Adiministrador = reader.GetBoolean("bt_adm");
                dto.Funcionario = reader.GetBoolean("bt_funcionario");

                lista.Add(dto);
            }
            reader.Close();

            return lista;
        }

        public List<UsuarioDTO> Listar()
        {
            string script = @"SELECT * FROM tb_usuario";

            List<MySqlParameter> parms = new List<MySqlParameter>();

            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            List<UsuarioDTO> lista = new List<UsuarioDTO>();
            while (reader.Read())
            {
                UsuarioDTO dto = new UsuarioDTO();
                dto.IdUsuario = reader.GetInt32("id_usuario");
                dto.Nome = reader.GetString("nm_usuario");
                dto.CPF = reader.GetString("ds_cpf");
                dto.Telefone = reader.GetString("ds_telefone");
                
                dto.EmailUsu = reader.GetString("ds_email_usuario");
                dto.SenhaUsu = reader.GetString("ds_senha_usuario");

                lista.Add(dto);
            }
            reader.Close();

            return lista;
        }
        public List<UsuarioDTO> consultar(string Nome)
        {
            string script =
            @"SELECT * FROM tb_usuario WHERE nm_usuario LIKE @nm_usuario";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("nm_usuario", "%" + Nome + "%"));

            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            List<UsuarioDTO> Usuario = new List<UsuarioDTO>();
            while (reader.Read())
            {
                UsuarioDTO dto = new UsuarioDTO();
                dto.IdUsuario = reader.GetInt32("id_usuario");
                dto.Nome = reader.GetString("nm_usuario");
                dto.CPF = reader.GetString("ds_cpf");
                dto.Telefone = reader.GetString("ds_telefone");
                dto.Celular = reader.GetString("ds_celular");
                dto.EmailUsu = reader.GetString("ds_email_usuario");
                dto.SenhaUsu = reader.GetString("ds_senha_usuario");

                Usuario.Add(dto);
            }
            reader.Close();
            return Usuario;
        }
        public UsuarioDTO ConsultarPorUsuario(string usuario)
        {
            string script = @"SELECT * FROM tb_usuario WHERE nm_usuario = @nm_usuario";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("nm_usuario", usuario));

            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            UsuarioDTO dto = null;
            if (reader.Read())
            {
                dto = new UsuarioDTO();

                dto.IdUsuario = reader.GetInt32("id_usuario");
                dto.Nome = reader.GetString("nm_usuario");
                dto.CPF = reader.GetString("ds_cpf");
                dto.EmailUsu = reader.GetString("ds_email_usuario");
            }
            reader.Close();

            return dto;
        }
        public UsuarioDTO ConsultarPorEmail(string email)
        {
            string script = @"SELECT * FROM tb_usuario WHERE ds_email_usuario = @ds_email_usuario";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("ds_email_usuario", email));

            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            UsuarioDTO dto = null;
            if (reader.Read())
            {
                dto = new UsuarioDTO();

                dto.IdUsuario = reader.GetInt32("id_usuario");
                dto.Nome = reader.GetString("nm_usuario");
                dto.EmailUsu = reader.GetString("ds_email_usuario");
            }
            reader.Close();

            return dto;
        }
        public UsuarioDTO ConsultarPorTelefone(string Telefone)
        {
            string script = @"SELECT * FROM tb_usuario WHERE ds_telefone = @ds_telefone";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("ds_telefone", Telefone));

            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            UsuarioDTO dto = null;
            if (reader.Read())
            {
                dto = new UsuarioDTO();

                dto.IdUsuario = reader.GetInt32("id_usuario");
                dto.Nome = reader.GetString("nm_usuario");
                dto.Telefone = reader.GetString("ds_telefone");
            }
            reader.Close();

            return dto;
        }
        public UsuarioDTO ConsultarPorCelular(string Celular)
        {
            string script = @"SELECT * FROM tb_usuario WHERE ds_celular = @ds_celular";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("ds_celular", Celular));

            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            UsuarioDTO dto = null;
            if (reader.Read())
            {
                dto = new UsuarioDTO();

                dto.IdUsuario = reader.GetInt32("id_usuario");
                dto.Nome = reader.GetString("nm_usuario");
                dto.Telefone = reader.GetString("ds_celular");
            }
            reader.Close();

            return dto;
        }
    }
}
