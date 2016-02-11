using System;

namespace ServiceArch.Api.Models.TaskListService
{
    public class TaskListItemUpdate
    {
        public Guid ListId { get; set; } 
        public Guid ItemId { get; set; } 
        public string Description { get; set; } 
        public bool IsCompleted { get; set; }
    }

    public class TaskListItemDelete
    {
        public Guid ItemId { get; set; }
    }
}