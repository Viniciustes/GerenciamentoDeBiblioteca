using System;
using System.ComponentModel.DataAnnotations;

namespace GerenciamentoDeBiblioteca.Data.Entidades
{
    public class Livro
    {
        [Key]
        public Guid LivroId { get; set; }
        public string Titulo { get; set; }

        public virtual Autor Autor { get; set; }
        public Guid AutorId { get; set; }

        /// <summary>
        /// O cliente é o locatário do livro
        /// </summary>
        public virtual Cliente Cliente { get; set; }
        public Guid ClienteId { get; set; }
    }
}
