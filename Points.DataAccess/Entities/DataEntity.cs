using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Points.DataAccess.Entities
{
    public class BaseEntity<TIdentity>
    {
        public TIdentity Id { get; set; }
        public DateTime CreatedAt { get; set; } = new DateTime();
        public DateTime? ModifiedAt { get; set; } = new DateTime();
    }
    //public class BaseEntity<TEntity, TIdentity>
    //{
        //public TIdentity Id { get; set; }
        //public TEntity Data { get; set; }
        //public DateTime CreatedAt { get; set; }
        //public DateTime? ModifiedAt { get; set; }
   // }

    //public class DataEntity<TEntity>
    //{
    //    TEntity Entity { get; set; }

    //}

    //public class EntityIdentity<TIDentity>
    //{
    //    TIDentity Identity { get; set; }
    //}
}
