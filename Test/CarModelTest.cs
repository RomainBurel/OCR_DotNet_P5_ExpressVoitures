using OCR_DotNet_P5_ExpressVoitures.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Test
{
    public class CarModelTest
    {
        [Fact]
        public void CarShoudYearIsInRange1990Today()
        {
            // Arrange
            var carModel = new CarModel
            {
                IdCar = 1,
                VIN = "123AB56",
                Year = 1988,
                Brand = "Ford",
                Model = "Fiesta",
                Finish = "Trend",
                DateOfBuy = new DateTime(2024, 1, 1),
                Price = 8000d,
                DateOfRepair = new DateTime(2024, 2, 1),
                RepairCost = 1500d,
                RepairDescription = "Révision + carrosserie",
                DateOfAvailabilityForSale = new DateTime(2024, 2, 2),
                Description = "Une jolie voiture",
                NoMoreAvailable = false
            };

            // Act
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(carModel, new ValidationContext(carModel), validationResults, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(validationResults, vr => vr.MemberNames.Contains("Year"));
        }

        [Fact]
        public void CarShoudHaveBrand()
        {
            // Arrange
            var carModel = new CarModel
            {
                IdCar = 1,
                VIN = "123AB56",
                Year = 2012,
				Model = "Fiesta",
                Finish = "Trend",
                DateOfBuy = new DateTime(2024, 1, 1),
                Price = 8000d,
                DateOfRepair = new DateTime(2024, 2, 1),
                RepairCost = 1500d,
                RepairDescription = "Révision + carrosserie",
                DateOfAvailabilityForSale = new DateTime(2024, 2, 2),
                Description = "Une jolie voiture",
                NoMoreAvailable = false
            };

            // Act
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(carModel, new ValidationContext(carModel), validationResults, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(validationResults, vr => vr.MemberNames.Contains("Brand"));
        }

		[Fact]
		public void CarDateOfBuyShouldBeLaterOrEqualToYear()
		{
			// Arrange
			var carModel = new CarModel
			{
				IdCar = 1,
				VIN = "123AB56",
				Year = 2024,
				Brand = "Ford",
				Model = "Fiesta",
				Finish = "Trend",
				DateOfBuy = new DateTime(2023, 1, 1),
				Price = 8000d,
				DateOfRepair = new DateTime(2023, 2, 1),
				RepairCost = 1500d,
				RepairDescription = "Révision + carrosserie",
				DateOfAvailabilityForSale = new DateTime(2024, 2, 2),
				Description = "Une jolie voiture",
				NoMoreAvailable = false
			};

			// Act
			var validationResults = new List<ValidationResult>();
			var isValid = Validator.TryValidateObject(carModel, new ValidationContext(carModel), validationResults, true);

			// Assert
			Assert.False(isValid);
			Assert.Contains(validationResults, vr => vr.MemberNames.Contains("DateOfBuy"));
		}

		[Fact]
		public void CarDateOfRepairShouldBeLaterOrEqualToDateOfBuy()
		{
			// Arrange
			var carModel = new CarModel
			{
				IdCar = 1,
				VIN = "123AB56",
				Year = 2020,
				Brand = "Ford",
				Model = "Fiesta",
				Finish = "Trend",
				DateOfBuy = new DateTime(2024, 1, 1),
				Price = 8000d,
				DateOfRepair = new DateTime(2023, 2, 1),
				RepairCost = 1500d,
				RepairDescription = "Révision + carrosserie",
				DateOfAvailabilityForSale = new DateTime(2024, 2, 2),
				Description = "Une jolie voiture",
				NoMoreAvailable = false
			};

			// Act
			var validationResults = new List<ValidationResult>();
			var isValid = Validator.TryValidateObject(carModel, new ValidationContext(carModel), validationResults, true);

			// Assert
			Assert.False(isValid);
			Assert.Contains(validationResults, vr => vr.MemberNames.Contains("DateOfRepair"));
		}

		[Fact]
		public void CarDateOfAvailabilityForSaleShouldBeLaterOrEqualToDateOfRepair()
		{
			// Arrange
			var carModel = new CarModel
			{
				IdCar = 1,
				VIN = "123AB56",
				Year = 2020,
				Brand = "Ford",
				Model = "Fiesta",
				Finish = "Trend",
				DateOfBuy = new DateTime(2024, 1, 1),
				Price = 8000d,
				DateOfRepair = new DateTime(2024, 4, 1),
				RepairCost = 1500d,
				RepairDescription = "Révision + carrosserie",
				DateOfAvailabilityForSale = new DateTime(2024, 2, 2),
				Description = "Une jolie voiture",
				NoMoreAvailable = false
			};

			// Act
			var validationResults = new List<ValidationResult>();
			var isValid = Validator.TryValidateObject(carModel, new ValidationContext(carModel), validationResults, true);

			// Assert
			Assert.False(isValid);
			Assert.Contains(validationResults, vr => vr.MemberNames.Contains("DateOfAvailabilityForSale"));
		}

		[Fact]
		public void CarDatesCanAllBeEqual()
		{
			// Arrange
			var carModel = new CarModel
			{
				IdCar = 1,
				VIN = "123AB56",
				Year = 2024,
				Brand = "Ford",
				Model = "Fiesta",
				Finish = "Trend",
				DateOfBuy = new DateTime(2024, 1, 1),
				Price = 8000d,
				DateOfRepair = new DateTime(2024, 1, 1),
				RepairCost = 1500d,
				RepairDescription = "Révision + carrosserie",
				DateOfAvailabilityForSale = new DateTime(2024, 1, 1),
				Description = "Une jolie voiture",
				NoMoreAvailable = false
			};

			// Act
			var validationResults = new List<ValidationResult>();
			var isValid = Validator.TryValidateObject(carModel, new ValidationContext(carModel), validationResults, true);

			// Assert
			Assert.True(isValid);
		}
	}
}
