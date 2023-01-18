using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC_Hotel_For_Pets.DB.Funcionário
{
    class FuncionarioConsultarView
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf{ get; set; }
        public string Cargo { get; set; }
        public DateTime Nascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int Cep { get; set; }
        public bool Adiministrador { get; set; }
        public bool Funcionario { get; set; }
    }
}
