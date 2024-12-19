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
        => (player1, player2) switch
        {
            _ when player1 == player2 => new Result(Winner.Draw, "same choice"),
            _ when WhatBeatsWhat.ContainsKey(KeyFor(player1, player2)) => new Result(
                Winner.Player1,
                WhatBeatsWhat[KeyFor(player1, player2)]),
            _ when WhatBeatsWhat.ContainsKey(KeyFor(player2, player1)) => new Result(
                Winner.Player2,
                WhatBeatsWhat[KeyFor(player2, player1)]),
            _ => new Result(Winner.Draw, "unknown reason")
        };

    private static string KeyFor(Choice choice1, Choice choice2) => $"{choice1}-{choice2}";
}