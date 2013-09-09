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
            
            kernel.Bind<IParentItemService>().To<ParentItemService>();
            kernel.Bind<IChildItemService>().To<ChildItemService>();

            // repositories

            kernel.Bind(typeof(IRepository<>)).To(typeof(Repository<>));

        }
    }
}
