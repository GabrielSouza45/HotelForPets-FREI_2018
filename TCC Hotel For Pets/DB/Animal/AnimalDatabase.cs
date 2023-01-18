using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC_Hotel_For_Pets.DB.Animal_Cliente;
using TCC_Hotel_For_Pets.DB.BASE;

namespace TCC_Hotel_For_Pets.DB.Animal
{
    class AnimalDatabase
    {
        public int Salvar(AnimalDTO animal)
        {
            string script =
                @"INSERT INTO tb_animal(id_animal, ds_nome_animal, ds_especie, ds_pelagem, ds_porte, ds_raca, ds_cor, ds_castracao, ds_carteira_vacinacao)
                        VALUES(@id_animal, @ds_nome_animal, @ds_especie, @ds_pelagem, @ds_porte, @ds_raca, @ds_cor, @ds_castracao, @ds_carteira_vacinacao)";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_animal", animal.Id));
            parms.Add(new MySqlParameter("ds_nome_animal", animal.Nome));
            parms.Add(new MySqlParameter("ds_especie", animal.Especie));
            parms.Add(new MySqlParameter("ds_pelagem", animal.Pelagem));
            parms.Add(new MySqlParameter("ds_porte", animal.Porte));
            parms.Add(new MySqlParameter("ds_raca", animal.Raca));
            parms.Add(new MySqlParameter("ds_cor", animal.Cor));
            parms.Add(new MySqlParameter("ds_castracao", animal.Castracao));
            parms.Add(new MySqlParameter("ds_carteira_vacinacao", animal.Carteira));
            

            Database db = new Database();
            int pk = db.ExecuteInsertScriptWithPk(script, parms);
            return pk;
        }
        public void Alterar(ViewConsultarAnimal animal)
        {
            string script =
            @"UPDATE tb_animal 
                 SET ds_nome_animal = @ds_nome_animal,
                     ds_especie = @ds_especie,
                     ds_pelagem = @ds_pelagem, 
                     ds_porte = @ds_porte, 
                     ds_raca = @ds_raca, 
                     ds_cor = @ds_cor,
                     ds_castracao = @ds_castracao, 
                     ds_carteira_vacinacao = @ds_carteira_vacinacao

               WHERE id_animal = @id_animal";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_animal", animal.Id));
            parms.Add(new MySqlParameter("ds_nome_animal", animal.Nome));
            parms.Add(new MySqlParameter("ds_especie", animal.Especie));
            parms.Add(new MySqlParameter("ds_pelagem", animal.Pelagem));
            parms.Add(new MySqlParameter("ds_porte", animal.Porte));
            parms.Add(new MySqlParameter("ds_raca", animal.Raca));
            parms.Add(new MySqlParameter("ds_cor", animal.Cor));
            parms.Add(new MySqlParameter("ds_castracao", animal.Castracao));
            parms.Add(new MySqlParameter("ds_carteira_vacinacao", animal.Carteira));

            Database db = new Database();
            db.ExecuteInsertScript(script, parms);


        }
        public void Remover(int idanimal)
        {
            string script =
            @"DELETE FROM tb_animal WHERE id_animal = @id_animal";


            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("id_animal", idanimal));

            Database db = new Database();
            db.ExecuteInsertScript(script, parms);
        }
        public List<AnimalDTO> Listar()
        {
            string script = @"SELECT * FROM tb_animal";

            List<MySqlParameter> parms = new List<MySqlParameter>();

            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            List<AnimalDTO> lista = new List<AnimalDTO>();
            while (reader.Read())
            {
                AnimalDTO animal = new AnimalDTO();
                animal.Id = reader.GetInt32("id_animal");
                animal.Nome = reader.GetString("ds_nome_animal");
                animal.Especie = reader.GetString("ds_especie");
                animal.Pelagem = reader.GetString("ds_pelagem");
                animal.Porte = reader.GetString("ds_porte");
                animal.Raca = reader.GetString("ds_raca");
                animal.Cor = reader.GetString("ds_cor");
                animal.Castracao = reader.GetString("ds_castracao");
                animal.Carteira = reader.GetString("ds_carteira_vacinacao");


                lista.Add(animal);
            }
            reader.Close();
            return lista;
        }
        public List<AnimalDTO> Consultar(string animal)
        {
            string script = @"SELECT * FROM tb_animal WHERE ds_nome_animal like @ds_nome_animal";

            List<MySqlParameter> parms = new List<MySqlParameter>();
            parms.Add(new MySqlParameter("ds_nome_animal", "%" + animal + "%"));

            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelectScript(script, parms);

            List<AnimalDTO> lista = new List<AnimalDTO>();
            while (reader.Read())
            {
                AnimalDTO dto = new AnimalDTO();
                dto.Id = reader.GetInt32("id_animal");
                dto.Nome = reader.GetString("ds_nome_animal");
                dto.Especie = reader.GetString("ds_especie");
                dto.Pelagem = reader.GetString("ds_pelagem");
                dto.Porte = reader.GetString("ds_porte");
                dto.Raca = reader.GetString("ds_raca");
                dto.Cor = reader.GetString("ds_cor");
                dto.Castracao = reader.GetString("ds_castracao");
                dto.Carteira = reader.GetString("ds_carteira_vacinacao");
               

                lista.Add(dto);
            }
            reader.Close();

            return lista;

        }
    }
}
