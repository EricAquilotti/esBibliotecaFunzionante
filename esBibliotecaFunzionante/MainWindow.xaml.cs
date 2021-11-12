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

namespace esBibliotecaFunzionante
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Biblioteca _biblioteca;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_creaBiblioteca_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _biblioteca = new Biblioteca(txt_nome.Text, txt_indirizzo.Text, DateTime.Parse(txt_dataApertura.Text), DateTime.Parse(txt_dataChiusura.Text));
                WindowBiblioteca wndBiblioteca = new WindowBiblioteca(_biblioteca);
                wndBiblioteca.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRORE", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
