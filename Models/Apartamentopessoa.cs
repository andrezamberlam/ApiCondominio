using System;
using System.Collections.Generic;

namespace ApiCondominio.Models
{
    public partial class Apartamentopessoa
    {
        public int Idapartamento { get; set; }
        public int Idpessoa { get; set; }

        public virtual Apartamento IdapartamentoNavigation { get; set; }
        public virtual Pessoa IdpessoaNavigation { get; set; }
    }
}
