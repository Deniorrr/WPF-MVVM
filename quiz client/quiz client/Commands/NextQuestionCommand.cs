using quiz_client.Models;
using quiz_client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quiz_client.Commands
{
    internal class NextQuestionCommand : CommandsBase
    {
        private readonly Quiz _quiz;
        private readonly SolveQuizViewModel _solveQuizViewModel;

        public NextQuestionCommand(SolveQuizViewModel solveQuizViewModelQuiz,Quiz quiz)
        {
            _solveQuizViewModel = solveQuizViewModelQuiz;
            _quiz = quiz;
        }

        public override void Execute(object parameter)
        {
            _quiz.saveAnswers(_solveQuizViewModel.UserAnswer1, _solveQuizViewModel.UserAnswer2, _solveQuizViewModel.UserAnswer3, _solveQuizViewModel.UserAnswer4);
            _quiz.nextQuestion();
            if (_quiz.FirstQuestion())
            {
                _solveQuizViewModel.PreviousButtonEnabled = false;
            }
            else
            {
                _solveQuizViewModel.PreviousButtonEnabled = true;
            }
            if (_quiz.LastQuestion())
            {
                _solveQuizViewModel.NextButtonEnabled = false;
            }
            else
            {
                _solveQuizViewModel.NextButtonEnabled = true;
            }
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
