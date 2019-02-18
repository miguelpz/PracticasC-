using System;
using System.Linq;

namespace Rebel.WS.Data
{
    public class RebelRepository:IRebelRepository
    {
        public RebelEntitiesDB dbRebel = new RebelEntitiesDB();
        
        //Guardar registro creado para posterior verificación por el servicio.
        RebelRegister regCreated;


        public RebelRegister GetRegister(string rebelName)
        {
            return dbRebel.RebelRegister.Where(r => r.name.Equals(rebelName)).FirstOrDefault();
        }


        public RebelRegister Add(RebelRegister rebelRegister)
        {
            // Comprobar el registro guardado en db, tiene una fecha válida.
            try
            {
                DateTime date = DateTime.Parse(rebelRegister.registerdate.ToString());
            }
            catch(Exception ex)
            {
                throw new Exception("El registro debe tener una fecha valida",ex);
            }


            try
            {
                regCreated = dbRebel.RebelRegister.Add(rebelRegister);
                dbRebel.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception("Error al crear el registro", ex);
            }
            
            return regCreated;
        }
    }
}
