using Microsoft.Data.Entity;
using App1.AccountBaza.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App1.AccountBaza.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AccountiListView : Page
    {
        public AccountiListView()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new BankaBaza.Models.AccountDbContext())
            {
                //AccountiIS.ItemsSource = db.Accounti.OrderBy(c => c.Username).ToList();
            }
        }
        private void buttonDodaj_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new BankaBaza.Models.AccountDbContext())
            {
                //var contact = new BankaBaza.Models.Account { Username = UsernameInput.Text, Password = PasswordInput.Text }; db.Accounti.Add(contact);
                db.SaveChanges();
                //reset polja za unos 
                //UsernameInput.Text = string.Empty;
                //PasswordInput.Text = string.Empty;
                //refresh liste 
                //AccountiIS.ItemsSource = db.Accounti.OrderBy(c => c.Username).ToList();
            }
           
        }
        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            DependencyObject dep = (DependencyObject)e.OriginalSource;
            while ((dep != null) && !(dep is ListViewItem))
            {
                dep = VisualTreeHelper.GetParent(dep);
            }
            if (dep == null) return;
            using (var db = new BankaBaza.Models.AccountDbContext())
            {
                //db.Accounti.Remove((BankaBaza.Models.Account)AccountiIS.ItemFromContainer(dep));
                //Nije jos obrisano dok nije Save 
                //db.SaveChanges();
                //Refresh liste restorana 
                //AccountiIS.ItemsSource = db.Accounti.OrderBy(c => c.Username).ToList();
            }
        }
    }
}
        
