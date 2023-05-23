using quiz_client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quiz_client.ViewModels
{
    public class QuestionViewModel : ViewModelBase
    {
        private Question _question;

        private bool _correct;

        private int _id;

        public string question => _question.question;

        public bool Correct { get => _correct; set => _correct = value; }
        public int Id { get => _id; set => _id = value; }

        public QuestionViewModel(Question question, int id)
        {
            _question = question;
            checkAnswers();
            Id = id;
        }

        public void checkAnswers()
        {
            _correct = _question.Correct();
        }
    }
}
