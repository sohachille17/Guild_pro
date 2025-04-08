

public static class LogicPrincipal
{
    // logic pricipal ici


    public static void MiseAjourDunCombat(string FilePath, List<Guild>GuildList)
    {
        
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

            var Champion_ = guild_.Champions?.Find(c=> c.Nom == Nom);
            Console.WriteLine("Combien de combat voulez vous ajouter :");
            string? Nombre = Console.ReadLine();
            bool IsConvert = int.TryParse(Nombre, out int NombreCombat );
            if(IsConvert)
            {
                while(NombreCombat > 0){

                    if(Champion_ != null)
                        {
                            Console.WriteLine("Ajouter le TypeEpreuve ");
                            string? TypeEpreuve = Console.ReadLine();
                            
                            Console.WriteLine("Ajouter le Resultat ");
                            string? Resultat = Console.ReadLine();

                            Console.WriteLine("Ajouter le Score ");
                            string? Score_ = Console.ReadLine();
                            int.TryParse(Score_, out int Score);

                            Champion_.Combats.Add(
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


    //DELETE
    public static void SupressionAutomatique(string FielPath , List<Guild> GuildList)
    {
      
        
        GuildList = LogicJson.LoadGuldToList(FielPath);

        // La recherche 
        for(int i = 0; i < GuildList.Count; i++)
        {
           
           for(int j = 0 ; j < GuildList[i].Champions!.Count; j++)
           {
            if(GuildList[i].Champions![j].Actif == false)
            {
                const int NUM_FIX_DELIMITER = 60;
                
                
                int CountCombat = GuildList[i].Champions![j].Combats.Count();
                int Somme = GuildList[i].Champions![j].Combats.Sum(c => c.Score);
                int Moyenne = Somme / CountCombat;

                // Verifications des  Champions nombre et somme de < 2 ET < 60
                if(CountCombat < 2 || Moyenne < NUM_FIX_DELIMITER)
                {
                    try
                    {
                        GuildList[i].Champions!.Remove(GuildList[i].Champions![j]);
                       // GuildList[i].Champions!.RemoveAll(c => c != null);
                        Console.WriteLine("Deleted Successfully!");
                    }catch(Exception)
                    {
                        Console.WriteLine("Desole combat listes vide ");
                    }


                    
                    LogicJson.SaveGuildToJSON(FielPath, GuildList);
                    
                }
                
                
            }
           }
            

                

            }
       }
       public static void SupprimerGuideAvecChampionsVide(string FilePath, List<Guild>GuildList)
       {

        GuildList = LogicJson.LoadGuldToList(FilePath);
        for(int i = 0; i < GuildList.Count; i++)
        {
            Console.WriteLine(GuildList[i].Champions!.Count);
            if(GuildList[i].Champions!.Count == 0)
            {
                GuildList.Remove(GuildList[i]);
                Console.WriteLine($"Guild deleted successfully!!");
                LogicJson.SaveGuildToJSON(FilePath, GuildList);
            }
            
        }

       }
    }




