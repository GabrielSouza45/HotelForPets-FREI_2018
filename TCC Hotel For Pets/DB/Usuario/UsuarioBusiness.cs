using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCC_Hotel_For_Pets.DB.Login;

namespace TCC_Hotel_For_Pets.DB.Usuario
{
    class UsuarioBusiness
    {
        public int Salvar(UsuarioDTO dto)
        {

            
            UsuarioDatabase db = new UsuarioDatabase();
            return db.Salvar(dto);


        }


       
        public UsuarioDTO ConsultarPorEmail(string Login)
        {
            UsuarioDatabase db = new UsuarioDatabase();
            return db.ConsultarPorEmail(Login);
        }
        public UsuarioDTO ConsultarPorTelefone(string Telefone)
        {
            UsuarioDatabase db = new UsuarioDatabase();
            return db.ConsultarPorTelefone(Telefone);
        }
        public UsuarioDTO ConsultarPorCelular(string Celular)
        {
            UsuarioDatabase db = new UsuarioDatabase();
            return db.ConsultarPorCelular(Celular);
        }

        public List<UsuarioDTO> Listar()
        {
            UsuarioDatabase db = new UsuarioDatabase();
            return db.Listar();
        }

        public List<UsuarioDTO> Consultar(string usuario)
        {
            UsuarioDatabase db = new UsuarioDatabase();
            return db.Consultar(usuario);
        }

        public void Alterar(UsuarioDTO usuario)
        {
            UsuarioDatabase db = new UsuarioDatabase();
            db.Alterar(usuario);
        }
        public void Remover(int id)
        {
            UsuarioDatabase db = new UsuarioDatabase();
            db.Remover(id);

        }

    }
}
