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
    public void MeniuAutentificat()
    {
        Console.WriteLine($"\nBine ai revenit, {_utilizatorAutentificat.Nume} {_utilizatorAutentificat.Prenume}!\n");

        if (_utilizatorAutentificat is Angajat)
        {
            MeniuAngajat();
        }
        else
        {
            MeniuClient();
        }
    }
    public void MeniuAngajat()
    {
        Console.WriteLine("[1] Vizualizare comenzi buchete\n[2] Comanda materie pentru buchete\n[3] Preluare materie pentru buchete\n[4] Preluare comanda buchet\n[5] Finalizare comanda buchet\n[6] Vizualizare reviews\n[7] Iesire din cont");
        Console.Write("Alege o optiune: ");
        var optiune = Console.ReadLine();

        switch (optiune)
        {
            case "1":
                VizualizareComenzi();
                break;
            case "2":
                ComandaMaterieBuchet();
                break;
            case "3":
                PreluareComandaMaterie();
                break;
            case "4":
                PreluareComandaBuchet();
                break;
            case "5":
                FinalizareComanda();
                break;
            case "6":
                VizualizareReview();
                break;
            case "7":
                _utilizatorAutentificat = null;
                Console.WriteLine("Te-ai delogat cu succes.");
                break;
            default:
                Console.WriteLine("Optiune invalida!");
                break;
        }
    }
    public void VizualizareComenzi()
    {
        foreach (var comanda in Comenzi)
        {
            Console.WriteLine($"Comanda {comanda.CodUnic}: {comanda.Descriere} - Status: {comanda.Status}");
        }
    }
    public void ComandaMaterieBuchet()
    {
        Console.Write("Descriere materie: ");
        var descriere = Console.ReadLine();

        Console.Write("Cod Unic materie (numai numere): ");
        var codUnic = Console.ReadLine();

        Console.WriteLine("[1] InAsteptare\n[2] Finalizat");
        Console.Write("Status comanda materie: ");
        var statusInput = Console.ReadLine();
        StatusComanda status = statusInput switch
        {
            "1" => StatusComanda.InAsteptare,
            "2" => StatusComanda.Finalizat,
            _ => StatusComanda.InAsteptare,
        };

        ComenziMaterie.Add(new ComandaMaterie
        {
            Descriere = descriere,
            CodUnic = codUnic,
            Status = status
        });

        Console.WriteLine("Comanda de materie adaugata cu succes.");
    }
    public void PreluareComandaMaterie()
    {
        Console.WriteLine("Selecteaza comanda materie de preluat:");
        foreach (var comanda in ComenziMaterie.Where(c => c.Status == StatusComanda.InAsteptare))
        {
            Console.WriteLine($"- {comanda.CodUnic}: {comanda.Descriere}");
        }

        var codUnicComanda = Console.ReadLine();
        var comandaMaterie = ComenziMaterie.FirstOrDefault(c => c.CodUnic == codUnicComanda && c.Status == StatusComanda.InAsteptare);
        var comandaBuchet = Comenzi.FirstOrDefault(c => c.Status == StatusComandaBuchet.AsteptareMaterie);
        if (comandaMaterie != null)
        {
            comandaMaterie.Status = StatusComanda.Finalizat;
            Console.WriteLine("Comanda de materie preluata.");
            if(comandaBuchet != null)
                comandaBuchet.Status = StatusComandaBuchet.InLucru;
        }
        else
        {
            Console.WriteLine("Comanda de materie nu exista sau este deja finalizata.");
        }
    }
    public void MeniuClient()
    {
        Console.WriteLine("[1] Comanda buchet\n[2] Vizualizare istoric comenzi\n[3] Vizualizare detalii comanda\n[4] Ridicare comanda\n[5] Review comanda\n[6] Iesire din cont");
        Console.Write("Alege o optiune: ");
        var optiune = Console.ReadLine();

        switch (optiune)
        {
            case "1":
                ComandaBuchet();
                break;
            case "2":
                VizualizareIstoricComenzi();
                break;
            case "3":
                VizualizareDetaliiComanda();
                break;
            case "4":
                //RidicareComanda();
                break;
            case "5":
               // ReviewComanda();
                break;
            case "6":
                _utilizatorAutentificat = null;
                Console.WriteLine("Te-ai delogat cu succes.");
                break;
            default:
                Console.WriteLine("Optiune invalida!");
                break;
        }
    }
    public void ComandaBuchet()
    {
        Console.Write("Nume persoana pentru care este buchetul: ");
        var numePersoana = Console.ReadLine();
        Console.Write("Descriere buchet: ");
        var descriere = Console.ReadLine();
        Console.Write("Numarul de telefon: ");
        var numar = Console.ReadLine();
       // if (ValidareNumarTelefon(numar))
       // {
            Comenzi.Add(new Comanda
            {
                CodUnic = $"CMD{Comenzi.Count + 1}",
                Client = _utilizatorAutentificat as Client,
                Nume = numePersoana,
                Telefon = numar,
                Descriere = descriere,
                Status = StatusComandaBuchet.InPreluare
            });
            Console.WriteLine("Comanda a fost plasata cu succes.");
       // }
        //else
          //  Console.WriteLine("Numar de telefon invalid. Comanda nu a fost plasata.");
    }
    public void VizualizareIstoricComenzi()
    {
        var client = _utilizatorAutentificat as Client;
        Console.WriteLine("Istoricul comenzilor tale:");
        foreach (var comanda in Comenzi.Where(c => c.Client == client))
        {
            Console.WriteLine($"Comanda {comanda.CodUnic}: {comanda.Descriere} - Status: {comanda.Status}");
        }
    }
    public void VizualizareDetaliiComanda()
    {
        Console.Write("Introduceti codul unic al comenzii pentru detalii: ");
        var codComanda = Console.ReadLine();
        var comanda = Comenzi.FirstOrDefault(c => c.CodUnic == codComanda && c.Client == _utilizatorAutentificat);
        if (comanda != null)
        {
            Console.WriteLine($"Comanda {comanda.CodUnic}: {comanda.Descriere}");
            Console.WriteLine($"Status: {comanda.Status}");
            Console.WriteLine($"Nume persoana: {comanda.Nume}");
        }
        else
        {
            Console.WriteLine("Comanda nu a fost gasita sau nu apartine dumneavoastra.");
        }
    }
}