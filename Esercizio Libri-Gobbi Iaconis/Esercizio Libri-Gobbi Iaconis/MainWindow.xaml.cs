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
using Microsoft.Win32;

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

        //Bottone per visualizzazione elenco completo
        private void btnElenco_Click(object sender, RoutedEventArgs e)
        {
            XDocument xmlLibri = XDocument.Parse(File.ReadAllText(txt_Path.Text, System.Text.Encoding.UTF8), LoadOptions.None);
            try
            {
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Bottone per visualizzare titoli di un autore
        private void btnTitoli_Click(object sender, RoutedEventArgs e)
        {
            string autore = txtAutore.Text;

            XDocument xmlLibri = XDocument.Parse(File.ReadAllText(txt_Path.Text, System.Text.Encoding.UTF8), LoadOptions.None);
            try
            {
                //Query per ricerca titoli di un certo autore
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Bottone per ricerca numero copie
        private void btnCopie_Click(object sender, RoutedEventArgs e)
        {
            string libro = txtLibro.Text;

            XDocument xmlLibri = XDocument.Parse(File.ReadAllText(txt_Path.Text, System.Text.Encoding.UTF8), LoadOptions.None);
            try
            {
                //Query per ricavare i libri con un determinato titolo per ricercare il numero di copie
                IEnumerable<string> books = from libri in xmlLibri.Elements("Biblioteca").Elements("wiride")
                                            where (libri.Element("titolo").Value).ToLower() == libro.ToLower()
                                            select libri.Element("titolo").Value;

                if (books.Count() == 0)
                {
                    MessageBox.Show("Non è presente nessuna copia del libro " + "\"" + libro + "\"");
                }
                else
                {
                    lblCopie.Content = books.Count();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Bottone per ricerca genere
        private void btnGenere_Click(object sender, RoutedEventArgs e)
        {
            string titLibro = txtLibriGen.Text;
            string newGenere = txtGenere.Text;

            XDocument xmlLibri = XDocument.Parse(File.ReadAllText(txt_Path.Text, System.Text.Encoding.UTF8), LoadOptions.None);
            try
            {
                //Modifica del genere
                xmlLibri.Root.Elements("wiride").Where(x => x.Element("titolo").Value == titLibro).FirstOrDefault().SetElementValue("genere", newGenere);

                MessageBox.Show("Modificato genere del libro \"" + titLibro + "\"");

                xmlLibri.Save(txt_Path.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Bottone per creazione del documento librishort.xml
        private void btnLibriShort_Click(object sender, RoutedEventArgs e)
        {
            XDocument newLibri;
            newLibri = XDocument.Load(txt_Path.Text);

            try
            {
                //Conteggio numero di elementi
                int n = newLibri.Elements("Biblioteca").Elements("wiride").Count();

                //Ciclo che permette di eseguirlo su ogni elemento dl documento
                for (int i = 0; i < n; i++)
                {
                    //Query oer prendere tutti gli elementi
                    IEnumerable<XElement> elementi = from libri in newLibri.Elements("Biblioteca")
                                                     select libri.Element("wiride");

                    //Operazioni fatte su ogni elemento
                    foreach (XElement elemento in elementi)
                    {
                        //Modifica nome tag "wiride" in "libro"
                        elemento.Name = "libro";

                        //Eliminazione del primo elemento usando come condizione where una condizione sempre vera
                        newLibri.Root.Elements().Where(x => x.Value.Contains("")).FirstOrDefault().Remove();

                        //Cancellazione tag su ogni elemento
                        elemento.SetElementValue("codice_dewey", null);
                        elemento.Element("autore").SetElementValue("nome", null);
                        elemento.SetElementValue("genere", null);
                        elemento.SetElementValue("abstract", null);

                        //Aggiunta alla fine dell'elemento appena modificato
                        newLibri.Element("Biblioteca").Add(elemento);

                        //Salvataggio
                        newLibri.Save(txtDestination.Text + "\\librishort.xml");

                        //Utilizzata questa procedura in modo da avere sempre come primo elemento l'elemento successivo da modificare
                    }
                }
                MessageBox.Show("librishort.xml creato");

                //Salvataggio
                newLibri.Save(txtDestination.Text + "\\librishort.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Bottone per ricerca dei romanzi
        private void btnRomanzo_Click(object sender, RoutedEventArgs e)
        {
            int n = 0;

            XDocument xmlLibri = XDocument.Parse(File.ReadAllText(txt_Path.Text, System.Text.Encoding.UTF8), LoadOptions.None);
            try
            {
                //Ricerca di tutti i romanzi
                IEnumerable<string> romanzo = from libri in xmlLibri.Elements("Biblioteca").Elements("wiride")
                                              where (libri.Element("genere")).ToString().Contains("romanzo")
                                              select libri.Element("titolo").Value;

                lstElenco.Items.Clear();
                foreach (string numero in romanzo)
                    n++;

                if (n == 0)
                {
                    MessageBox.Show("Nessun risultato per la ricerca dei romanzi");
                }

                lblTitRom.Content = n.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Bottone per eliminazione del tag abstract
        private void btnDeleteAbstract_Click(object sender, RoutedEventArgs e)
        {
            XDocument newLibri;
            newLibri = XDocument.Load(txt_Path.Text);

            try
            {
                //Conteggio numero di elementi
                int n = newLibri.Elements("Biblioteca").Elements("wiride").Count();

                for (int i = 0; i < 60; i++)
                    newLibri.Root.Elements("wiride").Elements("abstract").Where(x => x.Value.Contains("")).FirstOrDefault().Remove();

                //newLibri.Element("Biblioteca").Element("wiride").SetAttributeValue("abstract", null);

                newLibri.Save(txtDestination.Text + "\\libriNoAbstract.xml");
                MessageBox.Show("tag abstract eliminato");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Bottone per aprire finestra di selezione del documento xml
        private void btn_Sfoglia_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog selezioneFile = new OpenFileDialog();

            if ((bool)selezioneFile.ShowDialog())
                txt_Path.Text = selezioneFile.FileName;
        }
    }
}
