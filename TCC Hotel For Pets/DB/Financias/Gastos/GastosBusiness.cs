using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC_Hotel_For_Pets.DB.Financias.Gastos
{
    class GastosBusiness
    {
        public int Salvar(GastosDTO dto)
        {
            if (dto.Nome == string.Empty)
            {
                throw new ArgumentException("Descrição do gasto é obrigatório");
            }

            if (dto.Valor == 0)
            {
                throw new ArgumentException("Valor do gasto é obrigatório");
            }

            if (dto.Tipo == string.Empty)
            {
                throw new ArgumentException("Tipo do gasto é obrigatório");
            }

            GastosDatabase db = new GastosDatabase();
            return db.Salvar(dto);
        }

        public void Remover(int id)
        {
            GastosDatabase db = new GastosDatabase();
            db.Remover(id);
        }

        public List<GastosDTO> Listar()
        {
            GastosDatabase db = new GastosDatabase();
            return db.Listar();
        }

        public List<GastosDTO> Consultar(DateTime inicio, DateTime fim)
        {
            GastosDatabase db = new GastosDatabase();
            return db.Consultar(inicio, fim);
        }

        public void Alterar(GastosDTO dto)
        {
            if (dto.Nome == string.Empty)
            {
                throw new ArgumentException("Descrição do gasto é obrigatório");
            }

            if (dto.Valor == 0)
            {
                throw new ArgumentException("Valor do gasto é obrigatório");
            }

            if (dto.Tipo == string.Empty)
            {
                throw new ArgumentException("Tipo do gasto é obrigatório");
            }

            GastosDatabase db = new GastosDatabase();
            db.Alterar(dto);
        }
    }
}
