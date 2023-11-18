using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2.BL
{
    public class PromedioFinal
    {

        public static double CalcularLab(double lab1, double lab2, double lab3)
        {
            double laboratorio = 0.4 * ((lab1 + lab2 + lab3) / 3);
            return laboratorio;
        }

        public static double calcularParcial(double parcial1, double parcial2, double parcial3)
        {
            double parcial = 0.6 * ((parcial1 + parcial2 + parcial3) / 3);
            return parcial;
        }
        public static double calcularNotaFinal(double lab1, double lab2, double lab3,
                                               double parcial1, double parcial2, double parcial3)
        {
            double notaFinal = 0.4 * ((lab1 + lab2 + lab3) / 3) + 0.6 * ((parcial1 + parcial2 + parcial3) / 3);
            return notaFinal;
        }
    }
}
