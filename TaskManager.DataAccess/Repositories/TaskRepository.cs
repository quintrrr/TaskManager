using Microsoft.Data.Sqlite;
using NLog;
using TaskManager.DataAccess.Interfaces;
using TaskManager.DataAccess.Models;

namespace TaskManager.DataAccess.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly string _connectionString;

        public TaskRepository()
        {
            _connectionString = "Data Source=tasks.db";
            EnsureTable();
        }

        private void EnsureTable()
        {
            using var conn = new SqliteConnection(_connectionString);
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS Tasks (
                    Id           TEXT    PRIMARY KEY,
                    Description  TEXT    NOT NULL,
                    IsDone  INTEGER NOT NULL DEFAULT 0
                );";
            cmd.ExecuteNonQuery();
        }

        public async Task<IEnumerable<TaskItem>> GetAllAsync()
        {
            _logger.Info("Загрузка всех задач");
            var list = new List<TaskItem>();

            await using var conn = new SqliteConnection(_connectionString);
            await conn.OpenAsync();
            await using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Id, Description, IsDone FROM Tasks;";

            await using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                list.Add(new TaskItem
                {
                    Id = Guid.Parse(reader.GetString(0)),
                    Description = reader.GetString(1),
                    IsDone = reader.GetInt32(2) == 1
                });
            }
            return list;
        }

        public async Task AddAsync(TaskItem item)
        {
            _logger.Info($"Добавление новой задачи: {item.Description}");
            if (item.Id == Guid.Empty)
                item.Id = Guid.NewGuid();

            await using var conn = new SqliteConnection(_connectionString);
            await conn.OpenAsync();
            await using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                INSERT INTO Tasks (Id, Description, IsDone)
                VALUES ($id, $desc, $done);";
            cmd.Parameters.AddWithValue("$id", item.Id.ToString());
            cmd.Parameters.AddWithValue("$desc", item.Description);
            cmd.Parameters.AddWithValue("$done", item.IsDone ? 1 : 0);

            await cmd.ExecuteNonQueryAsync();
        }

        public async Task EditAsync(TaskItem item)
        {
            _logger.Info($"Изменение задачи {item.Id}");
            await using var conn = new SqliteConnection(_connectionString);
            await conn.OpenAsync();
            await using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                UPDATE Tasks
                   SET Description = $desc,
                       IsDone = $done
                 WHERE Id = $id;";
            cmd.Parameters.AddWithValue("$desc", item.Description);
            cmd.Parameters.AddWithValue("$done", item.IsDone ? 1 : 0);
            cmd.Parameters.AddWithValue("$id", item.Id.ToString());

            await cmd.ExecuteNonQueryAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            _logger.Info($"Удаление задачи {id}");

            await using var conn = new SqliteConnection(_connectionString);
            await conn.OpenAsync();

            await using var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM Tasks WHERE Id = $id;";
            cmd.Parameters.AddWithValue("$id", id.ToString());

            await cmd.ExecuteNonQueryAsync();
        }
    }
}
