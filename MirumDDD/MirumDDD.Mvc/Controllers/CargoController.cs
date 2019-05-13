using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Cadastrar()
        {
            return View();
        }
    }
}