using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain;
using FluentNHibernate.Mapping;

namespace Template.Repository.Mappings
{
    class ParentItemMap : ClassMap<ParentItem>
    {
        public ParentItemMap()
        {
            Table("ParentItem");
            Id(x => x.ParentItemid);
						Map(x => x.Name);
            HasMany(x=>x.ChildItems).Cascade.All();
        }
    }
}
