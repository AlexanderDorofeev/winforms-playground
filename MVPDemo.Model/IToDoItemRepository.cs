using System.Reflection.Metadata;
using System.Threading;
using System.Threading.Tasks;
using MVPDemo.Model;

namespace MVPDemo.Model
{
    public interface IToDoItemRepository
    {
        Task<TodoItem[]> GetAllAsync(CancellationToken cancellationToken);

        ValueTask<TodoItem> GetByIdAsync(int id, CancellationToken cancellationToken);
        
        void Add(TodoItem item);
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}