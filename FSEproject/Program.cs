using System;
using System.Net.Http;
using System.Numerics;
using Newtonsoft.Json;
using System.Threading.Tasks;


namespace FSEproject
{
    public class Program
    {
        public static Dictionary<string, Dictionary<string, string>> Languages = new Dictionary<string, Dictionary<string, string>>
        {
            ["eng"] = new Dictionary<string, string>
            {
                ["just now"] = "just now",
                ["less than a minute ago"] = "less than a minute ago",
                ["a couple of minutes ago"] = "a couple of minutes ago",
                ["an hour ago"] = "an hour ago",
                ["today"] = "today",
                ["yesterday"] = "yesterday",
                ["this week"] = "this week",
                ["a long time ago"] = "a long time ago",
                ["was online"] = "was online"
            },
            ["spa"] = new Dictionary<string, string>
            {
                ["just now"] = "justo ahora",
                ["less than a minute ago"] = "hace menos de un minuto",
                ["a couple of minutes ago"] = "hace un par de minutos",
                ["an hour ago"] = "hace una hora",
                ["today"] = "hoy",
                ["yesterday"] = "ayer",
                ["this week"] = "esta semana",
                ["a long time ago"] = "hace mucho tiempo",
                ["was online"] = "estuvo en línea"
            },
            ["ukr"] = new Dictionary<string, string>
            {
                ["just now"] = "хвильку тому",
                ["less than a minute ago"] = "менше хвилини тому",
                ["a couple of minutes ago"] = "декілька хвилин тому",
                ["an hour ago"] = "годину тому",
                ["today"] = "сьогодні",
                ["yesterday"] = "вчора",
                ["this week"] = "цього тижня",
                ["a long time ago"] = "дуже давно",
                ["was online"] = "був онлайн"
            },
            ["fre"] = new Dictionary<string, string>
            {
                ["just now"] = "à l'instant",
                ["less than a minute ago"] = "il y a moins d'une minute",
                ["a couple of minutes ago"] = "il y a quelques minutes",
                ["an hour ago"] = "il y a une heure",
                ["today"] = "aujourd'hui",
                ["yesterday"] = "hier",
                ["this week"] = "cette semaine",
                ["a long time ago"] = "il y a longtemps",
                ["was online"] = "était en ligne"
            },
            ["ita"] = new Dictionary<string, string>
            {
                ["just now"] = "proprio ora",
                ["less than a minute ago"] = "meno di un minuto fa",
                ["a couple of minutes ago"] = "alcuni minuti fa",
                ["an hour ago"] = "un'ora fa",
                ["today"] = "oggi",
                ["yesterday"] = "ieri",
                ["this week"] = "questa settimana",
                ["a long time ago"] = "molto tempo fa",
                ["was online"] = "era online"
            },
        };

        public static string GetTextTime(DateTime lastSeen)
        {
            var timeSpan = DateTime.Now - lastSeen;

            if (timeSpan.TotalSeconds < 30) return "just now";
            if (timeSpan.TotalSeconds < 60) return "less than a minute ago";
            if (timeSpan.TotalMinutes < 59) return "a couple of minutes ago";
            if (timeSpan.TotalMinutes < 119) return "an hour ago";
            if (timeSpan.TotalDays < 1) return "today";
            if (timeSpan.TotalDays < 2) return "yesterday";
            if (timeSpan.TotalDays < 7) return "this week";
            return "a long time ago";
        }
        public static string CreateOutput(UsersData user, string Language)
        {
            if (user.lastSeenDate == null)
                return $"{user.nickname} {Languages[Language]["was online"]} {Languages[Language]["a long time ago"]}.";
            else
                return $"{user.nickname} {Languages[Language]["was online"]} {Languages[Language][GetTextTime((DateTime)user.lastSeenDate)]}.";
        }

        static async Task Main(string[] args)
        {
            Console.WriteLine("Fetching last seen data...");
            string apiUrl = "https://sef.podkolzin.consulting/api/users/lastSeen?offset=";
            var httpClient = new HttpClient();
            var offset = 0;
            var response = await httpClient.GetStringAsync(apiUrl + offset);
            Console.WriteLine(response);
            Console.WriteLine("Choose the language (eng, spa, ukr, fre, ita)");
            var Language = Console.ReadLine();
            while(Language == null) Language = Console.ReadLine();
            var usersData = JsonConvert.DeserializeObject<AllData>(response);
            if(usersData == null) return;
            foreach (var user in usersData.data)
            {
                Console.WriteLine(CreateOutput(user, Language));
            }
        }
    }
}