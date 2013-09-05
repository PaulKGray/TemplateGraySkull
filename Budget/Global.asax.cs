using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Template
{

    //http://blog.bobcravens.com/2010/06/the-repository-pattern-with-linq-to-fluent-nhibernate-and-mysql/
     
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }

        private void MvcApplication_EndRequest(object sender, System.EventArgs e)
        {
            if (Context.Items.Contains(Template.Services.Registrations.NHibernateModule.SESSION_KEY))
            {
                NHibernate.ISession Session = (NHibernate.ISession)Context.Items[Services.Registrations.NHibernateModule.SESSION_KEY];
                Session.Dispose();
                Context.Items[Services.Registrations.NHibernateModule.SESSION_KEY] = null;
            }
        }
    }




}