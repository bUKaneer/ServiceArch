using System;

namespace ServiceArch.DataInterfaces.TaskListService.Entities
{
    public class Task : Entity
    {
        public Task()
        { }

        public Task(Guid id)
            : base(id)
        { }

        public string Description { get; set; }
        public bool IsComplete { get; set; }

        public virtual TaskList TaskList { get; set; }
    }


}