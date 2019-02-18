using Rebel.WS.Data.Repositorios;
using Rebel.WS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pruebas
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> listaOk = new List<string>
            {
                "nombre","planeta"
            };


            MockRebelRepository repository = new MockRebelRepository();

            RegistrationService registrationService = new RegistrationService( repository);

            string result = registrationService.Register(listaOk);
        }
    }
}
