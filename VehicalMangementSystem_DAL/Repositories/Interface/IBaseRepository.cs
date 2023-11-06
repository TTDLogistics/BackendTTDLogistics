namespace EmployeeMangementSystem_DAL.Repositories.Interface;
    public interface IBaseRepository<T>:IDisposable where T : class
    {
        T Add(T t);
        Task<T> AddAsync(T t);
        Task<IEnumerable<T>> AddAsync(IList<T> t);
        void Delete(T t);
        Task DeleteAsync(T t);

        T Get(int id);
        T Get(Expression<Func<T, bool>> match);


        Task<T> GetAsync(string id);
        Task<T> GetAsyncById(int id);
        Task<T> GetAsync(Expression<Func<T, bool>> match);

        IQueryable<T> GetBy(Expression<Func<T, bool>> predicate);
        Task<ICollection<T>> GetByAsync(Expression<Func<T, bool>> predicate);

        IQueryable<T> GetAll();
        ICollection<T> GetAll(Expression<Func<T, bool>> match);
        IQueryable<T> GetMany(Expression<Func<T, bool>> match);
        Task<ICollection<T>> GetManyAsync(Expression<Func<T, bool>> match);

        Task<ICollection<T>> GetAllAsync();
        Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> match);

        IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);

        Task<T> GetAllPump(string id1, string id2);
        T Update(T t);
        Task MultiDeleteAsync(IEnumerable<T> entities);
    }

