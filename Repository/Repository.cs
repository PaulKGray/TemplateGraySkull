using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using Template.Repository.Interfaces;
using System.Linq.Expressions;

namespace Template.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ISession _session;

        public Repository(ISession session)
        {
            _session = session;
        }

        public T Add(T entity)
        {
            _session.Save(entity);
            return entity;
        }

        public IList<T> Add(IList<T> items)
        {
            foreach (T item in items)
            {
                _session.Save(item);
            }
            return items;
        }

        public bool Update(T entity)
        {
            _session.Update(entity);
            return true;
        }

        public bool Delete(T entity)
        {
            _session.Delete(entity);
            return true;
        }

        public bool Delete(IList<T> entities)
        {
            foreach (T entity in entities)
            {
                _session.Delete(entity);
            }
            return true;
        }



        public T FindBy(int id)
        {
            return _session.Get<T>(id);
        }

        public IList<T> FindAll()
        {
            return _session
                   .CreateCriteria<T>()
                    .List<T>();
        }

        public IList<T> FindAll(Expression<Func<T, bool>> criteria)
        {
            return _session
                .QueryOver<T>()
                .Where(criteria)
                .List();
        }

        public T Find(Expression<Func<T, bool>> criteria)
        {
            return _session
                .QueryOver<T>()
                .Where(criteria)
                .SingleOrDefault();
        }




				
		}
}
