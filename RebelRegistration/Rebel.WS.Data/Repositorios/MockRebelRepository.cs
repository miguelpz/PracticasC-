using System;
using System.Collections.Generic;
using System.Linq;

namespace Rebel.WS.Data.Repositorios
{
    public class MockRebelRepository : IRebelRepository
    {
        List<RebelRegister> rebelRegisterList;        
        public bool ForzarFalloCrear { get; set; }

        public MockRebelRepository()
        {
            ForzarFalloCrear = false;

            rebelRegisterList = new List<RebelRegister>
            {
                new RebelRegister { name = "Lucke", planet = "tatuin" }
            };
        }

        // Forzar una excepción al salvar un registro.
        public void ForzarFalloAlCrear()
        {
            ForzarFalloCrear = true;
        }

        public RebelRegister Add(RebelRegister rebelRegister)
        {
            if (ForzarFalloCrear) throw new Exception("Fallo al crear registro");

            rebelRegisterList.Add(rebelRegister);
            return rebelRegister;
        }

        public RebelRegister GetRegister(string rebelName)
        {
            return rebelRegisterList.Where(o => o.name.Equals(rebelName)).FirstOrDefault();
        }
    }
}
