using System.Collections.Generic;

namespace BLL.Interfaces.Entities
{
    public class StatisticsEntity
    {
        public StatisticsEntity()
        {
            Categories = new List<string>();
            TotalNumberOfLots = new List<int>();
            NumberOfForSaleLots = new List<int>();
            NumberOfSoldLots = new List<int>();
            NumberOfUnsoldLots = new List<int>();
        }
        public List<string> Categories { get; set; }
        public List<int> TotalNumberOfLots { get; set; }
        public List<int> NumberOfForSaleLots { get; set; }
        public List<int> NumberOfSoldLots { get; set; }
        public List<int> NumberOfUnsoldLots { get; set; }
    }
}
