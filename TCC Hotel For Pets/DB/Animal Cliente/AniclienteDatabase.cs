using MySql.Data.MySqlClient;
using System.Collections.Generic;
using TCC_Hotel_For_Pets.DB.BASE;

namespace TCC_Hotel_For_Pets.DB.Animal_Cliente
{
    class AniclienteDatabase
    {
        public int Salvar(AniclienteDTO anicliente)
        {
            string script =
                @"INSERT INTO tb_anicliente (id_anicliente, id_cliente, id_animal)
                    VALUES(@id_anicliente, @id_cliente, @id_animal)";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_anicliente", anicliente.Id));
            parms.Add(new MySqlParameter("id_cliente", anicliente.IdCliente));
            parms.Add(new MySqlParameter("id_animal", anicliente.IdAnimal));

            Database db = new Database();
            int pk = db.ExecuteInsertScriptWithPk(script, parms);
            return pk;


        }
        public void Alterar(AniclienteDTO anicliente)
        {
            string script =
            @"UPDATE tb_anicliente 
                 SET id_cliente = @id_cliente,
                     id_animal = @id_animal,
                    
               WHERE id_anicliente = @id_anicliente";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_anicliente", anicliente.Id));
            parms.Add(new MySqlParameter("id_cliente", anicliente.IdCliente));
            parms.Add(new MySqlParameter("id_animal", anicliente.IdAnimal));
           
            Database db = new Database();
            db.ExecuteInsertScript(script, parms);


        }
        public void Remover(int idanicli)
        {
            string script =
            @"DELETE FROM tb_anicliente WHERE id_anicliente = @id_anicliente";


            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_anicliente", idanicli));

            Database db = new Database();
            db.ExecuteInsertScript(script, parms);
        }
        public List<AniclienteDTO> Listar()
        {
            string script =
            @"SELECT * FROM tb_anicliente";
            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, null);
            List<AniclienteDTO> animais = new List<AniclienteDTO>();
            while (reader.Read())
            {
                AniclienteDTO animal = new AniclienteDTO();
                animal.Id = reader.GetInt32("id_anicliente");
                animal.IdAnimal = reader.GetInt32("id_animal");
                animal.IdCliente = reader.GetInt32("id_cliente");
                
                animais.Add(animal);
            }
            reader.Close();
            return animais;
        }
        public List<ViewConsultarAnimal> Consultar(string animal)
        {
            string script = @"SELECT * FROM VW_ANIMAL_CONSULTA WHERE ds_nome_animal like @ds_nome_animal";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("ds_nome_animal", "%" + animal + "%"));

            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            List<ViewConsultarAnimal> lista = new List<ViewConsultarAnimal>();
            while (reader.Read())
            {
                ViewConsultarAnimal dto = new ViewConsultarAnimal();
                dto.Id = reader.GetInt32("id_anicliente");
                dto.IdCliente = reader.GetInt32("id_cliente");
                dto.IdAnimal = reader.GetInt32("id_animal");
                dto.Nome = reader.GetString("ds_nome_animal");
                dto.Especie = reader.GetString("ds_especie");
                dto.Pelagem = reader.GetString("ds_pelagem");
                dto.Porte = reader.GetString("ds_porte");
                dto.Raca = reader.GetString("ds_raca");
                dto.Cor = reader.GetString("ds_cor");
                dto.Castracao = reader.GetString("ds_castracao");
                dto.Carteira = reader.GetString("ds_carteira_vacinacao");
                dto.Cliente = reader.GetString("nm_nome");
                 

                lista.Add(dto);
            }
            reader.Close();

            return lista;
        }

    }
}
