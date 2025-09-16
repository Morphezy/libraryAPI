using Domain.Models;

namespace Application;

public interface IBookRepository
{
    public Task<IEnumerable<Book>> GetAll();
    public Task<Book> GetById(int id);
    public Task<IEnumerable<Book>> GetByAuthor(string author);
    public Task<IEnumerable<Book>> GetByPublisher(string publisher);
    public Task<IEnumerable<Book>> GetByName(string name);
    
    public Task<Book> Add(Book book);
    public Task<Book> Rent(int id);
    public Task<Book> Return(int id);
}