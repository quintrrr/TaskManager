using TaskManager.DataAccess.Models;

namespace TaskManager.DataAccess.Interfaces
{
    public interface ITaskRepository
    {
        Task AddAsync(TaskItem task);

        Task DeleteAsync(Guid id);

        Task EditAsync(TaskItem task);

        Task<IEnumerable<TaskItem>> GetAllAsync();
    }
}
