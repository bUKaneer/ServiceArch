using FluentValidation;
using ServiceArch.DataInterfaces.TaskListService.Entities;
using System;

namespace ServiceArch.DataInterfaces.TaskListService.Validation
{
    public class TaskListValidator : AbstractValidator<TaskList>
    {
        public TaskListValidator()
        {
            RuleFor(tl => tl.Id).NotEmpty().NotEqual(Guid.Empty);
            RuleFor(tl => tl.Name).NotEmpty();
            RuleFor(tl => tl.Description).NotEmpty();
        }
    }
}