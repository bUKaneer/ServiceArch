using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiceArch.DataInterfaces.TaskListService.TransferObjects
{
    public class TaskListDto
    {
        public Guid Id { get; set; }

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

        public IList<TaskDto> Tasks { get; set; }
    }
}
