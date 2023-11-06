namespace EmployeeMangementSystem_DAL.Repositories.Implement;


/// <summary>
/// BaseRepository
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
{
    #region Fields

    private bool _disposed;
    private readonly DbSet<T> _dbSet;
    private readonly EmployeeDbContext _employeeDbContext;

    #endregion Fields

    #region Constructor && Destructors 

    /// <summary>
    /// Initialize a new instance of the <see cref="BaseRepository{T}"/> class.
    /// Constructor
    /// </summary>
    /// <param name="oftDbContext"></param>
    protected BaseRepository(EmployeeDbContext employeeDbContext)
    {
        this._employeeDbContext = employeeDbContext;
        this._dbSet = this._employeeDbContext.Set<T>();
    }

    #endregion Constructor && Destructors

    #region public Methods and operators

    /// <summary>
    /// Add/Insert new record to database.
    /// </summary>
    /// <param name="t"></param>
    /// <returns>T</returns>
    public virtual T Add(T t)
    {
        this._dbSet.Add(t);
        this._employeeDbContext.SaveChanges();
        return t;
    }

    /// <summary>
    /// Add/Insert entity to database with async.
    /// </summary>
    /// <param name="t"></param>
    /// <returns>A <see ></see> </returns>
    public virtual async Task<T> AddAsync(T t)
    {
        await this._dbSet.AddAsync(t);
        await this._employeeDbContext.SaveChangesAsync();
        return t;
    }

    public async Task<IEnumerable<T>> AddAsync(IList<T> ts)
    {
        this._dbSet.AddRangeAsync(ts);
        this._employeeDbContext.SaveChanges();
        return ts as IEnumerable<T>;
    }

    /// <summary>
    /// remove element from db 
    /// </summary>
    /// <param name="t"></param>
    public void Delete(T t)
    {
        this._dbSet.Remove(t);
        this._employeeDbContext.SaveChanges();
    }

    public async Task DeleteAsync(T t)
    {
        _dbSet.Remove(t);
        await this._employeeDbContext.SaveChangesAsync(true);
    }

    public virtual T Get(int id) => _dbSet.Find(id);

    public virtual T Get(Expression<Func<T, bool>> match)
    {
        return _dbSet.AsNoTracking().FirstOrDefault(match);
    }

    public IQueryable<T> GetAll()
    {
        return _dbSet.AsNoTracking();
    }

    public ICollection<T> GetAll(Expression<Func<T, bool>> match)
    {
        throw new NotImplementedException();
    }

    public async Task<ICollection<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> match)
    {
        throw new NotImplementedException();
    }

    public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
    {
        throw new NotImplementedException();
    }

    public async Task<T> GetAsync(string id)
    {
        return await _dbSet.FindAsync(id);
    }
    public async Task<T> GetAllPump(string id1, string id2)
    {
        return await _dbSet.FindAsync(id1, id2);
    }

    public async Task<T> GetAsyncById(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public Task<T> GetAsync(Expression<Func<T, bool>> match)
    {
        throw new NotImplementedException();
    }

    public IQueryable<T> GetBy(Expression<Func<T, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<T>> GetByAsync(Expression<Func<T, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public IQueryable<T> GetMany(Expression<Func<T, bool>> match)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<T>> GetManyAsync(Expression<Func<T, bool>> match)
    {
        throw new NotImplementedException();
    }

    public Task MultiDeleteAsync(IEnumerable<T> entities)
    {
        throw new NotImplementedException();
    }

    public T Update(T t)
    {
        var result = _dbSet.Update(t).Entity;
        _employeeDbContext.SaveChanges();
        return result;

    }
    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    #endregion public Method and Operators

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                this._employeeDbContext.Dispose();
            }
            _disposed = true;
        }
    }
}
