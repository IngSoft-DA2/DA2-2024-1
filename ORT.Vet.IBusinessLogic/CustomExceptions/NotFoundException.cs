using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORT.Vet.IBusinessLogic.CustomExceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base("No se encontro el perro.") { }
    }
}
