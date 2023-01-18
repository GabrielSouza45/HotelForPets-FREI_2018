using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC_Hotel_For_Pets.DB.Cliente;
using TCC_Hotel_For_Pets.DB.Funcionário;
using TCC_Hotel_For_Pets.DB.Login;

namespace TCC_Hotel_For_Pets
{
   static  class UserSession
    {
        public static UsuarioDTO UsuarioLogado { get; set; }
    }
}
