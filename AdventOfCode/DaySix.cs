// See https://aka.ms/new-console-template for more information

public class DaySix
{
    private string datastream;
    private int marker;

    public DaySix(string filepath)
    {
        datastream = File.ReadAllText(filepath);
    }

    public void FindMarker(int lengthOfMarker)
    {
        for (int i = 0; i < datastream.Length - lengthOfMarker; i++)
        {
            if (CheckForDuplicates(datastream.Substring(i, lengthOfMarker)) == false)
            {
                marker += lengthOfMarker;
                break;
            }
            else
                marker++;
        }
    }

    private bool CheckForDuplicates(string word)
    {
        for (var i = 0; i < word.Length; i++)
        {
            var tempWord = word.Remove(i, 1);
            if (tempWord.Contains(word[i]))
            {
                return true;
            }
        }
        return false;
    }

    public int GetMarker()
    {
        return marker;
    }
}