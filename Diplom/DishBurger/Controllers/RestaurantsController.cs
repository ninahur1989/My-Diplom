using DishBurger.Data;
using DishBurger.Data.Services.ServiceInterfaces;
using DishBurger.Data.Static;
using DishBurger.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DishBurger.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantsService _service;

        public RestaurantsController(IRestaurantsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allRestaurants = await _service.GetAllAsync();
            return View(allRestaurants);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description,Address")]Restaurant restaurant)
        {
            if (!ModelState.IsValid) return View(restaurant);
            await _service.AddAsync(restaurant);
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var restaurantDetails = await _service.GetByIdAsync(id);
            if (restaurantDetails == null) return View("NotFound");
            return View(restaurantDetails);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var restaurantDetails = await _service.GetByIdAsync(id);
            if (restaurantDetails == null) return View("NotFound");
            return View(restaurantDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description,Address")] Restaurant restaurant)
        {
            if (!ModelState.IsValid) return View(restaurant);
            await _service.UpdateAsync(id, restaurant);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var restaurantDetails = await _service.GetByIdAsync(id);
            if (restaurantDetails == null) return View("NotFound");
            return View(restaurantDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var restaurantDetails = await _service.GetByIdAsync(id);
            if (restaurantDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
