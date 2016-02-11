using ServiceArch.DataInterfaces.TaskListService.Entities;
using ServiceArch.DataInterfaces.TaskListService.TransferObjects;
using System;
using System.Collections.Generic;

namespace ServiceArch.DataInterfaces.Interfaces.Services
{
    public interface ITaskListService
    {
        TaskListDto TaskListCreate(string name, string description);
        IEnumerable<TaskListDto> TaskListGetAll();
        TaskListDto TaskListGetById(Guid id);
        void TaskListDelete(Guid id);
        TaskDto TaskListItemCreate(Guid listId, string description);
        void TaskListItemUpdate(Guid listId, Guid itemId, string description, bool completed);
        void TaskListItemDelete(Guid itemId);
    }
}