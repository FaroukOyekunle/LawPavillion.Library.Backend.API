using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LawPavillion.Library.Backend.API.Entities
{
    /// <summary>
    /// Represents a book record in the Library system.
    /// </summary>
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        [MaxLength(100)]
        public string Author { get; set; }

        [Required]
        [MaxLength(13)]
        public string ISBN { get; set; }

        public DateTime PublishedDate { get; set; }

    }
}
