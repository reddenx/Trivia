using System;
using System.Collections.Generic;
using System.Text;

namespace Trivia.Core.Question.Infrastructure
{
    public interface IQuestionRepository
    {
        QuestionAggregate GetQuestion(Guid questionId);
        void SaveQuestion(QuestionAggregate question);
    }
}
