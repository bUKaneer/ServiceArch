using FluentValidation;
using ServiceArch.DataInterfaces.SettingService.Entities;

namespace ServiceArch.Common.DataInterfaces.SettingService.Validation
{
    public class SettingValidator : AbstractValidator<Setting>
    {
        public SettingValidator()
        {
            RuleFor(tl => tl.Key).NotEmpty();
            RuleFor(tl => tl.Value).NotEmpty();
        }
    }
}
