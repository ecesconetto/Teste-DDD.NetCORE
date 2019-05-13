using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MirumDDD.Service.Interfaces;

namespace MirumDDD.Mvc.Controllers
{
    public class PessoaController : Controller
    {
        private readonly IPessoaService pessoaService;

        public PessoaController(IPessoaService pessoaService)
        {
            this.pessoaService = pessoaService;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var retorno = await pessoaService.Get();
            return View(retorno);
        }

        [HttpGet]
        public async Task<IActionResult> Cadastrar()
        {
            return View();
        }
    }
}