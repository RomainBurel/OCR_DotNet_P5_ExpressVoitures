using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using OCR_DotNet_P5_ExpressVoitures.Models.Entities;
using System.ComponentModel;

namespace OCR_DotNet_P5_ExpressVoitures.Models.ViewModels
{
    public class CarMainInfosModel
    {
        public int IdCar { get; set; }

        [DisplayName("Année")]
        public int Year { get; set; }

        [DisplayName("Marque")]
        public int IdBrand { get; set; }

        [DisplayName("Modèle")]
        public int IdModel { get; set; }

        [DisplayName("Finition")]
        public int IdFinish { get; set; }

        [DisplayName("Prix de vente")]
        public double SellingPrice { get; set; }

        public string? Description { get; set; }

        [DisplayName("Photo")]
        public string? ImagePath { get; set; }

        [DisplayName("Photo de la voiture")]
        public IFormFile? UploadedImage { get; set; }

        [ValidateNever]
        public string BrandName { get; set; } = string.Empty;

        [ValidateNever]
        public string ModelName { get; set; } = string.Empty;

        [ValidateNever]
        public string FinishName { get; set; } = string.Empty;
    }
}
