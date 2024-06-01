


//---------------------------------------------------------------------------------------------------------------------------------------------
//Console.WriteLine("Dia : " + DateTime.Now.ToString("dddd"));
//Console.WriteLine("Mes : " + DateTime.Now.ToString("MMMM"));
//Console.WriteLine("Anio : " + DateTime.Now.ToString("yyyy"));
//Console.WriteLine("Era : " + DateTime.Now.ToString("gg"));
//Console.WriteLine("Hora : " + DateTime.Now.ToString("HH"));
//Console.WriteLine("Minuto : " + DateTime.Now.ToString("mm"));
//Console.WriteLine("Segundos : " + DateTime.Now.ToString("ss"));
//Console.WriteLine("Desfase UTC (hh:mm) : " + DateTime.Now.ToString("zzz"));
//---------------------------------------------------------------------------------------------------------------------------------------------



//---------------------------------------------------------------------------------------------------------------------------------------------
/*
 * 3.Realice un programa que solicite cuál fue el primer día del mes, por ejemplo el primer día del mes de marzo de 2022 fue un martes.    
  Luego con esta información el sistema debe poder calcular que día será, el correspondiente a una fecha dada. Por lo cual el sistema 
  podría preguntar, ingrese una fecha del mes de marzo y le diré que día cae.
*/

//Console.Write(" Ingrese los numeros correspondietes a la fecha de la cual se desea saber el nombre del dia y el nombre del mes;\n" +
//    " ejemplo para el 4 de Enero del 2024, ingrese, en formato Anio/Mes/Dia :  2024<Enter>01<Enter>04<Enter>" + "\n\n Anio : ");

//int anio, mes, dia;
////Se aprovecha el hecho de que TryParse() asigna 0 a la vble de salida, en caso de no poder parsear, para el control de bucle do ... while();

//do Console.Write(int.TryParse(Console.ReadLine(), out anio) ? " Mes : " : " #ERROR...intente de nuevo.\n Anio : "); while (anio == 0);

//do Console.Write(int.TryParse(Console.ReadLine(), out mes) ? " Dia : " : " # ERROR...intente de nuevo.\n Mes : "); while (mes == 0);

//do Console.Write(int.TryParse(Console.ReadLine(), out dia) ? "\n" : " #ERROR...intente de nuevo.\n Dia : "); while (dia == 0);

//DateTime dt = new DateTime(anio, mes, dia);

//Console.WriteLine(" Fecha : " + dt.ToString("dddd") + "/" + dt.ToString("MMMM") + "/" + dt.ToString("yyyy"));

//Console.WriteLine(dt.ToString("dddd").Equals("viernes") ? "Alerta de proximidad de fin de semana!" : "No esta muy proximo al fin de semana.");
//---------------------------------------------------------------------------------------------------------------------------------------------



//---------------------------------------------------------------------------------------------------------------------------------------------
/*
  4.Realice un programa que solicite el primer día de cada uno de los doce meses del año. Con esta información podrá pedir al sistema que 
  dada una determinada fecha el mismo le indique que día será. El sistema también podrá responder al requerimiento que fechas caen 
  los fines de semana de un determinado mes. 
*/

//string[] diasDelComienzoDeMes = 
//{   "Lunes",
//    "Jueves",
//    "Viernes",
//    "Lunes",
//    "Miercoles",
//    "Sabado",
//    "Lunes",
//    "Jueves",
//    "Domingo",
//    "Martes",
//    "Viernes",
//    "Domingo"
//};//Estos datos son validos unicamente para el 2024 y estan aqui solo para las pruebas.

//string[] diasDelComienzoDeMes = new string[12];

//string[] semana = 
//{   "Lunes", 
//    "Martes", 
//    "Miercoles", 
//    "Jueves", 
//    "Viernes", 
//    "Sabado", 
//    "Domingo" 
//};

//string[] meses =
//{   "Enero",
//    "Febrero",
//    "Marzo",
//    "Abril",
//    "Mayo",
//    "Junio",
//    "Julio",
//    "Agosto",
//    "Septiembre",
//    "Octubre",
//    "Noviembre",
//    "Diciembre"
//};

//byte[] cantidadDeDiasXMes = { 31, 0, 31, 30, 31, 30, 31, 30, 31, 31, 30, 31 };//Segunda posicion se asigna segun sea bisiesto o no.

//short anio;
//do
//{
//    Console.Write("Año ¿? : >>> ");
//    Console.WriteLine(short.TryParse(Console.ReadLine(), out anio)? "" : "Error de formato o fuera de rango.");
//} while (anio< 1);
//cantidadDeDiasXMes[1] = (byte)((anio % 4 == 0 && (!(anio % 100 == 0) || anio % 400 == 0)) ? 29 : 28);//Anio bisiesto o no.

