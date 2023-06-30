using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyModel.Resolution;
using ProjectClean.Application.Interfaces;
using ProjectClean.Application.ViewModels;

namespace ProjectClean.MVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [RequireHttps]
        public async Task<IActionResult> Index()
        {
            return View(await _productService.GetProducts());
        }

        [HttpGet()]
        [RequireHttps]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [RequireHttps]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id, Name, Description, Price")] ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                _productService.Add(productViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(productViewModel);
        }

        [HttpGet()]
        [RequireHttps]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var productViewModel = await _productService.GetById(id);
            if (productViewModel == null) return NotFound();
            return View(productViewModel);
        }

        [HttpPost()]
        [RequireHttps]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id, Name, Description, Price")] ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _productService.Update(productViewModel);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(productViewModel);
        }

        [RequireHttps]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var productViewModel = await _productService.GetById(id);
            if (productViewModel == null) return NotFound();
            return View(productViewModel);
        }

        [HttpGet()]
        [RequireHttps]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var productViewModel = await _productService.GetById(id);
            if (productViewModel == null) return NotFound();
            return View(productViewModel);
        }

        [HttpPost(), ActionName(nameof(Delete))]
        [RequireHttps]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _productService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}