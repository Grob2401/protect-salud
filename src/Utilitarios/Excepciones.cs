using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class MyExcepcion:Exception
    {
        public MyExcepcion(string msn): base(msn)
        { 
        }
    }
}
