using Rebel.WS.Data;
using System;
using System.Collections.Generic;

namespace Rebel.WS.Domain
{
    public class RegistrationService : IRegistrationService
    {

        private const string  NODATA_ERROR = "No se han recibido datos";
        private const string CREATE_REGISTER_ERROR = "Error al guardar en la base de datos";
        private const string NUMBER_PARAMS_ERROR = "Insuficientes Parámetros";
        private const string ok = "OK";

        private IRebelRepository _rebelRepository;

        public RegistrationService(IRebelRepository rebelRepository)
        {
            _rebelRepository = rebelRepository;
        }

       

        public string OK { get => ok; }

        public bool isRegister(string rebelName)
        {
            RebelRegister rebel = _rebelRepository.GetRegister(rebelName);

            if (rebel==null) return false;
            return true;
        }



        public string Register(List<string> datosRebeldes)
        {
            if (datosRebeldes == null)
            {
                return NODATA_ERROR;
            }

            if (datosRebeldes.Count < 2)
            {
                return NUMBER_PARAMS_ERROR;
            }

            RebelRegister register = new RebelRegister { name = datosRebeldes[0], planet = datosRebeldes[1], registerdate = DateTime.Today };

            register = _rebelRepository.Add(register);

            if (register == null)
            {
                return CREATE_REGISTER_ERROR;
            }

            return OK;          
        }
    }
}
