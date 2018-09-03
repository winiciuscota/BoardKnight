using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BoardKnight.Domain;
using BoardKnight.Domain.ValueObjects;
using System.Text.RegularExpressions;

namespace BoardKnight.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardKnightController : ControllerBase
    {
        // GET api/values/5
        [HttpGet("{position}")]
        [HttpGet("{position}/moves/{moves}")]
        public ActionResult<IEnumerable<string>> GetPossiblePositions(string position, int moves = 1)
        {
            var inputPattern = @"^\w\d$";
            Regex r = new Regex(inputPattern, RegexOptions.IgnoreCase);

            var validMoves = moves > 0 && moves <= 2;

            if(!r.Match(position).Success || !validMoves) 
            {
                return BadRequest("Invalid input");
            }

            var chessPosition = new ChessPosition(position);
            if(!chessPosition.Valid) {
                return BadRequest("Invalid chess position");
            }

            var boardKnightPredictor = new BoardKnightPredictor();

            IEnumerable<ChessPosition> positions = moves == 1 ? boardKnightPredictor.GetPossiblePositions(chessPosition) : 
                                         boardKnightPredictor.GetPossiblePositionsWith2Moves(chessPosition);

            var result = positions.Select(x => x.AlgebraicNotation);

            return Ok(result);
        }

    }
}
