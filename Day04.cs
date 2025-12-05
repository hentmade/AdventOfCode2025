namespace aoc
{
    public class Day04 : IDay
    {
        public Int64 RunPart1()
        {
            string inputFile = "04a_input.txt";
            string inputPath = Path.Combine("input", inputFile);

            string[] lines = File.ReadAllLines(inputPath);

            char[,] map = new char[lines.Length, lines[0].Length];

            for (int i = 0; i < lines.Length; ++i)
            {
                char[] tmp = lines[i].ToCharArray();
                for (int j = 0; j < tmp.Length; ++j)
                {
                    map[i, j] = tmp[j];
                }
            }

            int paperrollsInitial = CountPaperrollsTotal(map);
            int paperrollsNewBefore = paperrollsInitial;
            int paperrollsNewAfter = 0;

            while (paperrollsNewBefore != paperrollsNewAfter)
            {
                paperrollsNewBefore = CountPaperrollsTotal(map);
                for (int i = 0; i < lines.Length; ++i)
                {
                    for (int j = 0; j < lines[0].Length; ++j)
                    {
                        if (map[i, j] == '@' && CountPaperrollsAround(map, i, j) < 4)
                        {
                            map[i, j] = '.';
                        }
                    }
                }
                paperrollsNewAfter = CountPaperrollsTotal(map);
            }

            return paperrollsInitial - CountPaperrollsTotal(map);
        }

        public Int64 RunPart2()
        {
            string inputFile = "04a_input.txt";
            string inputPath = Path.Combine("input", inputFile);

            string[] lines = File.ReadAllLines(inputPath);

            char[,] map = new char[lines.Length, lines[0].Length];

            for (int i = 0; i < lines.Length; ++i)
            {
                char[] tmp = lines[i].ToCharArray();
                for (int j = 0; j < tmp.Length; ++j)
                {
                    map[i, j] = tmp[j];
                }
            }

            int paperrollsInitial = CountPaperrollsTotal(map);
            int paperrollsNewBefore = paperrollsInitial;
            int paperrollsNewAfter = 0;

            while (paperrollsNewBefore != paperrollsNewAfter)
            {
                paperrollsNewBefore = CountPaperrollsTotal(map);
                for (int i = 0; i < lines.Length; ++i)
                {
                    for (int j = 0; j < lines[0].Length; ++j)
                    {
                        if (map[i, j] == '@' && CountPaperrollsAround(map, i, j) < 4)
                        {
                            map[i, j] = '.';
                        }
                    }
                }
                paperrollsNewAfter = CountPaperrollsTotal(map);
            }

            return paperrollsInitial - CountPaperrollsTotal(map);
        }

        private int CountPaperrollsTotal(char[,] map)
        {
            int result = 0;
            for (int i = 0; i < map.GetLength(0); ++i)
            {
                for (int j = 0; j < map.GetLength(1); ++j)
                {
                    if (map[i, j] == '@')
                    {
                        result++;
                    }
                }
            }
            return result;
        }

        private int CountPaperrollsAround(char[,] map, int row, int column)
        {
            int result = 0;
            for (int i = row-1; i <= row+1; ++i)
            {
                if (i >= 0 && i < map.GetLength(0))
                {
                    for (int j = column-1; j <= column+1; ++j)
                    {
                        if (j >= 0 && j < map.GetLength(1) && (i != row || j != column))
                        {
                            if (map[i, j] == '@')
                            {
                                result++;
                            }
                        }
                    }
                }
            }
            return result;
        }
    }
}
