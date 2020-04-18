using EFStudy.Database;
using EFStudy.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFStudy.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly ApplicationDBContext _context;

        public FuncionarioController(ApplicationDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var funcionarios = _context.Funcionarios.ToList();

            return View(funcionarios);
        }
        
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Salvar(Funcionario model)
        {
            if(model.Id == 0)
            {
                _context.Funcionarios.Add(model);
            }
            else
            {
                var funcionario = _context.Funcionarios.First(x => x.Id == model.Id);
                funcionario.Nome = model.Nome;
                funcionario.CPF = model.CPF;
                funcionario.Salario = model.Salario;
            }
            
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            var funcionario = _context.Funcionarios.First(x => x.Id == id);
            return View("Cadastrar", funcionario);
        }
        
        public IActionResult Deletar(int id)
        {
            var funcionario = _context.Funcionarios.First(x => x.Id == id);
            _context.Funcionarios.Remove(funcionario);
            _context.SaveChanges();            
            return RedirectToAction("Index");
        }
    }
}
