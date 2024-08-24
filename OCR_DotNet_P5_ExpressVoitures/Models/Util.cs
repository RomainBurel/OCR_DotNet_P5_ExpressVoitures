namespace OCR_DotNet_P5_ExpressVoitures.Models
{
    public static class Util
    {
        public static string FormatValueAsCurrency(double value)
        {
            return value.ToString("C0");
        }

        public static string FormatBoolValue(bool value)
        {
            return value ? "Oui" : "Non";
        }
    }
}
