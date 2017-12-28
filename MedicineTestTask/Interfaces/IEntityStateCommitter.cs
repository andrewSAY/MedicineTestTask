using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicineTestTask.Interfaces
{
    public interface IEntityStateCommitter
    {
        void Add<TEntity>(TEntity entity) where TEntity : class;
        void Add<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        void Update<TEntity>(TEntity entity) where TEntity : class;
        void Update<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        void Remove<TEntity>(TEntity entity) where TEntity : class;
        void Remove<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        int CommitState();
        Task<int> CommitStateAsync();
    }
}
