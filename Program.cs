﻿

public class Program
{
    public const string FILE_PATH = @"tournoi.json";
    public static List<Guild> GuildList = new List<Guild>();
    public static void Main()
    {
        
        Menu.AfficherMenu();
        Console.WriteLine("Selectionner l'option");
        string ChoixUser = Console.ReadLine()!;
        
        switch (ChoixUser)
        {
            case "1":
            Console.WriteLine("");

            break;
            case "2":
            Console.WriteLine();
            LogicPrincipal.AjouterChampion(GuildList, FILE_PATH);
            break;
            case "3":
            Console.WriteLine();
            break;
            case "4":
            Console.WriteLine();
            break;
            
            default:
            Console.WriteLine($"{ChoixUser} n'existe pas desole");
            break;
        }


    }
}