using OCR_DotNet_P5_ExpressVoitures.Models.Entities;
using OCR_DotNet_P5_ExpressVoitures.Models.Repositories;
using OCR_DotNet_P5_ExpressVoitures.Models.ViewModels;

namespace OCR_DotNet_P5_ExpressVoitures.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        
        public CarService(ICarRepository carRepository, IWebHostEnvironment webHostEnvironment)
        {
            this._carRepository = carRepository;
            this._webHostEnvironment = webHostEnvironment;
        }

        public Car GetById(int id)
        {
            return this._carRepository.GetById(id);
        }

        public CarModel GetCarModelbyId(int id)
        {
            return this.GetCarModelFromCar(this._carRepository.GetById(id));
        }

        public CarMainInfosModel GetCarMainInfosModelbyId(int id)
        {
            return this.GetCarMainInfosModelFromCar(this._carRepository.GetById(id));
        }

        public IEnumerable<CarMainInfosModel> GetAll(bool onlyAvailableCars)
        {
            var carModels = onlyAvailableCars ? this._carRepository.GetAllAvailable() : this._carRepository.GetAll();
            return carModels.Select(c => this.GetCarMainInfosModelFromCar(c)).ToList();
        }

        public void Add(CarModel carModel, IFormFile? image)
        {
            carModel.ImagePath = this.UploadFile(image);
            this._carRepository.Add(this.GetCarFromCarModel(carModel));
            this._carRepository.SaveChanges();
        }

        public void Update(CarModel carModel, IFormFile? image)
        {
            if (image != null)
            {
                this.DeleteFile(carModel);
                carModel.ImagePath = this.UploadFile(image);
            }
            this._carRepository.Update(this.GetCarFromCarModel(carModel));
            this._carRepository.SaveChanges();
        }

        public void Delete(CarModel carModel)
        {
            var car = this.GetCarFromCarModel(carModel);
            this.DeleteFile(carModel);
            this._carRepository.Remove(car);
            this._carRepository.SaveChanges();
        }

        private CarMainInfosModel GetCarMainInfosModelFromCar(Car car)
        {
            return new CarMainInfosModel
            {
                IdCar = car.IdCar,
                Year = car.Year,
                Brand = car.Brand,
                Model = car.Model,
                Finish = car.Finish,
                SellingPrice = car.GetSellingPrice(),
                Description = car.Description,
                ImagePath = car.ImagePath == null ? @"img\\default.jpg" : car.ImagePath
            };
        }

        private CarModel GetCarModelFromCar(Car car)
        {
            return new CarModel
            {
                IdCar = car.IdCar,
                VIN = car.VIN,
                Year = car.Year,
                Brand = car.Brand,
                Model = car.Model,
                Finish = car.Finish,
                DateOfBuy = car.DateOfBuy,
                Price = car.Price,
                RepairDescription = car.RepairDescription,
                DateOfRepair = car.DateOfRepair,
                RepairCost = car.RepairCost,
                NoMoreAvailable = car.NoMoreAvailable,
                DateOfAvailabilityForSale = car.DateOfAvailabilityForSale,
                SellingPrice = car.GetSellingPrice(),
                Description = car.Description,
                ImagePath = car.ImagePath == null ? @"img\\default.jpg" : car.ImagePath,
                DateOfSale = car.DateOfSale
            };
        }

        private Car GetCarFromCarModel(CarModel carModel)
        {
            return new Car
            {
                IdCar = carModel.IdCar,
                VIN = carModel.VIN,
                Year = carModel.Year,
                Brand = carModel.Brand,
                Model = carModel.Model,
                Finish = carModel.Finish,
                DateOfBuy = carModel.DateOfBuy,
                Price = carModel.Price,
                RepairDescription = carModel.RepairDescription,
                DateOfRepair = carModel.DateOfRepair,
                RepairCost = carModel.RepairCost,
                NoMoreAvailable = carModel.NoMoreAvailable,
                DateOfAvailabilityForSale = carModel.DateOfAvailabilityForSale,
                Description = carModel.Description,
                ImagePath = carModel.ImagePath,
                DateOfSale = carModel.DateOfSale
            };
        }

        private string? UploadFile(IFormFile? image)
        {
            string? uniqueFileName = null;
            if (image != null)
            {
                string uploadsFolder = Path.Combine(this._webHostEnvironment.WebRootPath, @"img\cars");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }
                uniqueFileName = @"img\cars\" + uniqueFileName;
            }
            return uniqueFileName;
        }

        private void DeleteFile(CarModel carModel)
        {
            if (carModel.ImagePath != null)
            {
                if (!string.IsNullOrEmpty(carModel.ImagePath))
                {
                    var oldImagePath = Path.Combine(this._webHostEnvironment.WebRootPath, carModel.ImagePath.TrimStart('\\'));

                    if (File.Exists(oldImagePath))
                    {
                        File.Delete(oldImagePath);
                    }
                }
            }
        }
    }
}
