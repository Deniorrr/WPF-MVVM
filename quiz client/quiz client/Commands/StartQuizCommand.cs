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
            //if (!_quiz.IsEmpty())
            //{
                _navigationStore.CurrentViewModel = new SolveQuizViewModel(_quiz, _navigationStore);
            //}
        }

    }
}
