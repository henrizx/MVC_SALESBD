using Microsoft.AspNetCore.Mvc;
using SalesWebMvc3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc3.Models;

namespace SalesWebMvc3.Controllers
{
    public class SallarsController : Controller
    {
        private readonly SellerService _sellerService;
        public SallarsController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }


        public IActionResult Index()
        {

            var list = _sellerService.FindAll();
            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Saller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}
