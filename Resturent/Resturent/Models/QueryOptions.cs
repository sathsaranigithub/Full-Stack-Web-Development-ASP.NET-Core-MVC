using System.Linq.Expressions;

namespace Resturent.Models
{
    // The QueryOptions<T> class helps customize database queries.
    // It allows you to specify filtering (Where), sorting (OrderBy),
    // and related entities to include (Includes).
    //
    // <T> is a generic type, meaning this can be used for any model (like Product, Category, etc.)
    public class QueryOptions<T> where T : class
    {
        // Expression<Func<T, Object>> represents a LINQ expression.
        // Example: product => product.Price
        // This tells Entity Framework which property to sort by.
        // 'Expression' lets EF convert your C# code into a SQL command.
        public Expression<Func<T, Object>> OrderBy { get; set; } = null!;

        // Expression<Func<T, bool>> represents a condition (filter).
        // Example: product => product.Price > 100
        // This is used in LINQ 'Where()' clauses to filter results.
        public Expression<Func<T, bool>> Where { get; set; } = null!;

        // Private array to store the names of related entities to include.
        // Example: if you want to include Category when loading a Product.
        private string[] includes = Array.Empty<string>();

        // The Includes property lets you set related entity names as a comma-separated string.
        // Example usage:
        // options.Includes = "Category,OrderItems";
        // It removes spaces and splits the string into an array.
        public string Includes
        {
            set => includes = value.Replace(" ", "").Split(',');
        }

        // Returns the list of included related entity names as an array.
        // Example: ["Category", "OrderItems"]
        public string[] GetIncludes() => includes;

        // Checks if a 'Where' condition has been provided.
        // Returns true if there is a filter condition.
        public bool HasWhere => Where != null;

        // Checks if an 'OrderBy' condition has been provided.
        // Returns true if there is a sorting condition.
        public bool HasOrderBy => OrderBy != null;
    }
}
