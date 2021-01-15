using NewspaperMVCProject.EntityLayer.Entities.Interface;
using NewspaperMVCProject.EntityLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperMVCProject.EntityLayer.Entities.Concrete
{
    public class BaseEntity : IBaseEntity<int>
    {
        public int Id { get ; set; }
        private DateTime _createDate = DateTime.Now;
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }

        public DateTime? UpdateDate { get; set; } // "?" sebebi nullable olması gerektiğindendir.
        public DateTime? PassiveDate { get; set; }

        private Status _status = Status.Active;
        public Status Status { get => _status; set => _status = value; }
    }
}
