using Microsoft.AspNetCore.Mvc;
using RPSGame.API.Models;

namespace RPSGame.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GameController : ControllerBase
{
    [HttpPost("Play")]
    public IActionResult Play([FromBody] GameRequest request)
    {
        var random = new Random();
        var computerMove = (Move)random.Next(0, 3);
        string result;

        if (request.PlayerMove == computerMove)
        {
            result = "Draw";
        }
        else if ((request.PlayerMove == Move.Rock && computerMove == Move.Scissors)
            || (request.PlayerMove == Move.Paper && computerMove == Move.Rock)
            || (request.PlayerMove == Move.Scissors && computerMove == Move.Paper))
        {
            result = "You Win!";
        }
        else
        {
            result = "You Lose!";
        }

        return Ok(new GameResult
        {
            PlayerMove = request.PlayerMove,
            ComputerMove = computerMove,
            Result = result
        });
    }
}
