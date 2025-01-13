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
}