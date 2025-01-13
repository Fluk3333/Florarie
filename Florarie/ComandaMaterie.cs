namespace Florarie;

public enum StatusComanda
{
    InAsteptare,
    Finalizat
}
public class ComandaMaterie
{
    public string CodUnic { get; set; }
    public string Descriere { get; set; }
    public string CodUnicMaterie { get; set; }
    public StatusComanda Status { get; set; }
}