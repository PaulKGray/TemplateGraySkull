using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain;
using FluentNHibernate.Mapping;

namespace Template.Repository.Mappings
{
    class ChildItemMap : ClassMap<ChildItem>
    {
        public ChildItemMap()
        {
            Table("ChildItem");
            Id(x => x.ChildItemId);
						Map(x => x.Name);
            HasOne(x => x.Parent);

        }
    }
}
