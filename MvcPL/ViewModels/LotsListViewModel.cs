using System;
using System.Collections.Generic;


namespace MvcPL.ViewModels
{
    public class LotsListViewModel
    {
        public IEnumerable<LotViewModel> Lots { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
        public string CurrentSearchString { get; set; }
    }
}