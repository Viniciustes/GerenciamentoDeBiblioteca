﻿using GerenciamentoDeBiblioteca.Data.Entidades;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDeBiblioteca.Data.Contexto
{
    public class DbBibliotecaContexto : DbContext
    {
        public DbBibliotecaContexto(DbContextOptions<DbBibliotecaContexto> options) : base(options) { }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
    }
}
