using static LINQInCsharp.Datastore;

namespace LINQInCsharp
{
    internal class AggregatorOerators
    {
        public static void UsingAggregators()
        {
            int query = Formula1.GetChampions().Count();

            int queryTwo = Formula1.GetChampions()
                .Take(3)
                .Sum(x => x.Wins);

            int queryThree = Formula1.GetChampions()
                .Take(3)
                .Min(x => x.Wins);
        }
    }
}
