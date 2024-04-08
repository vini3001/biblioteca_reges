using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Cpf { get; set; }
        public string? BirthDate { get; set; }

    }
}
