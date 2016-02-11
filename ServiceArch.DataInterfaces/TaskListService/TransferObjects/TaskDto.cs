using System;

namespace ServiceArch.DataInterfaces.TaskListService.TransferObjects
{
    public class TaskDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }
        public Guid TaskListId { get; set; }
    }
}
