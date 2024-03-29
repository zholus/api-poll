using System;
using Polling.Repositories;

namespace Polling.Db.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IPollRepository Polls { get; }
        IAnswerRepository Answers { get; }
        int Commit();
    }
}