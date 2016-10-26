namespace _02Ladybugs
{
    using System;
    using System.Linq;

    public static class Ladybugs
    {
        private const string End = "end";
        private static bool[] field;

        public static void Main()
        {
            var fieldSize = int.Parse(Console.ReadLine());
            field = new bool[fieldSize];

            var bugs = Console.ReadLine()
                .Split()
                .Select(int.Parse);

            foreach (var bug in bugs)
            {
                if (bug >= 0 && bug < fieldSize)
                {
                    field[bug] = true;
                }
            }

            var commandTokens = Console.ReadLine().Split();
            while (commandTokens[0] != End)
            {
                var bugIndex = long.Parse(commandTokens[0]);
                var direction = commandTokens[1];
                var lenght = long.Parse(commandTokens[2]);

                if (bugIndex >= 0 && bugIndex < fieldSize && field[bugIndex] && lenght != 0)
                {
                    field[bugIndex] = false;

                    if (direction == "right")
                    {
                        while (true)
                        {
                            bugIndex += lenght;
                            if (bugIndex >= fieldSize)
                            {
                                break;
                            }

                            if (!field[bugIndex])
                            {
                                field[bugIndex] = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        while (true)
                        {
                            bugIndex -= lenght;
                            if (bugIndex < 0)
                            {
                                break;
                            }

                            if (!field[bugIndex])
                            {
                                field[bugIndex] = true;
                                break;
                            }
                        }
                    }
                }
            

                commandTokens = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(" ", field.Select(b => b ? 1 : 0)));
        }
    }
}
