using System.ComponentModel.DataAnnotations;

namespace OCR_DotNet_P5_ExpressVoitures.Models.Entities
{
    public class Car
    {
        [Key]
        public int IdCar { get; set; }

        public string? VIN { get; set; }

        public int Year { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Finish { get; set; }

        public DateTime DateOfBuy { get; set; }

        public double Price { get; set; }

        public string? RepairDescription { get; set; }

        public DateTime? DateOfRepair { get; set; }

        public double RepairCost { get; set; }

        public bool NoMoreAvailable { get; set; }

        public DateTime DateOfAvailabilityForSale { get; set; }

        public string? Description { get; set; }

        public DateTime? DateOfSale { get; set; }

        public string? ImagePath { get; set; }

        public double GetSellingPrice()
        {
            return this.Price + this.RepairCost + 500d;
        }
    }
}
