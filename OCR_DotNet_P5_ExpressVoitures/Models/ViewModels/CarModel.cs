using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OCR_DotNet_P5_ExpressVoitures.Models.ViewModels
{
    public class CarModel: IValidatableObject
    {
        public int IdCar { get; set; }

        [DisplayName("Numéro d'identification du véhicule")]
        public string? VIN { get; set; }

        [Required(ErrorMessage = "La saisie de l'année est obligatoire.")]
        [DisplayName("Année")]
		[RangeUntilCurrentYear(1990, ErrorMessage = "L'année doit être comprise entre 1990 et aujourd'hui.")]
		public int Year { get; set; }

        [Required(ErrorMessage = "La saisie de la marque est obligatoire.")]
        [DisplayName("Marque")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "La saisie du modèle est obligatoire.")]
        [DisplayName("Modèle")]
        public string Model { get; set; }

		[Required(ErrorMessage = "La saisie de la finition est obligatoire.")]
		[DisplayName("Finition")]
        public string? Finish { get; set; }

        [Required(ErrorMessage = "La saisie de la date d'achat est obligatoire.")]
        [DisplayName("Date d'achat")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfBuy { get; set; }

        [Required(ErrorMessage = "La saisie du prix d'achat est obligatoire.")]
		[DisplayName("Prix d'achat")]
		[DisplayFormat(DataFormatString = "{0:C0}")]
		public double Price { get; set; }

        [DisplayName("Réparation(s) effectuée(s)")]
        public string? RepairDescription { get; set; }

        [DisplayName("Date de la réparation")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DateOfRepair { get; set; }

        [Required(ErrorMessage = "La saisie du coût de réparation est obligatoire (mettre 0 si aucun).")]
		[DisplayName("Coût de la réparation")]
		[DisplayFormat(DataFormatString = "{0:C0}")]
		public double RepairCost { get; set; }

        [DisplayName("Véhicule plus disponible")]
        public bool NoMoreAvailable { get; set; }

        [Required(ErrorMessage = "La sélection d'une date de disponibilité est obligatoire.")]
        [DisplayName("Date de disponibilité")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfAvailabilityForSale { get; set; }

        [DisplayName("Prix de vente")]
		[DisplayFormat(DataFormatString = "{0:C0}")]
        public double SellingPrice { get; set; }

        public string? Description { get; set; }

        [DisplayName("Photo")]
        public string? ImagePath { get; set; }

        [DisplayName("Photo de la voiture")]
        public IFormFile? UploadedImage { get; set; }

        [DisplayName("Date de vente")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DateOfSale { get; set; }

        public CarModel()
        {
            this.Year = 1990;
            this.DateOfBuy = DateTime.Today;
            this.DateOfAvailabilityForSale = DateTime.Today;
        }

        public string GetCarSummary()
        {
            return this.Brand + " " + this.Model + " " + this.Finish + " (" + this.Year + ")";
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            if (DateOfBuy.Year < Year)
            {
                validationResults.Add(new ValidationResult("La date d'achat ne peut pas être inférieure à l'année de mise en circulation.", new[] { nameof(DateOfBuy) }));
            }

            if (DateOfRepair.HasValue && DateOfRepair.Value < DateOfBuy)
            {
                validationResults.Add(new ValidationResult("La date de réparation ne peut pas être antérieure à la date d'achat.", new[] { nameof(DateOfRepair) }));
            }

            if (DateOfAvailabilityForSale < DateOfBuy)
            {
                validationResults.Add(new ValidationResult("La date de disponibilité à la vente ne peut pas être antérieure à la date d'achat.", new[] { nameof(DateOfAvailabilityForSale) }));
            }

            if (DateOfRepair.HasValue && DateOfAvailabilityForSale < DateOfRepair)
            {
                validationResults.Add(new ValidationResult("La date de disponibilité à la vente ne peut pas être antérieure à la date de réparation.", new[] { nameof(DateOfAvailabilityForSale) }));
            }

            if (DateOfSale.HasValue && DateOfSale.Value < DateOfAvailabilityForSale)
            {
                validationResults.Add(new ValidationResult("La date de vente ne peut pas être antérieure à la date de disponibilité à la vente.", new[] { nameof(DateOfSale) }));
            }

            return validationResults;
        }
    }
}
