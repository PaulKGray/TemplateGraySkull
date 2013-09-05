using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Services.Interfaces;
using Template.Repository.Interfaces;
using Template.Repository;

using Ninject;
using Template.Domain;


namespace Template.Services.Registrations
{
    public static class Services
    {
        public static void RegisterServices(IKernel kernel)
        {
            
            // services

            
            kernel.Bind<IParentService>().To<BudgetService>();
            kernel.Bind<IBudgetPeriodService>().To<BudgetPeriodService>();
            kernel.Bind<IChildItemService>().To<BudgetItemService>();
            kernel.Bind<IBudgetPeriodItemService>().To<BudgetPeriodItemService>();
            kernel.Bind<IStandardItemService>().To<StandardItemService>();

            // repositories

            kernel.Bind(typeof(IRepository<>)).To(typeof(Repository<>));

        }
    }
}
