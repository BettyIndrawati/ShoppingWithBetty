using Microsoft.AspNetCore.Mvc;
using ShoppingWithBetty.DataAccess.Repositories;
using ShoppingWithBetty.DataAccess.Repositories.ViewModels;

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
    }
}
