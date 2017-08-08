using BLL.Interfaces.Services;
using MvcPL.Filters;
using MvcPL.ViewModels;
using MvcPL.Infrastructure.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using BLL.Interfaces.Entities;

namespace MvcPL.Controllers
{
    public class LotController : Controller
    {
        private readonly ILotService _lotService;
        private readonly ICommentService _commentService;
        private readonly IBidService _bidService;
        private readonly ICategoryService _categoryService;
        private readonly IUserService _userService;
        private readonly int pageSize=6;

        public LotController(ILotService lotService, ICommentService commentService, IBidService bidService,
            ICategoryService categoryService, IUserService userService)
        {
            _lotService = lotService;
            _commentService = commentService;
            _bidService = bidService;
            _categoryService = categoryService;
            _userService = userService;
        }

        public ViewResult Index(string category, string searchString, int page = 1)
        {
            IEnumerable<LotEntity> lotsForSale = _lotService.GetAllForSaleLotEntities().Where(l => searchString == null || Regex.IsMatch(l.Name, searchString, RegexOptions.IgnoreCase));
            IEnumerable<LotViewModel> sortedLots = lotsForSale.Where(l => category == null || l.Category.Name == category).Select(l => l.ToMvcLot()).OrderBy(l => l.StartDate)
                .Reverse().Skip((page - 1) * pageSize).Take(pageSize);
            LotsListViewModel model = new LotsListViewModel
            {
                Lots = sortedLots,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = category == null ? lotsForSale.Count() : lotsForSale.Where(l => l.Category.Name == category).Count()
                },
                CurrentCategory = category,
                CurrentSearchString = searchString
            };
            return View(model);
        }


        public ViewResult LotDetails(int id)
        {
            LotViewModel model = _lotService.GetLotEntity(id).ToMvcLot();
            return View(model);
        }

        [ChildActionOnly]
        public PartialViewResult GetCommentsList(int lotId)
        {
            IEnumerable<CommentViewModel> comments = _commentService.GetAllCommentEntitiesByLotId(lotId).Select(c=>c.ToMvcComment()).OrderBy(c => c.Date);
            CommentListViewModel model = new CommentListViewModel {Comments=comments, LotId=lotId};
            return PartialView(model);
        }

        [AjaxAuthorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetCommentsList(CommentListViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserEntity currentUser = _userService.GetUserByEmail(User.Identity.Name);
                CommentEntity newComment = new CommentEntity { LotId = model.LotId, Text = model.Text, Date = DateTime.Now, UserId=currentUser.Id };
                _commentService.CreateComment(newComment);
                if (!Request.IsAjaxRequest())
                {
                    return RedirectToAction("LotDetails", new { id = model.LotId });
                }
                else
                {
                    model.Comments = _commentService.GetAllCommentEntitiesByLotId(model.LotId).Select(c => c.ToMvcComment()).OrderBy(c => c.Date);                   
                    return PartialView(model);
                }
            }
            if (!Request.IsAjaxRequest())
            {
                return RedirectToAction("LotDetails", new { id = model.LotId });
            }
            else
            {
                model.Comments = _commentService.GetAllCommentEntitiesByLotId(model.LotId).Select(c => c.ToMvcComment()).OrderBy(c => c.Date);
                return PartialView(model);
            }
        }


        [ChildActionOnly]
        public PartialViewResult GetBidsList(int lotId)
        {
            IEnumerable<BidViewModel> bids = _bidService.GetAllBidEntitiesByLotId(lotId).Select(b => b.ToMvcBid()).OrderByDescending(b => b.Price);
            BidListViewModel model = new BidListViewModel { Bids = bids, LotId = lotId, Price=_lotService.GetLotEntity(lotId).ToMvcLot().CurrentPrice+1};
            return PartialView(model);
        }


