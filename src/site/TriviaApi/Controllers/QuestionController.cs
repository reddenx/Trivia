using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TriviaApi.Security;

namespace TriviaApi.Controllers
{
    [Route("api/question")]
    public class QuestionController : Controller
    {
        public class QuestionDto
        {
            public string[] Tags { get; internal set; }
            public ReadonlyQuestionDto.AnswersDto[] Answers { get; internal set; }
            public string Prompt { get; internal set; }
            public ReadonlyQuestionDto.PromptTypes PromptType { get; internal set; }
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
        [Authorize(AuthPolicies.Authenticated)]
        [ProducesResponseType(200, Type = typeof(ReadonlyQuestionDto))]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        public IActionResult GetQuestion([FromRoute] Guid id)
        {
            var question = new ReadonlyQuestionDto
            {
                Id = id,
                Answers = new ReadonlyQuestionDto.AnswersDto[] { },
                Prompt = "derp",
                PromptType = ReadonlyQuestionDto.PromptTypes.Text,
                Tags = new string[] { }
            };

            return StatusCode(200, question);
        }

        [HttpPost("")]
        [ProducesResponseType(200, Type = typeof(ReadonlyQuestionDto))]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        public IActionResult CreateQuestion([FromBody] QuestionDto question)
        {
            var newQuestion = new ReadonlyQuestionDto
            {
                Id = Guid.NewGuid(),
                Tags = question.Tags,
                Answers = question.Answers,
                Prompt = question.Prompt,
                PromptType = question.PromptType
            };

            return StatusCode(200, newQuestion);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(ReadonlyQuestionDto))]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        public IActionResult UpdateQuestion([FromRoute] Guid id, [FromBody] QuestionDto question)
        {
            var updatedQuestion = new ReadonlyQuestionDto
            {
                Id = id,
                Answers = question.Answers,
                Prompt = question.Prompt,
                PromptType = question.PromptType,
                Tags = question.Tags
            };

            return StatusCode(200, updatedQuestion);
        }
    }
}
