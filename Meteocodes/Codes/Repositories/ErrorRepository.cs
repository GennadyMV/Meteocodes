using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Codes.Common;
using NHibernate;
using NHibernate.Criterion;

namespace Codes.Repositories
{
    public class ErrorRepository : IRepository<Codes.Models.Error>
    {
        #region IRepository<Error> Members

        void IRepository<Codes.Models.Error>.Save(Codes.Models.Error entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(entity);
                    transaction.Commit();
                }
            }
        }

        void IRepository<Codes.Models.Error>.Update(Codes.Models.Error entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(entity);
                    transaction.Commit();
                }
            }
        }

        void IRepository<Codes.Models.Error>.Delete(Codes.Models.Error entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(entity);
                    transaction.Commit();
                }
            }
        }

        Codes.Models.Error IRepository<Codes.Models.Error>.GetById(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.CreateCriteria<Codes.Models.Error>().Add(Restrictions.Eq("ID", id)).UniqueResult<Codes.Models.Error>();
        }

        public Codes.Models.Error GetByCode(int code)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.CreateCriteria<Codes.Models.Error>().Add(Restrictions.Eq("Code", code)).UniqueResult<Codes.Models.Error>();
        }

        IList<Codes.Models.Error> IRepository<Codes.Models.Error>.GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(Codes.Models.Error));
                criteria.AddOrder(Order.Asc("ID"));
                return criteria.List<Codes.Models.Error>();
            }
        }

        #endregion
    }
}
