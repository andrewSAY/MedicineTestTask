using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MedicineTestTask.Interfaces
{
    public interface IAsyncRepository
    {
        /// <summary>
        /// Предоставляет объект, реализующий операции по добавлнеию, удалению и модификации данных
        /// </summary>
        ICommitter Committer { get; }
        /// <summary>
        /// Возвращает все сущности целевого типа
        /// </summary>
        /// <typeparam name="TEntity">Тип сущности</typeparam>
        /// <returns>Коллекция, содержащая сущности указанного типа</returns>
        Task<IEnumerable<TEntity>> AllAsync<TEntity>() where TEntity : class;
        /// <summary>
        /// Возвращает первую сущность, соответсвующую заданному условию
        /// </summary>
        /// <typeparam name="TEntity">Тип сущности</typeparam>
        /// <param name="condition">Выражение, представляющее условие поиска</param>
        /// <returns>Возвращает сущность заданного типа</returns>
        Task<TEntity> FirstByAsync<TEntity>(Expression<Func<TEntity, bool>> condition) where TEntity : class;
        /// <summary>
        /// Возвращает первую сущность, соответсвующую заданному условию, после приведения к типу TResult со всеми включенными объектами
        /// </summary>
        /// <typeparam name="TResult">Тип к которому должна быть приведена найденная сущность</typeparam>
        /// <param name="condition">Выражение, представляющее условие поиска</param>
        /// <param name="filter">Выражение, задающее преобразование найденной сущнсоти к типу TResult</param>
        /// <param name="includedePropertyNames">Коллекция имен свойств, для которых должны быть загружены значнеия</param>
        /// <returns>Возвращает сущность типа TResult</returns>
        Task<TResult> FirstByAsync<TEntity, TResult>(Expression<Func<TEntity, bool>> condition, Expression<Func<TEntity, TResult>> filter, IEnumerable<string> includedePropertyNames) where TEntity : class;
        /// <summary>
        /// Возвращает первую сущность, соответсвующую заданному условию
        /// </summary>
        /// <param name="condition">Выражение, представляющее условие поиска</param>
        /// <param name="includedePropertyNames">Коллекция имен свойств, для которых должны быть загружены значнеия</param>
        /// <returns>Возвращает сущность</returns>
        Task<TEntity> FirstByAsync<TEntity>(Expression<Func<TEntity, bool>> condition, IEnumerable<string> includedePropertyNames) where TEntity : class;
        /// <summary>
        /// Возвращает все  сущности, соответсвующие заданному условию
        /// </summary>
        /// <param name="condition">Выражение, представляющее условие поиска</param>
        /// <param name="includedePropertyNames">Коллекция имен свойств, для которых должны быть загружены значнеия</param>
        /// <returns>Возвращает коллекцию сущностей </returns>
        Task<IEnumerable<TEntity>> FindByAsync<TEntity>(Expression<Func<TEntity, bool>> condition) where TEntity : class;
        /// <summary>
        /// Возвращает все сущности, соответсвующте заданному условию, после приведения к типу TResult со всеми включенными объектами
        /// </summary>
        /// <typeparam name="TResult">Тип к которому должна быть приведена каждая найденная сущность</typeparam>
        /// <param name="condition">Выражение, представляющее условие поиска</param>
        /// <param name="filter">Выражение, задающее преобразование найденных сущнсотей к типу TResult</param>
        /// <param name="includedePropertyNames">Коллекция имен свойств, для которых должны быть загружены значнеия</param>
        /// <returns>Возвращает коллекцию объектов типа TResult</returns>
        Task<IEnumerable<TResult>> FindByAsync<TEntity, TResult>(Expression<Func<TEntity, bool>> condition, Expression<Func<TEntity, TResult>> filter, IEnumerable<string> includedePropertyNames) where TEntity : class;
        /// <summary>
        /// Возвращает все сущности, соответсвующте заданному условию со всеми включенными объектами
        /// </summary>
        /// <param name="condition">Выражение, представляющее условие поиска</param>
        /// <param name="filter">Выражение, задающее преобразование найденных сущнсотей к типу TResult</param>
        /// <param name="includedePropertyNames">Коллекция имен свойств, для которых должны быть загружены значнеия</param>
        /// <returns>Возвращает коллекцию объектов</returns>
        Task<IEnumerable<TEntity>> FindByAsync<TEntity>(Expression<Func<TEntity, bool>> condition, IEnumerable<string> includedePropertyNames) where TEntity : class;        
    }
}
