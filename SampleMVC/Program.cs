
using RoamLab.BLL;
using RoamLab.BLL.Interface;

var builder = WebApplication.CreateBuilder(args);
//menambahkan modul mvc
builder.Services.AddControllersWithViews();

//register session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

//register DI
//builder.Services.AddScoped<ICategoryBLL, CategoryBLL>();
//builder.Services.AddScoped<IArticleBLL, ArticleBLL>();
builder.Services.AddScoped<IUserBLL, UserBLL>();
builder.Services.AddScoped<ILocationBLL, LocationBLL>();
builder.Services.AddScoped<IPlaceBLL, PlaceBLL>();
builder.Services.AddScoped<ICategoryBLL, CategoryBLL>();
builder.Services.AddScoped<IVacationPlanBLL, VacationPlanBLL>();
//builder.Services.AddScoped<IRoleBLL, RoleBLL>();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Users}/{action=Login}");

app.Run();