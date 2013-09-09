using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Data;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using NHibernate.Tool.hbm2ddl;
using Ninject;
using Ninject.Activation;
using Ninject.Modules;

namespace Budget.Services.Registrations
{

        public class NHibernateModule : NinjectModule
        {
            public const string SESSION_KEY = "NHibernate.ISession";
            private static ISessionFactory _sessionFactory;


            public override void Load()
            {

                if (_sessionFactory == null) { 
                   _sessionFactory = CreateSessionFactory();

                }

                             
                Bind<ISessionFactory>().ToConstant(_sessionFactory);
                Bind<ISession>().ToMethod(x => GetRequestSession(x));
            }


            private static ISessionFactory CreateSessionFactory()
            {

                return Fluently.Configure()

                    .Database(
                            MsSqlConfiguration.MsSql2008
                            .ConnectionString(c => c.FromConnectionStringWithKey("Budget")))
                    .Mappings(m =>
                    {
                        m.AutoMappings.Add(
                           AutoMap.AssemblyOf<Entity>()
                            //.IgnoreBase<Entity>()
                           .Where(t => t.Namespace == "Modules.Business.Entities")
                           .Where(t => t == typeof(Entity))
                        )
                        .ExportTo("c:\\temp");
                    }
                    )

                    .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                    .BuildSessionFactory();
            }

            private ISession GetRequestSession(IContext ctx) { 
            
                    IDictionary Dict = ReflectiveHttpContext.HttpContextCurrentItems;
                      NHibernate.ISession Session;
                      if (!Dict.Contains(SESSION_KEY))
                      {
                        // Create an NHibernate session for this request
                        Debug.WriteLine("Creating an NHIbernate session");
                        Session = ctx.Kernel.Get<ISessionFactory>().OpenSession();
                        Dict.Add(SESSION_KEY, Session);
                        CurrentSessionContext.Bind(Session);
                      }
                      else
                      {
                        // Re-use the NHibernate session for this request
                        Debug.WriteLine("Re-using the NHibernate session");
                        Session = (NHibernate.ISession)Dict[SESSION_KEY];
                      } 
                      return Session;
                }

            
            }

        }

}
