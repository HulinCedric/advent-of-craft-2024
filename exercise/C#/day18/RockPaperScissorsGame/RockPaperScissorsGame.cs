namespace RockPaperScissorsGame;

public enum Choice
{
    Rock,
    Paper,
    Scissors,
    Lizard,
    Spock
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

        if (EvaluateWinner(player1, player2) is { } player1WinReason)
            return new Result(Winner.Player1, player1WinReason);

        if (EvaluateWinner(player2, player1) is { } player2WinReason)
            return new Result(Winner.Player2, player2WinReason);

        return new Result(Winner.Draw, "no winner");
    }

    private static string? EvaluateWinner(Choice player1, Choice player2)
        => (player1, player2) switch
        {
            (Choice.Rock, Choice.Scissors) => "rock crushes scissors",
            (Choice.Rock, Choice.Lizard) => "rock crushes lizard",
            (Choice.Paper, Choice.Rock) => "paper covers rock",
            (Choice.Paper, Choice.Spock) => "paper disproves spock",
            (Choice.Scissors, Choice.Paper) => "scissors cuts paper",
            (Choice.Scissors, Choice.Lizard) => "scissors decapitates lizard",
            (Choice.Lizard, Choice.Spock) => "lizard poisons spock",
            (Choice.Lizard, Choice.Paper) => "lizard eats paper",
            (Choice.Spock, Choice.Scissors) => "spock smashes scissors",
            _ => null
        };
}