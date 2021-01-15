using NewspaperMVCProject.EntityLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperMVCProject.Map.Mapping
{
    public class AppUserMap:BaseMap<AppUser>
    {
        public AppUserMap()
        {
            Property(x => x.FirstName).HasMaxLength(20).HasColumnName("FirstName").IsRequired();
            Property(x => x.LastName).HasMaxLength(20).HasColumnName("LastName").IsRequired();
            Property(x => x.UserName).HasMaxLength(15).HasColumnName("UserName").IsRequired();
            Property(x => x.Password).HasMaxLength(40).HasColumnName("Password").IsRequired();
            Property(x => x.Role).HasColumnName("Role").IsRequired();

            HasMany(x => x.Posts).WithRequired(x => x.AppUser).HasForeignKey(x => x.AppUserId).WillCascadeOnDelete(false);

            HasMany(x => x.Comments).WithRequired(x => x.AppUser).HasForeignKey(x => x.AppUserId).WillCascadeOnDelete(false);

        }

       

    }
}
