using Microsoft.EntityFrameworkCore;
using Server.DataContxt;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ContextApp>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("constring")));

builder.Services.AddCors(options => options.AddPolicy(name: "TemplateOrigins",
    policy =>
    {
        policy.WithOrigins("http://localhost:4100").AllowAnyMethod().AllowAnyHeader();
    }));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("TemplateOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
