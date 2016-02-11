using ServiceArch.Api.Models.TaskListService;
using ServiceArch.DataInterfaces.Interfaces.Services;
using ServiceArch.DataInterfaces.TaskListService.TransferObjects;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace ServiceArch.Api.Controllers
{
    [RoutePrefix("TaskList")]
    public class TaskListController : ApiController
    {
        readonly ITaskListService _taskListService;

        public TaskListController(ITaskListService taskListService)
        {
            _taskListService = taskListService;
        }

        [Route("Create")]
        [HttpPost]
        public TaskListDto Create(TaskListCreate model)
        {
            return _taskListService.TaskListCreate(model.Name, model.Description);
        }

        [Route("GetById")]
        [HttpPost]
        public TaskListDto GetById(Guid id)
        {
            return _taskListService.TaskListGetById(id);
        }

        [Route("GetAll")]
        [HttpGet]
        public IEnumerable<TaskListDto> GetAll()
        {
            return _taskListService.TaskListGetAll();
        }

        [Route("Delete")]
        [HttpPost]
        public void Delete(TaskListDelete model)
        {
            _taskListService.TaskListDelete(model.Id);
        }

        [Route("ItemCreate")]
        [HttpPost]
        public TaskDto ItemCreate(TaskListItemCreate model)
        {
            return _taskListService.TaskListItemCreate(model.ListId, model.Description);
        }

        [Route("ItemUpdate")]
        [HttpPost]
        public void ItemUpdate(TaskListItemUpdate model)
        {
            _taskListService.TaskListItemUpdate(model.ListId, model.ItemId, model.Description, model.IsCompleted);
        }

        [Route("ItemDelete")]
        [HttpPost]
        public void ItemDelete(TaskListItemDelete model)
        {
            _taskListService.TaskListItemDelete(model.ItemId);
        }
    }
}
