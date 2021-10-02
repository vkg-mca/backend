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
