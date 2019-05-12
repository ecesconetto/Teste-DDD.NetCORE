using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MirumDDD.Mvc.Controllers
{
    public class PessoaController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Cadastrar()
        {
            return View();
        }
    }
}