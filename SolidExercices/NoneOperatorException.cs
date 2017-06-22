using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidExercices
{
    public class NoneOperatorException : Exception
    {
        public NoneOperatorException() : base("Il n'y a aucun opérateur dans la chaine")
        {

        }
    }
}
