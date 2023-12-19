using System;
using System.Collections.Generic;

namespace DL
{
    public partial class Libro
    {
        public int IdLibro { get; set; }
        public string Titulo { get; set; } = null!;
        public string Volumen { get; set; } = null!;
        public int IdUbicacion { get; set; }

        public virtual Ubicacion IdUbicacionNavigation { get; set; } = null!;
    }
}
