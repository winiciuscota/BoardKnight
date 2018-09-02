using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BoardKnight.Domain;
using BoardKnight.Domain.ValueObjects;

namespace BoardKnight.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardKnightController : ControllerBase
    {
        // GET api/values/5
        [HttpGet("{position}")]
        public ActionResult<IEnumerable<string>> GetPossibleMoves(string position)
        {
            if(position.Length != 2) 
            {
                return BadRequest("Invalid input");
            }

            var chessPosition = new ChessPosition(position);
            if(!chessPosition.Valid) {
                return BadRequest("Invalid chess position");
            }

            var boardKnightPredictor = new BoardKnightPredictor();
            var result = boardKnightPredictor.GetPossibleMoves(chessPosition).Select(x => x.AlgebraicNotation);

            return Ok(result);
        }

    }
}
