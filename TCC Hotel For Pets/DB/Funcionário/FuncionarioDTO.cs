using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC_Hotel_For_Pets.DB.Funcionário
{
    public class FuncionarioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public int CEP { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string CPF { get; set; }
        public string Cargo { get; set; }

        public decimal VT { get; set; }
        public decimal SalarioLiquido { get; set; }
        public decimal VR { get; set; }
        public decimal Convenio { get; set; }
        
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataNasc { get; set; }
     
        public bool ADM { get; set; }
        public bool Funcionario { get; set; }

    }
}
