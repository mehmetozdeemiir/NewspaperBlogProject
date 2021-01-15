using NewspaperMVCProject.EntityLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperMVCProject.Map.Mapping
{
   public class PostMap:BaseMap<Post>
    {
        public PostMap()
        {
            Property(x => x.Header).HasMaxLength(122).IsRequired();
            Property(x => x.Content).HasMaxLength(700).IsRequired();

            HasRequired(x => x.AppUser).WithMany(x => x.Posts).HasForeignKey(x => x.AppUserId).WillCascadeOnDelete(false);
            
            HasMany(x => x.Comments).WithRequired(x => x.Post).HasForeignKey(x => x.PostId).WillCascadeOnDelete(false);
            
            HasRequired(x => x.Category).WithMany(x => x.Posts).HasForeignKey(x => x.CategoryId).WillCascadeOnDelete(false);

        }
    }
}
