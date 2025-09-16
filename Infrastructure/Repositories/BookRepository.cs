using System.Data;
using Dapper;
using Domain.Models;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Application.Repositories;

public class BookRepository(IConfiguration config) : IBookRepository
{
    private  readonly IConfiguration _configuration = config;
    
    public async  Task<IEnumerable<Book>> GetAll()
    {
        
        using (IDbConnection db = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        {
            var books = await db.QueryAsync<Book>("select * from public.books");
            return books;
        }
        
    }

    public async Task<Book> GetById(int id)
    {

        using (IDbConnection db = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        {
            var book = await  db.QueryFirstAsync<Book>("select  from public.books where id = @id", id);
            return book;
        }
        
    }

    public async Task<IEnumerable<Book>> GetByAuthor(string author)
    {
        using (IDbConnection db = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        {
            var books = await  db.QueryAsync<Book>("select  from public.books where author = @author", new{author});
            return books;
        }
    }

    public Task<IEnumerable<Book>> GetByPublisher(string publisher)
    {
        using (IDbConnection db = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        {
            var books =  db.QueryAsync<Book>("select  from public.books where publisher = @publisher" ,new{publisher});
            return books;
        }
    }

    public Task<IEnumerable<Book>> GetByName(string name)
    {
        using (IDbConnection db = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        {
            var books =  db.QueryAsync<Book>("select  from public.books where name = @name", new{name});
            return books;
        }
    }

    public async  Task<Book> Add(Book book)
    {
        using (IDbConnection db = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        {
            var result = await  db.ExecuteScalarAsync<Book>(@"insert public.books (name, author, publisher)
             values (@name, @author, @publisher) returning *",
                new{book.Name, book.Author, book.Publisher});
            return book;
        }   
    }

    public async Task<Book> Rent(int id)
    {
        using (IDbConnection db = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        {
            
       var book = await db.QueryFirstOrDefaultAsync<Book>("select * from public.books where id = @id", new{id});
       book?.ChangeAvailability(); 
       return book!;
        }
    }

    public async Task<Book> Delete(int id)
    {
        throw new NotImplementedException();
    }
}