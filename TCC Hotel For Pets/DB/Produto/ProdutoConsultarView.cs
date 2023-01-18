using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC_Hotel_For_Pets.DB.Produto
{
    public class ProdutoConsultarView
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public decimal PrecoCompra { get; set; }

        public decimal PrecoVenda { get; set; }

        public DateTime DataCompra { get; set; }

        public string Fornecedor { get; set; }

        public int IdFornecedor { get; set; }


    }

}
