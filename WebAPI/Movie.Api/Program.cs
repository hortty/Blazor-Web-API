using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Movie.Application.Services;
using Movie.Domain.Interfaces;
using Movie.Infrastructure.Context;
using Movie.Infrastructure.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Movie.Application.Validators;
using FluentValidation;
using System.ComponentModel.DataAnnotations;
using Movie.Domain.Models;
using Movie.Domain.Dtos.CustomerDto;
using Movie.Domain.Dtos.ShoppingCartMovieDto;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var config = new MapperConfiguration(cfg => {
    
    cfg.AddMaps("Movie.Domain");
});

var mapper = config.CreateMapper();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddSingleton(mapper);

// Services
builder.Services.AddScoped<IFilmService, FilmService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ISaleService, SaleService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IShoppingCartService, ShoppingCartService>();
builder.Services.AddScoped<IShoppingCartMovieService, ShoppingCartMovieService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<ICommentsService, CommentService>();
builder.Services.AddScoped<IUpvoteService, UpvoteService>();

// Repositories
builder.Services.AddScoped<IFilmRepository, FilmRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ISaleRepository, SaleRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
builder.Services.AddScoped<IShoppingCartMovieRepository, ShoppingCartMovieRepository>();
builder.Services.AddScoped<ICommentsRepository, CommentsRepository>();
builder.Services.AddScoped<IUpvoteRepository, UpvoteRepository>();

// Validators
builder.Services.AddTransient<IValidator<CreateShoppingCartMovieDto>, CreateShoppingCartMovieDtoValidator>();
builder.Services.AddTransient<IValidator<UpdateShoppingCartMovieDto>, UpdateShoppingCartMovieDtoValidator>();
builder.Services.AddTransient<IValidator<DeleteShoppingCartMovieDto>, DeleteShoppingCartMovieDtoValidator>();
builder.Services.AddTransient<IValidator<CreateCustomerDto>, CreateCustomerDtoValidator>();

builder.Services.Configure<MongoSettings>(builder.Configuration.GetSection(nameof(MongoSettings)));
builder.Services.AddSingleton<IMongoSettings>(sp => 
    sp.GetRequiredService<IOptions<MongoSettings>>().Value);
builder.Services.AddSingleton<IMongoClient>(s =>
    new MongoClient(builder.Configuration.GetValue<string>("MongoSettings:ConnectionString")));

//JWT
var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("AppSettings")["SecurityKey"]!);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
