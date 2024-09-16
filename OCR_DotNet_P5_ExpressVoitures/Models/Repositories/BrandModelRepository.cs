using OCR_DotNet_P5_ExpressVoitures.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace OCR_DotNet_P5_ExpressVoitures.Models.Repositories
{
	public class BrandModelRepository : GenericRepository<BrandModel>, IBrandModelRepository
	{
		public BrandModelRepository(DbContext context) : base(context)
		{
		}

		public IEnumerable<BrandModel> GetBrandModels(int idBrand)
		{
			return this._dbSet.Where(b => b.IdBrand == idBrand).ToList();
		}
	}
}
