﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC_Hotel_For_Pets.DB.Usuario
{
    public class UsuarioView
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
