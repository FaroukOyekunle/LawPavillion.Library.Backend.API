using System.ComponentModel.DataAnnotations;

namespace LawPavillion.Library.Backend.API.Dtos
{
    /// <summary>
    /// DTO for updating an existing book. Used in PUT /api/books/{id}.
    /// </summary>
    public class UpdateBookDto : CreateBookDto
    {
        [Required]
        public int Id { get; set; }
    }
}
