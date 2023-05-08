using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quiz_client.Models
{
    public class Quiz
    {
        private int _id;
        private string _name;
        private int _questionId = 0;
        private List<Question> _questions = new List<Question>();

        public Quiz(int id, string name)
        {
            _id = id;
            _name = name;
        }

        public List<Question> Questions { get { return _questions;} }

        public string Name { get => _name; set => _name = value; }

        public void addQuestion(Question question) {
            _questions.Add(question);
        }

        public Question GetQuestion()
        {
            return _questions[_questionId];
        }

        public void nextQuestion()
        {
            _questionId+=1;
        }
        public void previousQuestion()
        {
            _questionId-=1;
        }

        public void saveAnswers(bool UserAnswer1, bool UserAnswer2, bool UserAnswer3, bool UserAnswer4)
        {
            _questions[_questionId].saveAnswers(UserAnswer1, UserAnswer2, UserAnswer3, UserAnswer4);
        }

        public bool LastQuestion()
        {
            if(_questions.Count-1 == _questionId) return true;
            return false;
        }
        public bool FirstQuestion()
        {
            if(_questionId == 0) return true;
            return false;
        }
    }
}
