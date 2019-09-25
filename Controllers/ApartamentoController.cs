using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ApiCondominio.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiCondominio.Controllers
{
    [Route("api/[controller]"), Authorize("Bearer")]
    public class ApartamentoController : Controller
    {
        private dbcondominiosContext _context;

        public ApartamentoController(dbcondominiosContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // IList<Apartamento> apes = _context.Apartamento.ToList();
            // dynamic listaDinamica = apes;
            // foreach (Apartamento ape in listaDinamica)
            // {
            //     IList<Apartamentopessoa> apepes = _context.Apartamentopessoa.Where(x => x.Idapartamento == ape.Idapartamento).ToList();

            //     IList<Pessoa> pesList = null;
            //     foreach (Apartamentopessoa item in apepes)
            //     {
            //         Pessoa pes = _context.Pessoa.SingleOrDefault(x => x.Idpessoa == item.Idpessoa);
            //         if(pes != null)
            //             pesList.Add(pes);
            //     }


            //     ape
            //     listaDinamica.Where(x => x.);



                
            //     IList<Pessoa> pessoas = _context.Pessoa.Where(x => x.Apartamentopessoa.)
            // }
            return Ok(_context.Apartamento.ToArray().OrderBy(x => x.Numero));
        }

        [Route("cadastrar"), HttpPost]
        public IActionResult cadastrar([FromForm]Apartamento a)
        {
            a.Apartamentopessoa.Clear();
            List<int> pessoas = JsonConvert.DeserializeObject<List<int>>(HttpContext.Request.Form["Apartamentopessoa"]);
            foreach (var item in pessoas)
            {
                //int asd = int32.Parse(item);
                Apartamentopessoa app = new Apartamentopessoa();
                app.Idpessoa = item;
                a.Apartamentopessoa.Add(app);
            }

            if (pessoas.Count == 0)
                return Ok(new { sucess = false, message = "Necessário ao menos uma pessoa." });


            _context.Add(a);
            _context.SaveChanges();
            return Ok(new { sucess = true, message = "" });
        }

        [Route("excluir"), HttpPost]
        public IActionResult excluir([FromForm]int Idapartamento)
        {
            Apartamento ap = _context.Apartamento.Single(x => x.Idapartamento == Idapartamento);
            List<Apartamentopessoa> appes = _context.Apartamentopessoa.Where(x => x.Idapartamento == Idapartamento).ToList();
            if (appes.Count > 0)
                _context.Apartamentopessoa.RemoveRange(appes);
            _context.Remove(ap);
            _context.SaveChanges();
            return Ok(new { sucess = true, message = "" });
        }

        // [Route("abc")]
        // public IActionResult abc()
        // {
        //     Apartamento a = new Apartamento();
        //     a.Bloco = "A";
        //     a.Numero = 1522;

        //     _context.Add(a);
        //     _context.SaveChanges();
        //     return Ok();
        // }
    }
}