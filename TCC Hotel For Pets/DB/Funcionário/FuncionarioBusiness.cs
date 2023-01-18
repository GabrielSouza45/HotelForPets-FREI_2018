using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC_Hotel_For_Pets.DB.Funcionário
{
    class FuncionarioBusiness
    {
        FuncionarioDatabase db = new FuncionarioDatabase();

        public int Salvar(FuncionarioDTO funcionario)
        {
           
            int id = db.Salvar(funcionario);
            return id;
        }
        public void Alterar(FuncionarioDTO funcionario)
        {
            
             db.Alterar(funcionario);
        }

        public void Remover(int Id)
        {
            
            db.Remover(Id);

        }
        public List<FuncionarioDTO> Consultar(string funcionario)
        {
           
            return db.Consultar(funcionario);
        }
        public List<FuncionarioDTO> Listar()
        {
           
            return db.Listar();
        }
        public List<FuncionarioDTO> ConsultarADM(string btADM)
        {
            return db.ConsultarADM(btADM);
        }

        public List<FuncionarioDTO> ListarADM()
        {
            return db.ListarADM();
        }
    }
}
