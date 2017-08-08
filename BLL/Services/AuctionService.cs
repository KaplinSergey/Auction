using System;
using System.Threading;
using BLL.Interfaces.Entities;
using BLL.Mappers;
using BLL.Interfaces.Services;
using DAL.Interfaces.Interfaces;
using System.Net.Mail;
using System.Net;

namespace BLL.Services
{
    public class AuctionService:IAuctionService
    {
        private readonly IUnitOfWork uow;
        private readonly ILotService lotService;
        private Thread _checkingDbThread;
        private TimeSpan _interval;
        private volatile bool _isDbChecking = false;

        public AuctionService(IUnitOfWork uow, ILotService lotService)
        {
            this.uow = uow;
            this.lotService = lotService;
        }
        /// <summary>
        /// Start checking the status lots in the database
        /// </summary>
        /// <param name="interval"></param>
        public void StartDbChecking(int interval)
        {
            _interval = new TimeSpan(0, 0, interval, 0);
            _checkingDbThread = new Thread(CheckDb);
            _checkingDbThread.IsBackground = true;
            _isDbChecking = true;
            _checkingDbThread.Start();
        }
        /// <summary>
        /// Stop checking the status lots in the database
        /// </summary>
        public void StopDbChecking()
        {
            _isDbChecking = false;
            _checkingDbThread.Abort();
        }

        private void CheckDb()
        {
            while (_isDbChecking)
            {
                lotService.CheckAllLotEntities();
                Thread.Sleep(_interval);
            }
        }

    }
}
