using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using NPoco.Expressions;
using OpenXmlPowerTools;
using ShoppingWithBetty.DataAccess.Repositories;
using ShoppingWithBetty.DataAccess.Repositories.ViewModels;
using ShoppingWithBetty.Models;
using Product = ShoppingWithBetty.Models.Product;

namespace ShoppingWithBetty.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private IUnitOfRole _unitOfRole;
        private IWebHostEnvironment _hostingEnvironment;
        

        public ProductController(IUnitOfRole unitOfRole, 
            IWebHostEnvironment hostingEnvironment)
        {
            _unitOfRole = unitOfRole;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult AllProducts()
        {
            var products = _unitOfRole.Product.GetAll(includeProperties: "Catagory");
            return Json(new { data = products });
        }

        public IActionResult Index()
        {
            //CatagoryVM catagoryVM = new CatagoryVM();
            //catagoryVM.Catagories = _unitOfRole.Catagory.GetAll();
            return View();
        }

        //public Product GetProduct()
        //{
        //    return Product;
        //}

        [HttpGet]
        public IActionResult CreateUpdate(int? id)
        {
            ProductVM vm = new ProductVM()
            {
                Product = new(),
                Catagories = _unitOfRole.Catagory.GetAll().Select(x =>
            new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            })
            };
            if (id == null || id == 0)
            {
                return View(vm);
            }
            else
            {
                vm.Product = _unitOfRole.Product.GetT(x => x.Id == id);
                if (vm.Product == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(vm);
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUpdate(ProductVM vm, IFormFile?file)
        {
            if (ModelState.IsValid)
            { 
                string fileName = String.Empty;
                if (file !=null)
                    {
                    string uploadDir = Path.Combine(_hostingEnvironment.WebRootPath, "ProductImage");
                    fileName = Guid.NewGuid().ToString() + "-" + file.FileName;
                    string filePath = Path.Combine(uploadDir, fileName);

                    if (vm.Product.ImageUrl != null)
                    {
                        var GambarLamaPath = Path.Combine(_hostingEnvironment.WebRootPath, vm.Product.ImageUrl.TrimStart('\\'));
                            if (System.IO.File.Exists(GambarLamaPath))
                            {
                                System.IO.File.Delete(GambarLamaPath);
                            }
                    }
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    vm.Product.ImageUrl = @"\ProductImage\" + fileName;

                }
                if (vm.Product.Id == 0)
                {
                    _unitOfRole.Product.Add(vm.Product);
                    TempData["success"] = "Product Created Done!";
                }
                //if (vm.Product.Id == 0)
                //{
                //    _unitOfRole.Product.Add(vm.Product);
                //    TempData["success"] = "NEW PRODUCT CREATED";
                //}
                else
                {
                    _unitOfRole.Product.Update(vm.Product);
                    TempData["success"] = "PRODUCT UPDATED";
                }
                _unitOfRole.Save();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var product = _unitOfRole.Product.GetT(x => x.Id == id);
            if (product == null)
            {
                return Json(new { success = false, message = "Error Fatching" });
            }
            else
            {
                var GambarLamaPath = Path.Combine(_hostingEnvironment.WebRootPath, product.ImageUrl.TrimStart('\\'));
                if (System.IO.File.Exists(GambarLamaPath))
                {
                    System.IO.File.Delete(GambarLamaPath);  
                }
                _unitOfRole.Product.Delete(product);
                _unitOfRole.Save();
                return Json(new { success = true, message = "Product Deleted" });
            }
            
        }

        
    }
}
