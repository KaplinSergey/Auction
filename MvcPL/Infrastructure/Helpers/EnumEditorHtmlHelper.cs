using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace MvcPL.Infrastructure.Helpers
{
    public static class EnumEditorHtmlHelper
    {
        public static MvcHtmlString DropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmHelper,
            Expression<Func<TModel, TProperty>> expression) where TModel : class
        {
            TProperty value = htmHelper.ViewData.Model == null
                ? default(TProperty)
                : expression.Compile()(htmHelper.ViewData.Model);
            string selected = value == null ? String.Empty : value.ToString();
            return htmHelper.DropDownListFor(expression, CreateSelectList(expression.ReturnType, selected));
        }
        public static MvcHtmlString DropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmHelper,
            Expression<Func<TModel, TProperty>> expression, object htmlAttributes) where TModel : class
        {
            TProperty value = htmHelper.ViewData.Model == null
                ? default(TProperty)
                : expression.Compile()(htmHelper.ViewData.Model);
            string selected = value == null ? String.Empty : value.ToString();
            return htmHelper.DropDownListFor(expression, CreateSelectList(expression.ReturnType, selected), htmlAttributes);
        }

        private static IEnumerable<SelectListItem> CreateSelectList(Type enumType, string selectedItem)
        {
            return (from object item in Enum.GetValues(enumType)
                    let fi = enumType.GetField(item.ToString())
                    let attribute = fi.GetCustomAttributes(typeof(DescriptionAttribute), true).FirstOrDefault()
                    let title = attribute == null ? item.ToString() : ((DescriptionAttribute)attribute).Description
                    select new SelectListItem
                    {
                        Value = item.ToString(),
                        Text = title,
                        Selected = selectedItem == item.ToString()
                    }).ToList();
        }
    }
}