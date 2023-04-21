using Api.Contexts;
using Api.Models.Entities;
using Api.Repositories.BaseModels;

namespace Api.Repositories
{
    public class CustomerCommentRepository : Repository<CustomerCommentEntity>
	{
		public CustomerCommentRepository(DataContext dataContext) : base(dataContext)
		{
		}
	}
}
