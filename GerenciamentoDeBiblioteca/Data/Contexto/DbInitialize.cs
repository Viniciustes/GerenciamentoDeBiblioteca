using GerenciamentoDeBiblioteca.Data.Entidades;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace GerenciamentoDeBiblioteca.Data.Contexto
{
    public class DbInitialize
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var contexto = serviceScope.ServiceProvider.GetService<DbBibliotecaContexto>();

                // Add Clientes
                contexto.Clientes.Add(new Cliente { Nome = "Ronaldinho Gaúcho" });
                contexto.Clientes.Add(new Cliente { Nome = "Peter Pan" });
                contexto.Clientes.Add(new Cliente { Nome = "Roberto Carlos" });

                // Add Autores
                contexto.Autores.Add(new Autor
                {
                    Nome = "Brown,Dan",
                    Livros = new List<Livro>() { new Livro { Titulo = "Origem" }, new Livro { Titulo = "O código da vinci" } }
                });

                contexto.Autores.Add(new Autor
                {
                    Nome = "Jorge Amado",
                    Livros = new List<Livro>() { new Livro { Titulo = "Capitães da Areia" }, new Livro { Titulo = "Gabriela, Cravo e Canela" }, new Livro { Titulo = "Dona Flor e seus Dois Maridos" } }
                });

                contexto.SaveChanges();
            }
        }
    }
}
