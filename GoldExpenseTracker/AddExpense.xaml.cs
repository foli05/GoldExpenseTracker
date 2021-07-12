using GoldExpenseTracker.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoldExpenseTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddExpense : ContentPage
    {
        //removing the below: no longer needed
        //string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "expenses.text");
        public AddExpense()
        {
            InitializeComponent();

            //also removing the below, no longer needed since we are not reading that file anymore
            //if (File.Exists(fileName))
            //{
            //    editor.Text = File.ReadAllText(fileName);
            //}

        }
        protected override void OnAppearing()
        {
            var expense = (Expense)BindingContext;
            if (!string.IsNullOrEmpty(expense.FileName))
            {
                editor.Text = File.ReadAllText(expense.FileName);
            }
        }
        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var expense = (Expense)BindingContext;
            if (string.IsNullOrEmpty(expense.FileName))
            {
                expense.FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),$"{ Path.GetRandomFileName()}.expenses.txt");
            }


                //read everything (content) from the text editor and write it all into the file to be saved
                File.WriteAllText(expense.FileName, editor.Text);
            //upon hitting save, popout and go the previous page
            await Navigation.PopModalAsync();
        }

        private async void OnDeleteButtonClicked(object sender, EventArgs e)
        {

            //if (File.Exists(fileName))
            //{
            //    File.Delete(fileName);
            //}

            //once delete completes, we want to clear the textbox


            var expense = (Expense)BindingContext;
            if (File.Exists(expense.FileName))
            {
                File.Delete(expense.FileName);
            }

            editor.Text = string.Empty;
            await Navigation.PopModalAsync();

        }
    }
}