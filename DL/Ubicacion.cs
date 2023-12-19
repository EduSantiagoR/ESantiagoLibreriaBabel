using System;
using System.Collections.Generic;

namespace DL
{
    public partial class Ubicacion
    {
        public Ubicacion()
        {
            Libros = new HashSet<Libro>();
        }

        public int IdUbicacion { get; set; }
        public string Estante { get; set; } = null!;
        public string Sala { get; set; } = null!;
        public string Librero { get; set; } = null!;
        public string Posicion { get; set; } = null!;

        public virtual ICollection<Libro> Libros { get; set; }
    }
}
