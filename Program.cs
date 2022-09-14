using BookStoreAPI.Data;
using BookStoreAPI.Models;
using BookStoreAPI.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BookStoreContext>(    // Added Db context fro database reference
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("BookStoreDb")));
builder.Services.AddIdentity<UserModel, IdentityRole>()
    .AddEntityFrameworkStores<BookStoreContext>()
    .AddDefaultTokenProviders(); // Added identity and role for authentication and authorization.

// Database services registration
builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddAutoMapper(typeof(Program));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(option =>
{
    option.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
