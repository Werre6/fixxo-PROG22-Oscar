using Mvc.Helpers;
using Mvc.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<CustomerCommentService>();
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<JwtValidation>();
builder.Services.AddScoped<AdminServices>();
builder.Services.AddScoped<ShowcaseService>();

#region Authentication

#endregion




var app = builder.Build();

app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
