using quiz_client.Commands;
using quiz_client.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace quiz_client.ViewModels
{
    internal class TitleViewModel : ViewModelBase
    {
        private string _title = "";
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private ObservableCollection<QuizListViewModel> _quizes;
        public IEnumerable<QuizListViewModel> Quizes => _quizes;

        private int _selectedItem = 0;
        private int _selectedQuizId;
        private string _selectedQuizName;
        
        public int SelectedItem { get => _selectedItem;
            set
            {
                Console.Write(value);
                SelectedQuizId = _quizes[value].Id;
                SelectedQuizName = _quizes[value].Name;
                _selectedItem = value;
            }
        }

        public ICommand StartQuizCommand { get; set; }
        public int SelectedQuizId { get => _selectedQuizId; set => _selectedQuizId = value; }
        public string SelectedQuizName { get => _selectedQuizName; set => _selectedQuizName = value; }

        public TitleViewModel(Stores.NavigationStore navigationStore)
        {
            _quizes = new ObservableCollection<QuizListViewModel>();
            DataBaseAccess.ReadQuizes(_quizes);
            SelectedQuizId = _quizes[_selectedItem].Id;
            SelectedQuizName = _quizes[_selectedItem].Name;
            StartQuizCommand = new StartQuizCommand(navigationStore, this);
        }
    }
}
