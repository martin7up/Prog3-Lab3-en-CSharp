// See https://aka.ms/new-console-template for more information

SistemasDeCorreo correoHmail = new();
//correoHmail.mostrarBandejaEnviados();
//correoHmail.redaccionYEnvio();
//correoHmail.eliminarUnCorreo();
//correoHmail.mostrarBandejaEnviados();
bool salir = true;
do
{
    Console.Clear();
    Console.WriteLine("Menu Admin Correos\n Seleccione una de las siguientes opciones : \n1 Ver Correos en bandeja de enviados.\n2 Redactar y enviar un correo.\n3 Eliminar un correo\nEsc Salir.");
    switch (Console.ReadKey(true).Key)
    {
        case ConsoleKey.D1:
            Console.Clear();
            correoHmail.mostrarBandejaEnviados();
            Console.WriteLine("Presione Enter para volver al menu.");
            Console.ReadLine();
            break;

        case ConsoleKey.D2:
            Console.Clear();
            correoHmail.redaccionYEnvio();
            Console.WriteLine("Presione Enter para volver al menu.");
            Console.ReadLine();
            break;

        case ConsoleKey.D3:
            Console.Clear();
            correoHmail.mostrarBandejaEnviados();
            correoHmail.eliminarUnCorreo();
            Console.Clear();
            correoHmail.mostrarBandejaEnviados();
            Console.WriteLine("Presione Enter para volver al menu.");
            Console.ReadLine();
            break;
        case ConsoleKey.Escape:
            salir = false;
            break;
            
        default:
            Console.Clear();
            Console.WriteLine("Ups! Ingreso una opcion no valida... presione Enter e intente nuevamente.");
            Console.ReadLine();
            break;
    }

} while (salir);
Console.Clear();
Console.WriteLine("  FIN");

public class Correo
{
    string remitente, destinatario, asunto, cuerpo;
    public string Remitente { get; set; }
    public string Destinatario { get; set; }
    public string Asunto { get; set; }
    public string Cuerpo { get; set; }
    public Correo(string remitente, string destinatario, string asunto, string cuerpo)
    {
        Remitente = remitente;
        Destinatario = destinatario;    
        Asunto = asunto;    
        Cuerpo = cuerpo;    
    }
    public override string ToString()
    {
        return $"Destinatario : {Destinatario};\nRemitente : {Remitente};\nAsunto : {Asunto}\nCuerpo : {Cuerpo}";
    }
}

public class SistemasDeCorreo
{
    Correo[] correosEnviados;
    public SistemasDeCorreo()
    {
        correosEnviados = new Correo[10];
        correosEnviados[0] = new Correo("Jorf@hmail.com", "tere@electron.com", "Pedido", "Te pido prestado tu parrilla");
        correosEnviados[1] = new Correo("tere@hmail.com", "carlo@electron.com", "Prueba", "Probando el codigo");
        correosEnviados[2] = new Correo("Jorf@hmail.com", "pedro@electron.com", "Pedido", "Te pido prestado tu auto");
        correosEnviados[3] = new Correo("Mariaf@hmail.com", "tere@electron.com", "Gracias", "Te pido prestado tu parrilla");
    }
    public void redaccionYEnvio()
    {
        string[] nombresParametros = { "Destinatario", "Remitente", "Asunto", "Cuerpo" };
        string[] contenidoParametro = new string[4];

        for(byte i = 0; i<nombresParametros.Length; i++)
        {
            Console.Write(nombresParametros[i]+" ¿? : >>> ");
            contenidoParametro[i] = Console.ReadLine().Trim();
        }

        if (Array.IndexOf(correosEnviados, null) == -1)
        {
            Array.Resize(ref correosEnviados, correosEnviados.Length + 10);
            correosEnviados[Array.IndexOf(correosEnviados, null)] = 
                    (new Correo(contenidoParametro[0], contenidoParametro[1], contenidoParametro[2], contenidoParametro[3]));
        }
        else
        {
                correosEnviados[Array.IndexOf(correosEnviados, null)] =
                        (new Correo(contenidoParametro[0], contenidoParametro[1], contenidoParametro[2], contenidoParametro[3]));
        }    
    }
    public void eliminarUnCorreo()
    {
        
        Console.Write("Seleccione la posicion que corresponde al corre que desea eleminiar : >>> ");
        int.TryParse(Console.ReadLine(), out int posicionAEliminar);
        correosEnviados[posicionAEliminar] = null;
        Console.WriteLine("\n\n");
    }
    public void mostrarBandejaEnviados()
    {
        for (byte i = 0; i < correosEnviados.Length; i++)
        {
            if (correosEnviados[i] is null) continue;
            Console.WriteLine(correosEnviados[i].ToString() + "  ---> posicion " + i + "\n\n");
        }
    }
}
