using DishBurger.Data.Enums;
using DishBurger.Data.Services.ServiceInterfaces;
using DishBurger.Data.Static;
using DishBurger.Data.ViewModels;
using DishBurger.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PagedList;
using System;
using System.Threading.Tasks;

namespace DishBurger.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class DrinksController : Controller
    {
        private int _pageIndex = PageInfo._pageIndex;
        private readonly IDrinksService _service;

        public DrinksController(IDrinksService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(int? PageNumber, SortTypes? SortPage)
        {
            SortTypes curentSort = (SortPage ?? SortTypes.None);
            ViewData["Sort"] = curentSort;
            _pageIndex = PageNumber.HasValue ? Convert.ToInt32(PageNumber.Value) : 1;
            IPagedList<ItemEntity> pagedDrinks = null;

            var allitems = await _service.GetSortedDrinksAsync(SortPage);
            pagedDrinks = allitems.ToPagedList(_pageIndex, PageInfo._pageSize);
            return View(pagedDrinks);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var drinkDetail = await _service.GetDrinkByIdAsync(id);
            return View(drinkDetail);
        }

        public async Task<IActionResult> Create()
        {
            var drinkDropdownsData = await _service.GetNewDrinkDropdownsValues();

            ViewBag.Manufacturers = new SelectList(drinkDropdownsData.Manufacturers, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewDrinkVM drink)
        {
            if (!ModelState.IsValid)
            {
                var drinkDropdownsData = await _service.GetNewDrinkDropdownsValues();

                ViewBag.Manufacturers = new SelectList(drinkDropdownsData.Manufacturers, "Id", "Name");

                return View(drink);
            }

            await _service.AddNewDrinkAsync(drink);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var drinkDetails = await _service.GetDrinkByIdAsync(id);
            if (drinkDetails == null) return View("NotFound");

            var response = new NewDrinkVM()
            {
                Id = drinkDetails.Id,
                Name = drinkDetails.Name,
                Volume = drinkDetails.Drink.Volume,
                Price = drinkDetails.Price,
                ImageURL = drinkDetails.ImageURL,
                DrinkType = drinkDetails.Drink.DrinkType,
                ManufacturerId = drinkDetails.Drink.ManufacturerId,
            };

            var drinkDropdownsData = await _service.GetNewDrinkDropdownsValues();

            ViewBag.Manufacturers = new SelectList(drinkDropdownsData.Manufacturers, "Id", "Name"); ;

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewDrinkVM drink)
        {
            if (id != drink.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var drinkDropdownsData = await _service.GetNewDrinkDropdownsValues();

                ViewBag.Manufacturers = new SelectList(drinkDropdownsData.Manufacturers, "Id", "Name"); ;

                return View(drink);
            }

            await _service.UpdateDrinkAsync(drink);
            return RedirectToAction(nameof(Index));
        }
    }
}