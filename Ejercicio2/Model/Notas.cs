using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2.Model
{
    public class Notas
    {
        public int id { get; set; }
        public string? estudiante { get; set; }
        public double parciales { get; set; }
        public double laboratorio { get; set; }
        public double final { get; set; }
    }
}
