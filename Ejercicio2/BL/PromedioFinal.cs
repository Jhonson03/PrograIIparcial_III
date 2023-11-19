using Ejercicio2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2.BL
{
    public class PromedioFinal
    {
        public double CalcularLab(Promedios pro)
        {
            double laboratorio = Math.Round(0.4 * ((pro.lab1 + pro.lab2 + pro.lab3) / 3), 2);
            return laboratorio;
        }

        public double calcularParcial(Promedios pro)
        {
            double parcial = Math.Round(0.6 * ((pro.parcial1 + pro.parcial2 + pro.parcial3) / 3), 2);
            return parcial;
        }
        public double calcularNotaFinal(Promedios pro)
        {
            double notaFinal = Math.Round(CalcularLab(pro) + calcularParcial(pro), 2);
            return notaFinal;
        }

    }
}
