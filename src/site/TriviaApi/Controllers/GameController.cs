using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TriviaApi.Security;

namespace TriviaApi.Controllers
{
    [Route("api/game")]
    public class GameController : Controller
    {
        public class CreateGameDto
        {
            public string Name { get; set; }
        }

        /// <summary>
        /// This is a "game definition" like "luke's game"
        /// </summary>
        public class GameDto
        {
            public Guid Id { get; set; }

            public string Name { get; set; }
            public Guid OwnerAccountId { get; set; }

            public GameQuestionDto[] Questions { get; set; }
            public Dictionary<string, string> GameSpecificMetadata { get; set; }

            public class GameQuestionDto
            {
                public Guid QuestionId { get; set; }
                public Dictionary<string, string> GameSpecificMetadata { get; set; }
            }
        }

        [HttpPost]
        [Authorize(AuthPolicies.Authenticated)]
        [ProducesResponseType(200, Type = typeof(GameDto))]
        public IActionResult CreateGame([FromBody] CreateGameDto game)
        {
            var newGame = new GameDto
            {
                Id = Guid.NewGuid(),
            };

            return StatusCode(200, newGame);
        }

        [HttpGet]
        [Authorize(AuthPolicies.Authenticated)]
        [ProducesResponseType(200, Type = typeof(GameDto))]
        public IActionResult GetGame(Guid id)
        {
            var game = new GameDto()
            {
                Id = id
            };

            return StatusCode(200, game);
        }

        [HttpDelete]
        [Authorize(AuthPolicies.Authenticated)]
        [ProducesResponseType(204)]
        public IActionResult DeleteGate(Guid id)
        {
            return StatusCode(204);
        }

        [HttpPut]
        [Authorize(AuthPolicies.Authenticated)]
        [ProducesResponseType(200, Type = typeof(GameDto))]
        public IActionResult UpdateGame(GameDto game)
        {
            return StatusCode(200, game);
        }
    }
}
