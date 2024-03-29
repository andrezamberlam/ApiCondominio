﻿using System;
using System.Collections.Generic;

namespace ApiCondominio.Models
{
    public partial class Pessoa
    {
        public Pessoa()
        {
            Apartamentopessoa = new HashSet<Apartamentopessoa>();
        }

        public int Idpessoa { get; set; }
        public string Nome { get; set; }
        public DateTime? Datanascimento { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Apartamentopessoa> Apartamentopessoa { get; set; }
    }
}
