using System.ComponentModel.DataAnnotations;

namespace OCR_DotNet_P5_ExpressVoitures.Models.Entities
{
	public class Finish
	{
		[Key]
		public int IdFinish { get; set; }

		public string FinishName { get; set; } = string.Empty;
	}
}
