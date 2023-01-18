using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC_Hotel_For_Pets.DB.BASE;

namespace TCC_Hotel_For_Pets.DB.Folha_de_pagamento
{
    class FolhaDePagamentoDatabase
    {
        public int Salvar(FolhaDePagamentoDTO dto)
        {
            string script = @"INSERT INTO tb_folha_de_pagamento (id_folha_de_pagamento,vl_salario,vl_vt,vl_vr,vl_convenio,vl_fgts,vl_inss,vl_ir,vl_horasextras,vl_bruto,vl_liquido,dt_pagamento,fk_id_funcionario)
                             VALUES(@id_folha_de_pagamento,@vl_salario,@vl_vt,@vl_vr,@vl_convenio,@vl_fgts,@vl_inss,@vl_ir,@vl_horasextras,@vl_bruto,@vl_liquido,@dt_pagamento,@fk_id_funcionario)";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_folha_de_pagamento", dto.IdFolha));
            parms.Add(new MySqlParameter("vl_salario", dto.Salario));
            parms.Add(new MySqlParameter("vl_vt", dto.ValeTransporte));
            parms.Add(new MySqlParameter("vl_vr", dto.ValeRefeicao));
            parms.Add(new MySqlParameter("vl_convenio", dto.Convenio));
            parms.Add(new MySqlParameter("vl_fgts", dto.FGTS));
            parms.Add(new MySqlParameter("vl_inss", dto.INSS));
            parms.Add(new MySqlParameter("vl_ir", dto.IR));
            parms.Add(new MySqlParameter("vl_horasextras", dto.HorasExtras));
            parms.Add(new MySqlParameter("vl_bruto", dto.SalarioBruto));
            parms.Add(new MySqlParameter("vl_liquido", dto.SalarioLiquido));
            parms.Add(new MySqlParameter("dt_pagamento", dto.DataReferencia));
            parms.Add(new MySqlParameter("fk_id_funcionario", dto.IdFuncionario));

            Database db = new Database();
            return db.ExecuteInsertScriptWithPk(script, parms);

        }

        public List<FolhadePagamentoView> Consultar(string nome)
        {
            string script = @"SELECT * FROM vw_consultar_folha WHERE nm_nome like @nm_nome";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("nm_nome", nome + "%"));

            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            List<FolhadePagamentoView> lista = new List<FolhadePagamentoView>();

            while (reader.Read())
            {
                FolhadePagamentoView dto = new FolhadePagamentoView();
                dto.IdFolha = reader.GetInt32("id_folha_de_pagamento");
                dto.NomeFuncionario = reader.GetString("nm_nome");
                dto.SalarioBruto = reader.GetDecimal("vl_bruto");
                dto.SalarioLiquido = reader.GetDecimal("vl_liquido");
                dto.HorasExtras = reader.GetDecimal("vl_horasextras");
                dto.DataReferencia = reader.GetDateTime("dt_pagamento");

                lista.Add(dto);

            }
            reader.Close();
            return lista;

        }

        public List<FolhadePagamentoView> Listar()
        {
            string script = @"SELECT * FROM vw_consultar_folha";

            List<MySqlParameter> parms = new List<MySqlParameter>();

            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, null);

            List<FolhadePagamentoView> lista = new List<FolhadePagamentoView>();

            while (reader.Read())
            {
                FolhadePagamentoView dto = new FolhadePagamentoView();
                dto.IdFolha = reader.GetInt32("id_folha_de_pagamento");
                dto.NomeFuncionario = reader.GetString("nm_nome");
                dto.Salario = reader.GetDecimal("vl_salario");
                dto.SalarioBruto = reader.GetDecimal("vl_bruto");
                dto.SalarioLiquido = reader.GetDecimal("vl_liquido");
                dto.ValeAlimentacao = reader.GetDecimal("vl_vt");
                dto.ValeRefeicao = reader.GetDecimal("vl_vr");
                dto.ValeTransporte = reader.GetDecimal("vl_vt");
                dto.Convenio = reader.GetDecimal("vl_convenio");
                dto.HorasExtras = reader.GetDecimal("vl_horas_extras");
                dto.INSS = reader.GetDecimal("vl_inss");
                dto.FGTS = reader.GetDecimal("vl_fgts");
                dto.IR = reader.GetDecimal("vl_ir");
                dto.DataReferencia = reader.GetDateTime("dt_pagamento");
                lista.Add(dto);

            }
            reader.Close();
            return lista;


        }

        public void Remover(int id)
        {
            string script = @"DELETE FROM tb_folha_de_pagamento WHERE id_folha_de_pagamento = @id_folha_de_pagamento";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_folha_de_pagamento", id));

            Database db = new Database();
            db.ExecuteInsertScript(script, parms);

        }
    }
}
