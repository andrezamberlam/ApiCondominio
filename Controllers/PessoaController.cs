using System;
using System.Collections.Generic;
using System.Linq;
using ApiCondominio.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiCondominio.Controllers
{
    [Route("api/[controller]"), Authorize("Bearer")]
    public class PessoaController : Controller
    {
        private dbcondominiosContext _context;

        public PessoaController(dbcondominiosContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return Ok(_context.Pessoa.ToArray().OrderBy(x => x.Nome));
        }

        [Route("cadastrar"), HttpPost]
        public IActionResult cadastrar([FromForm]Pessoa p)
        {
            Pessoa pBD = _context.Pessoa.SingleOrDefault(x => x.Cpf == p.Cpf);
            if (pBD != null)
            {
                return Ok(new { sucess = false, message = "Cpf ja cadastrado" });
            }

            _context.Add(p);
            _context.SaveChanges();
            return Ok(new { sucess = true, message = "" });
        }

        [Route("excluir"), HttpPost]
        public IActionResult excluir([FromForm]int Idpessoa)
        {
            Pessoa pes = _context.Pessoa.Single(x => x.Idpessoa == Idpessoa);
            List<Apartamentopessoa> appes = _context.Apartamentopessoa.Where(x => x.Idpessoa == Idpessoa).ToList();

            if (appes.Count > 0)
                _context.Apartamentopessoa.RemoveRange(appes);

            _context.Remove(pes);
            _context.SaveChanges();
            return Ok(new { sucess = true, message = "" });
        }


        // [Route("abc")]
        // public IActionResult abc()
        // {
        //     Pessoa p = new Pessoa();
        //     p.Cpf = "";
        //     p.Datanascimento = new DateTime();
        //     p.Email = "";
        //     p.Nome = "teste add";
        //     p.Telefone = "";
        //     _context.Pessoa.Add(p);
        //     _context.SaveChanges();
        //     return Ok(p);
        // }


    }
}