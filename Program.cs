using aoc;

IDay puzzle = new Day05();

DateTime startTime = DateTime.UtcNow;

Int64 result = puzzle.RunPart2();

int millis = (DateTime.UtcNow - startTime).Milliseconds;

Console.WriteLine("Result: " + result);
Console.WriteLine("Milliseconds: " + millis);
