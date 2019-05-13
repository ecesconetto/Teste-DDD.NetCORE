using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MirumDDD.Domain.ViewModels;
using MirumDDD.Service.Interfaces;

namespace MirumDDD.Mvc.Controllers
{
    public class CargoController : Controller
    {
        private readonly ICargoService cargoService;

        public CargoController(ICargoService cargoService)
        {
            this.cargoService = cargoService;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var retorno = await cargoService.Get();
            return View(retorno);
        }

        [HttpGet]
        public async Task<IActionResult> Cadastrar() => View();

        [HttpPost]
        public async Task<IActionResult> Cadastrar(CargoViewModel model)
        {
            var retorno = await cargoService.Post(model);
            return View(retorno);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var retorno = await cargoService.Get(id);
            return View(retorno);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CargoViewModel model)
        {
            var retorno = await cargoService.Update(model);
            return View(retorno);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            //TODO: enviar só o id?
            //var retorno = await cargoService.Update(model);
            return View();
        }
    }
}