using NewspaperMVCProject.EntityLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperMVCProject.Map.Mapping
{
    public class CategoryMap:BaseMap<Category>
    {
        public CategoryMap()
        {
            Property(x => x.Name).HasMaxLength(20).IsRequired();

            HasMany(x => x.Posts).WithRequired(x => x.Category).HasForeignKey(x => x.CategoryId).WillCascadeOnDelete(false);
        }
    }
}
