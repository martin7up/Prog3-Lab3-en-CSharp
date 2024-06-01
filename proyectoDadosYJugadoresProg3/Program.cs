
namespace proyectoDadosYJugadoresProg3
{
    internal class Program
    {
        static int opcionElegida;
        static void Main(string[] args)
        {
            //mostrarEnumerados(typeof(TipoApuesta));

            //Jugador jugador11 = new("Damian Estevez.");
            //jugador11.ModoDeApuesta = TipoApuesta.conservador;

            //Jugador jugador12 = new("Fabian Cardozo.");
            //jugador11.ModoDeApuesta = TipoApuesta.arriesgado;

            //MesaDeApuesta mesaDelFondo = new MesaDeApuesta(jugador11, jugador12);

            //mesaDelFondo.unaRondaDeApostarALosDados();
        }
        static void mostrarEnumerados(Type enumerado)
        {
             foreach (var item in Enum.GetValues(enumerado)) Console.WriteLine(item.ToString() + " -> " + (int)item);
        }
    }
    public class Dado
    {
        Random generadorDeCara;
        uint _cara;
        public uint Cara { get; }
        public Dado()
        {
            generadorDeCara = new Random();
        }
        public uint tirarDado()
        {
            _cara = (uint)generadorDeCara.Next(1,7);
            return _cara;
        }
    }
    public class Jugador
    {
        //Propiedades
        public string Nombre { get; set; }
        public decimal Saldo { get; set; }
        public TipoApuesta ModoDeApuesta {  get; set; }
        public uint FactorDeGanancia
        {
            get
            {
                switch (ModoDeApuesta)
                {
                    case TipoApuesta.conservador:
                        return 2;
                    case TipoApuesta.arriesgado:
                        return 5;
                    case TipoApuesta.desesperado:
                        return 15;
                    default: return 2;//Si por algun caso no controlado se toma por defecto el modo conservador;
                }
            }
        }
        public uint FactorDePerdida
        {
            get
            {
                switch (ModoDeApuesta)
                {
                    case TipoApuesta.conservador:
                        return 1;
                    case TipoApuesta.arriesgado:
                        return 2;
                    case TipoApuesta.desesperado:
                        return 4;
                    default: return 1;//Si por algun caso no controlado se toma por defecto el modo conservador;
                }
            }
        }
        public Dado Dado { get; }
        //Constructores
        public Jugador(string nombre)
        {
            Nombre = nombre;
            Saldo = 100;
            Dado = new Dado();
        }
        //Metodos
        public override string ToString()
        {
            return $"Jugador : {Nombre};\tSaldo p/Apuestas : ${Saldo};\tModo de juego actual : {ModoDeApuesta}.";
        }
        public override int GetHashCode()
        {
            return Dado.GetHashCode();
        }
    }
    public enum TipoApuesta { conservador = 1, arriesgado, desesperado }
    public class MesaDeApuesta
    {
        //Atributos
        Jugador[] _jugadores;
        //Propiedades
        public decimal PozoDisponible { get; private set; }
        //Constructores
        public MesaDeApuesta(Jugador jugador1, Jugador jugador2)
        {
            _jugadores = new Jugador[2];
            _jugadores[0] = jugador1;
            _jugadores[1] = jugador2;
            PozoDisponible = 1000;   
        }
        //Metodos
        public void unaRondaDeApostarALosDados()
        {
            uint resultado, caraApostada;
            decimal montoDeApuesta;

            for(byte i = 0; i<2; i++)
            {
                Console.Clear();//Limpieza de pantalla

                //Opcion de no participar para el jugador de turno
                Console.WriteLine(_jugadores[i] + " Deseas participar en esta ronda ¿? (pulsa Esc para pasar, cualquier otra tecla para participar.)");
                if (Console.ReadKey().Key == ConsoleKey.Escape) continue;

                //Recepcion de apuesta(cara de dado)
                Console.Write($"Jugador : {_jugadores[i].Nombre}; Cara ¿? : >>> ");
                while (!uint.TryParse(Console.ReadLine(), out caraApostada) || caraApostada < 1 || caraApostada > 6)
                    Console.Write("Ups! >>> Valor fuera de rango o formato erroneo; intente de nuevo.\n\tCara de apuesta ¿? : >>> ");

                //Recepcion de apuesta(monto$)
                Console.Write($"Jugador : {_jugadores[i].Nombre}; Monto de apuesta ¿? : >>> ");
                while (!decimal.TryParse(Console.ReadLine(), out montoDeApuesta) || montoDeApuesta <= 0 || _jugadores[i].Saldo < montoDeApuesta * _jugadores[i].FactorDePerdida || PozoDisponible < montoDeApuesta * _jugadores[i].FactorDeGanancia)
                    Console.Write("Ups! >>> No dispone del saldo necesario o el formato es incorrecto, o el pozo es insuficiente; intente de nuevo.\n\tMonto de apuesta ¿? : >>> ");
                
                //Tirada
                resultado = _jugadores[i].Dado.tirarDado();
                
                //Resultados
                if(resultado == caraApostada)
                {
                    _jugadores[i].Saldo += montoDeApuesta * _jugadores[i].FactorDeGanancia;
                    PozoDisponible -= montoDeApuesta * _jugadores[i].FactorDeGanancia;
                    Console.WriteLine($"En hora buena, has ganado!\nApostaste por la cara numero : {caraApostada} y la tirada resulto en {resultado}" +
                        $"\nHas recuperado tu apuesta de : {montoDeApuesta}$, mas un extra de {montoDeApuesta * _jugadores[i].FactorDeGanancia - montoDeApuesta}$");
                }
                else
                {
                    _jugadores[i].Saldo -= montoDeApuesta * _jugadores[i].FactorDePerdida;
                    PozoDisponible += montoDeApuesta * _jugadores[i].FactorDePerdida;
                    Console.WriteLine($"Has perdido; mejor suerte la proxima!\nApostaste por la cara numero : {caraApostada} y la tirada resulto en {resultado}" +
                        $"\nHas perdido tu apuesta de : {montoDeApuesta}$, mas una penalizacion de {montoDeApuesta * _jugadores[i].FactorDePerdida - montoDeApuesta}$");
                }
                
                //Se verifica si es posible continuar el juego (ambos jugadores deben poseer saldo y el pozo de la mesa debe ser mayor a cero)
                if (PozoDisponible == 0)
                {
                    Console.WriteLine($"La casa ha tenido un mal dia, el pozo disponible es {PozoDisponible}$; por ello no es posible continuar.");
                    return;
                }else if (_jugadores[i].Saldo == 0)
                {
                    Console.WriteLine($"El saldo disponible de {_jugadores[i].Nombre} es {_jugadores[i].Saldo}$; por ello no es posible continuar.");
                    return;
                }
                
                //Muestra el estado final del pozo$ de la mesa y del jugador actual
                Console.WriteLine(_jugadores[i].ToString()+"\n"+this.ToString());
            }
        }
        public override string ToString()
        {
            return $"Mesa {GetHashCode()}; Pozo actual disponible : {PozoDisponible}";
        }
        public override int GetHashCode()
        {
            return _jugadores[0].GetHashCode() + _jugadores[1].GetHashCode();
        }
    }
}
/*
 *-----------------------------------------------------------------ANOTACIONES-------------------------------------------------------------------
 * 
 *  static void mostrarEnumerados(Type enumerado, out int valorSeleccionado)
        {
            int longitud = Enum.GetValues(typeof(tipoApuesta)).Length;
            int[] arreglo = new int[longitud];
            Array.Copy(Enum.GetValues(typeof(tipoApuesta)), arreglo, longitud);
            var niIdea = Enum.GetValues(typeof(tipoApuesta));
            
            valorSeleccionado = 0;
            
            //Muestra de constantes en el enumerado
            foreach (var item in niIdea) Console.WriteLine(item.ToString() + " -> " + (int)item);
            //Seleccion de un valor y retorno del mismo
            do
                Console.Write((arreglo.Contains(valorSeleccionado)) ? "Valor Recibido!" : "Valor ¿? : >>>"); 
            while (!int.TryParse(Console.ReadLine(), out valorSeleccionado) && (arreglo.Contains(valorSeleccionado)));
        }
 * 
 * 
 *-----------------------------------------------------------------------------------------------------------------------------------------------
 */
