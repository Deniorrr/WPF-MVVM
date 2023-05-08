using quiz_client.Models;
using quiz_client.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace quiz_client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Quiz _quiz;

        public App()
        {
            //Tu będzie kiedyś wczytanie quizu z bazy danych
            _quiz = new Quiz(1,"jeden quiz");
            _quiz.addQuestion(new Question("pytanko1", new Answer("odp1", false), new Answer("odp2", true), new Answer("odp3", false), new Answer("odp4", false)));
            _quiz.addQuestion(new Question("pytanko2", new Answer("odp5", true), new Answer("odp6", false), new Answer("odp7", false), new Answer("odp8", false)));
        }   

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_quiz)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
        
    }
}
