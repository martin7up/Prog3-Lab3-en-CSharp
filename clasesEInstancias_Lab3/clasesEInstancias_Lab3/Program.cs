
using System.Transactions;

HuincaClass huinca = new HuincaClass("InodoroToro - a.k.a. Crestiano macho.");
HuincaClass huainca = new HuincaClass();

huinca.edad = 12;
huinca.presentarHuinca();
int numero;
float numFloat;
huinca.numeroDeLaSuerteDelHuinca(out numero, out numFloat);
Console.WriteLine($"Numero del huinca {numero}\nNumero de la suerte del huinca {numFloat}");

huainca.presentarHuinca();

Ranquel ranQuel = new Ranquel(edad : 32, nombreCacique : "Cacique Lloriqueo");
ranQuel.presentarRanquel();

public class Ranquel
{
    public string nombreCacique;
    public int edad;
    public static string raza = "Ranquel";
    private int numeroDni;
    public int _numeroDni    
    {
        get
        {
            return numeroDni;
        }
        set
        {
            numeroDni = value > 0 ? value : -1; 
        }
    }

    public Ranquel() { }
    public Ranquel(string nombreCacique, int edad)
    {
        this.nombreCacique = nombreCacique;
        this.edad = edad;
    }

    public void presentarRanquel()
    {
        Console.WriteLine("Nombre del ranquel : " + this.nombreCacique + "; edad : " + this.edad + "; raza : " + raza);
    }
}
public class HuincaClass
{
    public string nombre;
    public int edad;
    static string raza = "Pampeano Criollo";

    public HuincaClass() { }
    public HuincaClass(string nombre)
    {
        
        this.nombre = nombre;   
    }

    public void presentarHuinca()
    {
        Console.WriteLine("Nombre del huinca : " + this.nombre + "; edad : " + this.edad + "; raza : " + raza);
    }

    public void numeroDeLaSuerteDelHuinca(out int num, out float numeroFlot)
    {
        num = edad + 13;
        numeroFlot = (float)(num) / 13;
    }
}

public abstract class Milico
{
    protected string nombre;
    protected string rango;

    protected Milico(string nombre, string rango)
    {
        this.nombre = nombre;
        this.rango = rango;
    }
    public abstract void presentarse();
}


public class Cabo : Milico
{
    public Cabo(string nombre) : base(nombre, rango : "Cabo")
    {
        this.nombre = nombre;
    }

    public override void presentarse()
    {
        Console.WriteLine($"Cabo {nombre}, reportandose.");
    }
}