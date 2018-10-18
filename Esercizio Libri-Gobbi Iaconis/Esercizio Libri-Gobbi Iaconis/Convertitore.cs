using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Esercizio_Libri_Gobbi_Iaconis
{
    static class Convertitore
    {
        public static XDocument Converti(string path)
        {
            XDocument newDoc = null;

            XDocument libriDoc = XDocument.Load(@path);

            //Ricerca dei vari campi all'interno del file XML libri.xml

            return newDoc;
        }
    }
}
