using System.Collections.Generic;

namespace BLL.Interfaces.Entities
{
    public class RoleEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<UserEntity> Users { get; set; }
    }
}
