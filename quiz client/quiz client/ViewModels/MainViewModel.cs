using Microsoft.Data.Sqlite;
using quiz_client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quiz_client.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ViewModelBase CurrentViewModel { get; set; }

        public MainViewModel(Quiz quiz)
        {
            CurrentViewModel = new SolveQuizViewModel(quiz);
            DataBaseAccess.ReadData();
        }
    }
}
