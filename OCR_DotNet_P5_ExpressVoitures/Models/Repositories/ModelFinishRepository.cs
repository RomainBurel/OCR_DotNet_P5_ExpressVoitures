using OCR_DotNet_P5_ExpressVoitures.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace OCR_DotNet_P5_ExpressVoitures.Models.Repositories
{
	public class ModelFinishRepository : GenericRepository<ModelFinish>, IModelFinishRepository
	{
		public ModelFinishRepository(DbContext context) : base(context)
		{
		}

		public IEnumerable<ModelFinish> GetModelFinishes(int idModel)
		{
			return this._dbSet.Where(m => m.IdModel == idModel).ToList();
		}
	}
}
