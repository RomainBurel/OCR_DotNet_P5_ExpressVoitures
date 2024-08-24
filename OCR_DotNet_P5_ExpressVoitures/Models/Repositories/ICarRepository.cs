using OCR_DotNet_P5_ExpressVoitures.Models.Entities;

namespace OCR_DotNet_P5_ExpressVoitures.Models.Repositories
{
    public interface ICarRepository : IGenericRepository<Car>
    {
        public IEnumerable<Car> GetAllAvailable();
    }
}
