using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Codes.Common;
using NHibernate;
using NHibernate.Criterion;

namespace Codes.Repositories
{
        public class MeasurementRepository : IRepository<Codes.Models.Measurement>
        {
            #region IRepository<Measurement> Members

            void IRepository<Codes.Models.Measurement>.Save(Codes.Models.Measurement entity)
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

            void IRepository<Codes.Models.Measurement>.Update(Codes.Models.Measurement entity)
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

            void IRepository<Codes.Models.Measurement>.Delete(Codes.Models.Measurement entity)
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

            Codes.Models.Measurement IRepository<Codes.Models.Measurement>.GetById(int id)
            {
                using (ISession session = NHibernateHelper.OpenSession())
                    return session.CreateCriteria<Codes.Models.Measurement>().Add(Restrictions.Eq("ID", id)).UniqueResult<Codes.Models.Measurement>();
            }

            public Codes.Models.Measurement GetByCode(int code)
            {
                using (ISession session = NHibernateHelper.OpenSession())
                    return session.CreateCriteria<Codes.Models.Measurement>().Add(Restrictions.Eq("Code", code)).UniqueResult<Codes.Models.Measurement>();
            }

            IList<Codes.Models.Measurement> IRepository<Codes.Models.Measurement>.GetAll()
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    ICriteria criteria = session.CreateCriteria(typeof(Codes.Models.Measurement));
                    criteria.AddOrder(Order.Desc("ID"));
                    return criteria.List<Codes.Models.Measurement>();
                }
            }

            #endregion
        }
    
}
