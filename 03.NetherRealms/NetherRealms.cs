namespace _03.NetherRealms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public static class NetherRealms
    {
        private static SortedDictionary<string, Deamon> deamonsList =
            new SortedDictionary<string, Deamon>();

        public static void Main()
        {
            var deamons = Console.ReadLine()
                .Split(new[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            foreach (var deamon in deamons)
            {
                var health = CalculateHealth(deamon);
                var damage = CalculateDamage(deamon);
                deamonsList.Add(deamon, new Deamon(deamon, health, damage));
            }

            foreach (var deamon in deamonsList)
            {
                Console.WriteLine(deamon.Value);
            }
        }

        private static double CalculateDamage(string deamonName)
        {
            var regex = new Regex(@"([+-]?)\d+(\.\d+)?");
            var matches = regex.Matches(deamonName);

            var total = 0D;
            foreach (var match in matches)
            {
                var num = match.ToString();
                if (num.StartsWith("+"))
                {
                    num = num.Substring(1);
                }

                total += double.Parse(num);
            }

            foreach (var ch in deamonName)
            {
                if (ch == '*')
                {
                    total *= 2;
                } 
                else if (ch == '/')
                {
                    total /= 2;
                }
            }

            return total;
        }

        private static long CalculateHealth(string deamonName)
        {
            var regex = new Regex(@"[^0-9*\/+\-.]");
            var matches = regex.Matches(deamonName);

            var total = 0;
            foreach (var match in matches)
            {
                var ch = char.Parse(match.ToString());
                total += ch;
            }


            return total;
        }

        internal class Deamon
        {
            public Deamon(string name, long health, double damage)
            {
                this.Name = name;
                this.Health = health;
                this.Damage = damage;
            }

            public string Name { get; set; }

            public long Health { get; set; }

            public double Damage { get; set; }

            public override string ToString()
            {
                return $"{this.Name} - {this.Health} health, {this.Damage:F2} damage";
            }
        }
    }
}