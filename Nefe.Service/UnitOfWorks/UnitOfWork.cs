using System;
using System.Linq;
using System.Transactions;
using Nefe.Domain;
using Nefe.Service.Repository;

namespace Nefe.Service.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NefeDataContext _nefeDataContext;
        private NefeRepository<User> _userRepository;
        private NefeRepository<Role> _roleRepository;
        private NefeRepository<Address> _addressRepository;
        private bool _disposed;

        public UnitOfWork()
        {
            _nefeDataContext = new NefeDataContext(); 
        }

        public NefeDataContext Context
        {
            get
            {
                return _nefeDataContext;
            }
        }

        public NefeRepository<User> UserRepository
        {
            get { return _userRepository ?? (_userRepository = new NefeRepository<User>(_nefeDataContext)); }
        }

        public NefeRepository<Role> RoleRepository
        {
            get { return _roleRepository ?? (_roleRepository = new NefeRepository<Role>(_nefeDataContext)); }
        }

        public NefeRepository<Address> AddressRepository
        {
            get { return _addressRepository ?? (_addressRepository = new NefeRepository<Address>(_nefeDataContext)); }
        }

        public void Save()
        {
            using (var ts = new TransactionScope())
            {
                _nefeDataContext.SaveChanges();
                ts.Complete();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _nefeDataContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
