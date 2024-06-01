
namespace simulacroPrimerParcialProg3
{
    internal class Program
    {
        //Variables de clase
        private static Intervalo[] intervalos =
        {                           //Inicio                  //Fin
                            // yyyyMMdd    hhmmss      yyyyMMdd    hhmmss
                new Intervalo(1990,06,12, 09,23,59,   1990,07,01, 12,35,03), //Este intervalo no se solapa con ningun otro
                new Intervalo(2000,06,11, 10,13,01,   2001,02,21, 13,45,02), //Este intervalo se solapa con el siguiente
                new Intervalo(2001,01,12, 06,08,59,   2002,05,01, 09,25,03),
                new Intervalo(2015,06,12, 12,23,35,   2021,07,01, 12,45,03), //Este intervalo absorbe al siguiente
                new Intervalo(2017,06,12, 13,23,55,   2018,12,09, 03,03,03),
                new Intervalo(2029,06,12, 13,23,55,   2029,12,09, 03,03,03) //Este intervalo no se solapa con ningun otro
        };
        //Metodo de ingreso
        static void Main(string[] args)
        {
            Console.WriteLine("Arreglo de intervalos originales.\n");
            mostrarArreglo(intervalos);

            Console.WriteLine("Arreglo de intervalos ordenados.\n");
            ordenarArreglo(intervalos);
            mostrarArreglo(intervalos);

            Console.WriteLine("Arreglo de union de intervalos(No se muestran aquellos que se setearon a nulo).\n");
            unionIntervalos(intervalos);
            mostrarArreglo(intervalos);
        }
        //Metodos de la clase
        private static void mostrarArreglo(Intervalo[] intervalos)
        {
            foreach (Intervalo intervalo in intervalos)
            {
                if (intervalo == null) continue;
                Console.WriteLine(intervalo.ToString() + "\n ------------ \n");
            }
        }
        private static void ordenarArreglo(Intervalo[] intervalos)
        {
            Intervalo aux;
            for (byte j = 0; j < intervalos.Length; j++)
            {
                for (byte i = 0; i < intervalos.Length - 1; i++)
                {
                    if (intervalos[i].Inicio >= intervalos[i + 1].Inicio)
                    {
                        aux = intervalos[i + 1];
                        intervalos[i + 1] = intervalos[i];
                        intervalos[i] = aux;
                    }
                }
            }
        }
        private static void unionIntervalos(Intervalo[] intervalos)
        {
            for (byte i = 0; i < intervalos.Length - 1; i++)
            {
                if (isAbsorbido(intervalos[i], intervalos[i + 1]))
                {
                    intervalos[i + 1] = intervalos[i];
                    intervalos[i] = null;
                    continue;          
                }                      
                if (isSolape(intervalos[i], intervalos[i + 1]))
                {
                    intervalos[i + 1] = new Intervalo(intervalos[i].Inicio, intervalos[i + 1].Fin);
                    intervalos[i] = null;
                    continue;
                }
            }
        }
        private static bool isSolape(Intervalo intervI, Intervalo intervF)
        {
            return intervI.Fin >= intervF.Inicio;
        }
        private static bool isAbsorbido(Intervalo intervI, Intervalo intervF)
        {
            return (intervI.Inicio <= intervF.Inicio) && (intervI.Fin >= intervF.Fin);
        }
    }
    //------------------------------------------------------------------------------------------------------------------------------------------------------

    //Clase Intervalo---------------------------------------------------------------------------------------------------------------------------------------
    public class Intervalo 
    {
        public DateTime Inicio { get; }
        public DateTime Fin { get; }
        public TimeSpan Duracion { get; }
        public Intervalo(int[] vlr)
        {
            Inicio = new DateTime(vlr[0], vlr[1], vlr[2], vlr[3], vlr[4], vlr[5]);
            Fin = new DateTime(vlr[6], vlr[7], vlr[8], vlr[9], vlr[10], vlr[11]);
            Duracion = Fin.Subtract(Inicio);
        }
        public Intervalo(DateTime Inicio, DateTime Fin)
        {
            this.Inicio = Inicio;
            this.Fin = Fin;
            Duracion = Fin.Subtract(Inicio);
        }
        public override string ToString()
        {
            return $"Inicio > {Inicio.ToString("G")}\nFin > {Fin.ToString("G")}\nDuracion > {Duracion.ToString("g")}";
        }

    }
    //------------------------------------------------------------------------------------------------------------------------------------------------------
}
/*-----------------------------------------------------------------------ANOTACIONES----------------------------------------------------------------------*/
//new Intervalo(1990, 06, 12, 09, 23, 59, 1990, 07, 01, 12, 35, 03),
//new Intervalo(2000, 06, 11, 10, 13, 01, 2019, 02, 21, 13, 45, 02),
//new Intervalo(1990, 04, 12, 06, 08, 59, 1990, 05, 01, 09, 25, 03),
//new Intervalo(1989, 06, 12, 12, 23, 35, 2021, 07, 01, 12, 45, 03),
//new Intervalo(1981, 06, 12, 13, 23, 55, 2000, 12, 09, 03, 03, 03)

/*
    private static Intervalo nuevoIntervalo(Intervalo intervI, Intervalo intervF)
    {
        if(isAbsorbido(intervI, intervF))
            return new Intervalo(intervI.Inicio, intervI.Fin);
        else//Solape
            return new Intervalo(intervI.Inicio, intervF.Fin);
    }
*/

//Pueden ocurrir cuatro cosas : que no haya solape alguno, que haya solape,
//que un intervalo absorba a otro y que
//coincidan fin e inicio de intervalos consecutivos(SE LO TRATA COMO SOLAPE).

//Constructor(<Inicio>( yyyy, MM, dd, hh, mm, ss) , <Fin>( yyyy, MM, dd, hh, mm, ss))
//yyyyMMdd hhmmss : AniosMesDia HoraMinutoSegundo
/*---------------------------------------------------------------------FIN_ANOTACIONES--------------------------------------------------------------------*/