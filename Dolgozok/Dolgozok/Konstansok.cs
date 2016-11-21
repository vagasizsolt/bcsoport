using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dolgozok
{
    static class Konstansok
    {
        static Form1 form1Elem;
        public static Form1 Form1Elem
        {
            get { return Konstansok.form1Elem; }
            set { Konstansok.form1Elem = value; }
        }

        static Login loginElem;
        public static Login LoginElem
        {
            get { return Konstansok.loginElem; }
            set { Konstansok.loginElem = value; }
        }
    }
}
