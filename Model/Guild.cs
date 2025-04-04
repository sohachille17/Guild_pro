

public class Guild
{
    public string? NomGuilde { get; set; }
    public string? Royaume { get; set; }
    public List<Champion>? Champions { get; set;} = new List<Champion>();
}