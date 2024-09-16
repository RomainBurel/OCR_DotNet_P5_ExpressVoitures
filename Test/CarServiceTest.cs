using Microsoft.AspNetCore.Hosting;
using Moq;
using OCR_DotNet_P5_ExpressVoitures.Models.Entities;
using OCR_DotNet_P5_ExpressVoitures.Models.Repositories;
using OCR_DotNet_P5_ExpressVoitures.Services;

namespace Test
{
	public class CarServiceTest
	{
		private List<Car> GetAllCars()
		{
			return new List<Car>()
			{
				new Car
				{
					IdCar = 1,
					VIN = "123AB56",
                    IdBrand = 1,
                    IdModel = 12,
                    IdFinish = 7,
                    Year = 2018,
					DateOfBuy = new DateTime(2024, 1, 1),
					Price = 8000d,
					DateOfRepair = new DateTime(2024, 2, 1),
					RepairCost = 1500d,
					RepairDescription = "Révision + carrosserie",
					DateOfAvailabilityForSale = new DateTime(2024, 2, 2),
					Description = "Une jolie voiture",
					NoMoreAvailable = false
				},
				new Car
				{
					IdCar = 2,
					VIN = "234BC67",
                    IdBrand = 1,
                    IdModel = 12,
                    IdFinish = 7,
                    Year = 2020,
					DateOfBuy = new DateTime(2024, 3, 1),
					Price = 7000d,
					DateOfRepair = new DateTime(2024, 4, 1),
					RepairCost = 100d,
					RepairDescription = "Révision",
					DateOfAvailabilityForSale = new DateTime(2024, 5, 2),
					Description = "Une belle voiture",
					NoMoreAvailable = false
				},
				new Car
				{
					IdCar = 3,
					VIN = "234BC67",
					IdBrand = 1,
					IdModel = 12,
					IdFinish = 7,
                    Year = 2020,
					DateOfBuy = new DateTime(2024, 3, 1),
					Price = 7000d,
					DateOfRepair = new DateTime(2024, 4, 1),
					RepairCost = 100d,
					RepairDescription = "Révision",
					DateOfAvailabilityForSale = new DateTime(2024, 5, 2),
					Description = "Une belle voiture",
					NoMoreAvailable = true
				}
			};
		}

		private Car GetCar(int idCar)
		{
			return this.GetAllCars().FirstOrDefault(c => c.IdCar == idCar);
		}

		[Fact]
		public void CalculatedSellingPriceIsCorrect()
		{
            // Arrange
            var mockBrandRepository = new Mock<IBrandRepository>();
            var mockModelRepository = new Mock<IModelRepository>();
            var mockFinishRepository = new Mock<IFinishRepository>();
            var mockBrandModelRepository = new Mock<IBrandModelRepository>();
            var mockModelFinishRepository = new Mock<IModelFinishRepository>();
            var mockCarRepository = new Mock<ICarRepository>();
			var mockWebHostEnvironment = new Mock<IWebHostEnvironment>();
			mockCarRepository.Setup(r => r.GetById(It.IsAny<int>())).Returns(this.GetCar(1));
            var carService = new CarService(mockCarRepository.Object, mockBrandRepository.Object, mockModelRepository.Object, mockFinishRepository.Object,
                mockBrandModelRepository.Object, mockModelFinishRepository.Object,
                mockWebHostEnvironment.Object);

            // Act
            var carModel = carService.GetCarModelbyId(1);

			// Assert
			Assert.Equal(carModel.Price + carModel.RepairCost + 500d, carModel.SellingPrice);
		}

		[Fact]
		public void AdminUserCanSeeAllCars()
		{
            // Arrange
            var mockBrandRepository = new Mock<IBrandRepository>();
            var mockModelRepository = new Mock<IModelRepository>();
            var mockFinishRepository = new Mock<IFinishRepository>();
            var mockBrandModelRepository = new Mock<IBrandModelRepository>();
            var mockModelFinishRepository = new Mock<IModelFinishRepository>();
            var mockCarRepository = new Mock<ICarRepository>();
			var mockWebHostEnvironment = new Mock<IWebHostEnvironment>();
			mockCarRepository.Setup(r => r.GetAll()).Returns(this.GetAllCars());
            var carService = new CarService(mockCarRepository.Object, mockBrandRepository.Object, mockModelRepository.Object, mockFinishRepository.Object,
                mockBrandModelRepository.Object, mockModelFinishRepository.Object,
                mockWebHostEnvironment.Object);

            // Act
            var allCars = this.GetAllCars();
			var cars = carService.GetAll(false);

			// Assert
			Assert.Equal(allCars.Count(), cars.Count());
		}

		[Fact]
		public void NonAdminUserCanSeeOnlyAvailableCars()
		{
			// Arrange
			var mockBrandRepository = new Mock<IBrandRepository>();
			var mockModelRepository = new Mock<IModelRepository>();
			var mockFinishRepository = new Mock<IFinishRepository>();
			var mockBrandModelRepository = new Mock<IBrandModelRepository>();
			var mockModelFinishRepository = new Mock<IModelFinishRepository>();
			var mockCarRepository = new Mock<ICarRepository>();
			var mockWebHostEnvironment = new Mock<IWebHostEnvironment>();
			mockCarRepository.Setup(r => r.GetAll()).Returns(this.GetAllCars());
			var carService = new CarService(mockCarRepository.Object, mockBrandRepository.Object, mockModelRepository.Object, mockFinishRepository.Object, 
				mockBrandModelRepository.Object, mockModelFinishRepository.Object,
				mockWebHostEnvironment.Object);

			// Act
			var allAvailableCars = this.GetAllCars().Where(c => c.NoMoreAvailable = false);
			var cars = carService.GetAll(true);

			// Assert
			Assert.Equal(allAvailableCars.Count(), cars.Count());
		}
	}
}
