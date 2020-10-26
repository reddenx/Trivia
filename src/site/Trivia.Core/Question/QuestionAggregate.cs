using System;
using System.Collections.Generic;
using System.Text;

namespace Trivia.Core.Question
{
    public class QuestionAggregate
    {
        public Guid Id;

        public string[] Tags { get; set; }
        public AnswerData[] Answers { get; set; }
        public string Prompt { get; set; }
        public PromptTypes PromptType { get; set; }
        public Guid CreatedByAccountId { get; set; }
    }

    public class AnswerData
    {
        public string[] Response { get; set; }
        public ResponseTypes ResponseType { get; set; }
    }

    public enum ResponseTypes
    {
        SingleTextAnswer,
        MultipleChoice,
        Drawing,
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
