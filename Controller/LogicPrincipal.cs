

public static class LogicPrincipal
{
    // logic pricipal ici


    public static void MiseAjourDunCombat(string FilePath, List<Guild>GuildList)
    {
        //int NombreDeVictoire = 0;
        List<Combat> CombatList = new List<Combat>();
        GuildList = LogicJson.LoadGuldToList(FilePath);

        foreach(var guild in GuildList)
        {
            
            foreach(var champion in guild.Champions!)
    
            {

                if(champion.Actif == true)
                {
                    int CountComb = champion.Combats.Count(c => c.Resultat == "Victoire" && c.TypeEpreuve == "Magie");
                    if(CountComb >= 2)
                    {
                        champion.Niveau = champion.Niveau + 1;
                        //Console.WriteLine(champion.Niveau);
                        LogicJson.SaveGuildToJSON(FilePath, GuildList);
                    }
              

                 
                }
            }
        }


    //GuildList =  LogicJson.LoadGuldToList(FilePath);

    }


    public static void AfficherToutLesGuilds(string FilePath, List<Guild> GuildList)
    {
        // On modifie dabord avant d'afficher [A Dieu seul la Gloire]
        MiseAjourDunCombat(FilePath, GuildList);
        
        GuildList = LogicJson.LoadGuldToList(FilePath);
        // Afficher le resultat
        Console.WriteLine($"List des Guilds et les champions |* Guild Total: {GuildList.Count} *|");
        Console.WriteLine("");
        for(int i = 0; i < GuildList.Count; i++)
        {
            Console.WriteLine("");
            Console.WriteLine($"{i + 1} " + GuildList[i].NomGuilde);

            foreach(var Champion in GuildList[i].Champions!)
            {
                
                
              
                Console.WriteLine("");
                // Console.WriteLine($"|Nom Champion: "+ Champion.Nom + "   "+  "| Niveau: " +"    "+ Champion.Niveau +"  "+"| Status: " +(Champion.Actif == true ? " Actif ": " Inactif "));
                Console.WriteLine($"**Nom champion {Champion.Nom} | Niveau: {Champion.Niveau} | {(Champion.Actif == true ? "Actif" : "Inactif")}");
                Console.WriteLine("");
                Console.WriteLine("  List des combats disponible");
                Console.WriteLine("");
                for(int c = 0; c < Champion.Combats.Count ;c++ )
                {
                    Console.WriteLine($"  ({c + 1})TypeEpreuve: {Champion.Combats[c].TypeEpreuve}  | |Resultat: {Champion.Combats[c].Resultat}  | |Score: {Champion.Combats[c].Score}");
                    
                }
                Console.WriteLine($"  Total de combat: {Champion.Combats.Count}");
                
            }
        }
    }


    public static void AjouterChampion(List<Guild> GuildList,string FilePath )
    {
        // On modifie dabord avant d'afficher [A Dieu seul la Gloire]
        MiseAjourDunCombat(FilePath, GuildList);

        GuildList = LogicJson.LoadGuldToList(FilePath);

        /* User Options */
        Console.WriteLine("Entrez les informations demandes .");
        Console.WriteLine("");

        
        Console.WriteLine("Entrez le nom de la guild : ");
        string? NomDeGuild = Console.ReadLine();

        
        Guild guild_ = GuildList.Find(gNom => gNom.NomGuilde == NomDeGuild)!;



        if(guild_ != null)
        {

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





            guild_.Champions?.Add(

                 new Champion {
                    Nom = Nom,
                    Niveau = Niveau,
                    Actif = Status,
                    Combats = new List<Combat>() 
 
                 
                }
            );

            Console.WriteLine("***| -Ajouter un nouveau combat- |***");
            Console.WriteLine("");

            var combat = guild_.Champions?.Find(c=> c.Nom == Nom);
            Console.WriteLine("Combien de combat voulez vous ajouter :");
            string? Nombre = Console.ReadLine();
            bool IsConvert = int.TryParse(Nombre, out int NombreCombat );
            if(IsConvert)
            {
                while(NombreCombat > 0){

                    if(combat != null)
                        {
                            Console.WriteLine("Ajouter le TypeEpreuve ");
                            string? TypeEpreuve = Console.ReadLine();
                            
                            Console.WriteLine("Ajouter le Resultat ");
                            string? Resultat = Console.ReadLine();

                            Console.WriteLine("Ajouter le Score ");
                            string? Score_ = Console.ReadLine();
                            int.TryParse(Score_, out int Score);

                            combat.Combats.Add(
                                new Combat{
                                    TypeEpreuve = TypeEpreuve,
                                    Resultat = Resultat,
                                    Score = Score
                                }
                            );
                            Console.WriteLine($"Nouveau combat pour le champion {guild_.Champions} a ete ajouter dans fichier Json!");
                        }
                        NombreCombat--;

                }
            }


            



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