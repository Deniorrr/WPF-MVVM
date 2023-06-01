using quiz_client.Models;
using quiz_client.Stores;
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
        private NavigationStore _navigationStore;


        public App()
        {
            _navigationStore = new NavigationStore();
        }   

        protected override void OnStartup(StartupEventArgs e)
        {
            
            
            //_navigationStore.CurrentViewModel = new SolveQuizViewModel(_quiz);
            _navigationStore.CurrentViewModel = new TitleViewModel(_navigationStore);
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
        
    }
}
