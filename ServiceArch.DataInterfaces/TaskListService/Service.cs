using AutoMapper;
using FluentValidation;
using ServiceArch.DataInterfaces.Interfaces;
using ServiceArch.DataInterfaces.Interfaces.Services;
using ServiceArch.DataInterfaces.TaskListService.Entities;
using ServiceArch.DataInterfaces.TaskListService.TransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiceArch.DataInterfaces.TaskListService
{
    public class Service : ITaskListService
    {
        private readonly IStorage _storage;
        private readonly IValidatorFactory _validatorFactory;
        private readonly IMapper _mapper;
        public Service(IStorage storage, IValidatorFactory validatorFactory)
        {
            _storage = storage;
            _validatorFactory = validatorFactory;
            _mapper = new MapperConfiguration(cfg => {
                cfg.AddProfile<AutoMapperProfile>();
            }).CreateMapper();
        }

        public TaskListDto TaskListCreate(string name, string description)
        {
            var taskList = new TaskList(Guid.NewGuid()) { Name = name, Description = description };
            _validatorFactory.GetValidator<TaskList>().ValidateAndThrow(taskList);
            using (var dataContext = _storage.DataContext)
            {
                dataContext.GetRepository<TaskList>().Create(taskList);
                dataContext.SaveChanges();
            }
            return _mapper.Map<TaskListDto>(taskList);
        }

        public TaskListDto TaskListGetById(Guid id)
        {
            using (var dataContext = _storage.DataContext)
            {
                return _mapper.Map<TaskListDto>(dataContext.GetRepository<TaskList>()
                    .GetById(id));
            }
        }

        public void TaskListDelete(Guid id)
        {
            using (var dataContext = _storage.DataContext)
            {
                IDataSet<Task> taskRepository = dataContext.GetRepository<Task>();
                foreach (var task in taskRepository.GetAll()
                                        .Where(t => t.TaskList.Id == id)
                                        .ToList())
                {
                    taskRepository.Delete(task.Id);
                }
                dataContext.GetRepository<TaskList>().Delete(id);
                dataContext.SaveChanges();
            }
        }

        public IEnumerable<TaskListDto> TaskListGetAll()
        {
            using (var dataContext = _storage.DataContext)
            {
                return _mapper.Map<List<TaskListDto>>(dataContext
                    .GetRepository<TaskList>()
                    .GetAll()
                    .ToList());
            }
        }

        public TaskDto TaskListItemCreate(Guid listId, string description)
        {
            var task = new Task(Guid.NewGuid())
            {
                Description = description,
                IsComplete = false
            };
            using (var dataContext = _storage.DataContext)
            {
                var repository = dataContext.GetRepository<TaskList>();
                var list = repository.GetAll().Single(l => l.Id == listId);
                list.Tasks.Add(task);
                repository.Update(list);
                dataContext.SaveChanges();
            }
            return _mapper.Map<TaskDto>(task);
        }

        public void TaskListItemUpdate(Guid listId, Guid itemId, string description, bool isComplete)
        {
            using (var dataContext = _storage.DataContext)
            {
                var repository = dataContext.GetRepository<TaskList>();
                var list = repository.GetAll().Single(l => l.Id == listId);
                var item = list.Tasks.Single(t => t.Id == itemId);
                item.Description = description;
                item.IsComplete = isComplete;
                repository.Update(list);
                dataContext.SaveChanges();
            }
        }

        public void TaskListItemDelete(Guid itemId)
        {
            using (var dataContext = _storage.DataContext)
            {
                var repository = dataContext.GetRepository<TaskList>();
                var list = repository.GetAll().Where(l => l.Tasks.Any(t => t.Id == itemId)).Single();
                list.Tasks.Remove(list.Tasks.Single(t => t.Id == itemId));
                repository.Update(list);
                dataContext.SaveChanges();
            }
        }
    }
}
