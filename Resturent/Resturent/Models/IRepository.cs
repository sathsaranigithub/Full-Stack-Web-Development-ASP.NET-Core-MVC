using System.Linq.Expressions;

namespace Resturent.Models

{
    // Generic repository interface for database operations
    // <T> means this interface can be used for any entity type (like Product, Category, etc.)
    // 'where T : class' ensures that T must be a reference type (a class)
    public interface IRepository<T> where T : class
    {
        // Asynchronous method to get all records from the database.
        // Example: Get all products, categories, etc.
        //
        // Why use async?
        // ✅ It allows the program to continue running other tasks (like UI updates)
        //    while waiting for the database to respond.
        // ✅ Prevents the application from “freezing” or becoming unresponsive.
        Task<IEnumerable<T>> GetAllAsync();

        // Asynchronous method to get all items by a specific ID or property.
        // Example: Get all products that belong to a certain CategoryId.
        // 'TKey' is a generic key type (int, string, etc.)
        // 'propertyName' specifies the property to match.
        // 'QueryOptions' can be used to include related data or filters.
        Task<IEnumerable<T>> GetAllByIdAsync<TKey>(TKey id, string propertyName, QueryOptions<T> options);

        // Asynchronous method to get a single entity by its ID.
        // Example: Get one product by its ProductId.
        Task<T> GetByIdAsync(int id, QueryOptions<T> options);

        // Asynchronous method to add a new entity (record) to the database.
        // Example: Add a new Product.
        Task AddAsync(T entity);

        // Asynchronous method to update an existing entity.
        // Example: Update product details.
        Task UpdateAsync(T entity);

        // Asynchronous method to delete an entity by its ID.
        // Example: Delete a product from the database.
        Task DeleteAsync(int id);
    }
}
