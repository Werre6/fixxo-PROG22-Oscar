using Api.Contexts;
using Api.Helpers;
using Api.Repositories;
using Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DataDB")));
builder.Services.AddDbContext<IdentityContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("IdentityDB")));
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<CustomerCommentRepository>();
builder.Services.AddScoped<JwtToken>();
builder.Services.AddScoped<UserProfileRepository>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<TagRepository>();
builder.Services.AddScoped<CategoryRepository>();
builder.Services.AddScoped<ShowcaseRepository>();


#region Identity

builder.Services.AddIdentity<IdentityUser, IdentityRole>(x =>
{
	x.User.RequireUniqueEmail = true;
	x.SignIn.RequireConfirmedAccount = false;
	x.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<IdentityContext>();

#endregion


#region Authentication

builder.Services.AddAuthentication(x =>
{
	x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
	x.Events = new JwtBearerEvents
	{
		OnTokenValidated = context =>
		{
			if (string.IsNullOrEmpty(context?.Principal?.FindFirst("id")?.Value) || string.IsNullOrEmpty(context?.Principal?.Identity?.Name))
				context?.Fail("Unauthorized");

			return Task.CompletedTask;
		}
	};

	x.RequireHttpsMetadata = true;
	x.SaveToken = true;
	x.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuerSigningKey = true,
		IssuerSigningKey = new SymmetricSecurityKey(
				Encoding.UTF8.GetBytes(builder.Configuration.GetSection("TokenValidation").GetValue<string>("SecretKey")!)),
		ValidateLifetime = true,
		ValidateIssuer = true,
		ValidIssuer = builder.Configuration.GetSection("TokenValidation").GetValue<string>("ValidIssuer"),
		ValidateAudience = true,
		ValidAudience = builder.Configuration.GetSection("TokenValidation").GetValue<string>("ValidAudience"),
		ClockSkew = TimeSpan.FromSeconds(0),
	};
});

builder.Services.AddAuthorization(options =>
{
	options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
	options.AddPolicy("ProductManagerOnly", policy => policy.RequireRole("ProductManager"));
});

#endregion



var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
