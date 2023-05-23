using quiz_client.Models;
using quiz_client.Stores;
using quiz_client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quiz_client.Commands
{
    internal class StartQuizCommand : CommandsBase
    {
        //private readonly Quiz _quiz;
        //private readonly SolveQuizViewModel _solveQuizViewModel;

        //public StartQuizCommand(SolveQuizViewModel solveQuizViewModelQuiz, Quiz quiz)
        //{
        //    _solveQuizViewModel = solveQuizViewModelQuiz;
        //    _quiz = quiz;
        //}
        private readonly NavigationStore _navigationStore;
        private readonly TitleViewModel _titleViewModel;
        public StartQuizCommand(NavigationStore navigationStore, TitleViewModel titleViewModel)
        {
            _navigationStore = navigationStore;
            _titleViewModel = titleViewModel;
        }

        public override void Execute(object parameter)
        {
            int quizId = _titleViewModel.SelectedQuizId;
            string quizName = _titleViewModel.SelectedQuizName;
            Quiz _quiz = DataBaseAccess.ReadQuizContent(quizId, quizName);
            //_quiz.addQuestion(new Question("pytanko1", new Answer("odp1", false), new Answer("odp2", true), new Answer("odp3", false), new Answer("odp4", false)));
            //_quiz.addQuestion(new Question("pytanko2", new Answer("odp5", true), new Answer("odp6", false), new Answer("odp7", false), new Answer("odp8", false)));
            _navigationStore.CurrentViewModel = new SolveQuizViewModel(_quiz);
            //To będzie w ctorze viewmodel
            //_solveQuizViewModel.StartVisibility = "Collapsed";

            //_solveQuizViewModel.startTimer();

            //Question currentQuestion = _quiz.GetQuestion();
            //_solveQuizViewModel.resetAnswers(currentQuestion.UserAnswer1, currentQuestion.UserAnswer2, currentQuestion.UserAnswer3, currentQuestion.UserAnswer4);
            //_solveQuizViewModel.ActiveQuestion = currentQuestion.question;
            //_solveQuizViewModel.ActiveAnswer1 = currentQuestion.Answer1.Content;
            //_solveQuizViewModel.ActiveAnswer2 = currentQuestion.Answer2.Content;
            //_solveQuizViewModel.ActiveAnswer3 = currentQuestion.Answer3.Content;
            //_solveQuizViewModel.ActiveAnswer4 = currentQuestion.Answer4.Content;
        }

    }
}
