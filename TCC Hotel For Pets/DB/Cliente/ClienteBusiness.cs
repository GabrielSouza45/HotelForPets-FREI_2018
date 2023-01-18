using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC_Hotel_For_Pets.DB.Login;
using TCC_Hotel_For_Pets.DB.Usuario;

namespace TCC_Hotel_For_Pets.DB.Cliente
{
    class ClienteBusiness
    {
        ClienteDatabase db = new ClienteDatabase();

        public int Salvar(ClienteDTO cliente)
        {

            int id = db.Salvar(cliente);
            return id;
        }
        public void Alterar(ClienteDTO cliente, UsuarioDTO dto)
        {
             db.Alterar(cliente);

            UsuarioDatabase udb = new UsuarioDatabase();
            dto.IdUsuario = cliente.IdUsuario;

            udb.Alterar(dto);
        }

        public void Remover(int Id)
        {

            db.Remover(Id);

        }
        public List<ClienteDTO> Consultar(string cliente)
        {

            return db.Consultar(cliente);
        }
        public List<ClienteDTO> Listar()
        {

            return db.Listar();
        }

    }
}
