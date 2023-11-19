
using Ejercicio2.BL;
using Ejercicio2.DAO;
using Ejercicio2.Model;
using System.Runtime.ConstrainedExecution;

Notas notas = new Notas();
Promedios promedios = new Promedios();
NotasDAO db = new NotasDAO();
PromedioFinal logi = new PromedioFinal();

bool vali1 = true;
int idWidth = 9;
int nomWidth = 20;
int parWidth = 15;
int labWidth = 15;
int finalWidth = 9;

Console.WriteLine("\tBienvenido al registro de notas");

while (vali1 == true)
{
    try
    {
        Console.Write("\n\tMenu  \n1- Agregar  \n2- Actualizar  \n3- Eliminar \n4- Ver lista de notas \n5- Salir \n-> ");
        var menu = int.Parse(Console.ReadLine());

        switch (menu)
        {
            case 1:
                Console.WriteLine("\n\tAgregar notas");
                try
                {
                    Console.Write("\nIngrese el nombre del estudiante: ");
                    notas.estudiante = Console.ReadLine();
                    Console.Write("\nIngrese nota del primer laboratorio: ");
                    promedios.lab1 = double.Parse(Console.ReadLine());
                    Console.Write("\nIngrese nota del segundo laboratorio: ");
                    promedios.lab2 = double.Parse(Console.ReadLine());
                    Console.Write("\nIngrese nota del tercer laboratorio: ");
                    promedios.lab3 = double.Parse(Console.ReadLine());
                    Console.Write("\nIngrese nota del primer parcial: ");
                    promedios.parcial1 = double.Parse(Console.ReadLine());
                    Console.Write("\nIngrese nota del segundo parcial: ");
                    promedios.parcial2 = double.Parse(Console.ReadLine());
                    Console.Write("\nIngrese nota del tercer parcial: ");
                    promedios.parcial3 = double.Parse(Console.ReadLine());
                    notas.laboratorio = logi.CalcularLab(promedios);
                    notas.parciales = logi.calcularParcial(promedios);
                    notas.final = logi.calcularNotaFinal(promedios);
                    db.CreateNota(notas);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n\tError \nDetalles: {ex.Message}");
                }
                break;

            case 2:
                try
                {
                    Console.WriteLine("\t\nActualizar notas\n");
                    Console.WriteLine($"\n{"Codigo".PadRight(idWidth)} {"Nombres".PadRight(nomWidth)} {"Laboratorios".PadRight(labWidth)} {"Parciales".PadRight(parWidth)} {"Nota final".PadRight(finalWidth)}");
                    Console.WriteLine(new string('-', idWidth + nomWidth + labWidth + parWidth + finalWidth + 8));

                    foreach (var i in db.ViewNota())
                    {
                        Console.WriteLine($"{i.id.ToString().PadRight(idWidth)} {i.estudiante.PadRight(nomWidth)} {i.laboratorio.ToString().PadRight(labWidth)} {i.parciales.ToString().PadRight(parWidth)} {i.final.ToString().PadRight(finalWidth)}   |");
                    }
                    Console.Write("\nIngrese el codigo que desea actualizar: ");
                    var buscar = db.Notaindivi(int.Parse(Console.ReadLine()));

                    if (buscar == null)
                    {
                        Console.WriteLine("El codigo no existe");
                    }
                    else
                    {
                        Console.Write(@$"
Ingrese el campo que desea actualizar

1- Estudiante 
2- Laboratorio 
3- Parcial 
4- Nota Fina 

-> ");
                        var Lector = int.Parse(Console.ReadLine());
                        switch (Lector)
                        {
                            case 1:
                                Console.Write("Ingrese el estudiante: ");
                                buscar.estudiante = Console.ReadLine();
                                break;

                            case 2:
                                Console.Write("\nIngrese nota del primer laboratorio: ");
                                promedios.lab1 = double.Parse(Console.ReadLine());
                                Console.Write("\nIngrese nota del segundo laboratorio: ");
                                promedios.lab2 = double.Parse(Console.ReadLine());
                                Console.Write("\nIngrese nota del tercer laboratorio: ");
                                promedios.lab3 = double.Parse(Console.ReadLine());
                                buscar.laboratorio = logi.CalcularLab(promedios);
                                buscar.final = Math.Round(buscar.parciales + buscar.laboratorio, 2);
                                break;

                            case 3:
                                Console.Write("\nIngrese nota del primer parcial: ");
                                promedios.parcial1 = double.Parse(Console.ReadLine());
                                Console.Write("\nIngrese nota del segundo parcial: ");
                                promedios.parcial2 = double.Parse(Console.ReadLine());
                                Console.Write("\nIngrese nota del tercer parcial: ");
                                promedios.parcial3 = double.Parse(Console.ReadLine());
                                buscar.parciales = logi.calcularParcial(promedios);
                                buscar.final = Math.Round(buscar.parciales + buscar.laboratorio, 2);
                                break;
                            case 4:
                                Console.Write("\nIngrese nota del primer laboratorio: ");
                                promedios.lab1 = double.Parse(Console.ReadLine());
                                Console.Write("\nIngrese nota del segundo laboratorio: ");
                                promedios.lab2 = double.Parse(Console.ReadLine());
                                Console.Write("\nIngrese nota del tercer laboratorio: ");
                                promedios.lab3 = double.Parse(Console.ReadLine());
                                Console.Write("\nIngrese nota del primer parcial: ");
                                promedios.parcial1 = double.Parse(Console.ReadLine());
                                Console.Write("\nIngrese nota del segundo parcial: ");
                                promedios.parcial2 = double.Parse(Console.ReadLine());
                                Console.Write("\nIngrese nota del tercer parcial: ");
                                promedios.parcial3 = double.Parse(Console.ReadLine());
                                buscar.laboratorio = logi.CalcularLab(promedios);
                                buscar.parciales = logi.calcularParcial(promedios);
                                buscar.final = logi.calcularNotaFinal(promedios);
                                break;
                        }
                        db.UpdateNota(buscar, Lector);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\t Error \nDetalles: {ex.Message}");
                }
                break;

            case 3:
                try
                {

                    Console.WriteLine("\n\tEliminar Notas");
                    Console.WriteLine($"\n{"Codigo".PadRight(idWidth)} {"Nombres".PadRight(nomWidth)} {"Laboratorios".PadRight(labWidth)} {"Parciales".PadRight(parWidth)} {"Nota final".PadRight(finalWidth)}");
                    Console.WriteLine(new string('-', idWidth + nomWidth + labWidth + parWidth + finalWidth + 8));

                    foreach (var i in db.ViewNota())
                    {
                        Console.WriteLine($"{i.id.ToString().PadRight(idWidth)} {i.estudiante.PadRight(nomWidth)} {i.laboratorio.ToString().PadRight(labWidth)} {i.parciales.ToString().PadRight(parWidth)} {i.final.ToString().PadRight(finalWidth)}   |");
                    }
                    Console.Write("\nIngrese el código del registro a eliminar: ");

                    var NotaIndivi = int.Parse(Console.ReadLine());

                    if (NotaIndivi == null)
                    {
                        Console.WriteLine("El registro no existe");
                    }
                    else
                    {
                        Console.WriteLine(db.DeleteNota(NotaIndivi));
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\t Error \nDetalles: {ex.Message}");
                }
                break;

            case 4:
                try
                {
                    var listarNotas = db.ViewNota();

                    Console.WriteLine($"\n{"Codigo".PadRight(idWidth)} {"Nombres".PadRight(nomWidth)} {"Laboratorios".PadRight(labWidth)} {"Parciales".PadRight(parWidth)} {"Nota final".PadRight(finalWidth)}");
                    Console.WriteLine(new string('-', idWidth + nomWidth + labWidth + parWidth + finalWidth + 8));

                    foreach (var i in db.ViewNota())
                    {
                        Console.WriteLine($"{i.id.ToString().PadRight(idWidth)} {i.estudiante.PadRight(nomWidth)} {i.laboratorio.ToString().PadRight(labWidth)} {i.parciales.ToString().PadRight(parWidth)} {i.final.ToString().PadRight(finalWidth)}   |");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\t Error \nDetalles: {ex.Message}");
                }
                break;

            case 5:
                vali1 = false;
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"\t Error \nDetalles: {ex.Message}");
    }
}
