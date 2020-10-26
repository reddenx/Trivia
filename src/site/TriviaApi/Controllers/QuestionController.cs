using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trivia.Application.Account;
using Trivia.Application.Question;
using Trivia.Infrastructure.Question;
using TriviaApi.Security;

namespace TriviaApi.Controllers
{
    [Route("api/v1/questions")]
    public class QuestionController : Controller
    {
        private readonly QuestionService _questionService;

        public QuestionController(QuestionService questionService)
        {
            _questionService = questionService;
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
            var userContext = this.GetUserContext();
            var result = _questionService.GetQuestion(id, userContext.AccountId);

            switch (result.Error)
            {
                case QuestionService.GetQuestionResult.Errors.NotFound:
                    return StatusCode(404);
                case QuestionService.GetQuestionResult.Errors.Validation:
                    return StatusCode(400);
                case null:
                    return Ok(result.Question);
                case QuestionService.GetQuestionResult.Errors.Technical:
                default:
                    return StatusCode(500);
            }
        }

        [HttpPost("")]
        [Authorize(AuthPolicies.Authenticated)]
        [ProducesResponseType(200, Type = typeof(ReadonlyQuestionDto))]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        public IActionResult CreateQuestion([FromBody] QuestionDto question)
        {
            var userContext = this.GetUserContext();
            var result = _questionService.CreateQuestion(question, userContext.AccountId);

            switch (result.Error)
            {
                case QuestionService.CreateQuestionResult.Errors.Validation:
                    return StatusCode(400);
                case null:
                    return Ok(result.Question);
                case QuestionService.CreateQuestionResult.Errors.Technical:
                default:
                    return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(ReadonlyQuestionDto))]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        public IActionResult UpdateQuestion([FromRoute] Guid id, [FromBody] QuestionDto question)
        {
            var userContext = this.GetUserContext();
            var result = _questionService.UpdateQuestion(id, question, userContext.AccountId);

            switch (result.Error)
            {
                case QuestionService.UpdateQuestionResult.Errors.NotFound:
                    return StatusCode(404);
                case QuestionService.UpdateQuestionResult.Errors.Validation:
                    return StatusCode(400);
                case null:
                    return Ok(result.Question);
                case QuestionService.UpdateQuestionResult.Errors.Technical:
                default:
                    return StatusCode(500);
            }
        }
    }
}
