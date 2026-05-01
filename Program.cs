using Microsoft.EntityFrameworkCore;
using ToDoApi.Data;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Adiciona suporte a Controllers
builder.Services.AddControllers();

// 🔹 Banco SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=tasks.db"));

// 🔹 Swagger (para testar API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 🔹 Swagger no ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseDefaultFiles();
app.UseStaticFiles();
// 🔹 ESSENCIAL — ativa Controllers
app.MapControllers();
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (!db.Users.Any(u => u.Email == "caio@gmail.com"))
    {
        db.Users.Add(new ToDoApi.Models.User
        {
            Email = "caio@gmail.com",
            Password = "123123",
            IsAdmin = true
        });

        db.SaveChanges();
    }
}
app.Run();