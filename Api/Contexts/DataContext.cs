using Api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Contexts;

public class DataContext : DbContext
{
	public DataContext(DbContextOptions<DataContext> options) : base(options)
	{
	}

	public DbSet<ProductEntity> Products { get; set; }
	public DbSet<CategoryEntity> Categories { get; set; }
	public DbSet<TagEntity> Tags { get; set; }
	public DbSet<ShowcaseEntity> Showcase { get; set; }

	// Låtsas att den här entityn går till en NoSql-Databas
	public DbSet<CustomerCommentEntity> CustomerComments { get; set; }
}
