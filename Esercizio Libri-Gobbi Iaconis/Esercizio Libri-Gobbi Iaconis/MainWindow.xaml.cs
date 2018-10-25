using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;

namespace Esercizio_Libri_Gobbi_Iaconis
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Converti_Click(object sender, RoutedEventArgs e)
        {
            XDocument newLibri;

            //Conversione del documento
            newLibri = Convertitore.Converti(txt_Path.Text);

            //Salvataggio sul nuovo documento
            //newLibri.Save(Indirizzo nuovo)
        }

        private void btnElenco_Click(object sender, RoutedEventArgs e)
        {
            XDocument xmlLibri = XDocument.Parse(File.ReadAllText(@"C:\Users\enrico.gobbi\Desktop\Esercizio-Libri\libri.xml", System.Text.Encoding.UTF8), LoadOptions.None);

            IEnumerable<string> titles = from libri in xmlLibri.Elements("Biblioteca").Elements("wiride")
                                         select libri.Element("titolo").Value; //element?

            lstElenco.Items.Clear();
            foreach (string titoli in titles)
                lstElenco.Items.Add(titoli);
        }

        private void btnTitoli_Click(object sender, RoutedEventArgs e)
        {
            string autore = txtAutore.Text;

            XDocument xmlLibri = XDocument.Parse(File.ReadAllText(@"C:\Users\enrico.gobbi\Desktop\Esercizio-Libri\libri.xml", System.Text.Encoding.UTF8), LoadOptions.None);

            //Mettere a posto
            IEnumerable<string> titles = from libri in xmlLibri.Elements("Biblioteca").Elements("wiride")
                                         where (string)libri.Element("autore").Element("nome").Value/*.ToLower()*/ + " " + (string)libri.Element("autore").Element("cognome")/*.ToLower()*/ == autore/*.ToLower()*/
                                         select libri.Element("titolo").Value;

            lstElenco.Items.Clear();
            foreach (string titoli in titles)
                lstElenco.Items.Add(titoli);
        }

        private void btnCopie_Click(object sender, RoutedEventArgs e)
        {
            string libro = txtLibro.Text;
        }

        private void btnGenere_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnLibriShort_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRomanzo_Click(object sender, RoutedEventArgs e)
        {
            int n = 0;

            XDocument xmlLibri = XDocument.Parse(File.ReadAllText(@"C:\Users\enrico.gobbi\Desktop\Esercizio-Libri\libri.xml", System.Text.Encoding.UTF8), LoadOptions.None);

            IEnumerable<string> romanzo = from libri in xmlLibri.Elements("Biblioteca").Elements("wiride")
                                          where (string)libri.Element("genere") == "romanzo"
                                          select libri.Element("titolo").Value;

            lstElenco.Items.Clear();
            foreach (string numero in romanzo)
                n++;

            lblTitRom.Content = n.ToString();
        }
    }
}
