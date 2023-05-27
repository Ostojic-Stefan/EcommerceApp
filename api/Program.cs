using api.Data;
using api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(Directory.GetCurrentDirectory());

builder.Services.AddApplicationServices(builder.Configuration);

//builder.WebHost.ConfigureAppConfiguration((hostingContext, config) =>
//{
//    var env = hostingContext.HostingEnvironment;
//    config.SetBasePath(env.ContentRootPath);
//});

builder.WebHost.UseWebRoot("wwwroot");

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

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
