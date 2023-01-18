using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC_Hotel_For_Pets.DB.Estoque;

namespace TCC_Hotel_For_Pets.DB.Produto
{
    class ProdutoBusiness
    {
        public int Salvar(ProdutoDTO dto, List<EstoqueConsultarView> estoque)
        {
            if (dto.Nome == string.Empty)
            {
                throw new ArgumentException("Nome do produto é obrigatório");
            }

            if (dto.PrecoCompra == 0)
            {
                throw new ArgumentException("Preço de compra deve ser maior que 0");
            }

            if (dto.PrecoVenda == 0)
            {
                throw new ArgumentException("Preço de venda deve ser maior que 0");
            }
            ProdutoDatabase produtoDB = new ProdutoDatabase();
            int id = produtoDB.Salvar(dto);
           

            EstoqueBusiness itemBusiness = new EstoqueBusiness();
            
            EstoqueDTO itemdto = new EstoqueDTO() ;
            itemdto.IdProduto = id;
            itemdto.QtdProduto = 0;

            itemBusiness.Salvar(itemdto);
            

            return id;

        }
        public void Alterar(ProdutoConsultarView produto)
        {
            ProdutoDatabase produtoDB = new ProdutoDatabase();
            produtoDB.Alterar(produto);
        }
        public void Remover(int Id)
        {
            ProdutoDatabase produtoDB = new ProdutoDatabase();
            produtoDB.Remover(Id);

        }
        public List<ProdutoConsultarView> Consultar(string produto)
        {
            ProdutoDatabase db = new ProdutoDatabase();
            return db.Consultar(produto);
        }
        public List<ProdutoDTO> Listar()
        {
            ProdutoDatabase db = new ProdutoDatabase();
            return db.Listar();
        }
        public List<ProdutoConsultarView> ConsultarPorFornecedor(string fornecedor)
        {
            ProdutoDatabase db = new ProdutoDatabase();
            return db.ConsultarPorFornecedor(fornecedor);
        }
    }

}
