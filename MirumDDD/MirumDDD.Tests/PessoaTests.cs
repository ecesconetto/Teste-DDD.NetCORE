using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.TestHost;
using MirumDDD.Domain.ViewModels;
using MirumDDD.Mvc.Controllers;
using MirumDDD.Service.Interfaces;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace MirumDDD.Tests
{
    public class PessoaTests
    {
        private readonly IWebHostBuilder _webHostBuilder;
        private readonly Mock<IPessoaService> pessoaService;
        private readonly Mock<ICargoService> cargoService;

        //Teste usando xUnit e Moq, mockando os services e chamando as controllers
        public PessoaTests()
        {
            this.pessoaService = new Mock<IPessoaService>();
            this.cargoService = new Mock<ICargoService>();

            _webHostBuilder = new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>();
        }

        [Fact]
        public async Task Should_List_Pessoas()
        {
            pessoaService.Setup(x => x.Get())
                .Returns(Task.FromResult(new List<PessoaViewModel>()));

            using (var server = new TestServer(_webHostBuilder))
            using (var client = server.CreateClient())
            {
                var controller = new PessoaController(pessoaService.Object, cargoService.Object);
                var retorno = await controller.Listar();

                var retornoOk = retorno as ViewResult;

                Assert.NotNull(retornoOk);
                Assert.NotNull(retorno);
                Assert.NotNull(retornoOk.Model);
                pessoaService.Verify(x => x.Get(), Times.Once);
            }
        }

        [Fact]
        public async Task Should_Not_Update_Pessoa()
        {
            pessoaService.Setup(x => x.Update(new PessoaViewModel()
            {
                Id = It.IsAny<int>(),
                Email = null,
                Nome = null,
                RG = null,
                CargoId = It.IsAny<int>()
            }));

            using (var server = new TestServer(_webHostBuilder))
            using (var client = server.CreateClient())
            {
                var controller = new PessoaController(pessoaService.Object, cargoService.Object);

                controller.ModelState.AddModelError("Id", "Required");

                var retorno = await controller.Update(new PessoaViewModel()
                {
                    Id = It.IsAny<int>(),
                    Email = null,
                    Nome = null,
                    RG = null,
                    CargoId = It.IsAny<int>()
                });

                var retornoOk = retorno as ViewResult;

                Assert.NotNull(retornoOk);
                Assert.False(retornoOk.ViewData.ModelState.IsValid);
                pessoaService.Verify(x => x.Update(new PessoaViewModel()
                {
                    Id = It.IsAny<int>(),
                    Email = null,
                    Nome = null,
                    RG = null,
                    CargoId = It.IsAny<int>()
                }), Times.Once);
            }
        }

        [Fact]
        public async Task Should_Update_Pessoa_Get()
        {
            pessoaService.Setup(x => x.Get(It.IsAny<int>()))
                .Returns(Task.FromResult(new PessoaViewModel()
                {
                    CargoId = It.IsAny<int>(),
                    Nome = It.IsAny<string>(),
                    Email = It.IsAny<string>(),
                    RG = It.IsAny<string>(),
                    Id = It.IsAny<int>()
                }));

            using (var server = new TestServer(_webHostBuilder))
            using (var client = server.CreateClient())
            {
                var controller = new PessoaController(pessoaService.Object, cargoService.Object);
                var retorno = await controller.Update(1);

                var retornoOk = retorno as ViewResult;

                Assert.NotNull(retornoOk);
                Assert.NotNull(retorno);
                Assert.NotNull(retornoOk.Model);
                pessoaService.Verify(x => x.Get(It.IsAny<int>()), Times.Once);
            }
        }
    }
}
