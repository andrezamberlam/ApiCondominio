using System;
using System.Collections.Generic;
using System.Linq;
using ApiCondominio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCondominio.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private dbcondominiosContext _context;

        public UsuarioController(dbcondominiosContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return Ok(_context.Usuario.ToArray());
        }

        [Route("cadastrar")]
        [HttpPost]
        public IActionResult cadastrar([FromForm]Usuario Usuario)
        {
            _context.Usuario.Add(Usuario);
            _context.SaveChanges();
            return Ok(Usuario);
        }


    }
}