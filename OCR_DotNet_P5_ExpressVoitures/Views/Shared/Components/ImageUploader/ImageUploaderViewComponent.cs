using Microsoft.AspNetCore.Mvc;

namespace OCR_DotNet_P5_ExpressVoitures.Views.Shared.Components.ImageUploader
{
    public class ImageUploaderViewComponent: ViewComponent
    {
        public ImageUploaderViewComponent()
        {
        }

        public IViewComponentResult Invoke(string FieldName)
        {
            return View("Default", FieldName);
        }
    }
}
