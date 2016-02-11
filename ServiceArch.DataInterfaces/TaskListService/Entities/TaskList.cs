using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiceArch.DataInterfaces.TaskListService.Entities
{
    public class TaskList : Entity
    {
        private ICollection<Task> _tasks = new List<Task>();

        public TaskList()
        { }

        public TaskList(Guid id) : base(id)
        { }

        public string Name { get; set; }
        public string Description { get; set; }

        public bool IsComplete
        {
            get { return Tasks.Count == Tasks.Where(t => t.IsComplete).ToList().Count(); }
        }

        public string Status
        {
            get
            {
                if (Tasks.Count == 0) return "New";
                return IsComplete ? "Completed" : "In progress";
            }
        }

        public virtual ICollection<Task> Tasks
        {
            get { return _tasks; }
            set { _tasks = value; }
        }
    }
}
