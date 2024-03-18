using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Author
    {
        [Key]
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Cpf { get; set; }
        public string? BirthDate { get; set; }

        public IList<Book>? Books { get; set; }

    }
}
