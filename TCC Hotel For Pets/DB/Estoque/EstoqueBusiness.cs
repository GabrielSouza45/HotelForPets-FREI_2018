using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC_Hotel_For_Pets.DB.Estoque
{
    class EstoqueBusiness
    {
        EstoqueDatabase db = new EstoqueDatabase();
        public int Salvar(EstoqueDTO dto)
        {
            
            return db.Salvar(dto);

        }

        public List<EstoqueConsultarView> Consultar(string produto)
        {
           
            return db.Consultar(produto);

        }

        public List<EstoqueConsultarView> Listar()
        {
           
            return db.Listar();
        }

        public List<EstoqueDTO> Listar2()
        {
            return db.Listar2();
        }


        public void Alterar(EstoqueDTO dto)
        {
            db.Alterar(dto);
        }

        public void Alterar2(EstoqueDTO dto)
        {
            db.Alterar2(dto);
        }

        public void AdicionarNoEstoque(int qtd, int idProduto)
        {
            db.AdicionarNoEstoque(qtd, idProduto);
        }
    }
}
