using System.Collections.Generic;
using MessagerApi.Business.Models;

namespace MessagerApi.DAL.Repository
{
    public abstract class RepositoryBase<T> where T : ModelBase
    {
        protected DataContext _context;
        public RepositoryBase(DataContext context)
        {
            _context = context;
        }

        public abstract IEnumerable<T> Get(int limit);
        public abstract T GetById(int id);
        public abstract void Insert(T model);
    }
}