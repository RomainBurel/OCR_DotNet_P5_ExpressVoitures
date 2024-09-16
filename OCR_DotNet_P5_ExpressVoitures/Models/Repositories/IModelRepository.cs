using OCR_DotNet_P5_ExpressVoitures.Models.Entities;

namespace OCR_DotNet_P5_ExpressVoitures.Models.Repositories
{
	public interface IModelRepository : IGenericRepository<Model>
	{
		public IEnumerable<Model> GetByRangeId(IEnumerable<int> ids);
	}
}