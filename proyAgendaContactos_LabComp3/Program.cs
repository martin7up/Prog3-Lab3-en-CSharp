namespace proyAgendaContactos_LabComp3
{
    internal static class Program
    {
        public static Persona[] personas = 
        { 
            new Persona("Eugenia","Denise",23,44589212), 
            new Persona("Carlos", "Denise", 33, 34582112),
            new Persona("Omar", "Pavel", 25, 39589102),
            new Persona("Orlando", "Cardozo", 43, 27189231),
        };
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
    public class Persona
    {
        uint _dni, _edad;
        string _nombre, _apellido;
        public static Random rnd = new();
        public uint Id { get; private set; }
        public DateTime Creacion { get; private set; }
        public string NombreCompleto { get { return _apellido + " " + _nombre; } }
        public Persona(string nombre, string apellido, uint edad, uint dni)
        {
            _dni = dni;
            _edad = edad;
            _nombre = nombre;
            _apellido = apellido;
            Creacion = DateTime.Now;
            Id = (uint)rnd.Next(35, 100)*(_dni - _edad);
        }
        public override string ToString()
        {
            return $"{NombreCompleto} ({Id})";
        }
    }
}