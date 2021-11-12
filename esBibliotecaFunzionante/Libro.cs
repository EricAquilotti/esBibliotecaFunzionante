using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esBibliotecaFunzionante
{
    public class Libro
    {
        private string _autore;
        private string _titolo;
        private DateTime _dataPubblicazione;
        private string _editore;
        private int _numeroPagine;

        public Libro(string autore, string titolo, DateTime dataPubblicazione, string editore, int numeroPagine)
        {
            Autore = autore;
            Titolo = titolo;
            DataPubblicazione = dataPubblicazione;
            Editore = editore;
            NumeroPagine = numeroPagine;
        }

        public string Autore { get => _autore; set => _autore = string.IsNullOrEmpty(value) ? throw new Exception("Autore non valido") : value; }
        public string Titolo { get => _titolo; set => _titolo = string.IsNullOrEmpty(value) ? throw new Exception("Titolo non valido") : value; }
        public DateTime DataPubblicazione { get => _dataPubblicazione; set => _dataPubblicazione = DateTime.Now < value ? throw new Exception("Data non valida") : value; }
        public string Editore { get => _editore; set => _editore = string.IsNullOrEmpty(value) ? throw new Exception("Editore non valido") : value; }
        public int NumeroPagine { get => _numeroPagine; set => _numeroPagine = value <= 0 ? throw new Exception("Numero pagine non valido") : value; }

        public int ReadingTime
        {
            get
            {
                if (NumeroPagine < 100)
                    return 1;
                if (NumeroPagine <= 200)
                    return 2;
                return NumeroPagine / 10 + 1; //+1 perchè nel testo c'è scritto che deve essere maggiore di 2
            }
        }

        public override string ToString()
        {
            return $"Titolo: {Titolo}\nAutore: {Autore}\nData di pubblicazione: {DataPubblicazione}\nEditore: {Editore}\nNumero pagine: {NumeroPagine}";
        }
    }
}
