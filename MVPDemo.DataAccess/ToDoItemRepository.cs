using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVPDemo.Model;

namespace MVPDemo.DataAccess
{
    public class ToDoItemRepository : IToDoItemRepository
    {
        private readonly AppDbContext _dbContext;

        public ToDoItemRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public Task<TodoItem[]> GetAllAsync(CancellationToken cancellationToken) => _dbContext.TodoItems.ToArrayAsync(cancellationToken);

        public  ValueTask<TodoItem> GetByIdAsync(int id, CancellationToken cancellationToken) =>_dbContext.TodoItems.FindAsync(new object[] {id},cancellationToken);


        public void Add(TodoItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            _dbContext.Add(item);
        }
        
        public Task SaveChangesAsync(CancellationToken cancellationToken) => _dbContext.SaveChangesAsync(cancellationToken);
    }
}