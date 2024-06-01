
using System.Timers;

namespace solucionModaEstadisticaProg3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Estatidista.ingresoDeValores(99,1,12,-23,102,1,3,2,1,99,12,56,99,125,99);
            Console.WriteLine($"El maximo valor ingresado es  {Estatidista.maximo()} y el minimo es {Estatidista.minimo()}");
            Estatidista.moda();
            
        }
    }
    public static class Estatidista
    {

        //Vbles de Clase-------------------------------------------------------------------------------------------------------------------------
        private static decimal[] _conjuntoDeValores;
        private static decimal[] _conjuntoDeModas;
        //---------------------------------------------------------------------------------------------------------------------------------------

        //Metodos de Clase-----------------------------------------------------------------------------------------------------------------------
        public static void ingresoDeValores(params decimal[] valores)
        {
            _conjuntoDeValores = new decimal[valores.Length];
            _conjuntoDeModas = new decimal[valores.Length];
            
            for (int i = 0; i < valores.Length; i++){
                if (_conjuntoDeValores.Contains(valores[i])) _conjuntoDeModas[Array.IndexOf(_conjuntoDeValores, valores[i])] += 1;
                _conjuntoDeValores[i] = valores[i]; 
            }
        }
        public static void mostrarValoresDelConjunto()
        {
            if (_conjuntoDeValores is null)
            {
                Console.WriteLine("El conjunto de valores actual se encuentra vacio, o ocurrio algun error durante el ingreso de datos.");
                return;
            }
            else
            {
                foreach (ValueType item in _conjuntoDeValores)
                    Console.Write(item.ToString() + "  ");
            }
        }
        public static void limpiarConjuntoDeDatos()
        {
            _conjuntoDeValores = null;
            _conjuntoDeModas = null;
        }
        public static void moda()
        {
            decimal moda = _conjuntoDeModas.Max() + 1;//Por no inicializar a 1 todos los valores del conjuntoModa
            decimal valorModal = _conjuntoDeValores[Array.IndexOf(_conjuntoDeModas, moda)];
            Console.WriteLine($"El valor {valorModal} se repite un total de {moda} veces.");
        }
        public static decimal maximo()
        {
            return _conjuntoDeValores.Max();
        }
        public static decimal minimo()
        {
            return _conjuntoDeValores.Min();
        }
        //---------------------------------------------------------------------------------------------------------------------------------------

    }
    /*
        //ANOTACIONES
        
        Main
            Console.WriteLine("El ingreso de valores resulto exitoso : " + Estatidista.ingresoDeValores(99,2,1,0,12,99,0,2,12,0.499,112,0.009));
            Estatidista.mostrarValoresDelConjunto();

            Console.WriteLine("\n\nSe ingresa, a continuacion un tipo por valor pero que no es un tipo numerico.\n");

            Console.WriteLine("El ingreso de valores resulto exitoso : " + Estatidista.ingresoDeValores(99, 2, 1, 0, 1.2, DateTime.Now, -9.9999191821, 0, 2, 12));
            Estatidista.mostrarValoresDelConjunto();

            Estatidista.mostrarValoresOrdenados();

            Console.WriteLine("\n\n");

            Estatidista.ordenarValores(false);
            Estatidista.mostrarValoresOrdenados();

        Clase
            private static ValueType[] _conjuntoDeValores;
            private static ValueType[] _conjuntoDeValoresOrdenados;

            public static bool ingresoDeValores(params ValueType[] valores)
            {
                _conjuntoDeValores = new ValueType[valores.Length];

                for(int i = 0; i< valores.Length; i++)
                {

                    if (!_IsNumeric(valores[i]))
                    {
                        _conjuntoDeValores = null;
                        return false;
                    }
                    _conjuntoDeValores[i] = valores[i];

                }

                return true;
            }
            public static void ordenarValores(bool alRevez = false)
            {
                _conjuntoDeValoresOrdenados = null;//En caso de que se requiera un nuevo orden
                if (_conjuntoDeValores is null)
                {
                    Console.WriteLine("El conjunto original se encuentra vacio; no hay datos para ordenar.");
                    return;
                }
                _conjuntoDeValoresOrdenados = new ValueType[_conjuntoDeValores.Length];
                Array.Copy(_conjuntoDeValores, _conjuntoDeValoresOrdenados, _conjuntoDeValores.Length);

                try
                {
                    Array.Sort(_conjuntoDeValoresOrdenados);
                }
                catch (InvalidOperationException Ex)
                {
                    Console.WriteLine($"Ocurrio una excepcion al intentar ordenar el arreglo\n{Ex.Message}");
                }
                if (alRevez) Array.Reverse(_conjuntoDeValoresOrdenados);
            }//Se deja opcional el ordenamiento para poder contar con el conjunto original
            public static void mostrarValoresDelConjunto()
            {
                if(_conjuntoDeValores is null)
                {
                    Console.WriteLine("El conjunto de valores actual se encuentra vacio, o ocurrio algun error durante el ingreso de datos.");
                    return;
                }
                else
                {
                    foreach (ValueType item in _conjuntoDeValores)
                        Console.Write(item.ToString() + "  ");
                }
            }
            public static void mostrarValoresOrdenados()
            {
                if(_conjuntoDeValoresOrdenados is null)
                {
                    Console.WriteLine("El conjunto de valores ordenados actual se encuentra vacio, o ocurrio algun error durante el ingreso de datos en el conjunto original.");
                    return;
                }
                else
                {
                    foreach (ValueType item in _conjuntoDeValoresOrdenados)
                        Console.Write(item.ToString() + "  ");
                }
            }
            public static void limpiarConjuntoDeDatos()
            {
                _conjuntoDeValores = null;
                _conjuntoDeValoresOrdenados = null;
            }
            public static ValueType moda() 
            {
                return -1;
            }
            public static ValueType maximo() 
            {
                return -1;
            }
            private static bool _IsNumeric(ValueType value)
            {
                //Metodo extraido de Microsoft Learn https://learn.microsoft.com/en-us/dotnet/api/system.valuetype?view=net-8.0

                return (value is Byte ||
                        value is Int16 ||
                        value is Int32 ||
                        value is Int64 ||
                        value is SByte ||
                        value is UInt16 ||
                        value is UInt32 ||
                        value is UInt64 ||
                        value is BigInteger ||
                        value is Decimal ||
                        value is Double ||
                        value is Single);
            }    


     */
}