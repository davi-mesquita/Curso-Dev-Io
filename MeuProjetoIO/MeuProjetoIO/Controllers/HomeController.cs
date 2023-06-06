using MeuProjetoIO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MeuProjetoIO.Controllers
{
    [Route("")] //sobrecarga de rotas -> oq diz ali é q mesmo se tiver uma rota vazia tbm vai encontrar a controller
    [Route("gestao-clientes")] // eles sempre usa a ultima rota especificada
    //[Route("gestao-clientes/{id}")] // com parametro na url
    //[Route("gestao-clientes/{id}/{categoria?}")] //lembrar sempre de colocar o nome do parametro da função igual o parametro da rota
    [Route("gestao-clientes/{id:int}/{categoria?}")] // Para colocar o tipo do paremetro na rota e só colocar : dps do nome dado a variable
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //[Route("pagina-inicial")]
        public IActionResult Index()
        {
            var filme = new Filme
            {
                Titulo = "Oi",
                DataLancamento = DateTime.Now,
                Genero = null,
                Avaliacao = 10,
                Valor = 20000,
            };
            return RedirectToAction("Privacy", filme);
           // return View();
        }

        [Route("privacidade")]
        public IActionResult Privacy(Filme filme)
        {
            if (ModelState.IsValid)
            {

            }
            foreach (var error in ModelState.Values.SelectMany(m => m.Errors))
            {
                Console.WriteLine(error.ErrorMessage);
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("erro-encontrado")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}