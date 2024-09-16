using System.ComponentModel.DataAnnotations.Schema;

namespace OCR_DotNet_P5_ExpressVoitures.Models.Entities
{
	public class BrandModel
	{
		[ForeignKey(nameof(IdBrand))]
		public int IdBrand { get; set; }

		[ForeignKey(nameof(IdModel))]
		public int IdModel { get; set; }
	}
}
