using OCR_DotNet_P5_ExpressVoitures.Models.Entities;
using OCR_DotNet_P5_ExpressVoitures.Models.ViewModels;

namespace OCR_DotNet_P5_ExpressVoitures.Services
{
    public interface ICarService
    {
        public Car GetById(int id);

        public CarModel GetCarModelbyId(int id);

        public CarMainInfosModel GetCarMainInfosModelbyId(int id);

        public IEnumerable<CarMainInfosModel> GetAll(bool onlyAvailableCars);

        public void Add(CarModel carModel, IFormFile? image);

        public void Update(CarModel carModel, IFormFile? image);

        public void Delete(CarModel carModel);

        public IEnumerable<Brand> GetAllBrands();

        public IEnumerable<Model> GetBrandModels(int idBrand);

        public IEnumerable<Finish> GetModelFinishes(int idModel);

        public string GetBrandName(int idBrand);

        public string GetModelName(int idModel);

        public string GetFinishName(int idFinish);
    }
}
