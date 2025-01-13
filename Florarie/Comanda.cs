namespace Florarie;
public enum StatusComandaBuchet
{
    InPreluare,
    AsteptareMaterie,
    InLucru,
    Finalizat,
    Revendicat
    
}
public class Comanda
{
    public string CodUnic { get; set; }
    public Client Client { get; set; }
    public string Nume { get; set; }
    public string Telefon { get; set; }
    public string Descriere { get; set; }
    public StatusComandaBuchet Status { get; set; }
}