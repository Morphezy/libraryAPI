using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Npgsql;

namespace Application;

public class DatabaseInitializer(IConfiguration configuration) : BackgroundService
{
    
    private readonly IConfiguration _configuration = configuration;
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
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
        await using var db = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")!);
        await db.OpenAsync();
        await db.ExecuteAsync(sql);

    }
}