using System;

namespace Nefe.Service.UnitOfWorks
{
    public interface IUnitOfWork: IDisposable
    {
        void Save();
    }
}
