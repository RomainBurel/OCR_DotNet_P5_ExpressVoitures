using OCR_DotNet_P5_ExpressVoitures.Models.Entities;

namespace OCR_DotNet_P5_ExpressVoitures.Models.Repositories
{
	public interface IModelFinishRepository : IGenericRepository<ModelFinish>
	{
		public IEnumerable<ModelFinish> GetModelFinishes(int idModel);
	}
}
