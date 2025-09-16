
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
    public bool IsAvailable { get; private set; }

    private Book() { }

    public Book(string name, string author, string publisher, bool isAvailable)
    {
        Name = name;
        Author = author;
        Publisher = publisher;
        IsAvailable = isAvailable;
    }

    public bool ChangeAvailability()
    {
        IsAvailable = !IsAvailable;
        if(IsAvailable)
            AddedAt = DateTime.UtcNow;
        return (IsAvailable);
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

    
    