namespace Points.DataAccess.Facades
{
    public interface IDataAccessFacade<TEntity>
    {
        void Create(DataAccessRequest<TEntity> request);
        TEntity Read(DataAccessRequest<TEntity> request);
        void Update(DataAccessRequest<TEntity> request);
        void Delete(DataAccessRequest<TEntity> request);
    }
}