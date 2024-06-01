/*
    Enunciado del problema:

    Un zoológico desea desarrollar un sistema para gestionar sus animales y cuidadores.
    El sistema debe permitir la creación y gestión de diferentes tipos de animales, incluyendo mamíferos, aves, peces y una planta carnívora.
    Cada animal debe tener un nombre, una especie y un tipo de comida asociado. 
    Los mamíferos deben ser capaces de amamantar, las aves deben poder volar y los peces deben poder nadar. 
    Además, se requiere la capacidad de crear una planta carnívora que se alimente de otros seres vivos.
    Los cuidadores serán responsables de alimentar a los animales. 
    Cada cuidador debe tener un nombre y ser capaz de alimentar a los animales bajo su cuidado con la comida adecuada. 
    Esto incluye tanto a los animales convencionales como a la planta carnívora.
    El zoológico debe tener la capacidad de administrar tanto a los animales como a los cuidadores. 
    Esto implica la capacidad de agregar, eliminar y actualizar la información de los animales y cuidadores. 
    Además, el zoológico debe ser capaz de mostrar la lista de animales y cuidadores disponibles.
    El sistema debe ser implementado en C# y ejecutarse por consola. 
    Los alumnos deberán utilizar herencia, polimorfismo, interfaces y métodos virtuales para garantizar la flexibilidad y extensibilidad del sistema. 
    Además, se debe implementar la inyección de dependencias para permitir que los cuidadores alimenten a cualquier tipo de animal, incluida 
    la planta carnívora.
 */
namespace proyectoZooLabComp3_TUP_SotoMartin_Leg26907
{
    internal class Program
    {
        LinkedList<seresVivosEnCautiverio> seresVivosEnCautiverios;
        LinkedList<Empleado> empleados;
        static void Main(string[] args)
        {
            

        }







        private static uint mostrarEspecies()
        {
            int maximoIndice = Enum.GetNames(typeof(especies)).Length;

            for (int i = 0; i < maximoIndice; i++)
            {
                Console.WriteLine(Enum.GetName(typeof(especies), i) + " -> " + i);
            }

            uint opcion;

            do Console.Write(" >>> "); while (uint.TryParse(Console.ReadLine(), out opcion) && opcion > 5);

            return opcion;
        }
        private static especies seleccionarUnaEspecie(uint opcion)
        {
            return (especies)opcion;
        }
        private static uint mostrarAlimentaciones()
        {
            int maximoIndice = Enum.GetNames(typeof(alimentacion)).Length;

            for (int i = 0; i < maximoIndice; i++)
            {
                Console.WriteLine(Enum.GetName(typeof(alimentacion), i) + " -> " + i);
            }

            uint opcion;

            do Console.Write(" >>> "); while (uint.TryParse(Console.ReadLine(), out opcion) && opcion > 5);

            return opcion;
        }
        private static alimentacion seleccionarUnaAlimentacion(uint opcion)
        {
            return (alimentacion)opcion;
        }
    }
    public interface seresVivosEnCautiverio 
    {
        public string nombreCientifico();
    }
    public enum especies : uint
    {
        PECES = 1, 
        AVES = 2,
        REPTILES = 3,
        MAMIFEROS = 4,
        ANFIBIOS = 5,
        PLANTAS_CARNIVORAS = 0
    }
    public enum alimentacion
    {
        CARNIVORO = 10,
        HERVIVORO = 11
    }
    public abstract class Empleado
    {
        protected string _nombre;
        public string nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
            }
        }
        protected Empleado(string nombre)
        {
            this.nombre = nombre;
        }
    }
    public sealed class Cuidador : Empleado
    {
        public Cuidador(string nombre) : base(nombre)
        {
        }
        public void darDeComer(seresVivosEnCautiverio serVivo)
        {
            Console.WriteLine($"El cuidador de nombre {_nombre}, da de comer a {serVivo.nombreCientifico()}");
        }
    }
    public abstract class Animal : seresVivosEnCautiverio
    {
        protected string _nombre;// Leon, Gaviota, Pez Espada, etc...
        protected especies _especie;
        protected alimentacion _alimentacion;
        public string nombre
        {
            get
            {
                return _nombre;
            }

            set
            {
                _nombre = value;
            }
        }
        public especies especie
        {
            get
            {
                return _especie;
            }
            set
            {
                _especie = value;
            }
        }
        public alimentacion alimento
        {
            get
            {
                return _alimentacion;
            }
            set
            {
                _alimentacion = value;
            }
        }
        protected Animal(string nombre, especies especie, alimentacion alimento)
        {
            _nombre = nombre;
            _especie = especie;
            _alimentacion = alimento;
        }
        public abstract void alimentarse();
        public abstract void moverseSegunGenero();
        public override string ToString()
        {
            return $"Nombre Animal : {_nombre}\nEspecie : {_especie}\nAlimentacion : {_alimentacion}";
        }

        public string nombreCientifico()
        {
            return this.nombre;
        }
    }
    public class Ave : Animal
    {
        public Ave(string nombre, especies especie, alimentacion alimento) : base(nombre, especie, alimento)
        {
        }
        public override void alimentarse()
        {
            Console.WriteLine($"El/La {_nombre} de la especie tipo {_especie}; se esta alimentando como el {_alimentacion} que es." +
                "\n *Ruidos de Ave comiendo...*");
        }

        public override void moverseSegunGenero()
        {
            Console.WriteLine("*Volando como el ave que es...*");
        }
    }
    public class Pez : Animal
    {
        public Pez(string nombre, especies especie, alimentacion alimento) : base(nombre, especie, alimento)
        {
        }
        public override void alimentarse()
        {
            Console.WriteLine($"El/La {_nombre} de la especie tipo {_especie}; se esta alimentando como el {_alimentacion} que es." +
                "\n *Ruidos de Pez comiendo...*");
        }

        public override void moverseSegunGenero()
        {
            Console.WriteLine("*Nadando como el pez que es...*");
        }
    }
    public class Mamifero : Animal
    {
        public Mamifero(string nombre, especies especie, alimentacion alimento) : base(nombre, especie, alimento)
        {
        }
        public override void alimentarse()
        {
            Console.WriteLine($"El/La {_nombre} de la especie tipo {_especie}; se esta alimentando como el {_alimentacion} que es." +
                "\n *Ruidos de Mamifero comiendo...*");
        }

        public override void moverseSegunGenero()
        {
            Console.WriteLine("*Moviendose como mamifero; nada si es cetaceo, vuela si es murcielago o anda sobre tierra si es oso.*");
        }
        public void amamantar()
        {
            Console.WriteLine("*Dando de amamantar a su crias, si las tiene.*");
        }

    }
    public class PlantaCarnivora : seresVivosEnCautiverio
    {
        private string _nombre;
        private especies _especie;
        private alimentacion _alimentacion;
        public PlantaCarnivora(string nombre)
        {
            _nombre = nombre;
            _especie = especies.PLANTAS_CARNIVORAS;
            _alimentacion = alimentacion.CARNIVORO;
        }

        public string nombreCientifico()
        {
            return this._nombre;
        }
    }
}
