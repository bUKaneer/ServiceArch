using AutoMapper;
using FluentValidation;
using ServiceArch.DataInterfaces.Interfaces.Services;
using ServiceArch.DataInterfaces.SettingService.TransferObjects;
using ServiceArch.DataInterfaces.TaskListService.TransferObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;

namespace ServiceArch.DataInterfaces.SettingService
{
    public class Service : ISettingService
    {
        private readonly IValidatorFactory _validatorFactory;
        private readonly IMapper _mapper;
        private readonly Assembly _assembley;
        public Service(IValidatorFactory validatorFactory)
        {
            _assembley = Assembly.Load("ServiceArch.DataProviders");
            _validatorFactory = validatorFactory;
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<TransferObjects.AutoMapperProfile>();
            }).CreateMapper();
        }

        public IEnumerable<string> GetKeys()
        {
            List<string> keys = new List<string>();
            foreach (var type in _assembley.GetTypes())
            {
                if (type.Name == "Settings" && typeof(SettingsBase).IsAssignableFrom(type))
                {
                    var defaults = (SettingsBase)type.GetProperty("Default").GetValue(null, null);
                    foreach (SettingsProperty prop in defaults.Properties)
                    {
                        keys.Add(prop.Name);
                    }
                }
            }
            return keys;
        }

        public SettingDto GetByKey(string key)
        {
            foreach (var type in _assembley.GetTypes())
            {
                if (type.Name == "Settings" && typeof(SettingsBase).IsAssignableFrom(type))
                {
                    var defaults = (SettingsBase)type.GetProperty("Default").GetValue(null, null);
                    foreach (SettingsProperty prop in defaults.Properties)
                    {
                        if (prop.Name.Equals(key)) {
                            return new SettingDto
                            { Key = prop.Name
                            , Value = defaults[prop.Name].ToString()
                            };
                        }
                    }
                }
            }
            throw new Exception("Key not found: " + key);
        }

        public void SaveSetting(SettingDto setting)
        {
            foreach (var type in _assembley.GetTypes())
            {
                if (type.Name == "Settings" && typeof(SettingsBase).IsAssignableFrom(type))
                {
                    var defaults = (SettingsBase)type.GetProperty("Default").GetValue(null, null);
                    foreach (SettingsProperty prop in defaults.Properties)
                    {
                        if (prop.Name.Equals(setting.Key))
                        {
                            defaults[prop.Name] = setting.Value;
                            defaults.Save();
                        }
                    }
                }
            }
        }
    }
}
