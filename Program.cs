using LawyerApi.Data;
using LawyerApi.Endpoints;
using LawyerApi.Models;
using LawyerApi.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// area de servicios
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll", builder => {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddOutputCache();
builder.Services.AddScoped<ISpecialtyRepository, SpecialtyRepository>();

builder.Services.AddAutoMapper(typeof(Program));

//Fin area de servicioss

var app = builder.Build();

app.UseOutputCache();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

// Endpoint para obtener todos los productos
var lawyerEndpoints = app.MapGroup("/lawyer");
lawyerEndpoints.MapGet("/", GetAllLayer).CacheOutput(c => c.Expire(TimeSpan.FromHours(1)).Tag("lawyers-getAll"));
lawyerEndpoints.MapPost("/", CreateLawyer);

app.MapGroup("/specialty").MapSpecialty();

app.Run();

static async Task<Ok<List<Lawyer>>> GetAllLayer (AppDbContext db) 
{ 
    var layers = await db.Lawyers.ToListAsync();
    return TypedResults.Ok(layers);
}

static async Task<Created<Lawyer>> CreateLawyer (AppDbContext db, Lawyer lawyer, IOutputCacheStore outputCacheStore) 
{
    db.Lawyers.Add(lawyer);
    await db.SaveChangesAsync();
    await outputCacheStore.EvictByTagAsync("lawyers-getAll", default);
    return TypedResults.Created($"/lawyer/{lawyer.LawyerId}", lawyer);
}



