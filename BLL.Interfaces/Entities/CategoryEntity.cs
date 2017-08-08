using System.Collections.Generic;


namespace BLL.Interfaces.Entities
{
    public class CategoryEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageType { get; set; }
        public IEnumerable<LotEntity> Lots { get; set; }
    }
}
