using BLL.Interfaces.Services;
using MvcPL.ViewModels;
using MvcPL.Infrastructure.Mappers;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPL.Filters;

namespace MvcPL.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILotService _lotService;
        private readonly IPurchaseService _purchaseService;
        private readonly IBidService _bidService;

        public UserController(IUserService userService, ILotService lotService, IPurchaseService purchaseService, IBidService bidService)
        {
            _userService = userService;
            _lotService = lotService;
            _purchaseService = purchaseService;
            _bidService = bidService;
        }

        [Authorize(Roles = "User")]
        public ActionResult UserPanel()
        {            
            return View();
        }


        [HttpGet]
        [Authorize]
        public ActionResult Edit(int? userId)
        {
            UserViewModel model;
            if (userId!=null)
            {
                model = _userService.GetUserEntity((int)userId).ToMvcUser(); 
            }
            else
            {
                model = _userService.GetUserByEmail(User.Identity.Name).ToMvcUser();
            }                       
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserViewModel updatedUser = _userService.GetUserEntity(model.Id).ToMvcUser();
                updatedUser.Name = model.Name;
                updatedUser.Email = model.Email;
                _userService.UpdateUser(updatedUser.ToBllUser());
                return RedirectToAction("UserPanel", "User");
            }
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int userId)
        {
            _userService.DeleteUser(_userService.GetUserEntity(userId));
            return RedirectToAction("AdminPanel", "Admin");
        }

        [Authorize]
        public ActionResult GetLotsList(string state, string searchString, int? userId, bool isPartial=false)
        {
            IEnumerable<LotViewModel> model;
            if (!String.IsNullOrEmpty(searchString))
            {
                model = _lotService.GetAllLotEntities().Select(l => l.ToMvcLot()).Where(l => Regex.IsMatch(l.Name, searchString, RegexOptions.IgnoreCase));
            }
            else
            {
                switch (state)
                {
                    case ("Sold"):
                        model = _lotService.GetAllLotEntities().Select(l => l.ToMvcLot()).Where(l => l.State == LotStateViewModel.Sold);
                        break;
                    case ("Unsold"):
                        model = _lotService.GetAllLotEntities().Select(l => l.ToMvcLot()).Where(l => l.State == LotStateViewModel.Unsold);
                        break;
                    case ("For sale"):
                        model = _lotService.GetAllLotEntities().Select(l => l.ToMvcLot()).Where(l => l.State == LotStateViewModel.ForSale);
                        break;
                    default:
                        model = _lotService.GetAllLotEntities().Select(l => l.ToMvcLot());
                        break;
                }
            }
            if (User.IsInRole("User"))
            {
                model = model.Where(l => l.UserId == _userService.GetUserByEmail(User.Identity.Name).Id);
            }
            else if (userId != null)
            {
                model = model.Where(l => l.UserId == userId);
            }
            ViewBag.TimeSpan = state;
            if (isPartial)
            {
                return PartialView("_GetLotsList", model);
            }
            return View(model);
        }

        [Authorize]
        public ActionResult GetBidsList(string state, int? userId, bool isPartial = false)
        {
            IEnumerable<BidViewModel> model;
            if (User.IsInRole("User"))
            {
                userId=_userService.GetUserByEmail(User.Identity.Name).Id;
            }
            switch (state)
            {
                case ("Current"):
                    model = _bidService.GetAllBidEntitiesForSaleLots().Where(b => b.UserId == userId).Select(b => b.ToMvcBid());
                    break;
                case ("All"):
                default:
                    model = _bidService.GetAllBidEntities().Where(b => b.UserId == userId).Select(b => b.ToMvcBid());
                    break;
            }
            ViewBag.State = state;
            if (isPartial)
            {
                return PartialView("_GetBidsList", model);
            }
            return View(model);
        }

        [Authorize]
        public ActionResult GetPurchasesList(int? id, bool isPartial = false)
        {
            IEnumerable<PurchaseViewModel> model;
            if (User.IsInRole("User"))
            {
                id = _userService.GetUserByEmail(User.Identity.Name).Id;
                model = _purchaseService.GetPurchasesByUserId((int)id).Select(p => p.ToMvcPurchase()).OrderByDescending(p => p.Date);
            }
            else if (id != null)
            {
                model = _purchaseService.GetPurchasesByUserId((int)id).Select(p => p.ToMvcPurchase()).OrderByDescending(p => p.Date);
            }
            else
            {
                model = _purchaseService.GetAllPurchaseEntities().Select(p => p.ToMvcPurchase()).OrderByDescending(p => p.Date);
            }
            if (isPartial)
            {
                return PartialView("_GetPurchasesList", model);
            }
            return View(model);
        }

    }
}
