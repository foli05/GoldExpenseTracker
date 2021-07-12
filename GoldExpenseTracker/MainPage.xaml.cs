using GoldExpenseTracker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GoldExpenseTracker
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            var expenses = new List<Expense>();
            var files = Directory.EnumerateFiles(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "*.expenses.txt");


            foreach (var filename in files)
            {
                var expense = new Expense
                {
                    Text = File.ReadAllText(filename),
                    Date = File.GetCreationTime(filename),
                    //Amount = amount,
                    // PurchaseDate = purchasedate,
                    // Category = category,
                    FileName = filename
            
                };
                expenses.Add(expense);
            }
            //binding to the ListView
            ExpensesListView.ItemsSource = expenses.OrderBy(exp => exp.Date).ToList();
        }


        private async void OnAddExpenseClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddExpense
            {
                BindingContext = new Expense()
            });
        }

        private async void OnExpenseItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushModalAsync(new AddExpense
            {
                BindingContext = (Expense)e.SelectedItem
            });
        }
    }
}
