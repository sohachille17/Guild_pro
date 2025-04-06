public static class Menu
{
    private const string NOM_APPLICATION = "***TORNADO***";
    public static void AfficherMenu()
    {
        Console.WriteLine($"Bienvenu chez {NOM_APPLICATION}");
        Console.WriteLine("");
        Console.WriteLine("[1].Afficher toutes les guildes, leurs champions et combats.");
        Console.WriteLine("[2].Ajouter un nouveau champion à une guilde existante et ses combats");
        Console.WriteLine("SUPP");
        Console.WriteLine("");
        Console.WriteLine("A noter que les supression et modification sont automatique");


       
        Console.WriteLine("");
    }
}