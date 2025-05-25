using Microsoft.VisualBasic;
using TaskManage.Core.Interfaces;
using TaskManager.DataAccess.Models;

namespace TaskManager.UI
{
    public partial class MainForm : Form
    {
        private readonly ITaskService _taskService;

        public MainForm(ITaskService taskService)
        {
            _taskService = taskService;

            InitializeComponent();
            IsDone.DataPropertyName = nameof(TaskItem.IsDone);
            Description.DataPropertyName = nameof(TaskItem.Description);
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await LoadTasksAsync();
        }

        private async Task LoadTasksAsync()
        {
            gridTasks.DataSource = await _taskService.GetAllAsync();
            if (gridTasks.Columns.Contains("Id"))
            {
                gridTasks.Columns["Id"].Visible = false;
            }
        }

        private async void BtnAddTask_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(taskDescription.Text))
            {
                await _taskService.AddAsync(taskDescription.Text);
                await LoadTasksAsync();
                taskDescription.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Введите описание");
            }
        }

        private async void BtnDeleteTask_Click(object sender, EventArgs e)
        {
            if (gridTasks.CurrentRow.DataBoundItem is TaskItem selectedTask)
            {
                await _taskService.DeleteAsync(selectedTask.Id);
                await LoadTasksAsync();
            }
        }

        private async void BtnEdit_Click(object sender, EventArgs e)
        {
            if (gridTasks.CurrentRow.DataBoundItem is TaskItem selectedTask)
            {
                var newDescription = Interaction
                    .InputBox("Изменить задачу", "Редактировать", selectedTask.Description);
                if (!string.IsNullOrWhiteSpace(newDescription))
                {
                    selectedTask.Description = newDescription;
                    await _taskService.EditAsync(selectedTask);
                    await LoadTasksAsync();
                }
            }
        }

        private void GridTasks_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (gridTasks.IsCurrentCellDirty)
            {
                gridTasks.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private async void GridTasks_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || gridTasks.Columns[e.ColumnIndex].Name != "IsDone")
            {
                return;
            }

            if (gridTasks.Rows[e.RowIndex].DataBoundItem is TaskItem selectedTask)
            {
                await _taskService.EditAsync(selectedTask);
                await LoadTasksAsync();
            }
        }
    }
}
