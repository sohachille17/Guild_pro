

public static class LogicPrincipal
{
    // logic pricipal ici

    public static void MiseAjourDunCombat(string FilePath, List<Guild>GuildList)
    {
        //int NombreDeVictoire = 0;
        List<Combat> CombatList = new List<Combat>();
        GuildList = LogicJson.LoadStudentToList(FilePath);

        foreach(var guild in GuildList)
        {
            foreach(var champion in guild.Champions!)
    
            {
                //var r = guild.Champions.GroupBy(kv => kv.Actif == true).SelectMany(pk => pk.).ToList();
                if(champion.Actif == true)
                {
              
                     var result = champion.Combats
                    .GroupBy(kv => kv.Resultat == "Victoire" && kv.TypeEpreuve == "Magie") // Group by key
                    .Where(group => group.Count() >= 2) // Only keep groups with 2+ elements
                    .SelectMany(group => group).ToList(); // Flatten back into a list

                    
                foreach(var combat in result){
                    Console.WriteLine(combat.Score);
                    }
                 
                }
            }
        }


    }


    public static void AfficherToutLesGuilds(string FilePath, List<Guild> GuildList)
    {
        GuildList = LogicJson.LoadStudentToList(FilePath);
        // Afficher le resultat
        Console.WriteLine($"List des Guilds et les champions |* Guild Total: {GuildList.Count} *|");
        Console.WriteLine("");
        for(int i = 0; i < GuildList.Count; i++)
        {
            Console.WriteLine($"{i + 1} " + GuildList[i].NomGuilde);
            foreach(var Champion in GuildList[i].Champions!)
            {
              
                Console.WriteLine($"Nom Champion: "+ Champion.Nom + " Niveau: " +" "+ Champion.Niveau + " Status: " + Champion.Actif);
                
            }
        }
    }


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


            // Ajouter Combat
            Console.WriteLine("Ajouter un nouveau combat");
            Console.WriteLine("Ajouter le TypeEpreuve ");
            string? TypeEpreuve = Console.ReadLine();
            
            Console.WriteLine("Ajouter le Resultat ");
            string? Resultat = Console.ReadLine();

            Console.WriteLine("Ajouter le Score ");
            string? Score_ = Console.ReadLine();
            int.TryParse(Score_, out int Score);


            guild_.Champions?.Add(

                 new Champion {
                    Nom = Nom,
                    Niveau = Niveau,
                    Actif = Status,
                    Combats = new List<Combat> 
                    {
                        new Combat{
                            TypeEpreuve = TypeEpreuve,
                            Resultat = Resultat,
                            Score = Score
                        }
                    }
                 
                }
            );




            Console.WriteLine(" ");
            Console.WriteLine($"{STATUS_CODE.SUCCESS} Nouveau champions ajouter avec ses combat {STATUS_CODE.SUCCESS} ");
            // sauvegardez dans fichier JSON
            LogicJson.SaveGuildToJSON(FilePath, GuildList);


        }else
        {
            Console.WriteLine($"La guild {NomDeGuild} n'existe pas");
            
        }



    }


}