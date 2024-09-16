using System.ComponentModel.DataAnnotations;

namespace OCR_DotNet_P5_ExpressVoitures.Models.Entities
{
	public class Brand
	{
		[Key]
		public int IdBrand { get; set; }

		public string BrandName { get; set; } = string.Empty;
	}
}
