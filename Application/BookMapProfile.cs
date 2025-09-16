
using Domain.Dto;
using Domain.Models;

namespace Application;

public  static class BookMapProfile
{
    public static Book AddBookDtoToBookModel(AddBookDto dto)
    {
        return   new Book(name:dto.Name, author:dto.Author, publisher:dto.Publisher);
    }
}