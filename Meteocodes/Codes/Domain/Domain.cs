using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using System.Web;
using System.Runtime.Remoting.Messaging;

namespace Codes.Domain
{
    public static class Domain
    {
        private const string sessionKey = "NHib.SessionKey";
        private static ISessionFactory sessionFactory;

        public static ISession CurrentSession
        {
            get
            {
                return GetSession(true);
            }
        }

        static Domain()
        {
        }

        public static void Init()
        {
            Configuration cfg = new Configuration();
            cfg.Configure("hibernate.cfg.xml");

//            cfg.AddAssembly(typeof(Codes.Meteocode).Assembly);

            NHibernate.Tool.hbm2ddl.SchemaUpdate schemaUpdate
                = new NHibernate.Tool.hbm2ddl.SchemaUpdate(cfg);
            schemaUpdate.Execute(true, true);

            sessionFactory = cfg.BuildSessionFactory();
        }

        public static void Close()
        {
            ISession currentSession = GetSession(false);

            if (currentSession != null)
            {
                currentSession.Close();
            }
        }

        private static ISession GetSession(bool getNewIfNotExists)
        {
            ISession currentSession;

            {
                currentSession = CallContext.GetData(sessionKey) as ISession;

                if (currentSession == null && getNewIfNotExists)
                {
                    currentSession = sessionFactory.OpenSession();
                    CallContext.SetData(sessionKey, currentSession);
                }
            }

            return currentSession;
        }
    }
}
