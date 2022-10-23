using Microsoft.AspNetCore.Mvc;
using ShoppingWithBetty.DataAccess.Repositories;
using ShoppingWithBetty.DataAccess.Repositories.ViewModels;
using ShoppingWithBetty.Models;

namespace ShoppingWithBetty.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CatagoryController : Controller
    {
        private IUnitOfRole _unitOfRole;
        public CatagoryController(IUnitOfRole unitOfRole)
        {
            _unitOfRole = unitOfRole;   
        }

        public IUnitOfRole Get_unitOfRole()
        {
            return _unitOfRole;
        }

        public IActionResult Index()
        {
            CatagoryVM catagoryVM = new CatagoryVM();
            catagoryVM.catagories = _unitOfRole.Catagory.GetAll();
            return View(catagoryVM);
        }

        [HttpGet]
        public IActionResult CreateUpdate(int? id)
        {
            CatagoryVM vm = new CatagoryVM();
            if (id == null || id == 0)
            {
                return View(vm);
            }
            else
            {
                vm.Catagory = _unitOfRole.Catagory.GetT(s => s.Id == id);
                if(vm.Catagory== null)
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
        public IActionResult CreateUpdate(CatagoryVM vm)
        {
            if (ModelState.IsValid)
            {
                if (vm.Catagory.Id == 0)
                {
                    _unitOfRole.Catagory.Add(vm.Catagory);
                    TempData["success"] = "NEW CATAGORY CREATED";
                }
                else
                {
                    _unitOfRole.Catagory.Update(vm.Catagory);
                    TempData["success"] = "CATAGORY UPDATED";
                }
                _unitOfRole.Save();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            else
            {
                var catagory = _unitOfRole.Catagory.GetT(s => s.Id == id);
                if (catagory == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(catagory);
                }
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteData(int? id)
        {
            var catagory = _unitOfRole.Catagory.GetT(x => x.Id == id);
            if (catagory == null)
            {
                return NotFound();
            }
            _unitOfRole.Catagory.Delete(catagory);
            _unitOfRole.Save();
            TempData["success"] = "Catagory Deleted";
            return RedirectToAction("Index");
        }
    }
}
