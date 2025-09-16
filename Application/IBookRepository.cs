using Domain.Models;

namespace Application;

public interface IBookRepository
{
    public List<Book> GetAll();
    public Book GetById(int id);
    public List<Book> GetByAuthor(string author);
    public List<Book> GetByPublisher(string publisher);
    public List<Book> GetByName(string name);
    
    public Book Add(Book book);
    
    public Book Delete(int id);
}