using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLib.Entitys
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid id { get; set; }
        //public int id { get; set; }//neste projeto estaremos usando o Guid no lugar do int

        private DateTime? _createAt;

        public DateTime? CreateAt 
        {
            get { return _createAt; }
            set { _createAt = value == null ? DateTime.UtcNow : value; }
        }

        public DateTime? UpdateAt { get; set; }

    }
}
