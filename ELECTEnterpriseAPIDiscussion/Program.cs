using ELECTEnterpriseAPIDiscussion.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<InMemoryDataStore>();
//Depending on the requirement of client (other wants to see the swagger UI and some other wants to see the openapi.json file), we can configure the swagger UI and openapi.json file in the below way.


var app = builder.Build();

// Configure the HTTP request pipeline.
using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.GetRequiredService<InMemoryDataStore>().Seed();
}
    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
        app.UseSwaggerUI();
        app.UseSwagger();
    }

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
