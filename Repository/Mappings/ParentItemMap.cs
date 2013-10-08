using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain;
using FluentNHibernate.Mapping;

namespace Template.Repository.Mappings
{
    public class ParentItemMap : ClassMap<ParentItem>
    {
        public ParentItemMap()
        {
            Table("ParentItem");
            Id(x => x.ParentItemid);
			Map(x => x.Name);
            Map(x => x.Description);
            HasMany(x => x.ChildItems).Cascade.All().KeyColumns.Add("Parent_Id");
        }
    }
}
