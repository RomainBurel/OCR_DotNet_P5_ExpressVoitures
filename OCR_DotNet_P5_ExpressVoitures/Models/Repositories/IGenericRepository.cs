namespace OCR_DotNet_P5_ExpressVoitures.Models.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);

        IEnumerable<T> GetAll();

        void Add(T entity);

        void Remove(T entity);

        void Update(T entity);

        void SaveChanges();
    }
}
