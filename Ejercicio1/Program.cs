/*Realziar un programa en C# que simule una calculadora, esta calculadora
las opciones de la calculadora son 1- Suma, 2-Resta, 3-Multiplicacion y 4- Division
deberan estar almacenados en un arreglo, si el valor encontrado es correcto realizar la
operacion si no utilizar un manejo de excepciones para el caso de la division los valores
a introducir deben ser enteros y utilizar manejo de excepciones 

Ej: int[] operaciones = {1, 2, 3, 4} */


int[] operaciones = { 1, 2, 3, 4 };
bool salir = false;

do
{
    Console.WriteLine("\tSeleccione una operación \n1- Sumar \n2-Restar \n3-Multiplicar \n4-Dividir \n5-Salir");

    try
    {
        int opcion = int.Parse(Console.ReadLine());

        if (opcion == 5)
        {
            salir = true;
        }
        else if (Array.Exists(operaciones, element => element == opcion))
        {
            Console.WriteLine("Ingrese el primer número:");
            int num1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el segundo número:");
            int num2 = int.Parse(Console.ReadLine());

            if (opcion == 4 && num2 == 0)
            {
                throw new DivideByZeroException("Error: No se puede dividir por cero.");
            }
            else
            {
                RealizarOperacion(opcion, num1, num2);
            }
        }
        else
        {
            throw new InvalidOperationException("Error: Seleccione una opción válida.");
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Error: Ingrese un valor numérico.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }

} while (!salir);

Console.WriteLine("Saliendo del programa.");

    static void RealizarOperacion(int opcion, int num1, int num2)
{
    switch (opcion)
    {
        case 1:
            Console.WriteLine($"Resultado: {num1 + num2}");
            break;
        case 2:
            Console.WriteLine($"Resultado: {num1 - num2}");
            break;
        case 3:
            Console.WriteLine($"Resultado: {num1 * num2}");
            break;
        case 4:
            Console.WriteLine($"Resultado: {num1 / num2}");
            break;
        default:
            Console.WriteLine("Error: Opción no válida.");
            break;
    }
}