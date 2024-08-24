using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OCR_DotNet_P5_ExpressVoitures.Models.ViewModels;
using OCR_DotNet_P5_ExpressVoitures.Services;

namespace OCR_DotNet_P5_ExpressVoitures.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            this._carService = carService;
        }

        // GET: CarsController/Index
        public ActionResult Index()
        {
			var currentUser = this.User;
			bool onlyAvailableCars = currentUser == null || !currentUser.IsInRole("Admin");
			return View(this._carService.GetAll(onlyAvailableCars));
        }

        // GET: CarsController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = this._carService.GetCarMainInfosModelbyId(id.Value);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: CarsController/Details/5
        public ActionResult DetailsForAdmin(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = this._carService.GetCarModelbyId(id.Value);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: CarsController/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            var carModel = new CarModel();
            return View(carModel);
        }

        // POST: CarsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(CarModel carModel, IFormFile? UploadedImage)
        {
			if (ModelState.IsValid)
            {
                this._carService.Add(carModel, UploadedImage);
				
                var notificationModel = new NotificationModel
				{
					Title = carModel.GetCarSummary(),
					Message = "a bien été ajoutée"
				};

				return View("Notification", notificationModel);
			}

			return View(carModel);
        }

        // GET: CarsController/Edit/5
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = this._carService.GetCarModelbyId(id.Value);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: CarsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id, CarModel carModel, IFormFile? UploadedImage)
        {
            if (id != carModel.IdCar)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
				{
                    this._carService.Update(carModel, UploadedImage);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (this._carService.GetById(carModel.IdCar) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

				var notificationModel = new NotificationModel
				{
					Title = carModel.GetCarSummary(),
					Message = "a bien été modifiée"
				};

				return View("Notification", notificationModel);
			}

			return View(carModel);
        }

        // GET: CarsController/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = this._carService.GetCarModelbyId(id.Value);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: CarsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id, CarModel carModel)
        {
            if (id != carModel.IdCar)
            {
                return NotFound();
            }

            try
            {
                this._carService.Delete(carModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (this._carService.GetById(carModel.IdCar) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

			var notificationModel = new NotificationModel
			{
				Title = carModel.GetCarSummary(),
				Message = "a bien été supprimée"
			};

			return View("Notification", notificationModel);
        }

		// GET: CarsController/Notification
		public ActionResult Notification(NotificationModel notificationModel)
		{
			return View(notificationModel);
		}
    }
}
