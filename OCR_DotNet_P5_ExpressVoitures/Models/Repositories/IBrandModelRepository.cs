using OCR_DotNet_P5_ExpressVoitures.Models.Entities;

namespace OCR_DotNet_P5_ExpressVoitures.Models.Repositories
{
	public interface IBrandModelRepository : IGenericRepository<BrandModel>
	{
		public IEnumerable<BrandModel> GetBrandModels(int idBrand);
	}
}
