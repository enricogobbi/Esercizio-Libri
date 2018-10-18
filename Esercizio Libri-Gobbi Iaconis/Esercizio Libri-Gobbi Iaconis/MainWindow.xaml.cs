using System;
using System.Collections.Generic;
using System.Linq;
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

        }

        private void btnTitAut_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLibri_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
