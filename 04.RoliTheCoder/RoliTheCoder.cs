namespace _04.RoliTheCoder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class RoliTheCoder
    {
        private const string End = "Time for Code";
        private static readonly Dictionary<int, string> EventNumberName = 
            new Dictionary<int, string>();

        private static readonly Dictionary<string, HashSet<string>> Events = 
            new Dictionary<string, HashSet<string>>();

        public static void Main()
        {
            var input = Console.ReadLine();
            while (input != End)
            {
                var inputTokens = input?
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (inputTokens[1].StartsWith("#"))
                {
                    var eventId = int.Parse(inputTokens[0]);
                    var eventname = inputTokens[1].Substring(1);
                    var members = inputTokens.Skip(2).ToArray();

                    if (!EventNumberName.ContainsKey(eventId))
                    {
                        EventNumberName[eventId] = eventname;
                        Events[eventname] = new HashSet<string>();
                    }

                    if (EventNumberName[eventId] == eventname)
                    {
                        foreach (var member in members)
                        {
                            Events[eventname].Add(member);

                        }
                    }
                }

                input = Console.ReadLine();
            }

            var sortedEvents = Events
                .OrderByDescending(e => e.Value.Count)
                .ThenBy(e => e.Key);

            foreach (var sortedEvent in sortedEvents)
            {
                Console.WriteLine($"{sortedEvent.Key} - {sortedEvent.Value.Count}");
                var sortedMembers = sortedEvent.Value.OrderBy(m => m);
                foreach (var member in sortedMembers)
                {
                    Console.WriteLine(member);
                }
            }
        }
    }
}
