using BLL.Interfaces.Services;
using MvcPL.Filters;
using MvcPL.Infrastructure.Mappers;
using MvcPL.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MvcPL.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILotService _lotService; 
        private readonly ICategoryService _categoryService;
        private readonly ICommentService _commentService;

        public AdminController(IUserService userService, ICategoryService categoryService, ILotService lotService, ICommentService commentService)
        {
            _userService = userService;
            _categoryService = categoryService;
            _lotService = lotService;
            _commentService = commentService;
        }
        public ActionResult AdminPanel()
        {
            return View();
        }

        public ActionResult UserDetails(int userId)
        {
            UserViewModel model = _userService.GetUserEntity(userId).ToMvcUser();
            return View(model);
        }

        [HttpGet]
        public ActionResult EditComment(int commentId)
        {
            CommentViewModel model = _commentService.GetCommentEntity(commentId).ToMvcComment();
            return View(model);
        }

        [HttpPost]
        public ActionResult EditComment(CommentViewModel model)
        {
            if (ModelState.IsValid)
            {
                _commentService.UpdateComment(model.ToBllComment());
                return RedirectToAction("AdminPanel", "Admin");
            }
            return View(model);
        }


        public ActionResult DeleteComment(int commentId)
        {
            _commentService.DeleteComment(_commentService.GetCommentEntity(commentId));
            return RedirectToAction("AdminPanel", "Admin");
        }



        public ViewResult GetCommentsList(string state)
        {
            IEnumerable<CommentViewModel> model;
            switch (state)
            {
                case ("Last Month"):
                    model = _commentService.GetAllCommentEntities().Select(c => c.ToMvcComment()).Where(c=>c.Date > DateTime.Now-new TimeSpan(30,0,0,0));
                    break;
                case ("Last week"):
                    model = _commentService.GetAllCommentEntities().Select(c => c.ToMvcComment()).Where(c => c.Date > DateTime.Now - new TimeSpan(7, 0, 0, 0));
                    break;
                case ("Last Year"):
                    model = _commentService.GetAllCommentEntities().Select(c => c.ToMvcComment()).Where(c => c.Date > DateTime.Now - new TimeSpan(365, 0, 0, 0));
                    break;
                case("All"):
                default:
                    model = _commentService.GetAllCommentEntities().Select(c => c.ToMvcComment());
                    break;
            }
            ViewBag.TimeSpan = state;
            return View(model);
        }

        public ViewResult GetStatistics(string span)
        {
            StatisticsViewModel model;
            switch (span)
            {
                case ("Last Month"):                   
                    model = _categoryService.GetStatistics(new TimeSpan(30, 0, 0, 0)).ToMvcStatistics();
                    break;
                case ("Last week"):
                    model = _categoryService.GetStatistics(new TimeSpan(7, 0, 0, 0)).ToMvcStatistics();
                    break;
                case ("Last Year"):
                    model = _categoryService.GetStatistics(new TimeSpan(365, 0, 0, 0)).ToMvcStatistics();
                    break;
                case ("All"):
                default:
                    model = _categoryService.GetStatistics(null).ToMvcStatistics();
                    break;
            }
            ViewBag.TimeSpan = span;
            return View(model);
        }

        public ActionResult GetChart(string span, string state)
        {
            StatisticsViewModel model = (StatisticsViewModel)GetStatistics(span).Model;
            switch (state)
            {
                case ("ForSale"):
                    new Chart(width: 200, height: 200).AddTitle("For Sale lots").AddSeries(chartType: "pie", xValue: model.Categories, yValues: model.NumberOfForSaleLots).Write("png");
                    break;
                case ("Sold"):
                    new Chart(width: 200, height: 200).AddTitle("Sold lots").AddSeries(chartType: "pie", xValue: model.Categories, yValues: model.NumberOfSoldLots).Write("png");
                    break;
                case ("Unsold"):
                    new Chart(width: 200, height: 200).AddTitle("Unsold lots").AddSeries(chartType: "pie", xValue: model.Categories, yValues: model.NumberOfUnsoldLots).Write("png");
                    break;
                case ("All"):
                default:
                    new Chart(width: 200, height: 200).AddTitle("All lots").AddSeries(chartType: "pie", xValue: model.Categories, yValues: model.TotalNumberOfLots).Write("png");
                    break;
            }            
            return null;
        }

        public ActionResult GetUsersList()
        {
            IEnumerable<UserInfoViewModel> model=_userService.GetAllUserEntities().Where(u=>u.Role.Name!="Admin").Select(u=>u.ToMvcUserInfo());
            return View(model);
        }


        [HttpGet]
        public ViewResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCategory(CategoryViewModel model, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid && image != null)
            {               
                model.ImageType = image.ContentType;
                model.ImageData = new byte[image.ContentLength];
                image.InputStream.Read(model.ImageData, 0, image.ContentLength);
                _categoryService.CreateCategory(model.ToBllCategory());
                return RedirectToAction("AdminPanel", "Admin");
            }
            if (image == null) ModelState.AddModelError("", "Add your image");
            return View(model);
        }

        public ActionResult GetGridCommentsList()
        {
            return View();
        }

        public string GetCommentsData()
        {
            return JsonConvert.SerializeObject(GetCommentsList("All").Model);
        }



        [HttpPost]
        public void EditGridComment(CommentViewModel model)
        {
            if (ModelState.IsValid)
            {
                _commentService.UpdateComment(model.ToBllComment());
            }
        }

        [HttpPost]
        public void DeleteGridComment(int id)
        {
            _commentService.DeleteComment(_commentService.GetCommentEntity(id));
        }
    }
}
