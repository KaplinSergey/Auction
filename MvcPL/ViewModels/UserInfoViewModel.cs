using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPL.ViewModels
{
    public class UserInfoViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public int NumberOfForSaleLots { get; set; }
        public int NumberOfSoldLots { get; set; }
        public int NumberOfUnsoldLots { get; set; }
        public int NumberOfBids { get; set; }
        public int NumberOfPurchases { get; set; }
    }
}