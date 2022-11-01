using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.FileProviders;
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
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot")),
    RequestPath = new PathString("/wwwroot")
});
app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();
app.UseCors("CorsPolicy");
app.Run();