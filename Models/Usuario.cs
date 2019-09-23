using System;
using System.Collections.Generic;

namespace ApiCondominio.Models
{
    public partial class Usuario
    {
        public int Idusuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
