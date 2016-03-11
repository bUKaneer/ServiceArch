using ServiceArch.Api.Models.SettingService;
using ServiceArch.DataInterfaces.Interfaces.Services;
using ServiceArch.DataInterfaces.SettingService.TransferObjects;
using System.Collections.Generic;
using System.Web.Http;

namespace ServiceArch.Api.Controllers
{
    [RoutePrefix("Setting")]
    public class SettingController : ApiController
    {
        readonly ISettingService _service;
        public SettingController(ISettingService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetKeys")]
        public IEnumerable<string> GetKeys()
        {
            return _service.GetKeys();
        }

        [HttpPost]
        [Route("GetByKey")]
        public SettingDto GetByKey(SettingGetByKey model)
        {
            return _service.GetByKey(model.Key);
        }

        [HttpPost]
        [Route("SaveChanges")]
        public void Save(List<SettingDto> model)
        {
            foreach(var setting in model)
            {
                _service.SaveSetting(setting);
            }
        }
    }
}