using System;
using System.Collections.Generic;
using System.Text;

namespace Trivia.Infrastructure.Question
{
    public class ReadonlyQuestionDto
    {
        public Guid Id { get; set; }

        public string Prompt { get; set; }
        public QuestionPromptTypes PromptType { get; set; }
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
    }
}
