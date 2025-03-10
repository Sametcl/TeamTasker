using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TeamTasker.Models;
using TeamTasker.Models.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//DbContext
builder.Services.AddDbContext<TaskDbContext>(optionsAction =>
{
    optionsAction.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//Identity
builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.Password.RequireNonAlphanumeric=false; //alfabede olmayan karakter kullanam zorunlulugu 
    options.Password.RequireDigit=false; //rakam kullanama zorunlulugu 
    options.Password.RequireUppercase=false; //kucuk harf kullanama zorunlulugu 
    options.Password.RequireUppercase=false; //buyuk harf kullanama zorunlulugu 
    options.Password.RequiredLength=1; //sifre uzunlugu en az olma siniri 

    options.SignIn.RequireConfirmedEmail=false; // email dogrulama

    options.User.RequireUniqueEmail=true;// email benzersiz yapma username icin bu ozellik yok mutalka unique olmak zorunda 

})
    .AddEntityFrameworkStores<TaskDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    options.SlidingExpiration = true;
    
    options.LoginPath = "/Account/Login"; 
    options.AccessDeniedPath = "/Account/AccessDenied"; 
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