//for (int i = 0; i < 12; i++)//Adquisicion de datos desde el usuario
//{
//    Console.Write($"Ingrese el primer dia correspondiente al mes de {meses[i]} >>> ");
//    diasDelComienzoDeMes[i] = Console.ReadLine();
//}

//byte mes;//Adquisicion del numero de mes desde el usuario
//do { 
//Console.Write("\nNumero de mes ¿? :(1 -> 12) >>> ");
//Console.WriteLine((byte.TryParse(Console.ReadLine(), out mes) && (mes >= 1 && mes <= 12)) ? "" : "Error de formato o fuera de rango, intente de nuevo."); 
//} while (mes < 1 || mes > 12);
//mes -= 1;

//byte j;//Busqueda del numero dia de semana 0 -> 6 que es el primer dia del mes
//for (j =0; j <7; j++)
//{
//    if (semana[j].Equals(diasDelComienzoDeMes[mes])) 
//        break;
//}

//byte dia;// numero de dia del mes cuyo string se desea averiguar(lunes, martes, miercoles, etc)
//do {
//    Console.Write("Numero del dia ¿? (1 -> numMax/segum mes): >>> ");
//    Console.WriteLine((byte.TryParse(Console.ReadLine(), out dia) && (dia >= 1 && dia <= cantidadDeDiasXMes[mes]) ? "" : "Error en el formato o fuera de rango, intente de nuevo."));
//} while (dia < 1 || dia > cantidadDeDiasXMes[mes]);

//byte k;
//for(k= 1; k< dia; k++)
//{
//    if (j == 6)
//    {
//        j = 0;
//        continue;
//    }       
//    j++;
//}

//Console.WriteLine($"Para la fecha {dia} del mes de {meses[mes]} del 2024, corresponde el dia {semana[j]}");

//Console.WriteLine("Desea conocer que fechas corresponden a fines de semana en el mes seleccionado ¿? : (s/n) >>> ");

//if(Console.ReadKey(true).Key == ConsoleKey.S)//Se muestra fechas correspondientes, al mes elegido, cuyos dias son Sabado y Domingo.
//{
//    for (k = 1; k < cantidadDeDiasXMes[mes]; k++)
//    {
//        Console.Write((semana[j].Equals("Sabado")) ? $"{k}/{mes+1}/{anio} >>> Sabado\n{k + 1}/{mes + 1}/{anio} >>> Domingo" : "");
//        if (j == 6)
//        {
//            j = 0;
//            continue;
//        }
//        j++;
//    }
//}

//do Console.WriteLine("Para salir de la consola presione <Esc>"); while (Console.ReadKey(true).Key != ConsoleKey.Escape);
//---------------------------------------------------------------------------------------------------------------------------------------------



//---------------------------------------------------------------------------------------------------------------------------------------------
/*
  5.Se agrega el nuevo requerimiento al sistemas de fechas. Se espera que pueda arrojar el monto de un presupuesto para desarrrollo considerando
  la siguiente informacion. La hora de desarrollo sera de $3000, el progrmador trabajar 4 hs por dia en el proyecto. El estimo terminar con la 
  incidencia 10 dias habiles, comenzando el 8 de abril de 2022.
*/

//Console.WriteLine("--------Calculo presupuestario para desarrollos--------");

//Console.WriteLine("Ingrese Año, mes y numero de dia de inicio de proyecto con formato de barras; ejemp : 1998/12/31");

//DateTime.TryParse(Console.ReadLine(), out DateTime inicio);

//Console.WriteLine("Ingrese Año, mes y numero de dia de fin de proyecto con formato de barras; ejemp : 1999/09/21");

//DateTime.TryParse(Console.ReadLine(), out DateTime fin);

//Console.Write("Cantidad de horas de trabajo diarias ¿? : >>> ");

//byte hsPorDia;
//byte.TryParse(Console.ReadLine(), out hsPorDia);

//int hsTotales = 0;

//TimeSpan duracion = fin.Subtract(inicio);
//for (int i = 0; i <= duracion.Days; i++)
//{
//    hsTotales += (inicio.ToString("dddd").Equals("domingo") || inicio.ToString("dddd").Equals("sábado")) ? 0 : hsPorDia;
//    inicio = inicio.AddDays(1);
//}

//Console.WriteLine("La cantidad de horas habiles del proyecto son : " + hsTotales);
//---------------------------------------------------------------------------------------------------------------------------------------------


class validaciones
{
    static decimal validacion()
    {
        decimal receivedFromUser;
        Console.Write("Input ¿? : >>> ");
        do Console.Write(decimal.TryParse(Console.ReadLine(), out receivedFromUser) ? $"Your input >>> {receivedFromUser}" : "...wrong format, try again.\nInput ¿? : >>> "); while (receivedFromUser == 0);
        return receivedFromUser;
    }
}

