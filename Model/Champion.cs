public class Champion
{
    public string? Nom { get; set; }
    public int Niveau { get; set; }
    public bool Actif { get; set; }
    public List<Combat> Combats { get; set; } = new List<Combat>();
    
}