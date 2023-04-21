using Api.Contexts;
using Api.Models.Entities;
using Api.Repositories.BaseModels;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Api.Repositories;

public class ProductRepository : Repository<ProductEntity>
{
	private readonly DataContext _dataContext;
	public ProductRepository(DataContext dataContext) : base(dataContext)
	{
		_dataContext = dataContext;
	}

	public override async Task<IEnumerable<ProductEntity>> GetAllAsync()
	{
		return await _dataContext.Products.Include("Category").Include("Tag").ToListAsync();
	}

	public override async Task<IEnumerable<ProductEntity>> GetListAsync(Expression<Func<ProductEntity, bool>> predicate)
	{
		return await _dataContext.Products.Include("Category").Include("Tag").Where(predicate).ToListAsync();
	}

	public override async Task<ProductEntity> GetAsync(Expression<Func<ProductEntity, bool>> predicate)
	{
		var result = await _dataContext.Products.Include("Category").Include("Tag").FirstOrDefaultAsync(predicate);

		if (result != null)
			return result;

		return null!;
	}
}
