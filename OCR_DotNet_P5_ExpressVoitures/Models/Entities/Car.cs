using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OCR_DotNet_P5_ExpressVoitures.Models.Entities
{
    public class Car
    {
        [Key]
        public int IdCar { get; set; }

        public string? VIN { get; set; }

        public int Year { get; set; }

        [ForeignKey(nameof(IdBrand))]
        public int IdBrand { get; set; }

		[ForeignKey(nameof(IdModel))]
		public int IdModel { get; set; }

		[ForeignKey(nameof(IdFinish))]
		public int IdFinish { get; set; }

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
