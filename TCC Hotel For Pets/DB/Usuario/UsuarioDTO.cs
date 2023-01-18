using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC_Hotel_For_Pets.DB.Login
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }

        public string Telefone { get; set; }

        public string Celular { get; set; }

        public string EmailUsu { get; set; }
        public string SenhaUsu { get; set; }

        public bool Adiministrador { get; set; }
        public bool Funcionario { get; set; }
       
    }
}
