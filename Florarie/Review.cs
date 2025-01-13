namespace Florarie;

public class Review : Comanda
{
    public int Stele { get; set; }
    public Client User { get; set; }
    public DateTime Data { get; set; }
}