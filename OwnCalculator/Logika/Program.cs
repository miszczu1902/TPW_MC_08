namespace Logika
{
    class Program
    {
        static void Main(string[] args)
        {
            Kula kula = new Kula(15, 10, 20);
            Console.WriteLine(kula.Radius);
            Console.WriteLine(kula.X);
            Console.WriteLine(kula.Y);

            Kula kula2 = new Kula();
            Generator gen = new Generator();
            gen.GenerateXY();
            kula2.X = gen.X;
            kula2.Y = gen.Y;
            Console.WriteLine(kula2.Radius);
            Console.WriteLine(kula2.X);
            Console.WriteLine(kula2.Y);
            
            Plansza plansza = new Plansza();
            Console.WriteLine(plansza.A);
            plansza.DodajKuleNaPlansze(kula);
            plansza.DodajKuleNaPlansze(kula2);
            plansza.WyswietlKule();
        }
    }
}
