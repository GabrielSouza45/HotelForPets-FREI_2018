using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC_Hotel_For_Pets.DB.BASE;

namespace TCC_Hotel_For_Pets.DB.Financias.Fluxo
{
    class FluxoDatabase
    {
        public List<FluxoDTO> Consultar(DateTime inicio, DateTime fim)
        {
            string script = @"SELECT * FROM vw_consultar_fluxodecaixa 
                 Where dt_referencia >= @inicio and dt_referencia <= @fim";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("inicio", inicio));
            parms.Add(new MySqlParameter("fim", fim));

            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            List<FluxoDTO> lista = new List<FluxoDTO>();
            while (reader.Read())
            {
                FluxoDTO dto = new FluxoDTO();
                dto.DataReferencia = reader.GetDateTime("dt_referencia");
                dto.ValorGanhos = reader.GetDecimal("vl_total_ganhos");
                dto.ValorDespesas = reader.GetDecimal("vl_total_despesas");
                dto.ValorLucros = reader.GetDecimal("vl_saldo");

                lista.Add(dto);

            }
            reader.Close();

            return lista;

        }
    }
}
