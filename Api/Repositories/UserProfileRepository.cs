using Api.Contexts;
using Api.Models.Entities;
using Api.Repositories.BaseModels;

namespace Api.Repositories
{
    public class UserProfileRepository : IdentityRepository<UserProfileEntity>
	{
		public UserProfileRepository(IdentityContext context) : base(context)
		{
		}
	}
}
