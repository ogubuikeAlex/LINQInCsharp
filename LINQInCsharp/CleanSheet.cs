namespace LINQInCsharp
{
    internal class CleanSheet
    {

    }

    public static class Formula2
    {
        private static List<RacerTwo> s_racers;
        public static IList<RacerTwo> GetChampions() => s_racers ?? (s_racers = InitializeRacers);
        private static List<RacerTwo> InitializeRacers =>
        new List<RacerTwo>
        {
             new RacerTwo("Nino", "Farina", "Italy", 33, 10, new int[] { 1950 },new string[] { "Alfa Romeo" }),
             new RacerTwo("Alberto", "Ascari", "Italy", 32, 10, new int[] { 1952, 1953 },new string[] { "Ferrari" }),
             new RacerTwo("Juan Manuel", "Fangio", "Argentina", 51, 24, new int[] { 1951, 1954, 1955, 1956, 1957 }, new string[] { "Alfa Romeo", "Maserati", "Mercedes", "Ferrari" }),
             new RacerTwo("Mike", "Hawthorn", "UK", 45, 3, new int[] { 1958 }, new string[] { "Ferrari" }),
             new RacerTwo("Phil", "Hill", "USA", 48, 3, new int[] { 1961 }, new string[] { "Ferrari" }),
         };


    }
    public class RacerTwo /*: IEqualityComparer<RacerTwo>*/
    {
        public RacerTwo(string firstName, string lastName, string country,
        int starts, int wins)
        : this(firstName, lastName, country, starts, wins, null, null) { }
        public RacerTwo(string firstName, string lastName, string country,
        int starts, int wins, IEnumerable<int> years, IEnumerable<string> cars)
        {
            FirstName = firstName;
            LastName = lastName;
            Country = country;
            Starts = starts;
            Wins = wins;
            Years = years != null ? new List<int>(years) : new List<int>();
            Cars = cars != null ? new List<string>(cars) : new List<string>();
        }
        public string FirstName { get; }
        public string LastName { get; }
        public int Wins { get; }
        public string Country { get; }
        public int Starts { get; }
        public IEnumerable<string> Cars { get; }
        public IEnumerable<int> Years { get; }
        public override string ToString() => $"{FirstName} {LastName}";
        public string ToString(string format) => ToString(format, null);
        public string ToString(string format, IFormatProvider formatProvider)
        {
            switch (format)
            {
                case null:
                case "N":
                    return ToString();
                case "F":
                    return FirstName;
                case "L":
                    return LastName;
                case "C":
                    return Country;
                case "S":
                    return Starts.ToString();
                case "W":
                    return Wins.ToString();
                case "A":
                    return $"{FirstName} {LastName}, {Country}; starts: {Starts}, wins: {Wins}";
                default:
                    throw new FormatException($"Format {format} not supported");
            }
        }
        public override bool Equals(object? obj)
        {            
           return this.Equals(obj as RacerTwo);
        }


        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
