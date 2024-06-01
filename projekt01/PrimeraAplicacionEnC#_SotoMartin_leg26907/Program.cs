/*
    Objetivo: Comprender el uso de variables, asignaciones y operaciones de forma simple en C#.
    _Cree una aplicación de consola
    _Solicite el ingreso de dos valores por pantalla
    _Al final muestre en forma descriptiva los resultados de aplicar las cuatro operaciones básicas
*/

Console.WriteLine("Ingrese a continuacion dos numeros reales cualesquiera >>> ");
Console.Write("Numero1 = ");
Console.WriteLine(double.TryParse(Console.ReadLine(), out double num1) ? "" : "#Formato_Incorrecto se asigna 0 por defecto#");
Console.Write("Numero2 = ");
Console.WriteLine(double.TryParse(Console.ReadLine(), out double num2) ? "" : "#Formato_Incorrecto se asigna 0 por defecto#");
Console.WriteLine("Suma >>> \n" + $"{num1} + {num2} = {num1 + num2}"+"\n" +
                  "Restas >>> \n" + $"{num1} - {num2} = {num1 - num2}" + "\n" +
                  $"{num2} - {num1} = {num2 - num1}" + "\n" +
                  "Multiplicacion >>> \n" + $"{num1} * {num2} = {num1 * num2}" + "\n" +
                  "Divisiones >>> \n" + $"{num1} / {num2} = {num1 / num2}" + "\n" +
                  $"{num2} / {num1} = {num2 / num1}");


//string cadenaIngres;
//decimal valorParseado;
//bool exito = false;
//do
//{
//    Console.WriteLine(exito ? "Formato inadecuado!... intenten nuevamente." : "Ingrese un valor real cualquiera : ");
//    cadenaIngres = Console.ReadLine();
//} while (exito = !decimal.TryParse(cadenaIngres, out valorParseado));
//Console.WriteLine($"{valorParseado} es el valor que pudo obtenerse desde teclado.");