using BSF.DAL;
using BSF.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BSF.Model
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    public sealed partial class SupervisorPanel : Page
    {
        SupervisorPanelViewModel viewModel;
        Person person;
        public SupervisorPanel()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            viewModel = (SupervisorPanelViewModel) e.Parameter;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var boundData = (Person)((Button)sender).DataContext;
            using(var db = new BankDbContext())
            {
                var person =  db.Persons.Where(x => x.AccoutnId == boundData.AccoutnId).FirstOrDefault();
                person.Validated = true;
                db.SaveChanges();
                viewModel.PenndingAccounts.Remove(boundData);
                listView_transactions.ItemsSource = null;
                listView_transactions.ItemsSource = 
            }
        }
    }
}
