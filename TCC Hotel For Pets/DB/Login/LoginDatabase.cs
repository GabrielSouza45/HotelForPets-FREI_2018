using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC_Hotel_For_Pets.DB.BASE;
using TCC_Hotel_For_Pets.DB.Funcionário;
using TCC_Hotel_For_Pets.DB.Usuario;

namespace TCC_Hotel_For_Pets.DB.Login
{
    class LoginDatabase
    {
        public UsuarioDTO Logar(string login, string senha)
        {
            string script = @"SELECT * FROM tb_usuario WHERE ds_email_usuario = @ds_email_usuario AND ds_Senha_usuario = @ds_Senha_usuario";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("ds_email_usuario", login));
            parms.Add(new MySqlParameter("ds_Senha_usuario", senha));

            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            UsuarioDTO dto = null;

            if (reader.Read())
            {
                dto = new UsuarioDTO();
                dto.IdUsuario = reader.GetInt32("id_Usuario");
                dto.Nome = reader.GetString("nm_Usuario");
                dto.CPF = reader.GetString("ds_cpf");
                dto.Telefone = reader.GetString("ds_Telefone");
                
                dto.EmailUsu = reader.GetString("ds_email_usuario");
                dto.SenhaUsu = reader.GetString("ds_Senha_usuario");
                dto.Adiministrador = reader.GetBoolean("bt_adm");
                dto.Funcionario = reader.GetBoolean("bt_funcionario");
                //dto = new FuncionarioDTO();
                //dto.Id = reader.GetInt32("id_funcionario");
                //dto.Nome = reader.GetString("nm_nome");
                //dto.CPF = reader.GetString("ds_cpf");
                //dto.Cargo = reader.GetString("ds_cargo");
                //dto.Email = reader.GetString("ds_email_funcionario");
                //dto.Senha = reader.GetString("ds_senha_funcionario");
                //dto.DataNasc = reader.GetDateTime("ds_data_de_nascimento");
                //dto.Telefone = reader.GetString("ds_telefone");
                //dto.Rua = reader.GetString("ds_rua");
                //dto.Bairro = reader.GetString("ds_bairro");
                //dto.CEP = reader.GetInt32("ds_cep");
                //dto.Numero = reader.GetString("nr_numero");
                //dto.Cidade = reader.GetString("ds_cidade");
                //dto.Estado = reader.GetString("ds_estado");
                //dto.ADM = reader.GetBoolean("bt_adm");
                //dto.Funcionario = reader.GetBoolean("bt_funcionario");

            }
            reader.Close();

            return dto;
        }

        //public LoginView Logarr(string login, string senha)
        //{
        //    string script = @"SELECT * FROM tb_usuario WHERE ds_email_usuario = @ds_email_usuario AND ds_senha_usuario = @ds_Senha_usuario";

        //    List<MySqlParameter> parms = new List<MySqlParameter>();
        //    parms.Add(new MySqlParameter("ds_email_usuario", login));
        //    parms.Add(new MySqlParameter("ds_Senha_usuario", senha));

        //    Database db = new Database();
        //    MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

        //    LoginView dto = null;

        //    if (reader.Read())
        //    {
        //        dto = new LoginView();

        //        dto.EmailCliente = reader.GetString("ds_email_usuario");
        //        dto.EmailFuncionario = reader.GetString("ds_email_usuario");
        //        dto.SenhaCliente = reader.GetString("ds_Senha_usuario");
        //        dto.SenhaFuncionario = reader.GetString("ds_Senha_usuario");
                
        //    }
        //    reader.Close();

        //    return dto;
        //}
    }
}
