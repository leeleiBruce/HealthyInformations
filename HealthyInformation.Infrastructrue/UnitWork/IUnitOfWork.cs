using System;
using System.Data.Entity;

namespace HealthyInformation.Infrastructrue
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }
        void Commit();
        bool IsDisposed { get; }
    }
}
