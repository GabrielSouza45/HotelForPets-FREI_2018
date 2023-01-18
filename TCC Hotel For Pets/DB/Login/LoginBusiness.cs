using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC_Hotel_For_Pets.DB.Funcionário;
using TCC_Hotel_For_Pets.DB.Usuario;

namespace TCC_Hotel_For_Pets.DB.Login
{
    class LoginBusiness
    {
        public UsuarioDTO Logar(string login, string senha)
        {
            if (login == string.Empty)
            {
                throw new ArgumentException("Usuário é obrigatório.");
            }

            if (senha == string.Empty)
            {
                throw new ArgumentException("Senha é obrigatório.");
            }

            LoginDatabase db = new LoginDatabase();
            return db.Logar(login, senha);
        }

        //public LoginView Logarr(string login, string senha)
        //{
        //    if (login == string.Empty)
        //    {
        //        throw new ArgumentException("Usuário é obrigatório.");
        //    }

        //    if (senha == string.Empty)
        //    {
        //        throw new ArgumentException("Senha é obrigatório.");
        //    }

        //    LoginDatabase db = new LoginDatabase();
        //    return db.Logarr(login, senha);
        //}
    }
}
