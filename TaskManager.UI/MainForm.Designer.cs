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
            btnEdit = new Button();
            Description = new DataGridViewTextBoxColumn();
            IsDone = new DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)gridTasks).BeginInit();
            SuspendLayout();
            // 
            // btnAddTask
            // 
            btnAddTask.Location = new Point(483, 22);
            btnAddTask.Name = "btnAddTask";
            btnAddTask.Size = new Size(99, 45);
            btnAddTask.TabIndex = 0;
            btnAddTask.Text = "Добавить";
            btnAddTask.UseVisualStyleBackColor = true;
            btnAddTask.Click += BtnAddTask_Click;
            // 
            // btnDeleteTask
            // 
            btnDeleteTask.Location = new Point(588, 22);
            btnDeleteTask.Name = "btnDeleteTask";
            btnDeleteTask.Size = new Size(93, 45);
            btnDeleteTask.TabIndex = 1;
            btnDeleteTask.Text = "Удалить";
            btnDeleteTask.UseVisualStyleBackColor = true;
            btnDeleteTask.Click += BtnDeleteTask_Click;
            // 
            // gridTasks
            // 
            gridTasks.AllowUserToAddRows = false;
            gridTasks.AllowUserToDeleteRows = false;
            gridTasks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridTasks.Columns.AddRange(new DataGridViewColumn[] { Description, IsDone });
            gridTasks.Location = new Point(12, 85);
            gridTasks.Name = "gridTasks";
            gridTasks.Size = new Size(776, 353);
            gridTasks.TabIndex = 2;
            gridTasks.CellValueChanged += GridTasks_CellValueChanged;
            gridTasks.CurrentCellDirtyStateChanged += GridTasks_CurrentCellDirtyStateChanged;
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
            // btnEdit
            // 
            btnEdit.Location = new Point(687, 22);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(101, 45);
            btnEdit.TabIndex = 4;
            btnEdit.Text = "Редактировать";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += BtnEdit_Click;
            // 
            // Description
            // 
            Description.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Description.HeaderText = "Описание задачи";
            Description.Name = "Description";
            Description.ReadOnly = true;
            Description.Resizable = DataGridViewTriState.False;
            // 
            // IsDone
            // 
            IsDone.HeaderText = "Статус выполнения";
            IsDone.Name = "IsDone";
            IsDone.Resizable = DataGridViewTriState.False;
            IsDone.Width = 90;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnEdit);
            Controls.Add(taskDescription);
            Controls.Add(gridTasks);
            Controls.Add(btnDeleteTask);
            Controls.Add(btnAddTask);
            MaximumSize = new Size(816, 489);
            MinimizeBox = false;
            MinimumSize = new Size(816, 489);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)gridTasks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAddTask;
        private Button btnDeleteTask;
        private DataGridView gridTasks;
        private TextBox taskDescription;
        private Button btnEdit;
        private DataGridViewTextBoxColumn Description;
        private DataGridViewCheckBoxColumn IsDone;
    }
}