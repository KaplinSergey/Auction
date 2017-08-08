using System.Web.Mvc;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Services;
using NLog;
using System;
using Ninject;
using DependencyResolver;

namespace MvcPL.Filters
{
    public class LogExceptionsAttribute : FilterAttribute, IExceptionFilter
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private IKernel kernel;
        
        public void OnException(ExceptionContext filterContext)
        {
            kernel = new StandardKernel();
            kernel.ConfigurateResolverWeb();
            var exceptionService = kernel.Get<IExceptionInformationService>();
            string exceptionMessage = filterContext.Exception.Message;
            string exceptionStackTrace = filterContext.Exception.StackTrace;
            string controllerName = filterContext.RouteData.Values["controller"].ToString();
            string actionName = filterContext.RouteData.Values["action"].ToString();

            _logger.Error("Message: {0}, \nController{1}, \nAction{2}, \nStacktrace: {3}", exceptionMessage, controllerName, actionName, exceptionStackTrace);

            ExceptionInformationEntity exception = new ExceptionInformationEntity
            {
                ExceptionMessage=exceptionMessage,
                StackTrace=exceptionStackTrace,
                ControllerName=controllerName,
                ActionName=actionName,
                Date=DateTime.Now
            };
            exceptionService.CreateExceptionInformation(exception);
            filterContext.Result = filterContext.HttpContext.Response.StatusCode == 404 ? new ViewResult { ViewName = "~/Views/Error/NotFound.cshtml" } : new ViewResult { ViewName = "~/Views/Shared/Error.cshtml" };
            filterContext.ExceptionHandled = true;
        }
    }
}