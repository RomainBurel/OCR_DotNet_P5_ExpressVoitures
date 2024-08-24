using System.ComponentModel;

namespace OCR_DotNet_P5_ExpressVoitures.Models.ViewModels
{
    public class CarMainInfosModel
    {
        public int IdCar { get; set; }

        [DisplayName("Année")]
        public int Year { get; set; }

        [DisplayName("Marque")]
        public string Brand { get; set; }

        [DisplayName("Modèle")]
        public string Model { get; set; }

        [DisplayName("Finition")]
        public string? Finish { get; set; }

        [DisplayName("Prix de vente")]
        public double SellingPrice { get; set; }

        public string? Description { get; set; }

        [DisplayName("Photo")]
        public string? ImagePath { get; set; }

        [DisplayName("Photo de la voiture")]
        public IFormFile? UploadedImage { get; set; }
    }
}
