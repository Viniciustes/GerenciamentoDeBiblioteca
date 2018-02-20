using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GerenciamentoDeBiblioteca.Data.Entidades;
using GerenciamentoDeBiblioteca.Data.Interfaces;

namespace GerenciamentoDeBiblioteca.Controllers
{
    public class LivroController : Controller
    {
        private readonly IRepositorioLivro _repositorioLivro;
        private readonly IRepositorioAutor _repositorioAutor;

        public LivroController(IRepositorioLivro repositorioLivro, IRepositorioAutor repositorioAutor)
        {
            _repositorioLivro = repositorioLivro;
            _repositorioAutor = repositorioAutor;
        }

        public IActionResult Listar(Guid? autorId, Guid? clienteId)
        {
            if (autorId == null && clienteId == null)
            {
                var livros = _repositorioLivro.BuscarTodosComAutor();

                return VerificarLivros(livros);
            }
            else if (autorId != null)
            {
                var autor = _repositorioAutor.BuscarComLivrosPorId((Guid)autorId);

                if (autor.Livros.Count() == 0)
                    return View("Vazio");
                else
                    return View(autor.Livros);
            }
            else if (clienteId != null)
            {
                var livros = _repositorioLivro.ProcurarComAutorELocator(v => v.ClienteId == clienteId);

                return VerificarLivros(livros);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public IActionResult VerificarLivros(IEnumerable<Livro> livros)
        {
            if (livros.Count() == 0)
                return View("Vazio");
            else
                return View(livros);
        }

    }
}