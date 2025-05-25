﻿namespace TaskManager.DataAccess.Models
{
    public class TaskItem
    {
        public Guid Id { get; set; }

        public string Description { get; set; } = string.Empty;

        public bool IsDone { get; set; }
    }
}
