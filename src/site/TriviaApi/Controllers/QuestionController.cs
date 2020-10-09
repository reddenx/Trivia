using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TriviaApi.Controllers
{
    [Route("api/question")]
    public class QuestionController : Controller
    {
        public class CreateQuestionDto
        {
        }
        public class QuestionDto
        {
            public Guid Id { get; set; }
        }

        public class ReadonlyQuestionDto
        {
            public Guid Id { get; set; }

            public string Prompt { get; set; }
            public PromptTypes PromptType { get; set; }
            public string[] Tags { get; set; }

            public AnswersDto[] Answers { get; set; }


            public class AnswersDto
            {
                public string[] Response { get; set; }
                public ResponseTypes ResponseType { get; set; }

                public enum ResponseTypes
                {
                    SingleTextAnswer,
                    MultipleChoice,
                    Drawing,
                }
            }

            public enum PromptTypes
            {
                Text,
                Markdown,
                Url,
                ImageUrl,
                VideoUrl,
            }
        }


        [HttpGet("{id}")]
        public IActionResult GetQuestion([FromRoute] Guid id)
        {
            var question = new QuestionDto
            {
                Id = id,
            };

            return StatusCode(200, question);
        }

        [HttpPost("")]
        public IActionResult CreateQuestion([FromBody] CreateQuestionDto question)
        {
            var newQuestion = new QuestionDto
            {
                Id = Guid.NewGuid()
            };

            return StatusCode(200, newQuestion);
        }

        public GameController GetDumbStuff()
        {
            return null;
        }
    }
}
