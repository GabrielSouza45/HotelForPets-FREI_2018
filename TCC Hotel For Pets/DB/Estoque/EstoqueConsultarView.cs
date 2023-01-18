using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC_Hotel_For_Pets.DB.Estoque
{
    class EstoqueConsultarView
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public string Produto { get; set; }
        public int Quantidade { get; set; }
        public string Fornecedor { get; set; }
        public decimal ValorVenda { get; set; }

    }

}
