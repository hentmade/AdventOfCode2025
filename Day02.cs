namespace aoc
{
    public class Day02 : IDay
    {
        public Int64 RunPart1()
        {
            string inputFile = "02a_input.txt";
            string inputPath = Path.Combine("input", inputFile);

            List<Int64[]> idRanges = [];

            string input = File.ReadAllText(inputPath);

            string[] ranges = input.Split(',');

            foreach (string range in ranges)
            {
                string lowerBound = range.Split('-')[0];
                string upperBound = range.Split('-')[1];


                if (Int64.TryParse(lowerBound, out Int64 lowerBoundInt) && Int64.TryParse(upperBound, out Int64 upperBoundInt))
                {
                    Int64[] boundaries = { lowerBoundInt, upperBoundInt };
                    idRanges.Add(boundaries);
                }
                else
                {
                    Console.WriteLine("Error");
                    return -1;
                }
            }

            Int64 result = 0;

            foreach (Int64[] idRange in idRanges)
            {
                for (Int64 id = idRange[0]; id <= idRange[1]; id++)
                {
                    for (int j = 2; j <= id.ToString().Length; j++)
                    {
                        if (id.ToString().Length % j == 0 && IsRepetitive(id, j))
                        {
                            result += id;
                            break;
                        }
                    }
                }
            }

            return result;
        }

        private bool IsRepetitive(Int64 value, int repeats = 2)
        {
            string sValue = value.ToString();

            string[] parts = new string[repeats];

            for (int i = 0; i < repeats; i++)
            {
                parts[i] = sValue.Substring(i * (sValue.Length / repeats), sValue.Length / repeats);
            }

            for (int i = 0; i < repeats-1; i++)
            {
                if (!parts[i].Equals(parts[i+1]))
                {
                    return false;
                }
            }

            return true;
        }

        public Int64 RunPart2()
        {
            string inputFile = "02a_input.txt";
            string inputPath = Path.Combine("input", inputFile);

            List<Int64[]> idRanges = [];

            string input = File.ReadAllText(inputPath);

            string[] ranges = input.Split(',');

            foreach (string range in ranges)
            {
                string lowerBound = range.Split('-')[0];
                string upperBound = range.Split('-')[1];


                if (Int64.TryParse(lowerBound, out Int64 lowerBoundInt) && Int64.TryParse(upperBound, out Int64 upperBoundInt))
                {
                    Int64[] boundaries = { lowerBoundInt, upperBoundInt };
                    idRanges.Add(boundaries);
                }
                else
                {
                    Console.WriteLine("Error");
                    return -1;
                }
            }

            Int64 result = 0;

            foreach (Int64[] idRange in idRanges)
            {
                for (Int64 id = idRange[0]; id <= idRange[1]; id++)
                {
                    for (int j = 2; j <= id.ToString().Length; j++)
                    {
                        if (id.ToString().Length % j == 0 && IsRepetitive(id, j))
                        {
                            result += id;
                            break;
                        }
                    }
                }
            }

            return result;
        }
    }
}
