using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC_Hotel_For_Pets.DB.Login
{
    class LoginDTO
    {
        public int IdLogin { get; set; }

        public string EmailCliente { get; set; }
        public string SenhaCliente { get; set; }

        public string EmailFuncionario { get; set; }
        public string SenhaFuncionario { get; set; }

        public string EmailADM { get; set; }
        public string SenhaADM { get; set; }

    }
}