        [AjaxAuthorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetBidsList(BidListViewModel model)
        {
            LotEntity currentLot=_lotService.GetLotEntity((int)model.LotId);
            string currentUserEmail = currentLot.User.Email;
            decimal currentPrice = currentLot.LastPrice ?? currentLot.StartPrice;
            if (currentUserEmail == User.Identity.Name)
            {
                ModelState.AddModelError("", "You can not add bid for your own lot");
            }
            else if ((model.Price <= currentPrice))
	        {
                ModelState.AddModelError("", string.Format("Your bid must be higher than the last bet {0} byn ", currentPrice));
	        }
            else if (ModelState.IsValid)
            {
                BidEntity newBid = new BidEntity {Price=model.Price, LotId=model.LotId, UserId=_userService.GetUserByEmail(User.Identity.Name).Id, Date=DateTime.Now };
                if (_bidService.TryCreateBid(newBid, currentLot))
                {
                    currentLot.LastPrice = newBid.Price;
                    _lotService.UpdateLot(currentLot);
                }
                if (!Request.IsAjaxRequest())
                {
                    return RedirectToAction("LotDetails", new { id = model.LotId });
                }
                else
                {
                    model.Bids = _bidService.GetAllBidEntitiesByLotId(model.LotId).Select(b => b.ToMvcBid()).OrderByDescending(b => b.Price);
                    return PartialView(model);
                }
            }
            if (!Request.IsAjaxRequest())
            {
                return RedirectToAction("LotDetails", new { id = model.LotId });
            }
            else
            {
                model.Bids = _bidService.GetAllBidEntitiesByLotId(model.LotId).Select(b => b.ToMvcBid()).OrderByDescending(b => b.Price);
                return PartialView(model);
            }
        }

        public FileContentResult GetImage(int id)
        {
            LotEntity lot = _lotService.GetLotEntity(id);
            if (lot.ImageData != null)
            {
                return File(lot.ImageData, lot.ImageType);
            }
            else
            {
                return null;
            }
        }

        [HttpGet]
        [Authorize]
        public ViewResult Create()
        {
            SelectList categoriesList = new SelectList(_categoryService.GetAllCategoryEntities(), "Id", "Name");
            ViewBag.CategoriesList = categoriesList;
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LotViewModel model, int categoryId, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid && image != null)
            {
                model.StartDate = DateTime.Now;
                model.ImageType = image.ContentType;
                model.ImageData = new byte[image.ContentLength];
                model.CategoryId = categoryId;
                model.UserId = _userService.GetUserByEmail(User.Identity.Name).Id;
                image.InputStream.Read(model.ImageData, 0, image.ContentLength);

                _lotService.CreateLot(model.ToBllLot());

                return RedirectToAction("Index", "Lot");
            }
            if (image == null) ModelState.AddModelError("", "Add your image");
            SelectList categoriesList = new SelectList(_categoryService.GetAllCategoryEntities(), "Id", "Name");
            ViewBag.CategoriesList = categoriesList;
            return View(model);
        }


        [HttpGet]
        [Authorize]
        public ActionResult Edit(int lotId)
        {
            LotViewModel model = _lotService.GetLotEntity(lotId).ToMvcLot();
            if (User.IsInRole("User") && model.State == LotStateViewModel.ForSale || model.State == LotStateViewModel.Sold)
            {
                return RedirectToAction("UserPanel", "User");
            }            
            SelectList categoriesList = new SelectList(_categoryService.GetAllCategoryEntities(), "Id", "Name", _categoryService.GetCategoryEntity((int)model.CategoryId));
            ViewBag.CategoriesList = categoriesList;            
            return View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LotViewModel model, int categoryId, HttpPostedFileBase image = null)
        {
            if (User.IsInRole("User") && model.State == LotStateViewModel.ForSale || model.State == LotStateViewModel.Sold)
            {
                return RedirectToAction("UserPanel", "User");
            }
            if (image==null)
            {
                var lot = _lotService.GetLotEntity(model.Id);
                model.ImageData = lot.ImageData;
                model.ImageType = lot.ImageType;
            }
            else
            {
                model.ImageType = image.ContentType;
                model.ImageData = new byte[image.ContentLength];
                image.InputStream.Read(model.ImageData, 0, image.ContentLength);
            }
            if (ModelState.IsValid)
            {
                model.CategoryId = categoryId;
                model.StartDate = model.StartDate + new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                _lotService.UpdateLot(model.ToBllLot());

                return RedirectToAction("AdminPanel", "Admin");
            }
            SelectList categoriesList = new SelectList(_categoryService.GetAllCategoryEntities(), "Id", "Name", _categoryService.GetCategoryEntity((int)model.CategoryId));
            ViewBag.CategoriesList = categoriesList;
            return View(model);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Delete(int lotId, string returnUrl)
        {
            _lotService.DeleteLot(_lotService.GetLotEntity(lotId));
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Lot");
            }
        }
     


    }
}
