using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using Ninject;

namespace Template.Controllers.Actionfilters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class TransactionAttribute : ActionFilterAttribute
    {

        private readonly ITransaction _currentTransaction;
        private readonly ISession _NHibernateSession;

        [Inject]
        public TransactionAttribute(ISession nhibernateSession)
        {
            if (nhibernateSession == null) { throw new NullReferenceException("NHibernateSession can not be null"); }
            _NHibernateSession = nhibernateSession;
            _currentTransaction = _NHibernateSession.BeginTransaction();
        }

        public TransactionAttribute()
        {

        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _currentTransaction.Begin();
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (_currentTransaction.IsActive)
            {
                if (filterContext.Exception == null)
                {
                    _currentTransaction.Commit();
                }
                else
                {
                    _currentTransaction.Rollback();
                }
            }
        }
    }
}