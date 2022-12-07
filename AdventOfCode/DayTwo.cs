// See https://aka.ms/new-console-template for more information
public class DayTwo
{
    private int rock = 1;
    private int paper = 2;
    private int scissors = 3;
    private int win = 6;
    private int draw = 3;
    private readonly IEnumerable<string> games;
    private int score;

    public DayTwo(string filepath)
    {
        games = File.ReadLines(filepath);
    }



    public void calculateTotalScore()
    {
        foreach (var game in games)
        {
            calculateRealGameScore(game);
        }
    }

    private void calculateGameScore(string game)
    {
        var picks = game.Split(" ");
        var opponentsPick = picks[0];
        var myPick = picks[1];
        switch (myPick)
        {
            case "Y":
                score += paper;
                break;
            case "X":
                score += rock;
                break;
            case "Z":
                score += scissors;
                break;
        }

        if (myPick == "X")
        {
            if (opponentsPick == "A")
                score += draw;
            else if (opponentsPick == "C")
                score += win;
        }
        if (myPick == "Y")
        {
            if (opponentsPick == "B")
                score += draw;
            else if (opponentsPick == "A")
                score += win;
        }
        if (myPick == "Z")
        {
            if (opponentsPick == "C")
                score += draw;
            else if (opponentsPick == "B")
                score += win;
        }
    }

    public int getScore()
    {
        return score;
    }

    public void calculateRealGameScore(string game)
    {
        var picks = game.Split(" ");
        var opponentsPick = picks[0];
        var myStrategy = picks[1];

        if (myStrategy == "X")
        {
            if (opponentsPick == "A")
                score += scissors;
            else if (opponentsPick == "B")
                score += rock;
            else if (opponentsPick == "C")
                score += paper;
        }
        if (myStrategy == "Y")
        {
            score += draw;
            if (opponentsPick == "A")
                score += rock;
            else if (opponentsPick == "B")
                score += paper;
            else if (opponentsPick == "C")
                score += scissors;
        }
        if (myStrategy == "Z")
        {
            score += win;
            if (opponentsPick == "A")
                score += paper;
            else if (opponentsPick == "B")
                score += scissors;
            else if (opponentsPick == "C")
                score += rock;
        }
    }
}