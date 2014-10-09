using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Agathas.Storefront.Infrastructure.Domain;
using Agathas.Storefront.Infrastructure.UnitOfWork;
using Agathas.Storefront.Infrastructure.Querying;

namespace Agathas.Storefront.Repository.NHibernate.Repositories
{    
    public abstract class Repository<T, EntityKey> where T : IAggregateRoot
    {
        private IUnitOfWork _uow;

        public Repository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void Add(T entity)
        {            
            SessionFactory.GetCurrentSession().Save(entity);
        }

        public void Remove(T entity)
        {
            SessionFactory.GetCurrentSession().Delete(entity);
        }

        public void Save(T entity)
        {
            SessionFactory.GetCurrentSession().SaveOrUpdate(entity);
        }

        public T FindBy(EntityKey Id)
        {
            return SessionFactory.GetCurrentSession().Get<T>(Id);
        }    

        public IEnumerable<T> FindAll()
        {
            ICriteria criteriaQuery = SessionFactory.GetCurrentSession().CreateCriteria(typeof(T));
            
            return (List<T>)criteriaQuery.List<T>();
        }

        public IEnumerable<T> FindAll(int index, int count)
        {
            ICriteria criteriaQuery = SessionFactory.GetCurrentSession().CreateCriteria(typeof(T));
            
            return (List<T>)criteriaQuery.SetFetchSize(count).SetFirstResult(index).List<T>();
        }

        public IEnumerable<T> FindBy(Query query)
        {
            ICriteria criteriaQuery = SessionFactory.GetCurrentSession().CreateCriteria(typeof(T));

            AppendCriteria(criteriaQuery);

            query.TranslateIntoNHQuery<T>(criteriaQuery);

            return criteriaQuery.List<T>();
        }

        public IEnumerable<T> FindBy(Query query, int index, int count)
        {
            ICriteria criteriaQuery = SessionFactory.GetCurrentSession().CreateCriteria(typeof(T));

            AppendCriteria(criteriaQuery);

            query.TranslateIntoNHQuery<T>(criteriaQuery);

            return criteriaQuery.SetFetchSize(count).SetFirstResult(index).List<T>();
        }

        public virtual void AppendCriteria(ICriteria criteria)
        {

        }
    }
}
