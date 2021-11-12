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
using System.Windows.Shapes;

namespace esBibliotecaFunzionante
{
    /// <summary>
    /// Logica di interazione per WindowBiblioteca.xaml
    /// </summary>
    public partial class WindowBiblioteca : Window
    {
        private Biblioteca _biblioteca;
        public WindowBiblioteca(Biblioteca biblioteca)
        {
            InitializeComponent();
            _biblioteca = biblioteca;
            lbl_intestazione.Content = lbl_intestazione.Content.ToString() + biblioteca.Nome;
            RiempiListaESvuotaTxt();
        }
        private void RiempiListaESvuotaTxt()
        {
            lst_libri.ItemsSource = null;
            lst_libri.ItemsSource = _biblioteca.Libri;
            txt_autore.Text = null;
            txt_cerca.Text = null;
            txt_dataPubblicazione.Text = null;
            txt_editore.Text = null;
            txt_nPagine.Text = null;
            txt_titolo.Text = null;
        }

        private void btn_aggiungi_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _biblioteca.AggiungiLibro(new Libro(txt_titolo.Text, txt_autore.Text, DateTime.Parse(txt_dataPubblicazione.Text), txt_editore.Text, int.Parse(txt_nPagine.Text)));
                RiempiListaESvuotaTxt();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRORE", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btn_cerca_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lst_libri.ItemsSource = null;
                lst_libri.ItemsSource = _biblioteca.Cerca((bool)chk_titolo.IsChecked, (bool)chk_autore.IsChecked, txt_cerca.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRORE", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
