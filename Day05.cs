using System.Linq;

namespace aoc
{
    public class Day05 : IDay
    {
        public Int64 RunPart1()
        {
            string inputFile = "05_input.txt";
            string inputPath = Path.Combine("input", inputFile);

            string[] lines = File.ReadAllLines(inputPath);

            List<Int64[]> freshIdBoundaries = [];
            List<Int64> ingredients = [];

            Int64 result = 0;

            bool ingredientsSection = false;
            foreach (string line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    ingredientsSection = true;
                }
                else if (ingredientsSection)
                {
                    ingredients.Add(Convert.ToInt64(line));
                }
                else
                {
                    string[] boundaries = line.Split('-');
                    Int64[] boundariesInt = [Convert.ToInt64(boundaries[0]), Convert.ToInt64(boundaries[1])];
                    freshIdBoundaries.Add(boundariesInt);
                }
            }

            foreach (Int64 ingredient in ingredients)
            {
                foreach (Int64[] freshIdRange in freshIdBoundaries)
                {
                    if (ingredient >= freshIdRange[0] && ingredient <= freshIdRange[1])
                    {
                        result++;
                        break;
                    }
                }
            }

            return result;
        }

        public Int64 RunPart2()
        {
            string inputFile = "05_input.txt";
            string inputPath = Path.Combine("input", inputFile);

            string[] lines2 = File.ReadAllLines(inputPath);
            List<string> lines = [];
            for (int i = 0; i < lines2.Length; ++i)
            {
                if (string.IsNullOrEmpty(lines2[i]))
                {
                    break;
                }
                else
                {
                    lines.Add(lines2[i]);
                }
            }

            Int64[,] freshIdBoundaries = new long[lines.Count, 2];

            Int64 result = 0;

            for (int i = 0; i < lines.Count; ++i)
            {
                string[] boundaries = lines[i].Split('-');
                freshIdBoundaries[i, 0] = Convert.ToInt64(boundaries[0]);
                freshIdBoundaries[i, 1] = Convert.ToInt64(boundaries[1]);
            }

            for (int i = 0; i < freshIdBoundaries.GetLength(0); ++i)
            {
                Int64 startId = freshIdBoundaries[i, 0];
                Int64 endId = freshIdBoundaries[i, 1];
                if (startId != 0 && endId != 0)
                {
                    for (int j = 0; j < freshIdBoundaries.GetLength(0); ++j)
                    {
                        if (i != j)
                        {
                            Int64 startId2 = freshIdBoundaries[j, 0];
                            Int64 endId2 = freshIdBoundaries[j, 1];
                            if (endId >= endId2 && startId <= startId2)
                            {
                                freshIdBoundaries[j, 0] = 0;
                                freshIdBoundaries[j, 1] = 0;
                            }
                            else if (startId == endId && startId >= startId2 && startId <= endId2)
                            {
                                freshIdBoundaries[i, 0] = 0;
                                freshIdBoundaries[i, 1] = 0;
                                break;
                            }
                            else if (startId <= endId2 && startId > startId2 && endId >= endId2)
                            {
                                freshIdBoundaries[j, 1] = startId - 1;
                            }
                            else if (endId >= startId2 && endId < endId2 && startId <= startId2)
                            {
                                freshIdBoundaries[j, 0] = endId + 1;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < freshIdBoundaries.GetLength(0); ++i)
            {
                if (freshIdBoundaries[i, 1] > freshIdBoundaries[i, 0])
                {
                    result += freshIdBoundaries[i, 1] - (freshIdBoundaries[i, 0] - 1);
                }
                else if (freshIdBoundaries[i, 1] == freshIdBoundaries[i, 0] && freshIdBoundaries[i, 0] != 0)
                {
                    result++;
                }
            }

            return result;
        }
    }
}
