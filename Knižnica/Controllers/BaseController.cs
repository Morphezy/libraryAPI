using System.Data;
using Application;
using Dapper;
using Domain.Dto;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace Knižnica.Controllers;

[ApiController]
[Route("[controller]")]
public class BaseController(IConfiguration configuration,
    IBookRepository repo) : ControllerBase
{

    private readonly IBookRepository _repo = repo;
    private readonly IConfiguration _configuration = configuration;

    [HttpGet(Name = "Get")]
    public async Task<IActionResult> GetAsync()
    {
        return Ok(await _repo.GetAll());
    }

    [HttpPost("Add")]
    public async Task<IActionResult> AddBook(AddBookDto book)
    {
        var bookmodel = BookMapProfile.AddBookDtoToBookModel(book);
        var bookAdded = await _repo.Add(bookmodel);
        return Ok(bookAdded);
    }




}