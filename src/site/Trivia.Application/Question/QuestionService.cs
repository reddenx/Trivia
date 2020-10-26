using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Trivia.Core.Question;
using Trivia.Infrastructure.Question;
using Trivia.Core.Question.Infrastructure;

namespace Trivia.Application.Question
{
    public class QuestionService
    {
        private readonly IQuestionRepository _questionRepo;

        public QuestionService(IQuestionRepository questionRepo)
        {
            _questionRepo = questionRepo;
        }

        public class GetQuestionResult
        {
            public ReadonlyQuestionDto Question { get; }
            public Errors? Error { get; }

            public GetQuestionResult(ReadonlyQuestionDto question, Errors? error)
            {
                Question = question;
                Error = error;
            }

            public enum Errors
            {
                Validation,
                NotFound,
                Technical,
            }
        }

        public GetQuestionResult GetQuestion(Guid questionId, Guid accountId)
        {
            var question = _questionRepo.GetQuestion(questionId);

            if (question == null)
                return new GetQuestionResult(null, GetQuestionResult.Errors.NotFound);

            var dto = new ReadonlyQuestionDto
            {
                Id = question.Id,
                Answers = question.Answers.Select(a => new ReadonlyQuestionDto.AnswersDto
                {
                    Response = a.Response,
                    ResponseType = MapResponseType(a.ResponseType),
                }).ToArray(),
                Prompt = question.Prompt,
                PromptType = MapPromptType(question.PromptType),
                Tags = question.Tags.ToArray()
            };

            return new GetQuestionResult(dto, null);
        }

        public class CreateQuestionResult
        {
            public ReadonlyQuestionDto Question { get; }
            public Errors? Error { get; }

            public CreateQuestionResult(ReadonlyQuestionDto question, Errors? error)
            {
                Question = question;
                Error = error;
            }

            public enum Errors
            {
                Validation,
                Technical,
            }
        }

        public CreateQuestionResult CreateQuestion(QuestionDto question, Guid accountId)
        {
            var newQuestion = new QuestionAggregate()
            {
                Answers = question.Answers?.Select(a => new AnswerData()
                {
                    Response = a.Response,
                    ResponseType = MapResponseType(a.ResponseType),
                }).ToArray() ?? new AnswerData[] { },
                Id = Guid.NewGuid(),
                Prompt = question.Prompt,
                PromptType = MapPromptType(question.PromptType),
                Tags = question?.Tags ?? new string[] { },
                CreatedByAccountId = accountId,
            };

            _questionRepo.SaveQuestion(newQuestion);
            var result = GetQuestion(newQuestion.Id, accountId);

            return new CreateQuestionResult(result.Question, null);
        }

        public class UpdateQuestionResult
        {
            public ReadonlyQuestionDto Question { get; }
            public Errors? Error { get; }

            public UpdateQuestionResult(ReadonlyQuestionDto question, Errors? error)
            {
                Question = question;
                Error = error;
            }

            public enum Errors
            {
                Validation,
                NotFound,
                Technical,
            }
        }

        public UpdateQuestionResult UpdateQuestion(Guid id, QuestionDto questionInput, Guid accountId)
        {
            var question = _questionRepo.GetQuestion(id);
            if (question == null)
                return new UpdateQuestionResult(null, UpdateQuestionResult.Errors.NotFound);

            question.Answers = questionInput.Answers?.Select(a => new AnswerData()
            {
                Response = a.Response,
                ResponseType = MapResponseType(a.ResponseType),
            }).ToArray() ?? new AnswerData[] { };

            question.Prompt = questionInput.Prompt;
            question.PromptType = MapPromptType(questionInput.PromptType);
            question.Tags = questionInput.Tags?.ToArray() ?? new string[] { };

            _questionRepo.SaveQuestion(question);
            var getResult = GetQuestion(id, accountId);

            return new UpdateQuestionResult(getResult.Question, null);
        }

        private QuestionPromptTypes MapPromptType(PromptTypes promptType)
        {
            switch(promptType)
            {
                case PromptTypes.ImageUrl:
                    return QuestionPromptTypes.ImageUrl;
                case PromptTypes.Markdown:
                    return QuestionPromptTypes.Markdown;
                case PromptTypes.Text:
                    return QuestionPromptTypes.Text;
                case PromptTypes.Url:
                    return QuestionPromptTypes.Url;
                case PromptTypes.VideoUrl:
                    return QuestionPromptTypes.VideoUrl;
                default:
                    throw new NotImplementedException();
            }
        }

        private PromptTypes MapPromptType(QuestionPromptTypes promptType)
        {
            switch (promptType)
            {
                case QuestionPromptTypes.ImageUrl:
                    return PromptTypes.ImageUrl;
                case QuestionPromptTypes.Markdown:
                    return PromptTypes.Markdown;
                case QuestionPromptTypes.Text:
                    return PromptTypes.Text;
                case QuestionPromptTypes.Url:
                    return PromptTypes.Url;
                case QuestionPromptTypes.VideoUrl:
                    return PromptTypes.VideoUrl;
                default:
                    throw new NotImplementedException();
            }
        }

        private ReadonlyQuestionDto.AnswersDto.ResponseTypes MapResponseType(ResponseTypes responseType)
        {
            switch(responseType)
            {
                case ResponseTypes.Drawing:
                    return ReadonlyQuestionDto.AnswersDto.ResponseTypes.Drawing;
                case ResponseTypes.MultipleChoice:
                    return ReadonlyQuestionDto.AnswersDto.ResponseTypes.MultipleChoice;
                case ResponseTypes.SingleTextAnswer:
                    return ReadonlyQuestionDto.AnswersDto.ResponseTypes.SingleTextAnswer;
                default:
                    throw new NotImplementedException();
            }
        }

        private ResponseTypes MapResponseType(ReadonlyQuestionDto.AnswersDto.ResponseTypes responseType)
        {
            switch(responseType)
            {
                case ReadonlyQuestionDto.AnswersDto.ResponseTypes.Drawing:
                    return ResponseTypes.Drawing;
                case ReadonlyQuestionDto.AnswersDto.ResponseTypes.MultipleChoice:
                    return ResponseTypes.MultipleChoice;
                case ReadonlyQuestionDto.AnswersDto.ResponseTypes.SingleTextAnswer:
                    return ResponseTypes.SingleTextAnswer;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
