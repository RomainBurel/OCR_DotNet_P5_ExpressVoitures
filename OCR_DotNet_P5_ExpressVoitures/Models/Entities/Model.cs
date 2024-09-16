using System.ComponentModel.DataAnnotations;

namespace OCR_DotNet_P5_ExpressVoitures.Models.Entities
{
	public class Model
	{
		[Key]
		public int IdModel { get; set; }

		public string ModelName { get; set; } = string.Empty;
	}
}
