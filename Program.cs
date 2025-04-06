

public class Program
{

    public static bool Stop = true;
    public const string FILE_PATH = @"tournoi.json";
    public static List<Guild> GuildList = new List<Guild>();
    public static List<Champion> ChampionList = new List<Champion>();

 
    public static void Main()
    {
        
        do
        {
        Menu.AfficherMenu();
        Console.WriteLine("Selectionner l'option");
        string ChoixUser = Console.ReadLine()!;
        
        switch (ChoixUser)
        {
            case "1":
            LogicPrincipal.MiseAjourDunCombat(FILE_PATH, GuildList);
            
            Console.WriteLine("");
            LogicPrincipal.AfficherToutLesGuilds(FILE_PATH, GuildList);


             // Automatique a chaque instruction
            LogicPrincipal.SupressionAutomatique(FILE_PATH, GuildList);
            LogicPrincipal.SupprimerGuideAvecChampionsVide(FILE_PATH, GuildList);
        
     

            break;
            case "2":
             LogicPrincipal.MiseAjourDunCombat(FILE_PATH, GuildList);
            Console.WriteLine();
            LogicPrincipal.AjouterChampion(GuildList, FILE_PATH);

            // Automatique a chaque instruction
            LogicPrincipal.SupressionAutomatique(FILE_PATH, GuildList);
            LogicPrincipal.SupprimerGuideAvecChampionsVide(FILE_PATH, GuildList);
        
            break;
            case "3":
          
          
            break;
            case "4":
            Stop = false;
            Console.WriteLine();
          
       
            //LogicPrincipal.MiseAjourDunCombat(FILE_PATH, GuildList);
            break;
            
            default:
            Console.WriteLine($"{ChoixUser} n'existe pas desole");
            break;
        }

        }while(Stop);
        



    }
}