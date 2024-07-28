using HomeWork2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork2.Controllers
{
    public class ProductController : Controller
    {
        private int _id = 4;
        public static List<Product> products = new List<Product>()
        {
            new Product
            {
                Id = 1,
                Name = "Coca-Cola",
                Description = "Classical coke",
                Price = 1.50f,
                Discount = 0
            },
            new Product
            {
                Id = 2,
                Name = "Coca-Cola Zero",
                Description = "Coke but with zero sugar",
                Price = 1.60f,
                Discount = 5
            },
            new Product
            {
                Id = 3,
                Name = "Coca-Cola Negative",
                Description = "Coke but with salt",
                Price = 1.40f,
                Discount = 20
            }
        };

        [HttpGet]
        public IActionResult Index()
        {
            return View(products);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            products.Remove(products.SingleOrDefault(item => item.Id == id));
            return RedirectToAction("Index",products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ProductAddViewModel viewModel = new ProductAddViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Add(ProductAddViewModel product)
        {
            if(!ModelState.IsValid)
                return View(product);

            var pr = new Product
            {
                Id= _id,
                Name= product.Name,
                Description= product.Description,
                Price = product.Price,
                Discount = product.Discount
            };
            _id++;
            products.Add(pr);
            return RedirectToAction("Index", products);
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            var pr = products.SingleOrDefault(item => item.Id == id);
            var pruVM = new ProductUpdateViewModel
            {
                Id = id,
                praVM = new ProductAddViewModel
                {
                    Name = pr.Name,
                    Description = pr.Description,
                    Price = pr.Price,
                    Discount = pr.Discount
                }
            };
            return View(pruVM);
        }


        [HttpPost]
        public IActionResult Update(ProductUpdateViewModel pruVM)
        {
            var index = products.FindIndex(item => item.Id == pruVM.Id);
            products[index].Name = pruVM.praVM.Name;
            products[index].Description = pruVM.praVM.Description;
            products[index].Price = pruVM.praVM.Price;
            products[index].Discount = pruVM.praVM.Discount;
            return RedirectToAction("Index",products);
        }

    }
}
