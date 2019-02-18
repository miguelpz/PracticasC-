using System.Collections.Generic;

namespace Rebel.WS.Domain
{
    public interface IRegistrationService
    {
        string Register(List<string> datosRebeldes);
        bool isRegister(string rebelName);
    }   
}
