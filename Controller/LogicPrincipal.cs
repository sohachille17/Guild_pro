

public static class LogicPrincipal
{
    // logic pricipal ici


    public static void AjouterChampion(List<Guild> GuildList,string FilePath )
    {

        GuildList = LogicJson.LoadStudentToList(FilePath);

        /* User Options */
        Console.WriteLine("Entrer les informations demander");
        Console.WriteLine("");
        
        Console.WriteLine("Entrez le nom de la guild : ");
        string? NomDeGuild = Console.ReadLine();

        
        Guild guild_ = GuildList.Find(gNom => gNom.NomGuilde == NomDeGuild)!;
        Console.WriteLine(guild_);
        if(guild_ != null)
        {
            Console.WriteLine("Ajouter nouveau champion: ");
            Console.WriteLine("");
            Console.WriteLine("Entrez Nom du champion");
    
            string? Nom = Console.ReadLine()!;

            Console.WriteLine("Entrez le Niveau du champion");
            string? Niveau__ = Console.ReadLine()!;
            int.TryParse(Niveau__, out int Niveau);

            Console.WriteLine("Status du champion est t-il actif (OUI / NON)");
            string? StringStatus = Console.ReadLine()!;
            bool Status = (StringStatus.ToLower() == "OUI".ToLower()) ? true : false;

            Console.WriteLine("");
            Console.WriteLine(Nom);
            Console.WriteLine(Niveau);
            Console.WriteLine(Status);

            guild_.Champions?.Add(

                 new Champion {
                    Nom = Nom,
                    Niveau = Niveau,
                    Actif = Status,
                    Combats = new List<Combat>()
                 
                }
            );
            Console.WriteLine("Nouveau champions ajouter");




        }else
        {
            Console.WriteLine("La guild n'existe pas");
        }
    }


}