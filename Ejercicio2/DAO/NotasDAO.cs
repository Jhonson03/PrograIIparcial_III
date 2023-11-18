using Ejercicio2.Data;
using Ejercicio2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2.DAO
{
    public class NotasDAO
    {
        RegistroContext db = new RegistroContext();

        public Notas Notaindivi(int Id)
        {
            var buscar = db.Notas.FirstOrDefault(x => x.id == Id);
            return buscar;
        }

        public List<Notas> ViewNota()
        {
            return db.Notas.ToList();
        }

        public void CreateNota(Notas nota)
        {
            try
            {
                Notas notas = new Notas();

                notas.id = nota.id;
                notas.estudiante = nota.estudiante;
                notas.parciales = nota.parciales;
                notas.laboratorio = nota.laboratorio;
                notas.final = nota.final;

                db.Add(notas);
                db.SaveChanges();

                Console.WriteLine($"La nota de {notas.estudiante} ha sido guardada con exito");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar \nDetalles: {ex}");
            }
        }

        public void UpdateNota(Notas nota, int Lector)
        {
            try {
                var buscar = Notaindivi(nota.id);

                if (buscar == null)
                {
                    Console.WriteLine("El id no existe");
                }
                else
                {
                    if (Lector == 1)
                    {
                        buscar.estudiante = nota.estudiante;
                    }
                    else if (Lector == 2)
                    {
                        buscar.parciales = nota.parciales;
                    }
                    else if (Lector == 3)
                    {
                        buscar.laboratorio = nota.laboratorio;
                    }
                    else if (Lector == 4)
                    {
                        buscar.final = nota.final;
                    }
                    db.Update(nota);
                    db.SaveChanges();
                    Console.WriteLine($"Ha sido actualizado con exito");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar \nDetalles: {ex}");
            }
        }

        public string DeleteNota(int Id)
        {
            var buscar = Notaindivi(Id);

            if (buscar == null)
            {
                return "El estudiante no existe";
            }
            else
            {
                string respuesta;
                do
                {
                    Console.WriteLine("¿Desea eliminar este estudiante? (S/N)");
                    respuesta = Console.ReadLine();

                    if (respuesta.Equals("S", StringComparison.OrdinalIgnoreCase))
                    {
                        db.Notas.Remove(buscar);
                        db.SaveChanges();
                        return "\nEliminación exitosa";
                    }
                    else if (!respuesta.Equals("N", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Respuesta no válida. Por favor, ingrese 'S' para confirmar o 'N' para cancelar.");
                    }
                } while (!respuesta.Equals("S", StringComparison.OrdinalIgnoreCase) && !respuesta.Equals("N", StringComparison.OrdinalIgnoreCase));
            }
            return string.Empty; // En caso de no retornar otro valor
        }

    }
}

