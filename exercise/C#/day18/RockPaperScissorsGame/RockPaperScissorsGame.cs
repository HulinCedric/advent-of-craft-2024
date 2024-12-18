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
        => player1 == player2
            ? new Result(Winner.Draw, "same choice")
            : Evaluate(player1, player2, Winner.Player1) ??
              Evaluate(player2, player1, Winner.Player2);

    private static Result? Evaluate(Choice player1, Choice player2, Winner winner)
        => Reason(player1, player2) is { } reason
            ? new Result(winner, reason)
            : null;

    private static string? Reason(Choice player1, Choice player2)
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
            (Choice.Spock, Choice.Rock) => "spock vaporizes rock",
            _ => null
        };
}