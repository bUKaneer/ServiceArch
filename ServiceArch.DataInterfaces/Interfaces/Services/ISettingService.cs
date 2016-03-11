using ServiceArch.DataInterfaces.SettingService.Entities;
using ServiceArch.DataInterfaces.SettingService.TransferObjects;
using System.Collections.Generic;

namespace ServiceArch.DataInterfaces.Interfaces.Services
{
    public interface ISettingService
    {
        IEnumerable<string> GetKeys();
        SettingDto GetByKey(string key);
        void SaveSetting(SettingDto setting);
    }
}