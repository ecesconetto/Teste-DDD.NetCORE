using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MirumDDD.Domain.ViewModels;
using MirumDDD.Service.Interfaces;

namespace MirumDDD.Mvc.Controllers
{
    public class PessoaController : Controller
    {
        private readonly IPessoaService pessoaService;
        private readonly ICargoService cargoService;

        public PessoaController(IPessoaService pessoaService, ICargoService cargoService)
        {
            this.pessoaService = pessoaService;
            this.cargoService = cargoService;
        }

        [HttpGet]
        public async Task<IActionResult> Listar(int cargoId = 0)
        {
            List<PessoaViewModel> retorno;
            ViewBag.Cargos = await cargoService.Get();
            ViewBag.Selected = cargoId;

            if (cargoId == 0)
                retorno = await pessoaService.Get();
            else
                retorno = await pessoaService.GetPessoaByCargoId(cargoId);

            return View(retorno);
        }

        [HttpGet]
        public async Task<IActionResult> Cadastrar()
        {
            ViewBag.Cargos = await cargoService.Get();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(PessoaViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var retorno = await pessoaService.Post(model);
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.Cargos = await cargoService.Get();
            var retorno = await pessoaService.Get(id);
            return View(retorno);
        }

        [HttpPost]
        public async Task<IActionResult> Update(PessoaViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var retorno = await pessoaService.Update(model);
            return RedirectToAction("Listar");
        }

        public async Task<JsonResult> Delete(int id)
        {
            var retorno = await pessoaService.Delete(id);
            return Json(true);
        }
    }
}