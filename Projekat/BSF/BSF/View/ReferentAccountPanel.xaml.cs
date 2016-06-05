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

namespace BSF.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ReferentAccountPanel : Page
    {
        ReferentAccount viewModel;
        public ReferentAccountPanel()
        {
            this.InitializeComponent();
            textBox_accountFrom.IsReadOnly = true;
            textBox_accountTo.IsReadOnly = true;
        }

        private void radioButton_transaction_Checked(object sender, RoutedEventArgs e)
        {
            textBox_accountFrom.IsReadOnly = false;
            textBox_accountTo.IsReadOnly = false;
        }

        private void radioButton_depozit_Checked(object sender, RoutedEventArgs e)
        {
            textBox_accountFrom.IsReadOnly = true;
            textBox_accountTo.IsReadOnly = false;
        }

        private void radioButton_preuzimanje_Checked(object sender, RoutedEventArgs e)
        {
            textBox_accountFrom.IsReadOnly = false;
            textBox_accountTo.IsReadOnly = true;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            viewModel = (ReferentAccount)e.Parameter;
        }
    }
}
