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
    internal class EndQuizCommand : CommandsBase
    {
        private readonly Quiz _quiz;
        private readonly SolveQuizViewModel _solveQuizViewModel;
        private readonly NavigationStore _navigationStore;

        public EndQuizCommand(SolveQuizViewModel solveQuizViewModelQuiz, Quiz quiz, NavigationStore navigationStore, string quizTime)
        {
            _solveQuizViewModel = solveQuizViewModelQuiz;
            _quiz = quiz;
            _navigationStore = navigationStore;
        }


        public override void Execute(object parameter)
        {
            _quiz.saveAnswers(_solveQuizViewModel.UserAnswer1, _solveQuizViewModel.UserAnswer2, _solveQuizViewModel.UserAnswer3, _solveQuizViewModel.UserAnswer4);
            int i = 1;
            _quiz.Questions.ForEach(x => { _solveQuizViewModel.QuestionsAdd(x, i++); });
            _solveQuizViewModel.stopTimer();
            _navigationStore.CurrentViewModel = new ResultViewModel(_solveQuizViewModel._questions, _solveQuizViewModel.QuizTime);
        }
    }
}
