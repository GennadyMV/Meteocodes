using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Codes.Common;
using NHibernate;
using NHibernate.Criterion;

namespace Codes.Repositories
{
    public class StationRepository : IRepository<Codes.Models.Station>
    {
        #region IRepository<Station> Members

        void IRepository<Codes.Models.Station>.Save(Codes.Models.Station entity)
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

        void IRepository<Codes.Models.Station>.Update(Codes.Models.Station entity)
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

        void IRepository<Codes.Models.Station>.Delete(Codes.Models.Station entity)
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

        Codes.Models.Station IRepository<Codes.Models.Station>.GetById(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.CreateCriteria<Codes.Models.Station>().Add(Restrictions.Eq("ID", id)).UniqueResult<Codes.Models.Station>();
        }

        public Codes.Models.Station GetByCode(int code)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.CreateCriteria<Codes.Models.Station>().Add(Restrictions.Eq("Code", code)).UniqueResult<Codes.Models.Station>();
        }

        IList<Codes.Models.Station> IRepository<Codes.Models.Station>.GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(Codes.Models.Station));
                criteria.AddOrder(Order.Asc("Code"));
                return criteria.List<Codes.Models.Station>();
            }
        }

        #endregion
    }
}
