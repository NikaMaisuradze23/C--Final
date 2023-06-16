using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Varianti2
{
    internal class Class1
    {
        private int cvladi;

        public int ChemiTviseba   // property
        {
            get { return cvladi; }   // get method
            set {
                if ((value <= 34) && (value % 6 == 0)) cvladi = value;
            }  
        }

    }
}
