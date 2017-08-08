using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MvcPL.ViewModels
{
    public enum LotStateViewModel
    {
        [Description("For sale")]
        ForSale,
        [Description("Unsold")]
        Unsold,
        [Description("Sold")]
        Sold
    }
}