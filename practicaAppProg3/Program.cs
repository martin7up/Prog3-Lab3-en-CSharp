
namespace practicaAppProg3
{
    internal class Program
    {
        static void Main(string[] args)
        {
        
        }
        static void mostrarEnumerados(Type enumerado)
        {
            foreach (var item in Enum.GetValues(enumerado)) Console.WriteLine(item + " -> " + (uint)item);
        }
        static bool contieneLaOpcion(uint opcion, Type enumerado)
        {
            object[] arregloAux = new object[1];
            foreach (var item in Enum.GetValues(enumerado))
            {
                if (Array.IndexOf(arregloAux, null) == -1) Array.Resize(ref arregloAux, arregloAux.Length + 1);
                arregloAux[Array.IndexOf(arregloAux, null)] = (uint)item;
            }
            return arregloAux.Contains(opcion);
        }
        static void seleccionarEnum(out uint opcion, Type enumerado)
        {
            Console.Write("\t¿? : >>> ");
            while(!uint.TryParse(Console.ReadLine().Trim(), out opcion) || !contieneLaOpcion(opcion, enumerado)) Console.WriteLine("Ups! ... opcion no disponible.\nIntente de nuevo.\n\t¿? : >>> ");       
        }
        static EstadoTarea retornarTarea(uint opcion)
        {
            return (EstadoTarea)opcion;
        }//Preguntar esta parte para saber como declarar la devolucion de una constante de un enum cualquiera
    }
    public enum EstadoTarea : uint { PENDIENTE = 1, EN_PROCESO, FINALIZADA, CANCELADA}
    public class Estado
    {
        public EstadoTarea _Estado { get; set; }
        public Estado()
        {
            _Estado = EstadoTarea.PENDIENTE;
        }
    }
    public class Tarea
    {
        static uint _numero = 0;
        public string Nombre { get; set; }
        public Estado Estado { get; set; }
        public TimeSpan Duracion { get; set; }
        public string Descripcion { get; set; }
        public uint Numero { get; private set; }
        public DateTime FechaPlaneada { get; set; }
        public DateTime FechaRealizada { get; set; }
        public Tarea()
        {
            _numero++;
        }
        public Tarea(string nombre, string descripcion, DateTime fechaPlaneada, TimeSpan duracion) : this()
        {
            Nombre = nombre;
            Descripcion = descripcion;
            Estado = new Estado();
            FechaPlaneada = fechaPlaneada;
            Duracion = duracion;
            Numero = _numero;
        }
        public override string ToString()
        {
            return $"Tarea numero : {Numero}\nNombre : {Nombre}\nDescripcion : {Descripcion}" +
                $"\nEstado : {Estado._Estado}\nFecha de inicio (ddMMaaaa): {FechaPlaneada.ToString("G")}\nDuracion (hhmmss): {Duracion.ToString("g")}";
        }
    }
    public class Agenda
    {
        //Atributos
        Tarea[] tareasEnAgenda;
        //Propiedades
        public string NombreDuenioAgenda { get; set; }
        //Constructor
        public Agenda(string nombre)
        {
            NombreDuenioAgenda = nombre;
            tareasEnAgenda = new Tarea[5];

            //Hardcode de prueba
            tareasEnAgenda[0] = new Tarea("Buscar Apuntes", "...ir a la casa de Damian, para hablar con el man.", new DateTime(2023,05,08,  14,00,00), new TimeSpan(2,30,00));
            tareasEnAgenda[0] = new Tarea("Hacer Deportes", "Salir a trotar por el parque.", new DateTime(2023,06,21,  09,00,00), new TimeSpan(0, 35, 00));
            tareasEnAgenda[0] = new Tarea("Comenzar Dieta", "... a ver si esta vez aguanto.", new DateTime(2023,07,25,  15,30,00), new TimeSpan(3, 40, 00));
            tareasEnAgenda[0] = new Tarea("Buscar Apuntes(de nuevo)", "...ir a la casa de Damian, otra vez!", new DateTime(2023,07,11,  22,00,00), new TimeSpan(0, 19, 00));
        }
        //Metodos
        public void establecerDuracionDeLaTarea(out TimeSpan ts)
        {
            //Vbles locales
            int horas = 0, minutos = 0;

            //Captacion de datos
            do Console.WriteLine(horas < 0? "Ups! Algo no salio bien, la duracion en horas debe tener formato entero positivo (9,23,37, etc); intente de nuevo.\nDuracion en horas ¿? : >>> " : "Duracion en horas ¿? : >>> "); while (!int.TryParse(Console.ReadLine().Trim(), out horas) || horas < 0);
            do Console.WriteLine(minutos < 0 ? "Ups! Algo no salio bien, la duracion en minutos debe tener formato entero positivo (15,12,45, etc); intente de nuevo.\nDuracion en minutos ¿? : >>> " : "Duracion en minutos ¿? : >>> "); while (!int.TryParse(Console.ReadLine().Trim(), out minutos) || minutos < 0);
            //Salida
            ts = new TimeSpan(horas, minutos, 0);
        }
        public void establecerFechaYHoraDeTarea(out DateTime dt)
        {
            //Vbles locales
            bool aux = false;
            uint anio, mes, dia, hora, minuto;

            //Captacion de Fechas
            do Console.WriteLine(aux ? "Ups! El anio debe ser el corriente o uno mayor...\nAnio de la tarea ¿? : >>> " : "Anio de la tarea (ingrese el numero correspondiente)¿? : >>> "); while (aux = (!uint.TryParse(Console.ReadLine().Trim(), out anio) || anio > DateTime.MaxValue.Year || anio < DateTime.Now.Year));
            if(anio == DateTime.Now.Year)//para Año actual
            {
                do Console.WriteLine(aux ? "Ups! El Mes debe ser el corriente o uno mayor...\nMes de la tarea ¿? : >>> " : "Mes de la tarea (ingrese el numero correspondiente)¿? : >>> "); while (aux = (!uint.TryParse(Console.ReadLine().Trim(), out mes) || mes > 12 || mes < DateTime.Now.Month));
                
                if(mes == DateTime.Now.Month)//para Mes actual
                {
                    do Console.WriteLine(aux ? "Ups! El Dia debe ser el corriente o uno mayor...\nDia de la tarea ¿? : >>> " : "Dia de la tarea (ingrese el numero correspondiente)¿? : >>> "); while (aux = (!uint.TryParse(Console.ReadLine().Trim(), out dia) || dia > DateTime.DaysInMonth((int)anio, (int)mes) || dia < DateTime.Now.Day));
                    
                    if(dia == DateTime.Now.Day)//para Dia actual
                        do Console.WriteLine(aux ? "Ups! La Hora debe ser la actual o mayor, intente de nuevo...\nHora de la tarea ¿? : >>> " : "Hora de la tarea (ingrese el numero correspondiente)¿? : >>> "); while (aux = (!uint.TryParse(Console.ReadLine().Trim(), out hora) || hora <= DateTime.Now.Hour || hora > 23));
                    else//para Dia despues del actual
                        do Console.WriteLine(aux ? "Ups! La Hora esta fuera de rango, intente de nuevo...\nHora de la tarea ¿? : >>> " : "Hora de la tarea (ingrese el numero correspondiente)¿? : >>> "); while (aux = (!uint.TryParse(Console.ReadLine().Trim(), out hora) || hora > 23));
                }
                else//para mes despues del actual
                {

                    do Console.WriteLine(aux ? "Ups! El Dia esta fuera de rango, intente de nuevo...\nDia de la tarea ¿? : >>> " : "Dia de la tarea (ingrese el numero correspondiente)¿? : >>> "); while (aux = (!uint.TryParse(Console.ReadLine().Trim(), out dia) || dia > DateTime.DaysInMonth((int)anio, (int)mes) || dia == 0));
                    do Console.WriteLine(aux ? "Ups! La Hora esta fuera de rango, intente de nuevo...\nHora de la tarea ¿? : >>> " : "Hora de la tarea (ingrese el numero correspondiente)¿? : >>> "); while (aux = (!uint.TryParse(Console.ReadLine().Trim(), out hora) || hora > 23));
                }
            }
            else
            {
                do Console.WriteLine(aux ? "Ups! El Mes esta fuera de rango, intente de nuevo...\nMes de la tarea ¿? : >>> " : "Mes de la tarea (ingrese el numero correspondiente)¿? : >>> "); while (aux = (!uint.TryParse(Console.ReadLine().Trim(), out mes) || mes > 12 || mes == 0));
                do Console.WriteLine(aux ? "Ups! El Dia esta fuera de rango, intente de nuevo...\nDia de la tarea ¿? : >>> " : "Dia de la tarea (ingrese el numero correspondiente)¿? : >>> "); while (aux = (!uint.TryParse(Console.ReadLine().Trim(), out dia) || dia > DateTime.DaysInMonth((int)anio, (int)mes) || dia == 0));
                do Console.WriteLine(aux ? "Ups! La Hora esta fuera de rango, intente de nuevo...\nHora de la tarea ¿? : >>> " : "Hora de la tarea (ingrese el numero correspondiente)¿? : >>> "); while (aux = (!uint.TryParse(Console.ReadLine().Trim(), out hora) || hora > 23));
            }

            dt = new DateTime((int)anio, (int)mes, (int)dia, (int)hora, 0, 0);
        }
        public void obtenerTareasEnUnMes(int anio, int mes)
        {
            foreach (Tarea tarea in tareasEnAgenda) Console.WriteLine(tarea.FechaPlaneada.Year == anio && tarea.FechaPlaneada.Month == mes ? tarea.ToString() : "");
        }
        public void obtenerTareasEnUnAnioDado(int anio)
        {
            foreach (Tarea tarea in tareasEnAgenda) Console.WriteLine(tarea.FechaPlaneada.Year == anio ? tarea.ToString() : "");
        }
        public void obtenerTareasPorFecha(DateTime dt)
        {
            foreach (Tarea tarea in tareasEnAgenda) Console.WriteLine(tarea.FechaPlaneada == dt ? tarea.ToString() : "");
        }
        public void obtenerTareasProximaSemana()
        {
            DateTime dt = DateTime.Now;
            while (true)
            {
                if (dt.DayOfWeek != DayOfWeek.Monday)
                {
                    dt = dt.AddDays(1);
                    continue;
                }//Bloque para moverse al lunes mas proximo
                Console.WriteLine(dt.DayOfWeek + "\n-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_");
                obtenerTareasPorFecha(dt);
                Console.WriteLine("\n-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_\n");
                dt = dt.AddDays(1);
                if (dt.DayOfWeek == DayOfWeek.Monday) return;
            }
        }
        public void listarTareas(uint opcion)//Opcion debe provenir desde el metodo estatico seleccionarEnum
        {
            foreach (Tarea item in tareasEnAgenda) Console.WriteLine(item.Estado._Estado == (EstadoTarea)opcion ? item.ToString() : "");
        }
        public void obtenerTareasEstaSemana() 
        {
            DateTime dt = DateTime.Now;
            do
            {
                Console.WriteLine(dt.DayOfWeek + "\n-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_");
                obtenerTareasPorFecha(dt);
                Console.WriteLine("\n-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_\n");
                dt = dt.AddDays(1);
            } while (dt.DayOfWeek != DayOfWeek.Monday);         
        }
        public void obtenerTareasEsteMes()
        {
        
        }
        public void agregarUnaTarea()
        {   //Vbles locales
            string[] nombreParametros = {"Nombre", "Descripcion", "Anio de inicio", "Mes de inicio", "Dia de inicio", "Hora de inicio", "Minuto de inicio", "Duracion en hs", "Duracion en minutos"};
            string[] nombrYDescrip = new string[2];
            DateTime dt;
            TimeSpan ts;
            
            //Captacion de nombre y descripcion
            for (byte i = 0; i < nombrYDescrip.Length; i++)
            {              
                do Console.Write(nombrYDescrip[i] is null? nombreParametros[i] + " de la tarea ¿? : >>> " : $"Ups! Este campo no debe quedar vacio; intente de nuevo.\n{nombreParametros[i]} ¿? : >>> "); while ((nombrYDescrip[i] = Console.ReadLine().Trim()).Equals(""));
            }
            
            //Captacion de fecha y hora de inicio
            establecerFechaYHoraDeTarea(out dt);

            //Captacion de duracion de la tarea
            establecerDuracionDeLaTarea(out ts);

            //Verificacion de espacio disponible en el arreglo
            if (Array.IndexOf(tareasEnAgenda, null) == -1) Array.Resize(ref tareasEnAgenda, tareasEnAgenda.Length + 10);

            //Se agrega la tarea en la primer poscion nula que se encuentre en el arreglo
            tareasEnAgenda[Array.IndexOf(tareasEnAgenda, null)] = new Tarea(nombrYDescrip[0], nombrYDescrip[1], dt, ts);
        }
    }
}
/*  --------------------------------------------------------ANOTACIONES--------------------------------------------------------------------------

    Tarea nuevaTarea = new("Reunion Virtual", "Estudiar para el examen", new DateTime(2024, 05, 16, 15, 00, 00), new TimeSpan(1, 30, 00));
    Tarea otraTarea = new("Reunion Virtual", "Estudiar para el examen", new DateTime(2025, 09, 6, 23, 50, 20), new TimeSpan(26, 30, 00));
    Tarea ultimTarea = new("Reunion Virtual", "Estudiar para el examen", new DateTime(2024, 07, 16, 09, 08, 01), new TimeSpan(0, 30, 09));
    Console.WriteLine(nuevaTarea.ToString() + "\n\n" + otraTarea.ToString() + "\n\n" + ultimTarea.ToString());

    uint opcion;
    mostrarEnumerados(typeof(EstadoTarea));
    seleccionarEstado(out opcion, typeof(EstadoTarea));
    Console.WriteLine("Bien!! Usted selecciono : " + retornarTarea(opcion)); 
    
    for(byte i = 1; i < 13; i++)
        Console.WriteLine(DateTimeFormatInfo.CurrentInfo.GetMonthName(i));
    foreach(string dia in DateTimeFormatInfo.CurrentInfo.DayNames)
        Console.WriteLine(dia);
    ---------------------------------------------------------------------------------------------------------------------------------------------
 */