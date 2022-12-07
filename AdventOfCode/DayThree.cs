// See https://aka.ms/new-console-template for more information
public class DayThree
{
    private char letter = 'a';
    private Dictionary<char, int> letterValues = new Dictionary<char, int>();
    private int letterValue = 1;
    private int rucksackSum;
    private int badgeSum;
    private List<string> rucksacks;

    public DayThree(string filepath)
    {
        ValueAssigner();
        rucksacks = File.ReadLines(filepath).ToList();
    }

    private void ValueAssigner()
    {
        while (true)
        {
            letterValues.Add(letter, letterValue);
            letterValue++;
            if (letter == 'z')
            {
                letter = 'A';
                continue;
            }
            else if (letter == 'Z')
                break;
            else
                letter++;
        }
    }

    public void CalculateTotalRucksacksSum()
    {
        foreach (var rucksack in rucksacks)
            CalculateSingleRucksackSum(rucksack);
    }

    private void CalculateSingleRucksackSum(string rucksack)
    {
        var compartments = SplitRucksack(rucksack);
        foreach (var letter in compartments[0])
        {
            if (compartments[1].Contains(letter))
            {
                rucksackSum += letterValues[letter];
                return;
            }
        }
    }

    private List<string> SplitRucksack(string rucksack)
    {
        var splitPoint = rucksack.Length / 2;
        var compartmentOne = rucksack.Substring(0, splitPoint);
        var compartmentTwo = rucksack.Substring(splitPoint);
        return new List<string> { compartmentOne, compartmentTwo };
    }

    public int GetRucksackSum()
    {
        return rucksackSum;
    }

    public void CalculateBadgesTotalSum()
    {
        for (int i = 0; i < rucksacks.Count; i += 3)
        {
            foreach (var letter in rucksacks[i])
            {
                if (rucksacks[i + 1].Contains(letter) && rucksacks[i + 2].Contains(letter))
                {
                    badgeSum += letterValues[letter];
                    break;
                }
            }
        }
    }

    public int GetBadgeSum()
    {
        return badgeSum;
    }

}