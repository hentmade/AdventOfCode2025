string inputFile = "01a_input.txt";
string inputPath = Path.Combine("input", inputFile);

List<string> rotations = File.ReadAllLines(inputPath).ToList();

int lowestPos = 0;
int highestPos = 99;
int currentPosition = 50;
int previousPosition = 50;
int countZeros = 0;

foreach (var rot in rotations)
{
    string direction = rot.Substring(0, 1);
    string sSteps = rot.Substring(1, rot.Length - 1);
    if (int.TryParse(sSteps, out int steps))
    {
        previousPosition = currentPosition;

        countZeros += steps / (highestPos + 1);
        steps %= highestPos + 1;

        if (direction.Equals("L"))
        {
            currentPosition -= steps;
            if (currentPosition < lowestPos)
            {
                currentPosition += highestPos + 1;
                if (previousPosition != 0 && currentPosition != 0)
                {
                    countZeros++;
                }
            }
        }
        else if (direction.Equals("R"))
        {
            currentPosition += steps;
            if (currentPosition > highestPos)
            {
                currentPosition -= highestPos + 1;
                if (previousPosition != 0 && currentPosition != 0)
                {
                    countZeros++;
                }
            }
        }

        if (currentPosition == 0)
        {
            countZeros++;
        }
    }
    else
    {
        Console.WriteLine("Error");
        break;
    }
}

Console.WriteLine("Zeros: " + countZeros);
