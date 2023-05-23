using quiz_client.Models;
using quiz_client.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quiz_client.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private NavigationStore _navigationStore;

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged; ;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }


        //public MainViewModel(Quiz quiz)
        //{
        //    CurrentViewModel = new SolveQuizViewModel(quiz);
        //}
    }
}
