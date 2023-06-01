using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quiz_client.ViewModels
{
    class ResultViewModel : ViewModelBase
    {
        private ObservableCollection<QuestionViewModel> _questions;
        public IEnumerable<QuestionViewModel> Questions => _questions;

        private int _questionAmount;
        private int _correctQuestionAmount = 0;

        private string _result;

        public string Result
        {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
                OnPropertyChanged(nameof(Result));
            }
        }

        private string _quizTime;
        public string QuizTime { get => _quizTime; set => _quizTime = value; }
        public ResultViewModel(ObservableCollection<QuestionViewModel> questions, string quizTime)
        {
            _questions = questions;
            _quizTime = quizTime;
            _questionAmount = questions.Count();
            foreach(QuestionViewModel x in questions)
            {
                if(x.Correct) _correctQuestionAmount+=1;
            }
            Result = "Result: " + _correctQuestionAmount + "/" + _questionAmount;
        }
    }
}
