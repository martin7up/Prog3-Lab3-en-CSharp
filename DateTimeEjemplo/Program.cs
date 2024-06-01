namespace DateTimeEjemplo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime dt1 = new DateTime(2035, 10, 25);
            DateTime dt2 = new DateTime(2033, 9, 12);
            TimeSpan ts = dt1.Subtract(dt2);
            Console.WriteLine(ts.TotalDays);
        }
    }
}
