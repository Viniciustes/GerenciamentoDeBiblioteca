using GerenciamentoDeBiblioteca.Data.Entidades;
using GerenciamentoDeBiblioteca.Data.Interfaces;
using GerenciamentoDeBiblioteca.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GerenciamentoDeBiblioteca.Controllers
{
    public class AutorController : Controller
    {
        private readonly IRepositorioAutor _repositorioAutor;

        public AutorController(IRepositorioAutor repositorioAutor)
        {
            _repositorioAutor = repositorioAutor;
        }

        public IActionResult Cadastrar()
        {
            var cadastrarAutorViewModel = new CadastrarAutorViewModel()
            {
                Referer = Request.Headers["Referer"].ToString()
            };

            return View(cadastrarAutorViewModel);
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastrarAutorViewModel cadastrarAutorViewModel)
        {
            if (!ModelState.IsValid) return View(cadastrarAutorViewModel);

            _repositorioAutor.Cadastrar(cadastrarAutorViewModel.Autor);

            if (!string.IsNullOrEmpty(cadastrarAutorViewModel.Referer))
                return Redirect(cadastrarAutorViewModel.Referer);

            return RedirectToAction("Listar");
        }

        public IActionResult Editar(Guid id)
        {
            var autor = _repositorioAutor.BuscarPorId(id);
            if (autor == null) return NotFound();

            return View(autor);
        }

        [HttpPost]
        public IActionResult Editar(Autor autor)
        {
            if (!ModelState.IsValid) return View(autor);

            _repositorioAutor.Atualizar(autor);
            return RedirectToAction("Listar");
        }

        public IActionResult Apagar(Guid id)
        {
            var autor = _repositorioAutor.BuscarPorId(id);
            if (autor == null) return NotFound();

            _repositorioAutor.Apagar(autor);

            return RedirectToAction("Listar");
        }

        [Route("Autor")]
        public IActionResult Listar()
        {
            var autores = _repositorioAutor.BuscarTodosComLivros();
            if (autores.Count() == 0) return View("Vazio");

            var autorViewModel = new List<AutorViewModel>();

            foreach (var autor in autores)
            {
                autorViewModel.Add(new AutorViewModel
                {
                    Autor = autor
                });
            }

            return View(autorViewModel);
        }
    }
}