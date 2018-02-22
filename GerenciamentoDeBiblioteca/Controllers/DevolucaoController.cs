using GerenciamentoDeBiblioteca.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace GerenciamentoDeBiblioteca.Controllers
{
    public class DevolucaoController : Controller
    {
        private readonly IRepositorioLivro _repositorioLivro;
        private readonly IRepositorioCliente _repositorioCliente;

        public DevolucaoController(IRepositorioLivro repositorioLivro, IRepositorioCliente repositorioCliente)
        {
            _repositorioLivro = repositorioLivro;
            _repositorioCliente = repositorioCliente;
        }

        [Route("Devolucao")]
        public IActionResult Listar()
        {
            var livrosAlugados = _repositorioLivro.ProcurarComAutorELocator(v => v.Emprestado == true);

            if (livrosAlugados.Count() == 0)
                return View("Vazio");
            else
                return View(livrosAlugados);
        }

        public IActionResult DevolverLivro(Guid livroId)
        {
            var livro = _repositorioLivro.BuscarPorId(livroId);
            livro.ClienteId = Guid.Empty;
            livro.Cliente = null;
            livro.Emprestado = false;

            _repositorioLivro.Atualizar(livro);

            return RedirectToAction("Listar");
        }
    }
}