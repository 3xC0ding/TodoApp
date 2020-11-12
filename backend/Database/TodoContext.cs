using Microsoft.EntityFrameworkCore;
using TodoApp.Models;

namespace TodoApp.Database
{
    public class TodoContext : DbContext
    {
        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="ops">Options</param>
        public TodoContext(DbContextOptions<TodoContext> ops):base(ops){}
        #endregion

        #region Db Sets
        public DbSet<Todo> Todos { get; set;}
        #endregion
    }
}