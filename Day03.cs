namespace aoc
{
    public class Day03 : IDay
    {
        public Int64 RunPart1()
        {
            string inputFile = "03a_input.txt";
            string inputPath = Path.Combine("input", inputFile);

            string[] banks = File.ReadAllLines(inputPath);

            Int64 result = 0;

            foreach (string bank in banks)
            {
                char[] cBatteries = bank.ToCharArray();
                int[] batteries = new int[cBatteries.Length];

                for (int i = 0; i < cBatteries.Length; ++i)
                {
                    batteries[i] = cBatteries[i] - '0';
                }

                

                int iterations = 12;
                int posHighestValue = 0;
                for (int k = 0; k < iterations; ++k)
                {
                    int highestValue = 0;

                    if (k == 0)
                    {
                        for (int i = batteries.Length - iterations; i >= 0; --i)
                        {
                            if (batteries[i] >= highestValue)
                            {
                                highestValue = batteries[i];
                                posHighestValue = i;
                            }
                        }
                    }
                    else
                    {
                        for (int i = posHighestValue + 1; i <= batteries.Length - (iterations - k); ++i)
                        {
                            if (batteries[i] > highestValue)
                            {
                                highestValue = batteries[i];
                                posHighestValue = i;
                            }
                        }
                    }

                    result += highestValue * Convert.ToInt64(Math.Pow(10, iterations - 1 - k));
                }
            }

            return result;
        }

        public Int64 RunPart2()
        {
            string inputFile = "03a_input.txt";
            string inputPath = Path.Combine("input", inputFile);

            string[] banks = File.ReadAllLines(inputPath);

            Int64 result = 0;

            foreach (string bank in banks)
            {
                char[] cBatteries = bank.ToCharArray();
                int[] batteries = new int[cBatteries.Length];

                for (int i = 0; i < cBatteries.Length; ++i)
                {
                    batteries[i] = cBatteries[i] - '0';
                }



                int iterations = 12;
                int posHighestValue = 0;
                for (int k = 0; k < iterations; ++k)
                {
                    int highestValue = 0;

                    if (k == 0)
                    {
                        for (int i = batteries.Length - iterations; i >= 0; --i)
                        {
                            if (batteries[i] >= highestValue)
                            {
                                highestValue = batteries[i];
                                posHighestValue = i;
                            }
                        }
                    }
                    else
                    {
                        for (int i = posHighestValue + 1; i <= batteries.Length - (iterations - k); ++i)
                        {
                            if (batteries[i] > highestValue)
                            {
                                highestValue = batteries[i];
                                posHighestValue = i;
                            }
                        }
                    }

                    result += highestValue * Convert.ToInt64(Math.Pow(10, iterations - 1 - k));
                }
            }

            return result;
        }
    }
}
