// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

public class DayFive //a holy mess
{
    //File.ReadLines(filepath).ToList();
    private int highestStackCount;
    private int numberOfColumns;
    private List<string> stacks = new List<string> { "", "", "", "", "", "", "", "", "" };

    private string filepath;
    private List<string> lines = new List<string>();
    public DayFive(string filepath)
    {
        this.filepath = filepath;
        CalculateHighestStackCount();
        CalculateNumberOfColumns();
        CreateStacks();
        ReverseStacks();
        Instructions();
    }

    private void CalculateHighestStackCount()
    {
        var counter = 0;
        lines = File.ReadAllLines(filepath).ToList();
        foreach (var line in lines)
        {
            if (Char.IsDigit(line[1]))
            {
                highestStackCount = counter;
                return;
            }
            else
                counter++;
        }
    }


    private void CreateStacks()
    {
        for (int i = 0; i < highestStackCount; i++)//goes through lines containing letters
        {
            var line = lines[i];
            var columnCount = 0;

            for (int x = 1; x < line.Length; x += 4)//letters are 4 spaces appart in input, not great but should work
            {
                if (Char.IsLetter(line[x]))
                    stacks[columnCount] += line[x];
                columnCount++;
            }
        }

    }

    private void ReverseStacks()
    {
        for (int i = 0; i < stacks.Count; i++)
            stacks[i] = Reverse(stacks[i]);
    }

    public static string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    private void CalculateNumberOfColumns()
    {
        numberOfColumns = lines[highestStackCount].Split(" ").Length;
    }

    public void Instructions()
    {
        lines.RemoveRange(0, highestStackCount + 2);
        foreach (var line in lines)
        {
            var temp = line.Split(' ');
            var numbers = temp.Where(v => Regex.IsMatch(v, @"^\d+$")).ToArray();
            var howMany = Convert.ToInt32(numbers[0]);
            var from = Convert.ToInt32(numbers[1]) - 1;
            var to = Convert.ToInt32(numbers[2]) - 1;
            CrateMover9001(from, to, howMany);
        }
    }

    private void CrateMover9000(int from, int to, int howMany)
    {
        for (int i = 0; i < howMany; i++)
        {
            stacks[to] += stacks[from].Last();
            stacks[from] = stacks[from].Remove(stacks[from].Length - 1);
        }
    }

    private void CrateMover9001(int from, int to, int howMany)
    {
        stacks[to] += stacks[from].Substring(stacks[from].Length - howMany);
        stacks[from] = stacks[from].Remove(stacks[from].Length - howMany);
    }

    public List<string> GetStacks()
    {
        return stacks;
    }

    public string Answer()
    {
        var answer = "";
        foreach (var stack in stacks)
        {
            answer += stack.Last();
        }
        return answer;
    }
}