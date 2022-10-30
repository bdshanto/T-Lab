using Microsoft.Extensions.FileProviders;
using TLabApp.Application.DependencyServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDependencyResolver();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(opt => opt.AddPolicy("CorsPolicy", c => c
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()
));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDefaultFiles();
app.UseStaticFiles();
var path = Path.Combine(Environment.CurrentDirectory, "wwwroot", "Files").Replace(@"\", @"/");

app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Environment.CurrentDirectory, "wwwroot", "Files")),
    //RequestPath = new PathString(path)
});
app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();
app.UseCors("CorsPolicy");
app.Run();