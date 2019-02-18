using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rebel.WS.Data
{
    public interface IRebelRepository
    {
        RebelRegister GetRegister(string rebelName);
        RebelRegister Add(RebelRegister rebelRegister);
    }
}
