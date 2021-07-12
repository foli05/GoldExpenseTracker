using GoldExpenseTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoldExpenseTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddMonthlyGoal : ContentPage
    {
        public AddMonthlyGoal()
        {
            InitializeComponent();
        }

        private async void GoalSaveClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MainPage
            {
                BindingContext = new Expense()
            });
        }

        private void GoalDeleteClicked(object sender, EventArgs e)
        {

        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {

        }
    }
}