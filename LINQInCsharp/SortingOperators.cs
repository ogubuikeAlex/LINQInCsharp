using static LINQInCsharp.Datastore;
using static LINQInCsharp.Datastore.Formula1;

namespace LINQInCsharp
{
    internal class SortingOperators
    {
        //OrderBy OrderByDescending
        public static void SortingViaQuerySyntax()
        {
            var racers = from racer in GetChampions()
                         orderby racer.Country, racer.FirstName, racer.LastName
                         select racer;

            var descendingRacers = from racer in GetChampions()
                                   orderby racer.Country, racer.FirstName descending
                                   select racer;

            foreach(var racer in descendingRacers)
            {
                Console.WriteLine($"Country:{racer.Country}, Firstname:{racer.FirstName}");
            }

        }

        public static void SortingViaMethodSyntax()
        {
            var racers = GetChampions()
                .OrderBy(x => x.Country)
                .ThenBy(x => x.FirstName)
                .ThenBy(x => x.LastName);

            var descendingRacers = GetChampions()
                 .OrderBy(x => x.Country)
                .ThenByDescending(x => x.FirstName)
                .ThenBy(x => x.LastName);

            foreach (var racer in descendingRacers)
            {
                Console.WriteLine($"Country:{racer.Country}, Firstname:{racer.FirstName}");
            }
        }
    }
}
