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

// Add service Session
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
//DI
builder.Services.AddDbContext<KoiCareSystemAhContext>();

//DI Repository
builder.Services.AddScoped<IKoiRespository, KoiRespository>();
builder.Services.AddScoped<IGrowthKoiRepository, GrowthKoiRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();

//DI Services
builder.Services.AddScoped<IKoiService,KoiService>();
builder.Services.AddScoped<IGrowthKoiService, GrowthKoiService>();
builder.Services.AddScoped<IUserService, UserService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseDeveloperExceptionPage();

app.UseSession();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
