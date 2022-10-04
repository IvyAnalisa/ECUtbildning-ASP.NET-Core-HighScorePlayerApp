using IvyGame.Data;
using IvyGame.Models.Domain;
using IvyGame.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IvyGame.API.v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HighScoresController : ControllerBase
    {

        public IvyGameContext Context { get; }
        public HighScoresController(IvyGameContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IEnumerable<HighScore> Index()
        {
            var highscores = Context.HighScore.Include(p => p.Game).ToList();

            return highscores;
        }
        /*
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<HighScoreDto> GetHighScore(int id)
        {
            var highscore = Context.HighScore.Include(p => p.Game).FirstOrDefault(x => x.Id == id);

            if (highscore == null)
            {
                // Sätter statuskod till 404 Not Found
                return NotFound();
            }

            var highScoreDto = new HighScoreDto
            {
                Id = highscore.Id,
                Player = highscore.Player,
                Score = highscore.Score,
                Date = highscore.Date,
                GameId = highscore.Game.GameId,

                GameName = highscore.Game.GameName


            };

            return highScoreDto;
        }

        [HttpPost]
        public IActionResult CreateHighScore(CreateHighScoreDto createHighScoreDto)
        {
            var highscore = new HighScore
            {

                Player = createHighScoreDto.Player,
                Score = createHighScoreDto.Score,
                Date = createHighScoreDto.Date,
                GameId = createHighScoreDto.GameId,

                GameName = createHighScoreDto.GameName


            };
            Context.Add(highscore);
            Context.SaveChanges();
            var highScoreDto = new HighScoreDto
            {

                Player = highscore.Player,
                Score = highscore.Score,
                Date = highscore.Date,
                GameId = highscore.GameId,
                GameName = highscore.Game.GameName



            };
            //return Created($"/api/products/{product.Id}", null);
            return CreatedAtAction(
                nameof(GetHighScore),
                new { id = highscore.Id },
                highScoreDto);
        }
        */




        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<HighScoreDto> GetHighScore(int id)
        {
            var highscore = Context.HighScore.Include(p => p.Game).FirstOrDefault(x => x.Id == id);

            if (highscore == null)
            {
                // Sätter statuskod till 404 Not Found
                return NotFound();
            }

            var highScoreDto = new HighScoreDto
            {
                Id = highscore.Id,
                Player = highscore.Player,
                Score = highscore.Score,
                Date = highscore.Date,
                GameId = highscore.Game.GameId,

                // GameName = highscore.Game.GameName


            };

            return highScoreDto;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult CreateHighScore(CreateHighScoreDto createHighScoreDto)
        {
            var highscore = new HighScore
            {

                Player = createHighScoreDto.Player,
                Score = createHighScoreDto.Score,
                Date = createHighScoreDto.Date,
                GameId = createHighScoreDto.GameId


            };
            Context.Add(highscore);
            Context.SaveChanges();
            var highScoreDto = new HighScoreDto
            {

                Player = highscore.Player,
                Score = highscore.Score,
                Date = highscore.Date,
                GameId = highscore.GameId

            };
            //return Created($"/api/products/{product.Id}", null);
            return CreatedAtAction(
                nameof(GetHighScore),
                new { id = highscore.Id },
                highScoreDto);
        }

    }
}
