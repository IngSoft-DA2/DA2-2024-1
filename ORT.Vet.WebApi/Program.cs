using ORT.Vet.Domain;
using ORT.Vet.ServicesFactory;
using ORT.Vet.WebApi.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// Agrego esta linea
// Aca registro el exception filter también (APLICA GLOBALMENTE)
builder.Services.AddControllers(
    options => options.Filters.Add(typeof(ExceptionFilter))
    );

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ServicesFactory.RegisterServices(builder.Services);
ServicesFactory.RegisterDataAccess(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Agrego esta linea
app.MapControllers();
//

app.Run();
