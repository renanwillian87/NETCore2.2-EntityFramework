using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFStudy.Models;
using EFStudy.Database;
using Microsoft.EntityFrameworkCore;

namespace EFStudy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDBContext _context;

        public HomeController(ApplicationDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Categoria()
        {
            //var c1 = new Categoria { Nome = "TV" };
            //var c2 = new Categoria { Nome = "Mobile" };
            //var c3= new Categoria { Nome = "Video Game" };
            //var c4 = new Categoria { Nome = "Automoveis" };

            //_context.AddRange(new List<Categoria>{ c1, c2, c3, c4 });
            //_context.SaveChanges();

            var categorias = _context.Categorias.Where(x => x.Nome.Equals("Mobile")).ToList();

            Console.WriteLine("===============CATEGORIAS=============");

            categorias.ForEach(categoria => {
                Console.WriteLine(categoria.ToString());
            });

            Console.WriteLine("=========================================");

            return Content("Dados Salvos");
        }

        public IActionResult RelacionamentoUmParaUmProdutoCategoria()
        {
            //var p1 = new Produto();
            //p1.Nome = "Doritos";
            //p1.Categoria = _context.Categorias.First(x => x.Id == 1);

            //var p2 = new Produto();
            //p2.Nome = "Agua";
            //p2.Categoria = _context.Categorias.First(x => x.Id == 1);

            //var p3 = new Produto();
            //p3.Nome = "Biscoito";
            //p3.Categoria = _context.Categorias.First(x => x.Id == 2);

            //_context.Add(p1);
            //_context.Add(p2);
            //_context.Add(p3);

            //_context.SaveChanges();

            var produtos = _context.Produtos
                .Include(x => x.Categoria)
                .ToList();

            produtos.ForEach(produto =>
            {
                Console.WriteLine(produto.ToString());
            });

            return Content("Relacionamento");
        }

        public IActionResult RelacionamentoUmParaMuitos()
        {
            var produtos = _context.Produtos
                .Include(x => x.Categoria)
                .Where(x => x.Categoria.Id == 1)
                .ToList();

            produtos.ForEach(produto =>
            {
                Console.WriteLine(produto.ToString());
            });

            return Content("Relacionamento");
        }

        public IActionResult RelacionamentoLazyLoad()
        {
            var produtos = _context.Produtos
                .Where(x => x.Categoria.Id == 1)
                .ToList();

            produtos.ForEach(produto =>
            {
                Console.WriteLine(produto.ToString());
            });

            return Content("Relacionamento");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
