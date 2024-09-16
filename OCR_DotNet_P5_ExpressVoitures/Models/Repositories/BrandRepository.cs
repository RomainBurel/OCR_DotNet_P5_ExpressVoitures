using OCR_DotNet_P5_ExpressVoitures.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace OCR_DotNet_P5_ExpressVoitures.Models.Repositories
{
	public class BrandRepository : GenericRepository<Brand>, IBrandRepository
	{
		public BrandRepository(DbContext context) : base(context)
		{
		}
	}
}
