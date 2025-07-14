using System.ComponentModel.DataAnnotations;

namespace LawPavillion.Library.Backend.API.Dtos
{
    /// <summary>
    /// DTO for creating a new book. Used in POST /api/books.
    /// </summary>
    public class CreateBookDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        [RegularExpression(@"^\d{10}(?:\d{3})?$", ErrorMessage = "ISBN must be 10 or 13 digits")]
        public string ISBN { get; set; }

        [Required]
        public DateTime PublishedDate { get; set; }
    }
}
