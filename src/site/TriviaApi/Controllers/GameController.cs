using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TriviaApi.Security;

namespace TriviaApi.Controllers
{
    [Route("api/v1/games")]
    public class GameController : Controller
    {
        public class GameDto
        {
            public string Name { get; set; }

            public GameQuestionDto[] Questions { get; set; }
            public Dictionary<string, string> GameSpecificMetadata { get; set; }
        }

        public class GameQuestionDto
        {
            public Guid QuestionId { get; set; }
            public Dictionary<string, string> GameSpecificMetadata { get; set; }
        }

        /// <summary>
        /// This is a "game definition" like "luke's game"
        /// </summary>
        public class ReadonlyGameDto
        {
            public Guid Id { get; set; }

            public string Name { get; set; }
            public Guid OwnerAccountId { get; set; }

            public GameQuestionDto[] Questions { get; set; }
            public Dictionary<string, string> GameSpecificMetadata { get; set; }
        }

        [HttpPost]
        [Authorize(AuthPolicies.Authenticated)]
        [ProducesResponseType(200, Type = typeof(ReadonlyGameDto))]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        public IActionResult CreateGame([FromBody] GameDto game)
        {
            var newGame = new ReadonlyGameDto
            {
                Id = Guid.NewGuid(),
                GameSpecificMetadata = game.GameSpecificMetadata,
                Name = game.Name,
                OwnerAccountId = Guid.Empty,
                Questions = game.Questions,
            };

            return StatusCode(200, newGame);
        }

        [HttpGet("{id}")]
        [Authorize(AuthPolicies.Authenticated)]
        [ProducesResponseType(200, Type = typeof(ReadonlyGameDto))]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        public IActionResult GetGame([FromRoute] Guid id)
        {
            var game = new ReadonlyGameDto()
            {
                Id = id,
                Questions = new GameQuestionDto[] { },
                OwnerAccountId = Guid.Empty,
                Name = "der",
                GameSpecificMetadata = new Dictionary<string, string> { },
            };

            return StatusCode(200, game);
        }

        [HttpDelete("{id}")]
        [Authorize(AuthPolicies.Authenticated)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        public IActionResult DeleteGate([FromRoute] Guid id)
        {
            return StatusCode(204);
        }

        [HttpPut("{id}")]
        [Authorize(AuthPolicies.Authenticated)]
        [ProducesResponseType(200, Type = typeof(ReadonlyGameDto))]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        public IActionResult UpdateGame([FromRoute] Guid id, [FromBody] GameDto game)
        {
            var updatedGame = new ReadonlyGameDto
            {
                Id = id,
                GameSpecificMetadata = game.GameSpecificMetadata,
                Name = game.Name,
                Questions = game.Questions,
                OwnerAccountId = Guid.Empty
            };

            return StatusCode(200, updatedGame);
        }
    }
}
