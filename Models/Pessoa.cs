using System;
namespace ApiCondominio.Models
{
    public class Pessoa
    {
        public int idPessoa { get; set; }
        public string nome { get; set; }
        public DateTime dataNascimento { get; set; }
        public string telefone { get; set; }
        public string cpf { get; set; }
        public string email { get; set; }
    }
}