using Api.Models.DTO;
using Api.Models.Entities;
using Api.Repositories;

namespace Api.Services;

public class ProductService
{
	private readonly ProductRepository _productRepo;
	private readonly CategoryRepository _categoryRepo;
	private readonly TagRepository _tagRepo;

	public ProductService(ProductRepository productRepo, CategoryRepository categoryRepo, TagRepository tagRepo)
	{
		_productRepo = productRepo;
		_categoryRepo = categoryRepo;
		_tagRepo = tagRepo;
	}

	public async Task<IEnumerable<ProductDTO>> GetAllAsync()
	{
		var products = await _productRepo.GetAllAsync();

		var dto = new List<ProductDTO>();

		foreach (var entity in products)
		{
			ProductDTO product = entity;
			dto.Add(product);
		}

		return dto;
	}

	public async Task<IEnumerable<ProductDTO>> GetByTagAsync(string tag)
	{
		var products = await _productRepo.GetListAsync(x => x.Tag.Name == tag);
		products = products.OrderByDescending(x => x.CreatedDate).Take(8);

		var dto = new List<ProductDTO>();

		foreach (var entity in products)
		{
			ProductDTO product = entity;
			dto.Add(product);
		}

		return dto;
	}

	public async Task<ProductDTO> GetByIdAsync(int id)
	{
		var product = await _productRepo.GetAsync(x => x.Id == id);

		ProductDTO dto = product;

		return dto;
	}

	public async Task<bool> CreateAsync(CreateProductDTO dto)
	{
		ProductEntity entity = dto;

		entity.Category = await _categoryRepo.GetAsync(x => x.Name == dto.Category);
		entity.Tag = await _tagRepo.GetAsync(x => x.Name == dto.Tag);
		entity.CreatedDate = DateTime.Now;

		try
		{
			await _productRepo.AddAsync(entity);
			return true;
		}
		catch
		{
			return false;
		}

	}

	public async Task<bool> DeleteAsync(int id)
	{
		var entity = await _productRepo.GetAsync(x => x.Id == id);

		try
		{
			await _productRepo.DeleteAsync(entity!);
			return true;
		}
		catch
		{
			return false;
		}
	}
}
