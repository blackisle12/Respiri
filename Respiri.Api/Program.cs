using Respiri.Repository;
using Respiri.Repository.Interface;
using Respiri.Service;
using Respiri.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Respiri.Repository.AppContext>();

builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

await SeedDatabase();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

async Task SeedDatabase()
{
    using var scope = app.Services.CreateScope();
    try
    {
        var scopedContext = scope.ServiceProvider.GetRequiredService<Respiri.Repository.AppContext>();
        await scopedContext.Database.EnsureCreatedAsync();
    }
    catch
    {
        throw;
    }
}
