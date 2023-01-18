using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC_Hotel_For_Pets.DB.BASE;

namespace TCC_Hotel_For_Pets.DB.Funcionário
{
    class FuncionarioDatabase
    {
        public int Salvar(FuncionarioDTO funcionario)
        {
            string script =
            @"INSERT INTO tb_funcionario (id_funcionario , nm_nome , ds_cpf, ds_cargo, ds_senha_funcionario, ds_data_de_nascimento, ds_telefone,ds_celular, ds_email_funcionario, 
                           ds_rua, ds_bairro, ds_cep, nr_numero, ds_cidade, ds_estado, bt_adm, bt_funcionario, vl_vale_transporte, vl_vale_refeicao, vl_convenio, vl_salario_liquido)
                VALUES (@id_funcionario , @nm_nome , @ds_cpf, @ds_cargo, @ds_senha_funcionario, @ds_data_de_nascimento, @ds_telefone, @ds_celular, @ds_email_funcionario, @ds_rua, 
                           @ds_bairro, @ds_cep, @nr_numero, @ds_cidade, @ds_estado, @bt_adm, @bt_funcionario, @vl_vale_transporte, @vl_vale_refeicao, @vl_convenio, @vl_salario_liquido)";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_funcionario", funcionario.Id));
            parms.Add(new MySqlParameter("nm_nome", funcionario.Nome));
            parms.Add(new MySqlParameter("ds_cpf", funcionario.CPF));
            parms.Add(new MySqlParameter("ds_cargo", funcionario.Cargo));
            parms.Add(new MySqlParameter("ds_senha_funcionario", funcionario.Senha));
            parms.Add(new MySqlParameter("ds_data_de_nascimento", funcionario.DataNasc));
            parms.Add(new MySqlParameter("ds_telefone", funcionario.Telefone));
            parms.Add(new MySqlParameter("ds_celular", funcionario.Celular));
            parms.Add(new MySqlParameter("ds_email_funcionario", funcionario.Email));
            parms.Add(new MySqlParameter("ds_rua", funcionario.Rua));
            parms.Add(new MySqlParameter("ds_bairro", funcionario.Bairro));
            parms.Add(new MySqlParameter("ds_cep", funcionario.CEP));
            parms.Add(new MySqlParameter("nr_numero", funcionario.Numero));
            parms.Add(new MySqlParameter("ds_cidade", funcionario.Cidade));
            parms.Add(new MySqlParameter("ds_estado", funcionario.Estado));
            parms.Add(new MySqlParameter("bt_adm", funcionario.ADM));
            parms.Add(new MySqlParameter("bt_funcionario", funcionario.Funcionario));
            parms.Add(new MySqlParameter("vl_vale_transporte", funcionario.VT));
            parms.Add(new MySqlParameter("vl_vale_refeicao", funcionario.VR));
            parms.Add(new MySqlParameter("vl_convenio", funcionario.Convenio));
            parms.Add(new MySqlParameter("vl_salario_liquido", funcionario.SalarioLiquido));


            Database db = new Database();
            int pk = db.ExecuteInsertScriptWithPk(script, parms);
            return pk;

        }
        public void Alterar(FuncionarioDTO funcionario)
        {
            string script =
            @"UPDATE tb_funcionario 
                 SET nm_nome  = @nm_nome,
                  ds_cpf = @ds_cpf,
                  ds_cargo = @ds_cargo,
                  ds_email_funcionario  = @ds_email_funcionario ,
                  ds_senha_funcionario  = @ds_senha_funcionario,
                  ds_data_de_nascimento = @ds_data_de_nascimento,
                  ds_telefone = @ds_telefone,
                    ds_celular = @ds_celular,
                     ds_rua = @ds_rua,
                     ds_bairro = @ds_bairro,
                     ds_cep = @ds_cep,
                     nr_numero = @nr_numero,
                     ds_cidade = @ds_cidade,
                     ds_estado = @ds_estado,
                    bt_adm = @bt_adm,
                    bt_funcionario = @bt_funcionario,
                  vl_vale_transporte = @vl_vale_transporte,
                  vl_vale_refeicao = @vl_vale_refeicao,
                    vl_convenio = @vl_convenio,
                    vl_salario_liquido = @vl_salario_liquido

               WHERE id_funcionario = @id_funcionario";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_funcionario", funcionario.Id));
            parms.Add(new MySqlParameter("nm_nome", funcionario.Nome));
            parms.Add(new MySqlParameter("ds_cpf", funcionario.CPF));
            parms.Add(new MySqlParameter("ds_cargo", funcionario.Cargo));
            parms.Add(new MySqlParameter("ds_email_funcionario", funcionario.Email));
            parms.Add(new MySqlParameter("ds_senha_funcionario", funcionario.Senha));
            parms.Add(new MySqlParameter("ds_data_de_nascimento", funcionario.DataNasc));
            parms.Add(new MySqlParameter("ds_telefone", funcionario.Telefone));
            parms.Add(new MySqlParameter("ds_celular", funcionario.Celular));
            parms.Add(new MySqlParameter("ds_rua", funcionario.Rua));
            parms.Add(new MySqlParameter("ds_bairro", funcionario.Bairro));
            parms.Add(new MySqlParameter("ds_cep", funcionario.CEP));
            parms.Add(new MySqlParameter("nr_numero", funcionario.Numero));
            parms.Add(new MySqlParameter("ds_cidade", funcionario.Cidade));
            parms.Add(new MySqlParameter("ds_estado", funcionario.Estado));
            parms.Add(new MySqlParameter("bt_adm", funcionario.ADM));
            parms.Add(new MySqlParameter("bt_funcionario", funcionario.Funcionario));
            parms.Add(new MySqlParameter("vl_vale_transporte", funcionario.VT));
            parms.Add(new MySqlParameter("vl_vale_refeicao", funcionario.VR));
            parms.Add(new MySqlParameter("vl_convenio", funcionario.Convenio));
            parms.Add(new MySqlParameter("vl_salario_liquido", funcionario.SalarioLiquido));

            Database db = new Database();
            db.ExecuteInsertScript(script, parms);


        }
        public void Remover(int idfunc)
        {
            string script =
            @"DELETE FROM tb_funcionario WHERE id_funcionario = @id_funcionario";


            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_funcionario", idfunc));

            Database db = new Database();
            db.ExecuteInsertScript(script, parms);
        }
        public List<FuncionarioDTO> Listar()
        {
            string script = @"SELECT * FROM tb_funcionario";

            List<MySqlParameter> parms = new List<MySqlParameter>();

            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            List<FuncionarioDTO> lista = new List<FuncionarioDTO>();
            while (reader.Read())
            {
                FuncionarioDTO funcionario = new FuncionarioDTO();
                funcionario.Id = reader.GetInt32("id_funcionario");
                funcionario.Nome = reader.GetString("nm_nome");
                funcionario.CEP = reader.GetInt32("ds_cep");
                funcionario.Rua = reader.GetString("ds_rua");
                funcionario.Numero = reader.GetString("nr_numero");
                funcionario.Bairro = reader.GetString("ds_bairro");
                funcionario.Cidade = reader.GetString("ds_cidade");
                funcionario.Estado = reader.GetString("ds_estado");
                funcionario.Telefone = reader.GetString("ds_telefone");
                funcionario.Celular = reader.GetString("ds_celular");
                funcionario.CPF = reader.GetString("ds_cpf");
                funcionario.Cargo = reader.GetString("ds_cargo");
                funcionario.VT = reader.GetDecimal("vl_vale_transporte");
                funcionario.SalarioLiquido = reader.GetDecimal("vl_salario_liquido");
                funcionario.VR = reader.GetDecimal("vl_vale_refeicao");
                funcionario.Convenio = reader.GetDecimal("vl_convenio");
                funcionario.Email = reader.GetString("ds_email_funcionario");
                funcionario.Senha = reader.GetString("ds_senha_funcionario");
                funcionario.DataNasc = reader.GetDateTime("ds_data_de_nascimento");
                funcionario.ADM = reader.GetBoolean("bt_adm");
                funcionario.Funcionario = reader.GetBoolean("bt_funcionario");


                lista.Add(funcionario);
            }
            reader.Close();
            return lista;
        }
        public List<FuncionarioDTO> Consultar(string funcionario)
        {
            string script = @"SELECT * FROM tb_funcionario WHERE nm_nome like @nm_nome";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("nm_nome", "%" + funcionario + "%"));

            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            List<FuncionarioDTO> lista = new List<FuncionarioDTO>();
            while (reader.Read())
            {
                FuncionarioDTO dto = new FuncionarioDTO();
                dto.Id = reader.GetInt32("id_funcionario");
                dto.Nome = reader.GetString("nm_nome");
                dto.CEP = reader.GetInt32("ds_cep");
                dto.Rua = reader.GetString("ds_rua");
                dto.Numero = reader.GetString("nr_numero");
                dto.Bairro = reader.GetString("ds_bairro");
                dto.Cidade = reader.GetString("ds_cidade");
                dto.Estado = reader.GetString("ds_estado");
                dto.Telefone = reader.GetString("ds_telefone");
                dto.Celular = reader.GetString("ds_celular");
                dto.CPF = reader.GetString("ds_cpf");
                dto.Cargo = reader.GetString("ds_cargo");
                dto.VT = reader.GetDecimal("vl_vale_transporte");
                dto.SalarioLiquido = reader.GetDecimal("vl_salario_liquido");
                dto.VR = reader.GetDecimal("vl_vale_refeicao");
                dto.Convenio = reader.GetDecimal("vl_convenio");
                dto.Email = reader.GetString("ds_email_funcionario");
                dto.Senha = reader.GetString("ds_senha_funcionario");
                dto.DataNasc = reader.GetDateTime("ds_data_de_nascimento");
                dto.ADM = reader.GetBoolean("bt_adm");
                dto.Funcionario = reader.GetBoolean("bt_funcionario");

                lista.Add(dto);
            }
            reader.Close();

            return lista;

        }



        public List<FuncionarioDTO> ListarADM()
        {
            string script = @"SELECT * FROM tb_funcionario";

            List<MySqlParameter> parms = new List<MySqlParameter>();

            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            List<FuncionarioDTO> lista = new List<FuncionarioDTO>();
            while (reader.Read())
            {
                FuncionarioDTO funci = new FuncionarioDTO();
                funci.Id = reader.GetInt32("id_funcionario");
                funci.Nome = reader.GetString("nm_nome");
                funci.Telefone = reader.GetString("ds_telefone");
                funci.Celular = reader.GetString("ds_celular");
                funci.Email = reader.GetString("ds_email_funcionario");


                lista.Add(funci);
            }
            reader.Close();
            return lista;
        }

        public List<FuncionarioDTO> ConsultarADM(string adm)
        {
            string script = @"SELECT * FROM tb_funcionario WHERE bt_adm = true";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("bt_adm", "%" + adm + "%"));

            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            List<FuncionarioDTO> lista = new List<FuncionarioDTO>();
            while (reader.Read())
            {
                FuncionarioDTO dto = new FuncionarioDTO();
                dto.Id = reader.GetInt32("id_funcionario");
                dto.Nome = reader.GetString("nm_nome");
                dto.Telefone = reader.GetString("ds_telefone");
                dto.Celular = reader.GetString("ds_celular");
                dto.Email = reader.GetString("ds_email_funcionario");
                

                lista.Add(dto);
            }
            reader.Close();

            return lista;
        }
    }
}
