using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesModeloSegundoParcial
{
    public class CantidadInvalidaException:Exception
    {
        public CantidadInvalidaException():base("Cantidad invalida")
        {

        }


    }
}
