using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoldExpenseTracker
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AddMonthlyGoal();

            //MainPage = new MainPage();

            //MainPage = new AddExpense();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
