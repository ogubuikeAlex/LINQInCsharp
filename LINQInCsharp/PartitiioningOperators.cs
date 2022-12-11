using static LINQInCsharp.Datastore;

namespace LINQInCsharp
{
    internal class TakePartitiioningOperators
    {
        //Take, TakeWhile, TakeLast
        public static void UsingTake()
        {
            var takeSampleOne = Formula1.GetChampions().Take(5);

            foreach (var racer in takeSampleOne)
            {
                Console.WriteLine($"Country:{racer.Country}, Firstname:{racer.FirstName}");
            }
        }

        public static void UsingTakeWhile()
        {
            var takeWhileSampleOne = Formula1.GetChampions().TakeWhile(x => x.FirstName.Contains('o'));

            foreach (var racer in takeWhileSampleOne)
            {
                Console.WriteLine($"Country:{racer.Country}, Firstname:{racer.FirstName}");
            }
        }

        public static void UsingTakeLast()
        {
            var takeLastSampleOne = Formula1.GetChampions().TakeLast(4);

            foreach (var racer in takeLastSampleOne)
            {
                Console.WriteLine($"Country:{racer.Country}, Firstname:{racer.FirstName}");
            }
        }
    }

    internal class SkipPartitiioningOperators
    {
        //Skip, SkipWhile, SkipLast
        public static void UsingSkip()
        {
            var skipSampleOne = Formula1.GetChampions().Skip(5);

            foreach (var racer in skipSampleOne)
            {
                Console.WriteLine($"Country:{racer.Country}, Firstname:{racer.FirstName}");
            }
        }

        public static void UsingSkipWhile()
        {
            var skipSampleOne = Formula1.GetChampions()
                .SkipWhile(x => x.Country.ToLower().Contains('a')
                || x.Country.Contains('A'));

            foreach (var racer in skipSampleOne)
            {
                Console.WriteLine($"Country:{racer.Country}, Firstname:{racer.FirstName}");
            }
        }
        public static void UsingSkipLast()
        {
            var skipSampleOne = Formula1.GetChampions().SkipLast(5);

            foreach (var racer in skipSampleOne)
            {
                Console.WriteLine($"Country:{racer.Country}, Firstname:{racer.FirstName}");
            }
        }
    }

    internal class PartitiioningOperatorsWithRangeAndIndex
    {
        //Skip, SkipWhile, SkipLast
        Index index = 1;
        Range range = 1..3;

        public static void UsingSkip()
        {
            var skipSampleOne = Formula1.GetChampions().Skip(3).Take(2);

            var skipSampleTwo = Formula1.GetChampions().Take(3..5);

            foreach (var racer in skipSampleTwo)
            {
                Console.WriteLine($"Country:{racer.Country}, Firstname:{racer.FirstName}");
            }
        }

    }
}
