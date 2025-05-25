using TaskManager.DataAccess.Models;

namespace TaskManage.Core.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskItem>> GetAllAsync();

        Task AddAsync(string description);

        Task DeleteAsync(Guid id);

        Task EditAsync(TaskItem task);
    }
}
