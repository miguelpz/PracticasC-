using Rebel.WS.Domain;
using System.Collections.Generic;

namespace Rebel.WS.Application
{
    public class RebelAppServices:IRebelAppServices
    {
        private const string DUPLICATE_ERROR = "Este rebelde ya está registrado";

        private IRegistrationService _registrationService;
        
        public RebelAppServices(IRegistrationService registrationService)
        {
            _registrationService = registrationService;    
        }
        
        public string  RebelRegister (List<string> rebelRegister)
        {
          
            if (_registrationService.isRegister(rebelRegister[0]))
            {
                return DUPLICATE_ERROR;
            }

            return  _registrationService.Register(rebelRegister);
        }        
    }
}
