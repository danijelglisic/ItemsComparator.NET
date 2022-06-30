using ItemsComapring.Models;
using ItemsComapring.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace ItemsComapring.Controllers
{
    public class HomeController : Controller
    {
        private readonly IItemRepository _itemRepository;

        public HomeController(IItemRepository itemRepository)
        {
            this._itemRepository = itemRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var items = _itemRepository.GetAllItems();
            ViewData["CombinationCount"] = _itemRepository.GetAllCombinations().Count();
            return View(items);
        }

        [HttpPost]
        public IActionResult Index([FromForm] CompareModel comparedItems)
        {
            _itemRepository.CompareItems(comparedItems);
            ViewData["CombinationCount"] = _itemRepository.GetAllCombinations().Count();
            var items = _itemRepository.GetAllItems();
            return View(items);
        }

        [HttpGet]
        public IActionResult ItemsComparePartialView()
        {
            return PartialView("~/Views/Shared/_ItemComparePartial.cshtml", _itemRepository.GetNextCombination() ?? null);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}