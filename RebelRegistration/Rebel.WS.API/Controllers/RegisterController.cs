using Rebel.WS.Application;
using System.Collections.Generic;
using System.Web.Http;

namespace Rebel.WS.API.Controllers
{
    public class RegisterController : ApiController
    {
        private IRebelAppServices _rebelAppServices;

        public RegisterController(IRebelAppServices rebelAppServices)
        {
            _rebelAppServices = rebelAppServices;

        }


        //Api/Register/
        [HttpGet]
        public string GetRebelFromUri([FromBody] List<string> paramsObject)
        {
            return _rebelAppServices.RebelRegister(paramsObject);
        }

    }
}
