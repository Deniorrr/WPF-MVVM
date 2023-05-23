using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quiz_client.ViewModels
{
    internal class QuizListViewModel : ViewModelBase
    {
        private int _id;
        private string _name;

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }

        public QuizListViewModel(int id, string name)
        {
            _id = id;
            _name = name;
        }
    }
}
