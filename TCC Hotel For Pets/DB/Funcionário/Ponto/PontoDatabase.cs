using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC_Hotel_For_Pets.DB.BASE;

namespace TCC_Hotel_For_Pets.DB.Funcionário.Ponto
{
    class PontoDatabase
    {
        public int Salvar(PontoDTO dto)
        {
            string script = @"INSERT into tb_ponto (id_ponto,dt_ponto,hr_entrada,hr_almoco_ida,hr_almoco_volta,hr_saida,hrs_trabalhadas_dia,fk_ponto_funcionario)
                              VALUES(@id_ponto,@dt_ponto,@hr_entrada,@hr_almoco_ida,@hr_almoco_volta,@hr_saida,@hrs_trabalhadas_dia,@fk_ponto_funcionario)";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_ponto", dto.Id));
            parms.Add(new MySqlParameter("dt_ponto", dto.Data));
            parms.Add(new MySqlParameter("hr_entrada", dto.Entrada));
            parms.Add(new MySqlParameter("hr_almoco_ida", dto.IdaAlmoco));
            parms.Add(new MySqlParameter("hr_almoco_volta", dto.VoltaAlmoco));
            parms.Add(new MySqlParameter("hr_saida", dto.Saida));
            parms.Add(new MySqlParameter("hrs_trabalhadas_dia", dto.HorasTrabalhadasDia));
            parms.Add(new MySqlParameter("fk_ponto_funcionario", dto.IdFuncionario));

            Database db = new Database();
            return db.ExecuteInsertScriptWithPk(script, parms);

        }

        public List<PontoConsultarView> Consultar(string nome)
        {
            string script = @"SELECT * FROM vw_consultar_ponto WHERE nm_funcionario like @nm_funcionario";


            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("nm_funcionario", nome + "%"));


            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            List<PontoConsultarView> lista = new List<PontoConsultarView>();

            while (reader.Read())
            {
                PontoConsultarView dto = new PontoConsultarView();

                dto.Id = reader.GetInt32("id_ponto");
                dto.NomeFuncionario = reader.GetString("nm_funcionario");
                dto.Data = reader.GetDateTime("dt_ponto");
                dto.Entrada = reader.GetTimeSpan("hr_entrada");
                dto.Saida = reader.GetTimeSpan("hr_saida");
                dto.HorasTrabalhadasDia = reader.GetInt32("hrs_trabalhadas_dia");

                lista.Add(dto);
            }
            reader.Close();
            return lista;



        }
    }
}
