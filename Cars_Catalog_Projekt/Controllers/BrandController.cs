using Cars_Catalog_Projekt.Data.Entities;
using Cars_Catalog_Projekt.Services;
using Cars_Catalog_Projekt.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cars_Catalog_Projekt.Controllers
{
    public class BrandController : Controller
    {
        private IBrandService brandService;

        public BrandController(IBrandService brandService)
        {
            this.brandService = brandService;
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Brand brand)
        {
            brandService.AddBrand(brand);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var model = brandService.GetBrandById(id);
            return View(model);
        }

        public IActionResult Edit(Brand brand)
        {
            brandService.EditBrand(brand);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var brand = brandService.GetBrandById(id);
            return View(brand);
        }

        public IActionResult DeleteConfirm(int id)
        {
            brandService.DeleteBrand(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
