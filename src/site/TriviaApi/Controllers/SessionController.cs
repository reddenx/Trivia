using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TriviaApi.Controllers
{
    [Route("api/session")]
    public class SessionController : Controller
    {
        public class CreateSessionDto
        {
            public string Name { get; set; }
        }

        public class SessionDto
        {
            public Guid Id { get; set; }
            public string Name { get; set; }

            public Guid? CurrentGameType { get; set; }
            public object[] CurrentGameEventJournal { get; set; }

            public SessionPlayerDto[] Players { get; set; }

            public class SessionPlayerDto
            { 
                public int AccountId { get; set; }
                public string Username { get; set; }
            }
        }

        [HttpGet("api/session/{id}")]
        public IActionResult GetSession([FromRoute] Guid id)
        {
            var session = new SessionDto
            {
                Id = id
            };

            return StatusCode(200, session);
        }

        [HttpPost("api/session")]
        public IActionResult CreateSession([FromBody] CreateSessionDto session)
        {
            var newSession = new SessionDto()
            {
                Id = Guid.NewGuid()
            };

            return StatusCode(200, newSession);
        }

        //todo
        //- player join
        //- event happened
        //- websocket upgrade handling
    }
}
