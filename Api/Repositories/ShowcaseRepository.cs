using Api.Contexts;
using Api.Models.DTO;
using Api.Models.Entities;
using Api.Repositories.BaseModels;

namespace Api.Repositories;

public class ShowcaseRepository : Repository<ShowcaseEntity>
{
	public ShowcaseRepository(DataContext dataContext) : base(dataContext)
	{
	}

	public async Task<ShowcaseModelDTO> GetLatestAsync()
	{
		var showcases = await GetAllAsync();
		return showcases.OrderByDescending(x => x.Date).FirstOrDefault()!;
	}
	
}
