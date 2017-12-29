using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicineTestTask.Interfaces
{
    public interface ICommitter
    {
        /// <summary>
        /// Добавляет к контексту новую сущность заданного типа
        /// </summary>
        /// <typeparam name="TEntity">Тип сущности</typeparam>
        /// <param name="entity">Сущность</param>
        void Add<TEntity>(TEntity entity) where TEntity : class;
        /// <summary>
        /// Добавляет к контексту коллекцию новцых сущностей заданного типа
        /// </summary>
        /// <typeparam name="TEntity">Тип сущности</typeparam>
        /// <param name="entities">Сущности</param>
        void Add<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        /// <summary>
        /// Помечает сущность как изменненую
        /// </summary>
        /// <typeparam name="TEntity">Тип сущности</typeparam>
        /// <param name="entity">Сущность</param>
        void Update<TEntity>(TEntity entity) where TEntity : class;
        /// <summary>
        /// Помечает коллекцию сущностей как изменненные
        /// </summary>
        /// <typeparam name="TEntity">Тип сущности</typeparam>
        /// <param name="entities">Сущности</param>
        void Update<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        /// <summary>
        /// Помечает сущность на удаление
        /// </summary>
        /// <typeparam name="TEntity">Тип сущности</typeparam>
        /// <param name="entity">Сущность</param>
        void Remove<TEntity>(TEntity entity) where TEntity : class;
        /// <summary>
        /// Помечает коллекцию сущностей на удаление
        /// </summary>
        /// <typeparam name="TEntity">Тип сущности</typeparam>
        /// <param name="entities">Сущности</param>
        void Remove<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        /// <summary>
        /// Сохраняет изменения в источнике данных
        /// </summary>
        /// <returns>Количество задейстованных строк</returns>
        int CommitState();
        /// <summary>
        /// Сохраняет изменения в источнике данных асинхронно
        /// </summary>
        /// <returns>Количество задейстованных строк</returns>
        Task<int> CommitStateAsync();
    }
}
