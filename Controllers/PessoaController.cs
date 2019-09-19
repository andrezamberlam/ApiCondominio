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
    }
}