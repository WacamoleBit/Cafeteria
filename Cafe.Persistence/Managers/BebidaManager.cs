using Cafe.Model.Cafes;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Persistence.Managers
{
    public class BebidaManager
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public object CrearBebida(Bebida bebida)
        {
            try
            {
                context.Set<Bebida>().Add(bebida);
                context.SaveChanges();

                return ("Bebida creada");
            }
            catch (DbUpdateException e)
            {

                return (e.Data, "Ocurrió un error, pero no te preocupes, lo estamos solucionando");
            }
        }

        public object VerBebidas()
        {
            try
            {
                var listaBebidas = context.Set<Bebida>().ToList();
                return listaBebidas;
            }
            catch (DbUpdateException e)
            {
                return (e.Data, "Ocurrió un error, pero no te preocupes, lo estamos solucionando");
            }
        }
    }
}
