using quiz_client.Models;
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
        private readonly Quiz _quiz;
        private readonly SolveQuizViewModel _solveQuizViewModel;

        public StartQuizCommand(SolveQuizViewModel solveQuizViewModelQuiz, Quiz quiz)
        {
            _solveQuizViewModel = solveQuizViewModelQuiz;
            _quiz = quiz;
        }

        public override void Execute(object parameter)
        {
            _solveQuizViewModel.StartVisibility = "Collapsed";

            _solveQuizViewModel.startTimer();

            Question currentQuestion = _quiz.GetQuestion();
            _solveQuizViewModel.resetAnswers(currentQuestion.UserAnswer1, currentQuestion.UserAnswer2, currentQuestion.UserAnswer3, currentQuestion.UserAnswer4);
            _solveQuizViewModel.ActiveQuestion = currentQuestion.question;
            _solveQuizViewModel.ActiveAnswer1 = currentQuestion.Answer1.Content;
            _solveQuizViewModel.ActiveAnswer2 = currentQuestion.Answer2.Content;
            _solveQuizViewModel.ActiveAnswer3 = currentQuestion.Answer3.Content;
            _solveQuizViewModel.ActiveAnswer4 = currentQuestion.Answer4.Content;
        }
    }
}
