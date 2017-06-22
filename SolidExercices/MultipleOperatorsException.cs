using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidExercices
{
    public class MultipleOperatorsException : Exception
    {
        public MultipleOperatorsException() : base("Il y a plusieurs opérateurs dans la chaine")
        {
            
        }
        
    }
}
