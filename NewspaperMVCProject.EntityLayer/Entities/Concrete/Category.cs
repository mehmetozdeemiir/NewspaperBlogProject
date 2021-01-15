using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperMVCProject.EntityLayer.Entities.Concrete
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }

        public virtual List<Post> Posts { get; set; }

    }
}
