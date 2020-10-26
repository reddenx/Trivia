using System;
using System.Collections.Generic;
using System.Text;
using Trivia.Core.Question;
using Trivia.Core.Question.Infrastructure;

namespace Trivia.Infrastructure.Question
{
    public class QuestionRepository : IQuestionRepository
    {
        private static readonly Dictionary<Guid, QuestionAggregate> _questions = new Dictionary<Guid, QuestionAggregate>();

        public QuestionAggregate GetQuestion(Guid questionId)
        {
            if(_questions.ContainsKey(questionId))
            {
                return _questions[questionId];
            }

            return null;
        }

        public void SaveQuestion(QuestionAggregate question)
        {
            _questions[question.Id] = question;
        }
    }
}
