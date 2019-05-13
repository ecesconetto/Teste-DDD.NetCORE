using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MirumDDD.Domain.ViewModels;
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
        public async Task<IActionResult> Cadastrar() => View();

        [HttpPost]
        public async Task<IActionResult> Cadastrar(PessoaViewModel model)
        {
            var retorno = await pessoaService.Post(model);
            return View(retorno);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var retorno = await pessoaService.Get(id);
            return View(retorno);
        }

        [HttpPut]
        public async Task<IActionResult> Update(PessoaViewModel model)
        {
            var retorno = await pessoaService.Update(model);
            return View(retorno);
        }

        [HttpPut]
        public async Task<IActionResult> Delete(PessoaViewModel model)
        {
            //TODO: enviar só o id?
            var retorno = await pessoaService.Update(model);
            return View(retorno);
        }
    }
}