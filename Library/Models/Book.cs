using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Book
    {
        [Key]
        public int? Id { get; set; }
        public string? Title { get; set; }
        public int Price { get; set; }
        public string? Category { get; set; }
        public DateTime? RegisteredAt { get; set; }

        [ForeignKey("Author")]
        public int? fk_AuthorID { get; set; }

    }
}
