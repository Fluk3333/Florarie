namespace Florarie;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Aplicatie Florarie ===\n");
        Florarie f = new Florarie();
        f.InitializareUtilizatori();
        while (true)
        {
            if (f._utilizatorAutentificat == null)
            {
                f.MeniuNeautentificat();
            }
            else
            {
                f.MeniuAutentificat();
            }
        }
    }
}