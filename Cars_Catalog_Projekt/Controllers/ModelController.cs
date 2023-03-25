using Cars_Catalog_Projekt.Data.Entities;
using Cars_Catalog_Projekt.Services;
using Cars_Catalog_Projekt.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cars_Catalog_Projekt.Controllers
{
    public class ModelController : Controller
    {
        private IModelService modelService;

        public ModelController(IModelService modelService)
        {
            this.modelService = modelService;
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Model model)
        {
            modelService.AddModel(model);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var model = modelService.GetModelById(id);
            return View(model);
        }

        public IActionResult Edit(Model model)
        {
            modelService.EditModel(model);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var model = modelService.GetModelById(id);
            return View(model);
        }

        public IActionResult DeleteConfirm(int id)
        {
            modelService.DeleteModel(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
