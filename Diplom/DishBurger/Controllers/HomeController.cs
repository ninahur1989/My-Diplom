using DishBurger.Data.Enums;
using DishBurger.Data.Services.ServiceInterfaces;
using DishBurger.Data.Static;
using DishBurger.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PagedList;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DishBurger.Controllers
{

    public class HomeController : Controller
    {
        private int _pageIndex = PageInfo._pageIndex;
        private readonly IHomeService _service;

        public HomeController(IHomeService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(int? PageNumber, SortTypes? SortPage)
        {
            SortTypes curentSort = (SortPage ?? SortTypes.None);
            ViewData["Sort"] = curentSort;
            _pageIndex = PageNumber.HasValue ? Convert.ToInt32(PageNumber.Value) : 1;
            IPagedList<ItemEntity> pagedItems = null;

            var allitems = await _service.GetSortedItemsAsync(SortPage);
            pagedItems = allitems.ToPagedList(_pageIndex, PageInfo._pageSize);
            return View(pagedItems);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString , int? PageNumber)
        {
            _pageIndex = PageNumber.HasValue ? Convert.ToInt32(PageNumber.Value) : 1;
            var allItems = await _service.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResultNew = allItems.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();
                var pagedItems1 = filteredResultNew.ToPagedList(_pageIndex, PageInfo._pageSize);
                return View("Index", pagedItems1);
            }

            var pagedItems = allItems.ToPagedList(_pageIndex, PageInfo._pageSize);
            return View("Index", pagedItems);
        }
    }
}