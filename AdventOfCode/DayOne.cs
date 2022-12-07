// See https://aka.ms/new-console-template for more information
public class DayOne
{
    private readonly List<KeyValuePair<int, int>> caloriesPerElf = new();
    private readonly IEnumerable<string> lines;
    private int elfIndex;
    private int caloryTotal;

    public DayOne(string filepath)
    {
        lines = File.ReadLines(filepath);
        elfIndex = 1;
        caloryTotal = 0;
    }

    //Returns the index of elf and total calories of the elf with highest calory count
    public KeyValuePair<int, int> GetElfWithTheMost()
    {
        CalculateCaloriesPerElf();
        return caloriesPerElf.MaxBy(kvp => kvp.Value);
    }


    public void CalculateCaloriesPerElf()
    {
        foreach (var line in lines)
        {
            CheckIfEmpty(line);
        }
    }



    //if line is empty it goes to the next elf and resets total calories to 0, else adds calories to total of current elf
    public void CheckIfEmpty(string input)
    {
        if (String.IsNullOrWhiteSpace(input))
        {
            AddNewPair();
            elfIndex++;
            caloryTotal = 0;
        }
        else
            caloryTotal += Convert.ToInt32(input);
    }

    //Adds current elf/calory pair to list
    public void AddNewPair()
    {
        caloriesPerElf.Add(new KeyValuePair<int, int>(elfIndex, caloryTotal));
    }



    //removes highest and then adds it to total
    //not working atm
    public int GetTotalOfTopThree()
    {
        int totalOfTopThree = 0;
        for (int i = 0; i < 3; i++)
        {
            var maxKVP = caloriesPerElf.MaxBy(kvp => kvp.Value);
            var elf = maxKVP.Key;
            var calories = maxKVP.Value;
            totalOfTopThree += calories;
            caloriesPerElf.Remove(new KeyValuePair<int, int>(elf, calories));
        }
        return totalOfTopThree;
    }
}