using Cars_Catalog_Projekt.Data.Entities;
using Cars_Catalog_Projekt.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace Cars_Catalog_Projekt.Controllers
{
    public class VechicleController : Controller
    {
        private IVechicleService vechicleService;

        public VechicleController(IVechicleService vechicleService)
        {
            this.vechicleService = vechicleService;
        }

        public IActionResult Index() 
        { 
            var vechicles = vechicleService.GetAllVechicles();
            return View(vechicles);
        }

        public IActionResult Create() 
        { 
            return View();
        }

        [HttpPost]

        public IActionResult Create(Vechicle vechicle) 
        {
            vechicleService.AddVechicle(vechicle);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id) 
        {
            var vechicle = vechicleService.GetVechicleById(id);
            return View(vechicle);
        }

        public IActionResult Edit(Vechicle vechicle) 
        { 
            vechicleService.EditVechicle(vechicle);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var vechicle = vechicleService.GetVechicleById(id);
            return View(vechicle);
        }

        public IActionResult DeleteConfirm(int id)
        {
            vechicleService.DeleteVechicle(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
