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

        return EvaluateWinner(player1, player2, Winner.Player1)
               ?? EvaluateWinner(player2, player1, Winner.Player2);
    }

    private static Result? EvaluateWinner(Choice player1, Choice player2, Winner winner)
        => (player1, player2) switch
        {
            (Choice.Rock, Choice.Scissors) => new Result(winner, "rock crushes scissors"),
            (Choice.Paper, Choice.Rock) => new Result(winner, "paper covers rock"),
            (Choice.Scissors, Choice.Paper) => new Result(winner, "scissors cuts paper"),
            (Choice.Spoke, Choice.Scissors) => new Result(winner, "spock smashes scissors"),
            _ => null
        };
}