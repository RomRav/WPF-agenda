using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Agenda
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //Route vers la page addCustomer
        public void toAddCustomer(Object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new System.Uri("addCustomer.xaml", UriKind.RelativeOrAbsolute));
        }
        //Route vers la liste des clients
        public void toCustomerList(Object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new System.Uri("customersList.xaml", UriKind.RelativeOrAbsolute));
        }
        //Route vers le formulaire d'ajout d'un courtier.
        public void toAddBroker(Object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new System.Uri("addBroker.xaml", UriKind.RelativeOrAbsolute));
        }
        //Route vers le formulaire d'ajout d'un courtier.
        public void toBrokersList(Object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new System.Uri("brokersList.xaml", UriKind.RelativeOrAbsolute));
        }
        //Route vers la liste des rendez-vous.
        public void toAppointmentsList(Object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new System.Uri("appointmentsList.xaml", UriKind.RelativeOrAbsolute));
        }
        
        //Route vers la liste des rendez-vous.
        public void toAddAppointment(Object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new System.Uri("addAppointment.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
