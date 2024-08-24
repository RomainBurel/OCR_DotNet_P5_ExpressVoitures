using OCR_DotNet_P5_ExpressVoitures.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace OCR_DotNet_P5_ExpressVoitures.Models.Repositories
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        public CarRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Car> GetAllAvailable()
        {
            return this._dbSet.Where(c => c.NoMoreAvailable == false).ToList();
        }
    }
}
