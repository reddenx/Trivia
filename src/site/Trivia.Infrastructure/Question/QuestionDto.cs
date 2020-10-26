using System;
using System.Collections.Generic;
using System.Text;

namespace Trivia.Infrastructure.Question
{
    public class QuestionDto
    {
        public string[] Tags { get; internal set; }
        public ReadonlyQuestionDto.AnswersDto[] Answers { get; internal set; }
        public string Prompt { get; internal set; }
        public QuestionPromptTypes PromptType { get; internal set; }
    }
}
