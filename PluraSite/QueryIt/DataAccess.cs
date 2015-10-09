using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryIt
{
    //Covariance :: A type more derrived than that specified can be used, only works with Delgates and Interfaces and handles RETURNS
    //ContraVariance :: A type less derrived than that specified can be used, only works with Delgates and Interfaces and handles INS
    //Invariant :: Interface supports Read and Write operations but only on the Type initially supplied

    //public interface IRepository<T> : IDisposable  //No out, Invariant, T is the only object that can use it.
    //public interface IRepository<out T> : IDisposable  //Methods must RETURN T they cannot use T.
    //public interface IRepository<T> : IDisposable 
    //{
    //    void Add(T newEntity);
    //    void Delete(T newEntity);

    //    T FindById(int id);

    //    IQueryable<T> FindAll();

    //    int Commit();
    //}

    public interface IReadOnlyRespository<out T> : IDisposable //Covariant
    {
        T FindById(int id);
        IQueryable<T> FindAll();
    }

    //public interface IRepository<T> : IDisposable, IReadOnlyRespository<T>  //Contravariant for Returns, Invariant for inputs
    //{
    //    void Add(T newEntity);
    //    void Delete(T newEntity);
        
    //    int Commit();
    //}

    //public interface IRepository<in T> : IDisposable, IReadOnlyRespository<T>  //Contravariant but conflicting
    //{
    //    void Add(T newEntity);
    //    void Delete(T newEntity);

    //    int Commit();
    //}

    public interface IWriteOnlyRepository<in T> : IDisposable  //Contravariant
    {
        void Add(T newEntity);
        void Delete(T newEntity);
        int Commit();        //Commit left here to follow Write Interface.
    }

    public interface IRepository<T> : IWriteOnlyRepository<T>, IReadOnlyRespository<T>
    {        
    }
    


    public class EmployeeDb : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
    }

    public class SqlRespository<T> : IRepository<T> where T: Person, IEntity        
    {
        private readonly DbContext _ctx;
        private readonly DbSet<T> _set;

        public SqlRespository(DbContext ctx)
        {
            _ctx = ctx;
            _set = _ctx.Set<T>();
        }

        public void Add(T newEntity)
        {
            if (newEntity.IsValid())
            {
                _set.Add(newEntity);
            }
        }

        public void Delete(T newEntity)
        {
            _set.Remove(newEntity);
        }

        public T FindById(int id)
        {
            //T entity = default(T);  //Use default value of T.
            return _set.Find(id);
        }

        public IQueryable<T> FindAll()
        {
            return _set;
        }

        public int Commit()
        {
            return _ctx.SaveChanges();
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}
