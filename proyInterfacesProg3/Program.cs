namespace proyInterfacesProg3
{
    internal class Program
    {
        internal static IColeccionable[] coleccion =
            {
                new Libro("Ernesto Sabato","La Resistencia."),
                new Libro("Garcia Marquez","Cien anios de soledad."),
                new Libro("Hebe Rabufetti","Calculo 1"),
                new DVD("Atlantis."),
                new Libro("Spinadel","Metodos numericos"),
                new Libro("Lucia Baquedano","Cinco panes de cebada"),
                new Libro("Dimitry Glukovsky","Metro 2033"),
                new Revista("Tendencia de invierno.","Caras"),
                new DVD("Ciudad Oscura."),
                new Revista("Tendencia de verano.", "Caras"),
                new Revista("Inflacion.", "LN+"),
                new Revista("Avistamiento de ovnis.", "Muy Interesante"),
                new Libro("Jose Hernandez","Martin fierro"),
                new DVD("Nosferatu."),
                new Libro("Victor Hugo","Los miserables"),
                new Libro("Arnaldo Flores","Apunte de analisis 1"),
            };
        static void Main(string[] args)
        {
            Console.WriteLine("\n\nColeccion sin ordenar.\n.....................................");

            foreach (var item in coleccion)
                Console.WriteLine(item.Titulo);

            Console.WriteLine("\n\nColeccion ordenada alfabeticamente.\n.....................................");

            Array.Sort(coleccion);//Ordenado alfabetico Descendente
            Array.Reverse(coleccion);

            foreach (var item in coleccion)
                Console.WriteLine(item.Titulo);
        }
    }
    interface IColeccionable : IComparable<IColeccionable>
    {
        string Titulo { get; set; }
        string Describir();
        //implementacion por defecto p/evitar repetir codigo en las clases
        int IComparable<IColeccionable>.CompareTo(IColeccionable other) => string.Compare(other.Titulo, this.Titulo, true);
        //--Sin esta parte de arriba-- No funciona!
    }
    internal class Libro : IColeccionable
    {
        //Atributos
        string _autor, _titulo;

        //Propiedades        
        public string Autor { get { return _autor; } set { _autor = value.Trim().ToLower(); } }
        public string Titulo { get ;private set; }//Sin usar(Imp implicita), solo para ver implementacion implicita y explicita
        string IColeccionable.Titulo { get => _titulo; set => _titulo = value.Trim().ToLower(); }//Implementacion explicita

        //Constructor
        public Libro(string autor, string titulo)
        {
            Autor = autor;
            Titulo = titulo;//string Libro.Titulo
            ((IColeccionable)this).Titulo = titulo; //string IColeccionable.Titulo
            //(this as IColeccionable).Titulo = titulo;
        }

        //Metodos
        public string Describir()
        {
            return $"Titulo : {Titulo}; Autor : {_autor}.";
        }
    }
    internal class Revista : IColeccionable
    {
        //Atributos
        string _editorial;

        //Propiedades
        public string Titulo { get; set; }
        public uint Edicion { get; private set; }

        //Constructor
        public Revista(string Titulo, string editorial)
        {
            this.Titulo = Titulo;
            _editorial = editorial;
            Edicion = (uint)DateTime.Now.Year;
        }

        //Metodos
        public string Describir()
        {
            return $"Encabezado : {Titulo} en formato papel; edicion : {Edicion}; editorial : {_editorial}";
        }
    }
    internal class DVD : IColeccionable
    {
        //Propiedades
        public string Titulo { get; set; }
        public TimeSpan Duracion { get; private set; }

        //Constructor
        public DVD(string Titulo)
        {
            this.Titulo = Titulo;
            Duracion = new TimeSpan(new Random().Next(1,5), new Random().Next(0, 60), new Random().Next(0, 60));
        }

        //Metodos
        public string Describir()
        {
            return $"DVD : {Titulo}; Duracion : {Duracion.ToString("g")}";
        }
    }
    internal class VideoCassette { }
}
/*
    --------------------------------------------------------------NOTAS--------------------------------------------------------------------------
    
    _autor = string.IsNullOrEmpty(autor) || string.IsNullOrWhiteSpace(autor) ? @"////Autor No Asignado////" : autor.Trim().ToLower();
    _titulo = string.IsNullOrEmpty(titulo) || string.IsNullOrWhiteSpace(titulo) ? @"////Titulo No Asignado////" : titulo.Trim().ToLower();
    Titulo = _titulo + " " + $"ISBN : {_rnd.Next(1,DateTime.Now.Year)*_titulo.Length}";
    
    public static Random _rnd = new Random();

    public override string ToString()
    {
        return _autor + "   " +Titulo;
    }

    new Libro(null,"Libro11"),              //p/probar
    new Libro("arnaldo Flores",null),       //p/probar
    new Libro("                                          ","Libro12"),
    
    public int CompareTo(object? obj)//Metodo necesario para aplicar Array.Sort(algunArregloDeInstancias) sin plantear herencia de interfaces
    {
        if (obj is Libro temp) return string.Compare(temp._autor, _autor);
        throw new ArgumentException("\t\tError el argumento pasado no es del tipo Libro!");
    }

    public int CompareTo(IColeccionable other)
    {
        return string.Compare(((Libro)other)._autor, this._autor);
    }

    ---------------------------------------------------------------------------------------------------------------------------------------------
 */