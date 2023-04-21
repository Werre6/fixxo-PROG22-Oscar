using Api.Contexts;
using Api.Models.Entities;
using Api.Repositories.BaseModels;

namespace Api.Repositories
{
    public class TagRepository : Repository<TagEntity>
	{
		public TagRepository(DataContext dataContext) : base(dataContext)
		{
		}
	}
}
