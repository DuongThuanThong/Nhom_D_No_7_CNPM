using Respositories1;
using Respositories1.Interfaces;
using Respositories1.Models;
using Services1;
using Services1.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//DI
builder.Services.AddDbContext<KoiCareSystemAhContext>();

//DI Repository
builder.Services.AddScoped<IKoiRespository, KoiRespository>();
builder.Services.AddScoped<IGrowthKoiRepository, GrowthKoiRepository>();

//DI Services
builder.Services.AddScoped<IKoiService,KoiService>();
builder.Services.AddScoped<IGrowthKoiService, GrowthKoiService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
