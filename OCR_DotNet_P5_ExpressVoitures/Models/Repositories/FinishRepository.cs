using OCR_DotNet_P5_ExpressVoitures.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace OCR_DotNet_P5_ExpressVoitures.Models.Repositories
{
	public class FinishRepository : GenericRepository<Finish>, IFinishRepository
	{
		public FinishRepository(DbContext context) : base(context)
		{
		}

		public IEnumerable<Finish> GetByRangeId(IEnumerable<int> ids)
		{
			return this.GetAll().Where(f => ids.ToList().Contains(f.IdFinish));
		}
	}
}
