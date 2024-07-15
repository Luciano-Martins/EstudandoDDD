using Academia.Domain.Entities.Account;
using Academia.Infra.Data.Contexto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

string str = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContexto>(option =>
{
    option.UseSqlServer(str);
});

builder.Services.AddIdentity<Users, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;//requer confirmação do e-mail
    options.Lockout.MaxFailedAccessAttempts = 3;// quantidade de tentativas de acesso
    options.Lockout.AllowedForNewUsers = true;// para permitir restringir acessos a determinadas areas
    options.Password.RequireDigit = false;//aqui define caracteres especiais , false não vai exigir
    options.Password.RequireUppercase = false;//aqui define se exige letras maiusculas
    options.Password.RequireNonAlphanumeric = false;//aqui requer  alphanumericos
    options.Password.RequiredLength =  6;//define a quantidade de caracteres da senha.


}).AddEntityFrameworkStores<DataContexto>()//passamod nosso DataContexto
  .AddDefaultTokenProviders();// e a utilização de token

builder.Services.Configure<DataProtectionTokenProviderOptions>(options =>
{
    options.TokenLifespan = TimeSpan.FromHours(3);// o token vai expirar em 3 horas
});


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
