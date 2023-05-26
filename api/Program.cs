using api.Data;
using api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();

await DbHelpers.MigrateDatabase(app.Services);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(
    options => options.AllowAnyHeader()
    .AllowAnyMethod()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials()
    .WithOrigins("http://localhost:3000")
);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
