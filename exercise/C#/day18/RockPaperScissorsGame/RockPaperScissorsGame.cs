using LanguageExt;

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
    private static readonly Map<string, string> WhatBeatsWhat = new(
    [
        (KeyFor(Choice.Rock, Choice.Scissors), "rock crushes scissors"),
        (KeyFor(Choice.Rock, Choice.Lizard), "rock crushes lizard"),
        (KeyFor(Choice.Paper, Choice.Rock), "paper covers rock"),
        (KeyFor(Choice.Paper, Choice.Spock), "paper disproves spock"),
        (KeyFor(Choice.Scissors, Choice.Paper), "scissors cuts paper"),
        (KeyFor(Choice.Scissors, Choice.Lizard), "scissors decapitates lizard"),
        (KeyFor(Choice.Lizard, Choice.Spock), "lizard poisons spock"),
        (KeyFor(Choice.Lizard, Choice.Paper), "lizard eats paper"),
        (KeyFor(Choice.Spock, Choice.Scissors), "spock smashes scissors"),
        (KeyFor(Choice.Spock, Choice.Rock), "spock vaporizes rock")
    ]);

    public static Result Play(Choice player1, Choice player2)
        => EvaluateEquality(player1, player2)
            .IfNone(
                () => EvaluateWinner(player1, player2, Winner.Player1)
                    .IfNone(
                        () => EvaluateWinner(player2, player1, Winner.Player2)
                            .IfNone(() => new Result(Winner.Draw, "unknown reason"))));

    private static Option<Result> EvaluateEquality(Choice player1, Choice player2)
        => player1 == player2 ? new Result(Winner.Draw, "same choice") : Option<Result>.None;

    private static Option<Result> EvaluateWinner(Choice player1, Choice player2, Winner winner)
        => Reason(player1, player2).Map(reason => new Result(winner, reason));

    private static Option<string> Reason(Choice player1, Choice player2)
        => WhatBeatsWhat.Find(KeyFor(player1, player2));

    private static string KeyFor(Choice choice1, Choice choice2) => $"{choice1}-{choice2}";
}