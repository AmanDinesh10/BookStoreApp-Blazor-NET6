using System.ComponentModel.DataAnnotations;

namespace  BookStoreApp.API.Models.Author
{   
    public class AuthorCreateDto
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        public string Bio { get; set; }
    }
}