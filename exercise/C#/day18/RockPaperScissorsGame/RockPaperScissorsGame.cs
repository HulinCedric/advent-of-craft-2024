namespace RockPaperScissorsGame;

public enum Choice
{
    Rock,
    Paper,
    Scissors,
    Lizard,
    Spoke
}

public enum Winner
{
    Player1,
    Player2,
    Draw
}

public record Result(Winner Winner, string Reason);

public static class RockPaperScissors
{
    public static Result? Play(Choice player1, Choice player2)
    {
        if (player1 == player2) return new Result(Winner.Draw, "same choice");
        return (player1, player2) switch
        {
            (Choice.Rock, Choice.Scissors) => new Result(Winner.Player1, "rock crushes scissors"),
            (Choice.Paper, Choice.Rock) => new Result(Winner.Player1, "paper covers rock"),
            (Choice.Scissors, Choice.Paper) => new Result(Winner.Player1, "scissors cuts paper"),
            (Choice.Spoke, Choice.Scissors) => new Result(Winner.Player1, "spock smashes scissors"),
            (Choice.Scissors, Choice.Rock) => new Result(Winner.Player2, "rock crushes scissors"),
            (Choice.Rock, Choice.Paper) => new Result(Winner.Player2, "paper covers rock"),
            (Choice.Paper, Choice.Scissors) => new Result(Winner.Player2, "scissors cuts paper"),
            _ => null
        };
    }
}