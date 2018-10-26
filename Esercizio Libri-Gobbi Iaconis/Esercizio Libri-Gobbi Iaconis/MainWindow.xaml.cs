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
            XDocument xmlLibri = XDocument.Parse(File.ReadAllText(txt_Path.Text, System.Text.Encoding.UTF8), LoadOptions.None);

            IEnumerable<string> titles = from libri in xmlLibri.Elements("Biblioteca").Elements("wiride")
                                         select libri.Element("titolo").Value;

            lstElenco.Items.Clear();
            if (titles.Count() == 0)
            {
                MessageBox.Show("Nessun libro presente");
            }
            else
            {
                foreach (string titoli in titles)
                    lstElenco.Items.Add(titoli);
            }   
        }

        private void btnTitoli_Click(object sender, RoutedEventArgs e)
        {
            string autore = txtAutore.Text;

            XDocument xmlLibri = XDocument.Parse(File.ReadAllText(txt_Path.Text, System.Text.Encoding.UTF8), LoadOptions.None);

            IEnumerable<string> titles = from libri in xmlLibri.Elements("Biblioteca").Elements("wiride")
                                         where (libri.Element("autore").Element("nome").Value/*.ToLower()*/ + " " + (string)libri.Element("autore").Element("cognome")).ToLower().Contains(autore.ToLower())///*.ToLower()*/ == autore/*.ToLower()*/
                                         select libri.Element("titolo").Value;

            lstElenco.Items.Clear();

            if (titles.Count() == 0)
            {
                MessageBox.Show("Nessun risultato per la ricerca: \"" + "autore" + "\"");
            }
            else
            {
                foreach (string titoli in titles)
                    lstElenco.Items.Add(titoli);
            }
        }

        private void btnCopie_Click(object sender, RoutedEventArgs e)
        {
            string libro = txtLibro.Text;

            XDocument xmlLibri = XDocument.Parse(File.ReadAllText(txt_Path.Text, System.Text.Encoding.UTF8), LoadOptions.None);

            IEnumerable<string> books = from libri in xmlLibri.Elements("Biblioteca").Elements("wiride")
                                         where (libri.Element("titolo").Value).ToLower() == libro.ToLower()
                                         select libri.Element("titolo").Value;

            if(books.Count() == 0)
            {
                MessageBox.Show("Non è presente nessuna copia del libro " + "\"" + libro + "\"");
            }
            else
            {
                lblCopie.Content = books.Count();
            }
        }

        private void btnGenere_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnLibriShort_Click(object sender, RoutedEventArgs e)
        {
            XDocument newLibri;
            newLibri = XDocument.Load(txt_Path.Text);
            newLibri.Save(txtDestination.Text + "\\librishort.xml");
        }

        private void btnRomanzo_Click(object sender, RoutedEventArgs e)
        {
            int n = 0;

            XDocument xmlLibri = XDocument.Parse(File.ReadAllText(txt_Path.Text, System.Text.Encoding.UTF8), LoadOptions.None);

            IEnumerable<string> romanzo = from libri in xmlLibri.Elements("Biblioteca").Elements("wiride")
                                          where (string)libri.Element("genere") == "romanzo"
                                          select libri.Element("titolo").Value;

            lstElenco.Items.Clear();
            foreach (string numero in romanzo)
                n++;

            if(n == 0)
            {
                MessageBox.Show("Nessun risultato per la ricerca dei romanzi");
            }

            lblTitRom.Content = n.ToString();
        }

        private void btnDeleteAbstract_Click(object sender, RoutedEventArgs e)
        {
            //XDocument newLibri;
            //newLibri = XDocument.Load(txt_Path.Text);
            //newLibri.Root.>Element().Where().FirstOrDefault().Remove(); //non completo
            //MessageBox.Show("tag abstract eliminato. DELETE!");
            //newLibri.Save(txt_Path.Text); //probabilmente sbagliato SCUSA :(
            
        }
    }
}
