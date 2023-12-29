using AutoMapper;
using BLL.Models;
using DAL.Entities;
using System.Linq;

namespace BLL.AutoMapper
{
    public class Automapper : Profile
    {
        public Automapper()
        {
            CreateMap<Book, BookDto>()
                    .ForMember(p => p.Book_ID, p2 => p2.MapFrom(src => src.Book_ID))
                    .ReverseMap();
            CreateMap<Employee, EmployeeDto>()
                  .ForMember(p => p.Employee_ID, p2 => p2.MapFrom(src => src.Employee_ID))
                  .ReverseMap();
            CreateMap<Author, AuthorDto>()
                  .ForMember(p => p.Author_ID, p2 => p2.MapFrom(src => src.Author_ID))
                  .ReverseMap();

        }
    }
}
