using System;
using System.Collections.Generic;

namespace ApiCondominio.Models
{
    public partial class Apartamento
    {
        public Apartamento()
        {
            Apartamentopessoa = new HashSet<Apartamentopessoa>();
        }

        public int Idapartamento { get; set; }
        public int? Numero { get; set; }
        public string Bloco { get; set; }

        public virtual ICollection<Apartamentopessoa> Apartamentopessoa { get; set; }
    }
}
