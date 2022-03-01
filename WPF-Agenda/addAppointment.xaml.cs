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
        private readonly agendaContext _db;
        public addAppointment()
        {
            _db = new agendaContext();
            InitializeComponent();
            List<Customer> listCustomers = _db.Customers.ToList();
            List<Broker> listBrokers = _db.Brokers.ToList();
            customerComboBox.ItemsSource = listCustomers;
            brokerComboBox.ItemsSource = listBrokers;
        }
        //Ajout un rendez-vous à la base de données
        private void insertAppointment(object sender, RoutedEventArgs e)
        {
            double hour = InputCheck.checkHourInput(appHour.Text);
            double minute = InputCheck.checkMinuteInput(appMinute.Text);
            if(hour < 25 && minute < 60)
            {
                DateTime appDateTime = appointmentdate.DisplayDate;
                appDateTime = appDateTime.AddHours(hour);
                appDateTime = appDateTime.AddMinutes(minute);
                Appointment newAppointment = new Appointment();
                Broker broker = (Broker)brokerComboBox.SelectedItem;
                Customer customer = (Customer)customerComboBox.SelectedItem;
                newAppointment.IdBroker = broker.IdBroker;
                newAppointment.IdCustomer = customer.IdCustomer;
                newAppointment.DateHour = appDateTime;
                newAppointment.Subject = appSubject.Text;
                try
                {
                    _db.Appointments.Add(newAppointment);
                    _db.SaveChanges();
                    erreurMessage.Content = "OK.";
                    erreurMessage.Foreground = Brushes.Green;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            else
            {
                erreurMessage.Content = "Erreur de saisie. Merci de vérifier vos saisies.";
                erreurMessage.Foreground = Brushes.Red;
            }
            
        }
    }
}
