using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPL.ViewModels
{
    public class StatisticsViewModel
    {
        public IList<string> Categories { get; set; }
        public IList<int> TotalNumberOfLots { get; set; }
        public IList<int> NumberOfForSaleLots { get; set; }
        public IList<int> NumberOfSoldLots { get; set; }
        public IList<int> NumberOfUnsoldLots { get; set; }

    }
}