using ORT.Vet.ServicesFactory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// Agrego esta linea
builder.Services.AddControllers();
//

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var servicesFactory = new ServicesFactory();
servicesFactory.RegisterServices(builder.Services);

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
