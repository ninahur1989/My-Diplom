using DishBurger.Data.Enums;
using DishBurger.Data.Services.ServiceInterfaces;
using DishBurger.Data.Static;
using DishBurger.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PagedList;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DishBurger.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class DishesController : Controller
    {
        private int _pageIndex = PageInfo._pageIndex;
        private readonly IDishesService _service;

        public DishesController(IDishesService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(int? PageNumber , SortTypes? SortPage)
        {
            SortTypes curentSort = (SortPage ?? SortTypes.None);
            ViewData["Sort"] = curentSort;
            _pageIndex = PageNumber.HasValue ? Convert.ToInt32(PageNumber.Value) : 1;
            IPagedList<ItemEntity> pagedDishes = null;

            var allDishes = await _service.GetSortedDishesAsync(curentSort);
            pagedDishes = allDishes.ToPagedList(_pageIndex, PageInfo._pageSize);
            return View(pagedDishes);
        }     

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var dishDetail = await _service.GetDishByIdAsync(id);
            return View(dishDetail);
        }

        public async Task<IActionResult> Create()
        {
            var dishDropdownsData = await _service.GetNewDishDropdownsValues();

            ViewBag.Restaurants = new SelectList(dishDropdownsData.Restaurants, "Id", "Name");
            ViewBag.Ingredients = new SelectList(dishDropdownsData.Ingredients, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewDishVM dish)
        {
            if (!ModelState.IsValid)
            {
                var dishDropdownsData = await _service.GetNewDishDropdownsValues();

                ViewBag.Restaurants = new SelectList(dishDropdownsData.Restaurants, "Id", "Name"); ;
                ViewBag.Ingredients = new SelectList(dishDropdownsData.Ingredients, "Id", "FullName");

                return View(dish);
            }

            await _service.AddNewDishAsync(dish);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var dishDetails = await _service.GetDishByIdAsync(id);
            if (dishDetails == null) return View("NotFound");

            var response = new NewDishVM()
            {
                Id = dishDetails.Id,
                Name = dishDetails.Name,
                Description = dishDetails.Dish.Description,
                Price = dishDetails.Price,
                ImageURL = dishDetails.ImageURL,
                DishCuisine = dishDetails.Dish.DishCuisine,
                RestaurantId = dishDetails.Dish.RestaurantId,
                IngredientIds = dishDetails.Dish.Ingredient_Dish.Select(n => n.IngredientId).ToList(),
            };

            var dishDropdownsData = await _service.GetNewDishDropdownsValues();
            ViewBag.Restaurants = new SelectList(dishDropdownsData.Restaurants, "Id", "Name");
            ViewBag.Ingredients = new SelectList(dishDropdownsData.Ingredients, "Id", "FullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewDishVM dish)
        {
            if (id != dish.Id) 
                return View("NotFound");

            if (!ModelState.IsValid)
            {
                var dishDropdownsData = await _service.GetNewDishDropdownsValues();

                ViewBag.Restaurants = new SelectList(dishDropdownsData.Restaurants, "Id", "Name");
                ViewBag.Ingredients = new SelectList(dishDropdownsData.Ingredients, "Id", "FullName");

                return View(dish);
            }

            await _service.UpdateDishAsync(dish);
            return RedirectToAction(nameof(Index));
        }
    }
}