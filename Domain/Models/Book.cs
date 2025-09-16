
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

[Table("books")]
public class Book
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Author { get; private set; }
    public string Publisher { get; private set; }
    public DateTime AddedAt { get; private set; } = DateTime.UtcNow;
    public bool IsAvailable { get; private set; } = true;

    private Book() { }

    public Book(string name, string author, string publisher)
    {
        Name = name;
        Author = author;
        Publisher = publisher;
    }

    public void ReturnBook()
    {
        IsAvailable = true;
        AddedAt = DateTime.UtcNow;
    }

    public void RentBook()
    {
        IsAvailable = false;
    }

    public bool CheckIsAvailable()
    {
        return IsAvailable;
    }

    public string GetAuthor()
    {
        return Author;
    }
    public string GetPublisher()
    {
        return Publisher;
    }
    public string GetName()
    {
        return Name;
    }
    public string ChangePublisher(string newPublisher)
    {
        Publisher = newPublisher;
        return Publisher;
    }
    public string ChangeAuthor(string newAuthor)
    {
        Author = newAuthor;
        return Author;
    }
}

    
    