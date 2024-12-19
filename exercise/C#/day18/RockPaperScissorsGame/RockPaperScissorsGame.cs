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

    public static Either<string, Result> Play(Choice player1, Choice player2)
        => (player1, player2) switch
        {
            _ when IsADraw(player1, player2) => new Result(Winner.Draw, "same choice"),
            _ when IsWinner(player1, player2) => new Result(Winner.Player1, Reason(player1, player2)),
            _ when IsWinner(player2, player1) => new Result(Winner.Player2, Reason(player2, player1)),
            _ => "no rules for these choices"
        };
    
    private static bool IsADraw(Choice choice1, Choice choice2) => choice1 == choice2;

    private static bool IsWinner(Choice choice1, Choice choice2) => WhatBeatsWhat.ContainsKey(KeyFor(choice1, choice2));

    private static string Reason(Choice choice1, Choice choice2) => WhatBeatsWhat[KeyFor(choice1, choice2)];

    private static string KeyFor(Choice choice1, Choice choice2) => $"{choice1}-{choice2}";
}