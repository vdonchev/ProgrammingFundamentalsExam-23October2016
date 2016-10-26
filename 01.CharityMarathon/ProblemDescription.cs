namespace _01.CharityMarathon
{
    using System;

    public static class ProblemDescription
    {
        public static void Main()
        {
            var marathonDays = int.Parse(Console.ReadLine());
            var numberOfRunners = int.Parse(Console.ReadLine());
            var averageLaps = int.Parse(Console.ReadLine());
            var trackLenght = int.Parse(Console.ReadLine());
            var trackCapacity = int.Parse(Console.ReadLine());
            var moneyPerKilometer = decimal.Parse(Console.ReadLine());

            long totalNumberOfRunners = Math.Min(numberOfRunners, (long)marathonDays * trackCapacity);
            var totalMetersRun = (long)(trackLenght) * averageLaps * totalNumberOfRunners;
            var totalKilometers = totalMetersRun / 1000.0M;
            var risedMoney = moneyPerKilometer * totalKilometers;

            Console.WriteLine($"Money raised: {risedMoney:F2}");
        }
    }
}
