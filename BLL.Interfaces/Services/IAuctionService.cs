using System.Collections.Generic;
using BLL.Interfaces.Entities;

namespace BLL.Interfaces.Services
{
    public interface IAuctionService
    {
        void StartDbChecking(int interval);
        void StopDbChecking();
    }
}
