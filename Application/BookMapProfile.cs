using AutoMapper;
using Domain.Dto;
using Domain.Models;

namespace Application;

public class BookMapProfile : Profile
{
    public BookMapProfile()
    {
        CreateMap<AddBookDto, Book>();
        CreateMap<Book, AddBookDto>();
    }
}