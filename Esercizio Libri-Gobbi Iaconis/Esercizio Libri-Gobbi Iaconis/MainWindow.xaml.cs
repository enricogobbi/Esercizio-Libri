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

        private void btnElenco_Click(object sender, RoutedEventArgs e)
        {
            XDocument xmlLibri = XDocument.Parse(File.ReadAllText(@"C:\Users\enrico.gobbi\Desktop\Esercizio-Libri\libri.xml", System.Text.Encoding.UTF8), LoadOptions.None); //da aggiungere percorso

            IEnumerable<string> titles =    from libri in xmlLibri.Descendants("wiride")
                                            select libri.Element("titolo").Value; //element?

            foreach (string titoli in titles)
                lstElenco.Items.Add(titoli);
        }

        private void btnTitoli_Click(object sender, RoutedEventArgs e)
        {
            XDocument newAutori;
            newAutori = XDocument.Load(txtAutore.Text);
            lstElenco.Items.Clear();
            lstElenco.Items.Add("gigi");//non completo
        }

        private void btnCopie_Click(object sender, RoutedEventArgs e)
        {
            string libro = txtLibro.Text;
            
            //IEnumerable<>
        }

        private void btnGenere_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLibriShort_Click(object sender, RoutedEventArgs e)
        {
            XDocument newLibri;
            newLibri = XDocument.Load(txt_Path.Text);
            newLibri.Save(txtDestination.Text+"\\librishort.xml");
        }

        private void btnDeleteAbstract_Click(object sender, RoutedEventArgs e)
        {
            XDocument newLibri;
            newLibri = XDocument.Load(txt_Path.Text);
            newLibri.Root.> Elements().Where().FirstOrDefault().Remove(); //non completo
            MessageBox.Show("tag abstract eliminato. DELETE!");
        }
    }
}
