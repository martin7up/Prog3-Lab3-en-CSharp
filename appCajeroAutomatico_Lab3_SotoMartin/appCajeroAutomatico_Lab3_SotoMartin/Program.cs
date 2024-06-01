namespace appCajeroAutomatico_Lab3_SotoMartin
{
    internal class Program
    {
        private static Cajero[] cajerosDisponibles = {new Cajero(9982712, "Donoban 9982"), new Cajero(9111092, "Urquisa 201"), new Cajero(119235, "Alverdi 82")};
        private static LinkedList<Cuenta> cuentasDisponibles = new LinkedList<Cuenta>();
        private static uint idBusqueda;
        static void Main(string[] args)
        {
            //Necesario p/funcionalidad solamente
            int indiceCajero = (new Random()).Next(0, 3);
            cuentasDisponibles.AddLast(new CuentaActivo("Cabrera Ecarnacion Silvia Diana", 2212));
            //Necesario p/funcionalidad solamente

            do
            {
                Console.Clear();
                Console.WriteLine($"---------------Bienvenido--------------\n{cajerosDisponibles[indiceCajero].ToString()}");
                
                menu(cajerosDisponibles[indiceCajero]);

                Console.WriteLine(">>> Presione <Esc> para salir, o cualquier tecla para operar nuevamente.");
                
            } while (Console.ReadKey().Key != ConsoleKey.Escape);

            Console.WriteLine("\n Gracias por emplear nuestros servicios.");
        }
        private static void menu(Cajero cajero)
        {
            Cuenta cuentaRecuperada;

            Console.Clear();
            Console.Write("Seleccione una operacion (solo el numero)\n<1>.........Crear una cuenta.\n<2>.........Ingresar a su cuenta" +
                    "\n<Esc>.........Salir\n>>> ");
            
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:

                    cuentasDisponibles.AddLast(crearCuenta());
                    Console.WriteLine("La cuenta se ha creado exitosamente.");
                    break;

                case ConsoleKey.D2:
                    cuentaRecuperada = ingresarACuenta();
                    if (cuentaRecuperada == null)
                    {
                        Console.WriteLine("No se encontro ninguna cuenta con el id proporcionado.");
                        break;
                    }
                    
                    cuentaRecuperada = (cuentaRecuperada is (CuentaActivo)) ? (CuentaActivo)cuentaRecuperada : (CuentaPasivo)cuentaRecuperada;
                    do
                    {
                        submenu(cuentaRecuperada, cajero);

                    } while (Console.ReadKey().Key != ConsoleKey.Escape);
                    break;

                default:
                    Console.WriteLine("Opcion no valida; intente de nuevo.");
                    break;
            }
        }
        private static void submenu(Cuenta cuenta, Cajero cajero)
        {
            decimal valor = 0;

            Console.Write("\nSubmenu de cuenta\nSeleccione una operacion (solo el numero)\n<1>_____Depositar efectivo.\n<2>_____Retirar efectivo" +
                            "\n<3>_____Retirar un adelanto\n<4>_____Pagar adelanto adeudado\n<Esc>_____Volver al menu primario");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    do Console.Write(valor == 0 ? "Ingrese el monto a depositar >>> " : ""); while (!decimal.TryParse(Console.ReadLine(), out valor));
                    cuenta.depositarValor(Math.Abs(valor),cajero);
                    break;

                case ConsoleKey.D2:
                    do Console.Write(valor == 0 ? "Ingrese el monto a retirar >>> " : ""); while (!decimal.TryParse(Console.ReadLine(), out valor));
                    cuenta.retirarValor(Math.Abs(valor), cajero);
                    break;

                case ConsoleKey.D3:
                    do Console.Write(valor == 0 ? "Ingrese el monto a retirar >>> " : ""); while (!decimal.TryParse(Console.ReadLine(), out valor));
                    cuenta.retirarAdelanto(Math.Abs(valor), cajero);
                    break;

                case ConsoleKey.D4:
                    cuenta.devolverAdelanto(cajero);
                    break;

                case ConsoleKey.Escape:
                    return;

                default:
                    Console.WriteLine("Opcion no valida; intente de nuevo.");
                    break;
            }
            return;
        }
        private static Cuenta crearCuenta()
        {
            string nombre;
            uint idCuenta;
            ConsoleKey tipoCuenta;

            do Console.Write("\n\nIngrese su nombre y apellido de cuenta >>> "); while (string.IsNullOrEmpty(nombre = Console.ReadLine().Trim()));

            Console.Write("\n\nIngrese si es Jubilado o Trabajador activo <J/A> >>> ");
            do tipoCuenta = Console.ReadKey().Key; while (tipoCuenta != ConsoleKey.A && tipoCuenta != ConsoleKey.J);

            do Console.Write("\n\nIngrese su id de cuenta generado >>> "); while (!uint.TryParse(Console.ReadLine(), out idCuenta));

            return (tipoCuenta == ConsoleKey.A) ? new CuentaActivo(nombre, idCuenta) : new CuentaPasivo(nombre, idCuenta);
        }
        private static Cuenta ingresarACuenta()
        {
            do Console.Write("\n\nIngrese su id de cuenta >>> "); while (!uint.TryParse(Console.ReadLine(), out idBusqueda));
            foreach (Cuenta cuenta in cuentasDisponibles)
                if (cuenta.idCuenta == idBusqueda)
                    return cuenta;
            return null;
        }

    }
    public class Cajero
    {
        private uint numeroCajero;
        private string direccion;
        public Cajero(uint numeroCajero, string direccion)
        {
            this.numeroCajero = numeroCajero;
            this.direccion = direccion;
        }
        public override string ToString()
        {
            return "Cajero numero : " + numeroCajero + "\nDireccion : " + direccion;
        }
    }
    abstract class Cuenta
    {
        protected string _nombreTitular;
        protected uint _idCuenta;
        protected decimal _saldo;
        protected decimal _saldoADebitar;
        protected bool _debeSaldo = false;
        protected Stack<Movimiento> _movimientos;
        public uint idCuenta
        {
            get
            {
                return _idCuenta;
            }
        }
        protected Cuenta(string nombreTitular, uint idCuenta)
        {
            _nombreTitular = nombreTitular;
            _idCuenta = idCuenta;
            _movimientos = new Stack<Movimiento>();
        }
        public abstract void verSaldo();
        public abstract void depositarValor(decimal valor, Cajero cajero);
        public abstract void retirarValor(decimal valor, Cajero cajero);
        public abstract void retirarAdelanto(decimal valor, Cajero cajero);
        public abstract void devolverAdelanto(Cajero cajero);
    }
    class CuentaActivo : Cuenta
    {
        protected decimal _valorAdelanto;
        public CuentaActivo(string nombreTitular, uint idCuenta) : base(nombreTitular, idCuenta)
        {
            _valorAdelanto = 20000;
        }
        public override void depositarValor(decimal valor, Cajero cajero)
        {
            _saldo += Math.Abs(valor);
            _movimientos.Push(new Movimiento(valor, _saldo, cajero, "Deposito"));
            Console.WriteLine("Operacion Exitosa : Deposito Recibido.");
        }
        public override void retirarAdelanto(decimal valor, Cajero cajero)
        {
            if (valor <= _valorAdelanto && ((_saldoADebitar + valor) <= _valorAdelanto))
            {
                _saldoADebitar += valor;
                _movimientos.Push(new Movimiento(valor, _saldo, cajero, "Adelanto"));
                Console.WriteLine("Operacion Exitosa : Adelanto Concedido.");
                return;
            }
            else
            {
                Console.WriteLine("Operacion Fallida : No dispone de ese cantidad para adelanto.");
                return;
            }
        }
        public override void devolverAdelanto(Cajero cajero)
        {
            if (_saldo > _saldoADebitar)
            {
                _saldo -= _saldoADebitar;
                _movimientos.Push(new Movimiento(_saldoADebitar, _saldo, cajero, "Pago de adelanto"));
                _saldoADebitar = 0;
                _debeSaldo = false;
                Console.WriteLine("Operacion Exitosa : Se ha debitado lo adeudado desde su saldo; ya no posee deuda de adelanto.");
                return;
            }
            Console.WriteLine("Operacion Fallida : Para pagar la deuda de adelanto, su saldo deber ser mayor a la deuda.");
        }
        public override void retirarValor(decimal valor, Cajero cajero)
        {
            if ((_saldo - valor >= 0))
            {
                _saldo -= valor;
                _movimientos.Push(new Movimiento(valor, _saldo, cajero, "Retiro"));
                Console.WriteLine("Operacion Exitosa : Retiro Concedido.");
            }
            else
            {
                Console.WriteLine("Operacion Fallida : No dispone de ese cantidad para retiro.");
                return;
            }
        }
        public override void verSaldo()
        {
            Console.WriteLine(_debeSaldo ? $"Su saldo actual es de : {_saldo} $ " : $"Su saldo actual es de : {_saldo} $ " +
                $"y debe {_saldoADebitar} $ correspondiente a un adelanto tomado con anterioridad.");
        }
    }
    class CuentaPasivo : CuentaActivo
    {
        public CuentaPasivo(string nombreTitular, uint idCuenta) : base(nombreTitular, idCuenta)
        {
            _valorAdelanto = 10000;
        }
    }
    class Movimiento
    {
        private decimal _valorMovido;
        private DateTime _fechaMovimiento;
        private decimal _saldoRestanteALaFecha;
        private string _tipoMov;
        private string _cajero;
        public Movimiento(decimal valorMovido, decimal saldoRestanteALaFecha, Cajero cajero, string tipoMov)
        {
            _fechaMovimiento = DateTime.Now;
            _valorMovido = valorMovido;
            _saldoRestanteALaFecha = saldoRestanteALaFecha;
            _cajero = cajero.ToString();
            _tipoMov = tipoMov;

        }
        public override string ToString()
        {
            return $"fecha : {_fechaMovimiento.ToString("d(es-AR)")} \n valor movido : {_valorMovido}" +
                $" \n saldo restante a la fecha indicada al comienzo : {_saldoRestanteALaFecha}" +
                $" \n {_cajero} \n {_tipoMov}";
        }
    }

}
