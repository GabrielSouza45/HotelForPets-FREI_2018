using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC_Hotel_For_Pets.DB.BASE;

namespace TCC_Hotel_For_Pets.DB.Financias.Gastos
{
    class GastosDatabase
    {
        public int Salvar(GastosDTO dto)
        {
            string script = @"INSERT INTO tb_gastos (nm_gasto,dt_gasto,ds_tipo,vl_gasto) VALUES (@nm_gasto,@dt_gasto,@ds_tipo,@vl_gasto)";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("nm_gasto", dto.Nome));
            parms.Add(new MySqlParameter("dt_gasto", dto.Data));
            parms.Add(new MySqlParameter("ds_tipo", dto.Tipo));
            parms.Add(new MySqlParameter("vl_gasto", dto.Valor));

            Database db = new Database();
            return db.ExecuteInsertScriptWithPk(script, parms);

        }
        public void Remover(int id)
        {
            string script = @"DELETE FROM tb_gastos WHERE id_gasto = @id_gasto";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_gasto", id));

            Database db = new Database();
            db.ExecuteInsertScript(script, parms);
        }

        public List<GastosDTO> Listar()
        {
            string script = @"SELECT * FROM tb_gastos";

            List<MySqlParameter> parms = new List<MySqlParameter>();

            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            List<GastosDTO> lista = new List<GastosDTO>();
            while (reader.Read())
            {
                GastosDTO dto = new GastosDTO();
                dto.Id = reader.GetInt32("id_gasto");
                dto.Nome = reader.GetString("nm_gasto");
                dto.Data = reader.GetDateTime("dt_gasto");
                dto.Tipo = reader.GetString("ds_tipo");
                dto.Valor = reader.GetDecimal("vl_gasto");

                lista.Add(dto);
            }
            reader.Close();
            return lista;
        }

        public List<GastosDTO> Consultar(DateTime inicio, DateTime fim)
        {
            string script = @"SELECT * FROM tb_gastos 
                                       Where dt_gasto >= @inicio and dt_gasto <= @fim";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("inicio", inicio));
            parms.Add(new MySqlParameter("fim", fim));

            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            List<GastosDTO> lista = new List<GastosDTO>();
            while (reader.Read())
            {
                GastosDTO dto = new GastosDTO();
                dto.Id = reader.GetInt32("id_gasto");
                dto.Nome = reader.GetString("nm_gasto");
                dto.Data = reader.GetDateTime("dt_gasto");
                dto.Tipo = reader.GetString("ds_tipo");
                dto.Valor = reader.GetDecimal("vl_gasto");


                lista.Add(dto);
            }
            reader.Close();

            return lista;
        }

        public void Alterar(GastosDTO dto)
        {
            string script = @"UPDATE tb_gastos SET nm_gasto = @nm_gasto, 
                                                   dt_gasto = @dt_gasto,
                                                   ds_tipo  = @ds_tipo, 
                                                   vl_gasto = @vl_gasto 
                                             WHERE id_gasto = @id_gasto";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_gasto", dto.Id));
            parms.Add(new MySqlParameter("nm_gasto", dto.Nome));
            parms.Add(new MySqlParameter("dt_gasto", dto.Data));
            parms.Add(new MySqlParameter("ds_tipo", dto.Tipo));
            parms.Add(new MySqlParameter("vl_gasto", dto.Valor));

            Database db = new Database();
            db.ExecuteInsertScript(script, parms);

        }
    }
}
