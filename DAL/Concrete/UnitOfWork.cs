using DAL.Interfaces.Interfaces;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;


namespace DAL.Concrete
{
    public class UnitOfWork:IUnitOfWork
    {
        private bool _isDisposed = false;
        public DbContext Context { get; private set; }
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public UnitOfWork(DbContext context)
        {
            Context = context;
        }       

        public void Commit()
        {
            Context.SaveChanges();                             
        }

        public void Rollback()
        {
            if (Context != null)
            {
                Context.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                _logger.Debug("DAL => Rollback entity framework entries");
            }
        }

        ~UnitOfWork()
        {
            Dispose(true);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool isDisposing)
        {
            if (!_isDisposed)
            {
                if (isDisposing)
                {
                    if (Context != null)
                    {
                        Context.Dispose();
                    }
                }
            }
            _isDisposed = true;
        }

    }
}
