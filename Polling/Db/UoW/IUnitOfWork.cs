using System;
using Polling.Repositories;

namespace Polling.Db.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        int Commit();
    }
}