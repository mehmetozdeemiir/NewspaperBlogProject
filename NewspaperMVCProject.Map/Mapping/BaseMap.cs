using NewspaperMVCProject.EntityLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperMVCProject.Map.Mapping
{
    public class BaseMap<T> : EntityTypeConfiguration<T> where T : BaseEntity
    {
        public BaseMap()
        {
            Property(x => x.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CreateDate).IsRequired(); //Boş geçilemez anlamına gelir "IsRequired()" metodu.
            Property(x => x.UpdateDate).IsOptional();//Nullable olduğu için "IsOptional()" kulandık.
            Property(x => x.PassiveDate).IsOptional();
            Property(x => x.Status).IsRequired();
        }
    }
}
