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
            XDocument newDoc;

            XDocument libriDoc = XDocument.Load(@path);
            newDoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));

            //Query titolo primo libro
            IEnumerable<string> titolo =    from libri in libriDoc.Descendants("wiride")
                                            select libri.Element("titolo").Element("proprio").Value;

            //IEnumerable<string> titolo = from libri in libriDoc.Descendants("wiride")
            //                             where libri.Element("codice_scheda").Value == "M-FKB0GR01"
            //                             select libri.Element("titolo").Element("proprio").Value;

            return newDoc;
        }
    }
}
