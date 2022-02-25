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
using WPF_Agenda.Models;

namespace WPF_Agenda
{
    public partial class addAppointment : Page
    {
        private readonly AgendaContext _db;
        public addAppointment()
        {
            _db = new AgendaContext();
            InitializeComponent();
            List<Customer> listCustomers = _db.Customers.ToList();
            List<Broker> listBrokers = _db.Brokers.ToList();
            customerComboBox.ItemsSource = listCustomers;
            brokerComboBox.ItemsSource = listBrokers;
        }
        //Ajout un rendez-vous à la base de données
        private void insertAppointment(object sender, RoutedEventArgs e)
        {
            DateTime appDateTime = appointmentdate.DisplayDate;
            appDateTime.AddHours(Convert.ToDouble(appHour.Text));
            appDateTime.AddMinutes(Convert.ToDouble(appMinute.Text));
            Appointment newAppointment = new Appointment();
            newAppointment.IdBroker = Convert.ToInt32(brokerComboBox.SelectedIndex);
            newAppointment.IdCustomer = Convert.ToInt32(customerComboBox.SelectedIndex);
            newAppointment.DateHour = appDateTime;
            Console.WriteLine(newAppointment.ToString());
        }
    }
}
