using OCR_DotNet_P5_ExpressVoitures.Models.Entities;

namespace OCR_DotNet_P5_ExpressVoitures.Models.Repositories
{
	public interface IFinishRepository : IGenericRepository<Finish>
	{
		public IEnumerable<Finish> GetByRangeId(IEnumerable<int> ids);
	}
}