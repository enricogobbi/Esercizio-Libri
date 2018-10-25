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
            XDocument xmlLibri = XDocument.Parse(File.ReadAllText(@".....", System.Text.Encoding.UTF8), LoadOptions.None); //da aggiungere percorso

            IEnumerable<string> titles = from libri in xmlLibri.Descendants("wiride")
                                        where libri.Element("barcode").Value == "M-FKB0GR01"
                                        select libri.Element("titolo").Element("").Value; //element?

            foreach (string titoli in titles)
                MessageBox.Show(titoli);
        }

        private void btnTitoli_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("TEST");
        }

        private void btnCopie_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnGenere_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLibriShort_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
