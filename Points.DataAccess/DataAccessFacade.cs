using System.Xml.Linq;

namespace Points.DataAccess.Facades
{
    public class DataAccessFacade<TEntity> : IDataAccessFacade<TEntity>
    {
        private readonly List<TEntity> _data;
        public DataAccessFacade()
        {
            _data = new List<TEntity> (10);
        }
        public TEntity Read(DataAccessRequest<TEntity> request)
        {
           return _data.FirstOrDefault(x => x.Equals(request.Data));
        }
        public void Create(DataAccessRequest<TEntity> request)
        {
            _data.ToList().Add (request.Data);
        }
        public void Update(DataAccessRequest<TEntity> request)
        { 

        }

        public void Delete(DataAccessRequest<TEntity> request)
        {
            _data.Remove(request.Data);
        }
    }
}