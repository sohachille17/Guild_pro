
using System.Text.Json;

public static class LogicJson
{


    public static List<Guild> LoadStudentToList(string FilePath)
    {
        if(File.Exists(FilePath))
        {
            using(StreamReader Sr = File.OpenText(FilePath))
            {
                string JsonLoad = Sr.ReadToEnd();
                return JsonSerializer.Deserialize<List<Guild>>(JsonLoad)!;

            }
        }

        
        return new List<Guild>();

    }


    /* Save File to Json Object */
    public static void SaveGuildToJSON(string FilePath, List<Guild> GuildJson)
    {
        if(File.Exists(FilePath))
        {
            
            using(StreamWriter Sw = File.CreateText(FilePath))
                {
                try
                {
                    var JsonGuild = JsonSerializer.Serialize(GuildJson, new JsonSerializerOptions 
                    {
                        WriteIndented = true
                    });
                    // Save to Json...
                    Sw.Write(JsonGuild);
                    Console.WriteLine("New guild created succdessfully and saved to Json file");
                    
                }catch(JsonException)
                {
                    Console.WriteLine("JSON : 'Invalid JSON Object.'");
                }

                }
        }
        else
        {
            Console.WriteLine("Sorry, but file empty or null will be created automatically.");
        }
        

       

    }
}