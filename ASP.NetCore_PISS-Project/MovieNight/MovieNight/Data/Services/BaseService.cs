using MovieNight.Data;
using System.Threading.Tasks;

namespace MovieNight.Repositories
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private ApplicationDbContext db;

        public ApplicationDbContext Db 
        {
            set
            {
                db = value;
            }
            get
            {
                return db;
            }
        }

        public  void Add(TEntity entity)
        {
             Db.Add<TEntity>(entity);
             Db.SaveChanges();

        }

        public void Remove(TEntity entity)
        {
            Db.Remove<TEntity>(entity);
            Db.SaveChanges();
        }

    }
}
