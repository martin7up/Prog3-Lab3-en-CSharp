//string cadenaIngres;
//decimal valorParseado;
//bool exito = false;
//do
//{
//    Console.WriteLine(exito ? "Formato inadecuado!... intenten nuevamente." : "Ingrese un valor real cualquiera : ");
//    cadenaIngres = Console.ReadLine();
//} while (exito = !decimal.TryParse(cadenaIngres, out valorParseado));
//Console.WriteLine($"{valorParseado} es el valor que pudo obtenerse desde teclado.");

Console.WriteLine("Ingrese a continuacion dos numeros reales cualesquiera >>> ");
Console.Write(" Numero1 = ");
Console.WriteLine(double.TryParse(Console.ReadLine(), out double num1) ? "\n--------------------" : "#Formato_Incorrecto se asigna 0 por defecto#");
Console.Write(" Numero2 = ");
Console.WriteLine(double.TryParse(Console.ReadLine(), out double num2) ? "\n--------------------" : "#Formato_Incorrecto se asigna 0 por defecto#");
Console.WriteLine($"{num1} + {num2} = {num1 + num2}" + "\n" +
                  $"{num1} - {num2} = {num1 - num2}" + "\n" +
                  $"{num2} - {num1} = {num2 - num1}" + "\n" +
                  $"{num1} * {num2} = {num1 * num2}" + "\n" +
                  $"{num1} / {num2} = {num1 / num2}" + "\n" +
                  $"{num2} / {num1} = {num2 / num1}");