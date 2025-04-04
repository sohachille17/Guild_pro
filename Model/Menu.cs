public static class Menu
{
    private const string NOM_APPLICATION = "***TORNADO***";
    public static void AfficherMenu()
    {
        Console.WriteLine($"Bienvenu chez {NOM_APPLICATION}");
        Console.WriteLine("");
        Console.WriteLine("[1].Afficher toutes les guildes, leurs champions et combats.");
        Console.WriteLine("[2].Ajouter un nouveau champion à une guilde existante, avec ses premiers combats.");
        Console.WriteLine("[3].Supprimer automatiquement :");
        Console.WriteLine("[4].Modifier le niveau des champions actifs :");
        Console.WriteLine("");
    }
}