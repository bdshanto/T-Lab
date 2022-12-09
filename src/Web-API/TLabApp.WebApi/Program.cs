using Microsoft.AspNetCore.Http.Features;
using TLabApp.Application.DependencyServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDependencyResolver();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<FormOptions>(o =>
{
    o.ValueLengthLimit = int.MaxValue;
    o.MultipartBodyLengthLimit = int.MaxValue;
    o.MemoryBufferThreshold = int.MaxValue;
});
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
var outputDir = Path.Combine(Environment.CurrentDirectory, "wwwroot", "Files");
if (!Directory.Exists(outputDir)) Directory.CreateDirectory(outputDir);
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();
app.UseCors("CorsPolicy");
app.Run();