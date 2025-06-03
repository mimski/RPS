namespace RPSGame.API.Models;

public class GameResult
{
    public Move PlayerMove { get; set; }

    public Move ComputerMove { get; set; }

    public string? Result { get; set; }
}
