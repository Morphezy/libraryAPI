using System.Data;
using Dapper;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace Knižnica.Controllers;

[ApiController]
[Route("[controller]")]
public class BaseController(IConfiguration configuration) : ControllerBase
{
    private readonly IConfiguration _configuration = configuration;

    [HttpPost("Init")]
    public async Task<IActionResult> InitAsync()
    {
        var sql = @"create schema if not exists public;

create table if not exists public.books
(
    id serial primary key,
    name varchar(255) not null,
    author varchar(255) not null,
    publisher varchar(255) not null,
    is_available boolean not null default true,
    added_at timestamp not null default now()
);";
        await using var db = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")!);
        await db.OpenAsync();
        await db.ExecuteAsync(sql);
        return Ok("done");
    }
    [HttpGet(Name = "Get")]
    public async Task<IActionResult> GetAsync(){ 
        List<Book> books = new List<Book>();
        using (IDbConnection db = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")!))
        {
            books = db.Query<Book>("Select * from public.books").ToList();
        }
        return Ok(books);
    }
    
    
    
    
}