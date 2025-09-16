using System.Data;
using Application;
using AutoMapper;
using Dapper;
using Domain.Dto;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace Knižnica.Controllers;

[ApiController]
[Route("[controller]")]
public class BaseController(IConfiguration configuration,
    IBookRepository repo,
    IMapper mapper) : ControllerBase
{
    private readonly IMapper _mapper = mapper;
    private readonly IBookRepository _repo = repo;
    private readonly IConfiguration _configuration = configuration;

    [HttpPost("Init")]

    [HttpGet(Name = "Get")]
    public async Task<IActionResult> GetAsync()
    {
        return Ok(await _repo.GetAll());
    }

    public async Task<IActionResult> AddBook(AddBookDto book)
    {
        var bookmodel = _mapper.Map<Book>(book);
        var bookAdded = await _repo.Add(bookmodel);
        return Ok(bookAdded);
    }




}