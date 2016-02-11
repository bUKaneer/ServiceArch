using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ServiceArch.Api.FluentValidation
{
    public class AutofacValidationFactory : IValidatorFactory
    {
        public IValidator GetValidator(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            return GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IValidator<>).MakeGenericType(type)) as IValidator;
        }

        public IValidator<T> GetValidator<T>()
        {
            return (IValidator<T>)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IValidator<>).MakeGenericType(typeof(T)));
        }
    }
}