namespace TaskManager.UI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnAddTask = new Button();
            btnDeleteTask = new Button();
            gridTasks = new DataGridView();
            taskDescription = new TextBox();
            ((System.ComponentModel.ISupportInitialize)gridTasks).BeginInit();
            SuspendLayout();
            // 
            // btnAddTask
            // 
            btnAddTask.Location = new Point(509, 22);
            btnAddTask.Name = "btnAddTask";
            btnAddTask.Size = new Size(127, 45);
            btnAddTask.TabIndex = 0;
            btnAddTask.Text = "Добавить";
            btnAddTask.UseVisualStyleBackColor = true;
            // 
            // btnDeleteTask
            // 
            btnDeleteTask.Location = new Point(665, 22);
            btnDeleteTask.Name = "btnDeleteTask";
            btnDeleteTask.Size = new Size(123, 45);
            btnDeleteTask.TabIndex = 1;
            btnDeleteTask.Text = "Удалить";
            btnDeleteTask.UseVisualStyleBackColor = true;
            // 
            // gridTasks
            // 
            gridTasks.AllowUserToAddRows = false;
            gridTasks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridTasks.Location = new Point(12, 85);
            gridTasks.Name = "gridTasks";
            gridTasks.Size = new Size(776, 353);
            gridTasks.TabIndex = 2;
            // 
            // taskDescription
            // 
            taskDescription.Location = new Point(12, 22);
            taskDescription.Multiline = true;
            taskDescription.Name = "taskDescription";
            taskDescription.ScrollBars = ScrollBars.Vertical;
            taskDescription.Size = new Size(465, 45);
            taskDescription.TabIndex = 3;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(taskDescription);
            Controls.Add(gridTasks);
            Controls.Add(btnDeleteTask);
            Controls.Add(btnAddTask);
            MaximumSize = new Size(816, 489);
            MinimizeBox = false;
            MinimumSize = new Size(816, 489);
            Name = "MainForm";
            Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)gridTasks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAddTask;
        private Button btnDeleteTask;
        private DataGridView gridTasks;
        private TextBox taskDescription;
    }
}