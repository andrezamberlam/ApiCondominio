using System;
using System.Linq;
using ApiCondominio.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiCondominio.Controllers
{
    [Route("api/[controller]")]
    public class PessoaController : Controller
    {
        private dbcondominiosContext _context;

        public PessoaController(dbcondominiosContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return Ok(_context.Pessoa.ToArray());
        }

        [Route("abc")]
        public IActionResult abc()
        {
            Pessoa p = new Pessoa();
            p.Cpf = "";
            p.Datanascimento = new DateTime();
            p.Email = "";
            p.Nome = "teste add";
            p.Telefone = "";
            _context.Pessoa.Add(p);
            _context.SaveChanges();
            return Ok(p);
        }

        
    }
}