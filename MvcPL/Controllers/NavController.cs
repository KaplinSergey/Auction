using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using BLL.Interfaces.Services;
using MvcPL.Filters;
using BLL.Interfaces.Entities;
using MvcPL.Infrastructure.Mappers;
using MvcPL.ViewModels;

namespace MvcPL.Controllers
{
    public class NavController : Controller
    {
        private readonly ILotService _lotService;
        private readonly ICategoryService _categoryService;
        private readonly IUserService _userService;
        public NavController(ICategoryService categoryService, ILotService lotService, IUserService userService)
        {
            _categoryService = categoryService;
            _lotService = lotService;
            _userService = userService;
        }


        [ChildActionOnly]
        public PartialViewResult Menu()
        {
            IEnumerable<string> categories = _categoryService.GetAllCategoryEntities().Select(c => c.Name).OrderBy(c => c);
            return PartialView(categories);
        }


        [ChildActionOnly]
        public PartialViewResult Carousel()
        {
            IList<CategoryViewModel> categories = _categoryService.GetAllCategoryEntities().Select(c => c.ToMvcCategory()).OrderBy(c => c.Name).ToList();
            return PartialView(categories);
        }


        [ChildActionOnly]
        public PartialViewResult Search()
        {
            return PartialView();
        }


        public JsonResult Autocomplete(string term)
        {
            var lots = _lotService.GetAllForSaleLotEntities().Where(l => Regex.IsMatch(l.Name, term, RegexOptions.IgnoreCase))
                .Select(l => new { id = l.Id, label = l.Name, value = l.Name });
            return Json(lots.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AutocompleteAllLots(string term)
        {
            var lots = _lotService.GetAllLotEntities().Where(l => Regex.IsMatch(l.Name, term, RegexOptions.IgnoreCase))
                .Select(l => new { id = l.Id, label = l.Name, value = l.Name });
            return Json(lots.ToList(), JsonRequestBehavior.AllowGet);
        }


        public JsonResult AutocompleteForUser(string term)
        {
            var user = _userService.GetUserByEmail(User.Identity.Name);
            var lots = _lotService.GetAllLotEntities().Where(l => l.UserId==user.Id && Regex.IsMatch(l.Name, term, RegexOptions.IgnoreCase))
                .Select(l => new { id = l.Id, label = l.Name, value = l.Name });
            return Json(lots.ToList(), JsonRequestBehavior.AllowGet);
        }


        [ChildActionOnly]
        public PartialViewResult AdminNavBar()
        {
            return PartialView();
        }


        [ChildActionOnly]
        public PartialViewResult UserNavBar()
        {
            return PartialView();
        }


        [ChildActionOnly]
        public PartialViewResult AdminSideBar()
        {
            return PartialView();
        }


        [ChildActionOnly]
        public PartialViewResult UserSideBar()
        {
            return PartialView();
        }


        public FileContentResult GetImage(int id)
        {
            CategoryEntity category = _categoryService.GetCategoryEntity(id);
            if (category.ImageData != null)
            {
                return File(category.ImageData, category.ImageType);
            }
            else
            {
                return null;
            }
        }
    }
}
