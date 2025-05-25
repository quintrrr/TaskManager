using TaskManage.Core.Interfaces;
using TaskManager.DataAccess.Interfaces;
using TaskManager.DataAccess.Models;

namespace TaskManage.Core.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repo;

        public TaskService(ITaskRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<TaskItem>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task AddAsync(string description)
        {
            var item = new TaskItem { Description = description };
            await _repo.AddAsync(item);
        }

        public async Task EditAsync(TaskItem item)
        {
            await _repo.EditAsync(item);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}
