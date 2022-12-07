// See https://aka.ms/new-console-template for more information
public class DayFour
{
    private List<string> assignmentPairs = new List<string>();
    private int overlapping;
    private int anyOverlap;

    public DayFour(string filepath)
    {
        assignmentPairs = File.ReadLines(filepath).ToList();
    }

    public void CalculateOverlappingPairs()
    {
        foreach (string pair in assignmentPairs)
        {
            var idNumbers = pair.Split(',');
            CheckIDs(idNumbers);
        }
    }

    private void CheckIDs(string[] idNumbers)
    {
        CheckForOverlap(idNumbers[0], idNumbers[1]);
    }

    private void CheckForOverlap(string idsElfOne, string idsElfTwo)
    {
        var idsElfOneSplit = idsElfOne.Split('-');
        var idsElfTwoSplit = idsElfTwo.Split('-');

        var idOne = Convert.ToInt32(idsElfOneSplit[0]);
        var idTwo = Convert.ToInt32(idsElfOneSplit[1]);
        var idThree = Convert.ToInt32(idsElfTwoSplit[0]);
        var idFour = Convert.ToInt32(idsElfTwoSplit[1]);


        if (idOne <= idThree && idTwo >= idFour)
            overlapping++;
        else if (idOne >= idThree && idTwo <= idFour)
            overlapping++;

        var rangeElfOne = Enumerable.Range(idOne, (idTwo - idOne + 1));
        var rangeElfTwo = Enumerable.Range(idThree, (idFour - idThree + 1));

        foreach (var id in rangeElfOne)
        {
            if (rangeElfTwo.Contains(id))
            {
                anyOverlap++;
                return;
            }
        }
    }

    public int GetOverlappingPairs()
    {
        return overlapping;
    }


    public int GetAnyOverlap()
    {
        return anyOverlap;
    }
}