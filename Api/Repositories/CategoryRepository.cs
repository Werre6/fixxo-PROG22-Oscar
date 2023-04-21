using Api.Contexts;
using Api.Models.Entities;
using Api.Repositories.BaseModels;

namespace Api.Repositories
{
    public class CategoryRepository : Repository<CategoryEntity>
	{
		public CategoryRepository(DataContext dataContext) : base(dataContext)
		{
		}
	}
}
