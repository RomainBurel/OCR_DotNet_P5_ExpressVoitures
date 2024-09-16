using System.ComponentModel.DataAnnotations.Schema;

namespace OCR_DotNet_P5_ExpressVoitures.Models.Entities
{
	public class ModelFinish
	{
		[ForeignKey(nameof(IdModel))]
		public int IdModel { get; set; }

		[ForeignKey(nameof(IdFinish))]
		public int IdFinish { get; set; }
	}
}
