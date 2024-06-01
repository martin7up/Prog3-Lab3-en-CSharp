
Console.WriteLine("Ingrese por teclado una frase completa... ");

string frase = Console.ReadLine().Trim();

bool verificacion = string.IsNullOrEmpty(frase) || string.IsNullOrWhiteSpace(frase);  

Console.WriteLine( verificacion ? "Ha ingresado una frase vacia.." : "Elija una opcion a continuacion >>> ");

if (verificacion)
{
    
    Console.WriteLine("Vuelva a iniciar la aplicacion porfavor.");
}
else
{
    
    Console.WriteLine("1 Texto en mayusculas.\n2 Texto en minusculas.\n3 Texto original.");

        switch (Console.ReadKey(true).KeyChar)
        {

            case '1': frase = frase.ToUpper(); break;
            
            case '2': frase = frase.ToLower(); break;
            
            case '3':; break;
            
            default: Console.WriteLine("Opcion no disponible."); break;
        }

    Console.WriteLine(frase);
}

Console.WriteLine("Presione <Enter> para salir.");
while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }