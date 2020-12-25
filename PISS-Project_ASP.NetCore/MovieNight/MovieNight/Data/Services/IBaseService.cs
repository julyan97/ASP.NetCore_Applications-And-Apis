using System.Linq;
using System.Threading.Tasks;

namespace MovieNight.Repositories
{

    public interface IBaseService<TEntity>
    {
        void Add(TEntity entity);
        void Remove(TEntity entity);


    }
}
