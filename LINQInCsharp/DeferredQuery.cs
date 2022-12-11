using static LINQInCsharp.Datastore;

namespace LINQInCsharp
{
    internal class DeferredQuery
    {
        static List<int> numbers = new() { 1, 2, 3, 20, 5, 7, 8, 10 };
        static List<int> numbersTwo = new() { 1, 2, 3, 20, 5, 7, 8, 10 };
        static List<int> numbersThree = new() { 1, 2, 3, 20, 5, 7 };
        static List<int> numbersModulo = new() { 1, 0, 1, 0, 1, 1, 0, 0 };

        public static void TestDeferredQueries()
        {
            HashSet<int> query = (from number in numbers
                                  where number % 2 == 0
                                  select number).ToHashSet();

            foreach (var item in query)
            {
                Console.WriteLine(item);
            }

            numbers.Add(4);
            numbers.Add(12);
            numbers.Add(7);
            numbers.Add(6);

            Console.WriteLine("\nSecond Query\n");
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }

        public static void TestAggregateQueries()
        {
            //Type One

            //var query = Formula1.GetChampions().Aggregate((x, y) => x.Wins + y.Wins);
            var query = numbers.Aggregate((x, y) => x + y);

            //Method One
            var queryTwo = numbers.Aggregate((x, y) => x > y ? x : y);

            var queryThree = numbers.MaxBy(x => x % 2);

            //var queryFour = 
            var queryFour = Formula1.GetChampions().MaxBy(x => x.Wins);

            var racer = Formula1.GetChampions()[0];

            var queryFive = Formula1.GetChampions()
                .Aggregate(
                racer,
                (x, y) => x.Wins > y.Wins ? x : y,
                x => new
                {
                    Name = x.FirstName,
                    Country = x.Country
                }
                );

            // var queryThree 

            Console.WriteLine($"{queryFive.Name} {queryFive.Country}");


        }

        public static void UsingQuantification()
        {
            var areEqual = numbers.SequenceEqual(numbersTwo);

            var areEqualTwo = numbers.SequenceEqual(numbersThree);

            Console.WriteLine($"areEqualTwo: {areEqualTwo}"); 
            Console.WriteLine($"areEqual: {areEqual}");

            IEnumerable<RacerTwo> racerOne = Formula2.GetChampions().Take(1);
            IEnumerable<RacerTwo> racerTwo = Formula2.GetChampions().Skip(1).Take(1);

            var areEqualThree = racerOne.Equals(racerTwo);
            Console.WriteLine($"areEqualTwo: {areEqualThree}");

        }
    }
}