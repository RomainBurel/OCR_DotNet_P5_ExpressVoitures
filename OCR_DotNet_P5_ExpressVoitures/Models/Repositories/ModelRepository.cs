using OCR_DotNet_P5_ExpressVoitures.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace OCR_DotNet_P5_ExpressVoitures.Models.Repositories
{
	public class ModelRepository : GenericRepository<Model>, IModelRepository
	{
		public ModelRepository(DbContext context) : base(context)
		{
		}

		public IEnumerable<Model> GetByRangeId(IEnumerable<int> ids)
		{
			return this.GetAll().Where(m => ids.ToList().Contains(m.IdModel));
		}
	}
}
