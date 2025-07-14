using AutoMapper;
using LawPavillion.Library.Backend.API.Dtos;
using LawPavillion.Library.Backend.API.Entities;

namespace LawPavillion.Library.Backend.API.Configurations.Mapping
{
    /// <summary>
    /// AutoMapper profile for mapping between Book entities and DTOs.
    /// Helps simplify data transformation between layers.
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // This map incoming CreateBookDto to Book entity for creation
            CreateMap<CreateBookDto, Book>();

            // This map incoming UpdateBookDto to Book entity for update operations
            CreateMap<UpdateBookDto, Book>();

            // This aslo map Book entity to BookDto for returning data to clients
            CreateMap<Book, BookDto>();
        }
    }
}
