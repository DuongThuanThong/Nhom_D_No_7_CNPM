using Respositories1;
using Respositories1.Interfaces;
using Respositories1.Entities;
using Services1;
using Services1.Interfaces;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;






var builder = WebApplication.CreateBuilder(args);
    
// Add services to the container.
builder.Services.AddRazorPages();

// Thêm cấu hình này
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 10000000; // 10MB
});


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


app.UseDeveloperExceptionPage();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
