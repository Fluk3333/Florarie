namespace Florarie;

public class Florarie
{
    public List<Utilizator> Utilizatori = new();
    public List<Comanda> Comenzi = new();
    public List<Review> Reviews = new();
    public List<ComandaMaterie> ComenziMaterie = new();
    public Utilizator _utilizatorAutentificat;
    public void InitializareUtilizatori()
    {
        // Adaugare utilizatori de test (1 angajat, 2 clienti)
        Utilizatori.Add(new Angajat
        {
            CodUnic = "ANG1",
            Nume = "Popescu",
            Prenume = "Ion",
            Email = "ion.popescu@florarie.ro", 
            Parola = "1234"
        });

        Utilizatori.Add(new Client
        {
            CodUnic = "CLI1", 
            Nume = "Ionescu", 
            Prenume = "Maria", 
            Email = "maria.ionescu@gmail.com", 
            Parola = "abcd"
        });

        Utilizatori.Add(new Client
        {
            CodUnic = "CLI2", 
            Nume = "Georgescu", 
            Prenume = "Vasile", 
            Email = "vasile.georgescu@yahoo.com", 
            Parola = "5678"
        });
        
        Comenzi.Add(new Comanda { CodUnic = "CMD1", Client = Utilizatori[1] as Client, Nume = "Ion Popescu", Telefon = "0748123456", Descriere = "Buchet pentru aniversare", Status = StatusComandaBuchet.InPreluare });
        Comenzi.Add(new Comanda { CodUnic = "CMD2", Client = Utilizatori[2] as Client, Nume = "Vasile Georgescu", Telefon = "0754321876", Descriere = "Buchet de flori pentru ziua mamei", Status = StatusComandaBuchet.AsteptareMaterie });
        
        ComenziMaterie.Add(new ComandaMaterie { CodUnic = "1", Descriere = "Flori de trandafir", CodUnicMaterie = "123", Status = StatusComanda.InAsteptare });
        ComenziMaterie.Add(new ComandaMaterie { CodUnic = "2", Descriere = "Frunze de ferigă", CodUnicMaterie = "456", Status = StatusComanda.Finalizat });
    }
    public void MeniuNeautentificat()
    {
        Console.WriteLine("\n[1] Logare\n[2] Adauga Utilizator\n[3] Iesire\n");
        Console.Write("Alege o optiune: ");
        var optiune = Console.ReadLine();

        switch (optiune)
        {
            case "1":
                Logare();
                break;
            case "2":
                AdaugaUtilizator();
                break;
            case "3":
                Console.WriteLine("Iesire din aplicatie. La revedere!");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Optiune invalida!");
                break;
        }
    }
    public void Logare()
    {
        Console.Write("Email: ");
        var email = Console.ReadLine();
        Console.Write("Parola: ");
        var parola = Console.ReadLine();

        var utilizator = Utilizatori.FirstOrDefault(u => u.Email == email && u.Parola == parola);

        if (utilizator != null)
        {
            _utilizatorAutentificat = utilizator;
            Console.WriteLine("Logare reusita!");
        }
        else
        {
            Console.WriteLine("Email sau parola gresita.");
        }
    }
    public void AdaugaUtilizator()
    {
        Console.Write("Tip utilizator (angajat/client): ");
        var tip = Console.ReadLine()?.ToLower();

        Console.Write("Cod Unic: ");
        var codUnic = Console.ReadLine();

        Console.Write("Nume: ");
        var nume = Console.ReadLine();

        Console.Write("Prenume: ");
        var prenume = Console.ReadLine();

        Console.Write("Email: ");
        var email = Console.ReadLine();
        
        if (Utilizatori.Any(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine("Eroare: E-mailul este deja folosit de un alt utilizator.");
            return;
        }
        
        Console.Write("Parola: ");
        var parola = Console.ReadLine();

        switch (tip)
        {
            case "angajat":
                Utilizatori.Add(new Angajat
                {
                    CodUnic = codUnic, 
                    Nume = nume, 
                    Prenume = prenume, 
                    Email = email, 
                    Parola = parola
                });
                Console.WriteLine("Angajat adaugat cu succes.");
                break;
            case "client":
                Utilizatori.Add(new Client
                {
                    CodUnic = codUnic, 
                    Nume = nume, 
                    Prenume = prenume, 
                    Email = email, 
                    Parola = parola
                });
                Console.WriteLine("Client adaugat cu succes.");
                break;
            default:
                Console.WriteLine("Tip utilizator invalid. Incearca din nou.");
                break;
        }
    }
    
}