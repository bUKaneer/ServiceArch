using FluentValidation;
using ServiceArch.DataInterfaces.TaskListService.Entities;
using System;

namespace ServiceArch.Common.DataInterfaces.TaskListService.Validation
{
    public class TaskValidator : AbstractValidator<Task>
    {
        public TaskValidator()
        {
            RuleFor(tl => tl.Id).NotEmpty().NotEqual(Guid.Empty);
            RuleFor(tl => tl.Description).NotEmpty();
        }
    }
}
