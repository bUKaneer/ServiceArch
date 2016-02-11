using System;

namespace ServiceArch.Api.Models.TaskListService
{
    public class TaskListItemCreate
    {
        public Guid ListId { get; set; }
        public string Description { get; set; }
    }
}