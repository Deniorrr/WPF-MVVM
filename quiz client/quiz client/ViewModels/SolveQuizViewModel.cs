using quiz_client.Commands;
using quiz_client.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Markup;
using System.ComponentModel;

namespace quiz_client.ViewModels
{
    public class SolveQuizViewModel : ViewModelBase
    {

        private string _quizTitle;

        public string QuizTitle { get => _quizTitle; set => _quizTitle = value; }

        private string _activeQuestion = "";
        public string ActiveQuestion
        { 
            get {
                return _activeQuestion;
            } 
            set {
                _activeQuestion = value;
                OnPropertyChanged(nameof(ActiveQuestion));
            }
        }
        private string _startVisibility = "Visible";
        public string StartVisibility
        {
            get
            {
                return _startVisibility;
            }
            set
            {
                _startVisibility = value;
                OnPropertyChanged(nameof(StartVisibility));
            }
        }
        private string _endVisibility = "Collapsed";
        public string EndVisibility
        {
            get
            {
                return _endVisibility;
            }
            set
            {
                _endVisibility = value;
                OnPropertyChanged(nameof(EndVisibility));
            }
        }
        private string _activeAnswer1;
        public string ActiveAnswer1
        {
            get
            {
                return _activeAnswer1;
            }
            set
            {
                _activeAnswer1 = value;
                OnPropertyChanged(nameof(ActiveAnswer1));
            }
        }

        private string _activeAnswer2;
        public string ActiveAnswer2
        {
            get
            {
                return _activeAnswer2;
            }
            set
            {
                _activeAnswer2 = value;
                OnPropertyChanged(nameof(ActiveAnswer2));
            }
        }

        private string _activeAnswer3;
        public string ActiveAnswer3
        {
            get
            {
                return _activeAnswer3;
            }
            set
            {
                _activeAnswer3 = value;
                OnPropertyChanged(nameof(ActiveAnswer3));
            }
        }

        private string _activeAnswer4;
        public string ActiveAnswer4
        {
            get
            {
                return _activeAnswer4;
            }
            set
            {
                _activeAnswer4 = value;
                OnPropertyChanged(nameof(ActiveAnswer4));
            }
        }

        private bool _userAnswer1;
        public bool UserAnswer1
        {
            get
            {
                return _userAnswer1;
            }
            set
            {
                _userAnswer1 = value;
                OnPropertyChanged(nameof(UserAnswer1));
            }
        }
        private bool _userAnswer2;
        public bool UserAnswer2
        {
            get
            {
                return _userAnswer2;
            }
            set
            {
                _userAnswer2 = value;
                OnPropertyChanged(nameof(UserAnswer2));
            }
        }
        private bool _userAnswer3;
        public bool UserAnswer3
        {
            get
            {
                return _userAnswer3;
            }
            set
            {
                _userAnswer3 = value;
                OnPropertyChanged(nameof(UserAnswer3));
            }
        }
        private bool _userAnswer4;
        public bool UserAnswer4
        {
            get
            {
                return _userAnswer4;
            }
            set
            {
                _userAnswer4 = value;
                OnPropertyChanged(nameof(UserAnswer4));
            }
        }

        private bool _nextButtonEnabled = true;
        public bool NextButtonEnabled
        {
            get
            {
                return _nextButtonEnabled;
            }
            set
            {
                _nextButtonEnabled = value;
                OnPropertyChanged(nameof(NextButtonEnabled));
            }
        }

        private bool _previousButtonEnabled = false;
        public bool PreviousButtonEnabled
        {
            get
            {
                return _previousButtonEnabled;
            }
            set
            {
                _previousButtonEnabled = value;
                OnPropertyChanged(nameof(PreviousButtonEnabled));
            }
        }



        private int seconds = 0;

        private string quizTime = TimeSpan.FromSeconds(0).ToString();

        public string QuizTime
        {
            get
            {
                return quizTime;
            }
            set
            {
                quizTime = value;
                OnPropertyChanged(nameof(QuizTime));
            }
        }

        public void addSecond(Object source, System.Timers.ElapsedEventArgs e)
        {
            seconds += 1;
        }

        public void updateTime(Object source, System.Timers.ElapsedEventArgs e)
        {
            QuizTime = TimeSpan.FromSeconds(seconds).ToString();

        }

        public void resetAnswers(bool _ua1, bool _ua2, bool _ua3, bool _ua4)
        {
            UserAnswer1 = _ua1;
            UserAnswer2 = _ua2;
            UserAnswer3 = _ua3;
            UserAnswer4 = _ua4;
        }
        private IEnumerable<Question> _list;

        private ObservableCollection<QuestionViewModel> _questions;

        public IEnumerable<QuestionViewModel> Questions => _questions;

        public ICommand NextQuestionCommand { get; set; }
        public ICommand StartQuizCommand { get; set; }

        public ICommand EndQuizCommand { get; set; }
        public ICommand PreviousQuestionCommand { get; set; }


        public void QuestionsAdd(Question question, int id)
        {
            _questions.Add(new QuestionViewModel(question, id));
        }

        private Timer aTimer = new System.Timers.Timer();

        public void startTimer()
        {
            aTimer.Enabled = true;
        }

        public void stopTimer()
        {
            //aTimer.Enabled = true;
            aTimer.Stop();
        }
        public SolveQuizViewModel(Quiz quiz)
        {
            aTimer.Interval = 1000;
            aTimer.Elapsed += addSecond;
            aTimer.Elapsed += updateTime;
            aTimer.AutoReset = true;
            _quizTitle = quiz.Name;
            _questions = new ObservableCollection<QuestionViewModel>();
            NextQuestionCommand = new NextQuestionCommand(this, quiz);
            PreviousQuestionCommand = new PreviousQuestionCommand(this, quiz);
            StartQuizCommand = new StartQuizCommand(this, quiz);
            EndQuizCommand = new EndQuizCommand(this, quiz);
        }
    }
}
