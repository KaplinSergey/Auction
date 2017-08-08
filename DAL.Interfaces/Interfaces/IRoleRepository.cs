using DAL.Interfaces.DTO;

namespace DAL.Interfaces.Interfaces
{
    public interface IRoleRepository : IRepository<DalRole>
    {
        DalRole GetRoleByName(string name);
    }
}
