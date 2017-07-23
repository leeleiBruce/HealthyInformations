using System;
using System.Data.Entity;

namespace HealthyInformation.Infrastructrue
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        public DbContext Context
        {
            get { return _context; }
        }

        public event EventHandler Disposed;

        public bool IsDisposed { get; private set; }
        public void Dispose()
        {
            Dispose(true);
        }
        public virtual void Dispose(bool disposing)
        {
            lock (this)
            {
                if (disposing && !IsDisposed)
                {
                    _context.Dispose();
                    var evt = Disposed;
                    if (evt != null) evt(this, EventArgs.Empty);
                    Disposed = null;
                    IsDisposed = true;
                    GC.SuppressFinalize(this);
                }
            }
        }

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
