using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QLThuVienMVC.Models;
using QLThuVienMVC.Models.UserModel;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<LibDataContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultString"));

});
builder.Services.AddScoped<InterfaceSach, SachRepository>();
builder.Services.AddScoped<InterfaceThongTin, ThongTinRepository>();
builder.Services.AddSession();
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
    options =>
    {
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequiredUniqueChars = 1;
        options.Password.RequiredLength = 8;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
        options.User.RequireUniqueEmail = false;
        options.SignIn.RequireConfirmedAccount = false;
        options.SignIn.RequireConfirmedPhoneNumber = false;
        options.SignIn.RequireConfirmedEmail = false;
    }
    )
    .AddEntityFrameworkStores<LibDataContext>()
    .AddDefaultTokenProviders();
builder.Services.AddRazorPages();
var app = builder.Build();

app.UseSession();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.MapDefaultControllerRoute();
app.MapRazorPages();



app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await IdentityDataInitializer.SeedRoles(services);
}
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<LibDataContext>();
    SeedData.SeedDatabase(context);
}


app.Run();
