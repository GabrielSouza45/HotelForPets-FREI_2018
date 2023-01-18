using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC_Hotel_For_Pets.DB.Fornecedor
{
    class FornecedorBusiness
    {
        public int Salvar(FornecedorDTO fornecedor)
        {
            FornecedorDatabase database = new FornecedorDatabase();
            int id = database.Salvar(fornecedor);
            return id;
        }
        public void Alterar(FornecedorDTO fornecedor)
        {
            FornecedorDatabase db = new FornecedorDatabase();
            db.Alterar(fornecedor);
        }
        public void Remover(int Id)
        {
            FornecedorDatabase db = new FornecedorDatabase();
            db.Remover(Id);

        }
        public List<FornecedorDTO> Consultar(string fornecedor)
        {
            FornecedorDatabase db = new FornecedorDatabase();
            return db.consultar(fornecedor);
        }
        public List<FornecedorDTO> Listar()
        {
            FornecedorDatabase db = new FornecedorDatabase();
            return db.Listar();
        }
    }
}
