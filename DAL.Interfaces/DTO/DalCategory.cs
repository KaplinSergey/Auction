using System.Collections.Generic;

namespace DAL.Interfaces.DTO
{
    public class DalCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageType { get; set; }
        public IEnumerable<DalLot> Lots { get; set; }
    }
}
