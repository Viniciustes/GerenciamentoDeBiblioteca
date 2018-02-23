using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GerenciamentoDeBiblioteca.Data.Entidades
{
    public class Autor
    {
        [Key]
        public Guid AutorId { get; set; }

        [Required, MinLength(3), MaxLength(50)]
        public string Nome { get; set; }

        public virtual ICollection<Livro> Livros { get; set; }
    }
}
