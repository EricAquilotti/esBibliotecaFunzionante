using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esBibliotecaFunzionante
{
    public class Biblioteca
    {
        private string _nome;
        private string _indirizzo;
        private DateTime _dataApertura, _dataChiusura;
        private List<Libro> _libri;

        public Biblioteca(string nome, string indirizzo, DateTime dataApertura, DateTime dataChiusura)
        {
            Nome = nome;
            Indirizzo = indirizzo;
            DataApertura = dataApertura;
            DataChiusura = dataChiusura;
            Libri = new List<Libro>();
        }

        public string Nome { get => _nome; set => _nome = string.IsNullOrEmpty(value) ? throw new Exception("Nome non corretto") : value; }
        public string Indirizzo { get => _indirizzo; set => _indirizzo = string.IsNullOrEmpty(value) ? throw new Exception("Indirizzo non corretto") : value; }
        public DateTime DataApertura { get => _dataApertura; set => _dataApertura = value; }
        public DateTime DataChiusura { get => _dataChiusura; set => _dataChiusura = DataApertura > value ? throw new Exception("Data chiusura non corretta") : value; }
        public List<Libro> Libri { get => _libri; set => _libri = value; }
        public int NLibri => Libri.Count;

        public void AggiungiLibro(Libro l)
        {
            Libri.Add(l);
        }

        public List<Libro> Cerca(bool titolo, bool autore, string s)
        {
            List<Libro> libri = new List<Libro>();
            foreach (Libro l in Libri)
            {
                if ((titolo && l.Titolo.Contains(s)) || (autore && l.Autore.Contains(s)))
                {
                    libri.Add(l);
                }
            }
            return libri;
        }
    }
}
