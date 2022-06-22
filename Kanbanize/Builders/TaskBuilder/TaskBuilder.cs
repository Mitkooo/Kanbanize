using Kanbanize.DTOs.KanbanizeTask;
using Kanbanize.Tests;

namespace Kanbanize.Builders.TaskBuilder
{
    public class TaskBuilder
    {
        private KanbanizeTask _task;

        public TaskBuilder()
        {
            _task = new KanbanizeTask();
        }

        public TaskBuilder DefaultTaskWithColumn()
        {
            _task = new KanbanizeTask();
            _task.boardid = "1";
            _task.taskid = "1";
            _task.column = "In Progress";
            return this;
        }

        public TaskBuilder DefaultTaskWithBoardId()
        {
            _task = new KanbanizeTask();
            _task.boardid = "1";
            _task.column = "Requested";
            _task.priority = "High";
            _task.assignee = "Mitaka";
            _task.title = "Test task";
            _task.description = "To do list";
            return this;
        }

        public KanbanizeTask Build()
        {
            return _task;
        }
    }
}
