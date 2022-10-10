using DishBurger.Data.Services.ServiceInterfaces;
using DishBurger.Data.Static;
using DishBurger.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DishBurger.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class IngredientsController : Controller
    {
        private readonly IIngredientsService _service;

        public IngredientsController(IIngredientsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Ingredient ingredient)
        {
            if (!ModelState.IsValid)
            {
                return View(ingredient);
            }
            await _service.AddAsync(ingredient);
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var ingredientDetails = await _service.GetByIdAsync(id);

            if (ingredientDetails == null) return View("NotFound");
            return View(ingredientDetails);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var ingredientDetails = await _service.GetByIdAsync(id);
            if (ingredientDetails == null) return View("NotFound");
            return View(ingredientDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Ingredient ingredient)
        {
            if (!ModelState.IsValid)
            {
                return View(ingredient);
            }
            await _service.UpdateAsync(id, ingredient);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var ingredientDetails = await _service.GetByIdAsync(id);
            if (ingredientDetails == null) return View("NotFound");
            return View(ingredientDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ingredientDetails = await _service.GetByIdAsync(id);
            if (ingredientDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
