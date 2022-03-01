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
    public partial class appointmentsList : Page
    {
        private readonly agendaContext _db;
        
        public IEnumerable<Customer> listCustomers;
        public IEnumerable<Broker> listBrokers;

        public appointmentsList()
        {
            _db = new agendaContext();
            listCustomers = _db.Customers;
            listBrokers = _db.Brokers;
            InitializeComponent();
            this.DataContext = new Appointment();
            appointmentsDataGrid.ItemsSource = AppointmentListBuilder();
        }
        //au double clique sur un rendez-vous de la liste les données de ce rendez-vous sont tranférées dans le formulaire de modification.
        private void transferDataToForm_Click(object sender, MouseButtonEventArgs e)
        {
            
            customerComboBox.ItemsSource = listCustomers.ToList();
            brokerComboBox.ItemsSource = listBrokers.ToList();
            Appointment appointment = (Appointment)appointmentsDataGrid.SelectedItem;
            id.Content = appointment.IdAppointment;
            
            brokerComboBox.SelectedIndex = findBrokerComboIndex(appointment.IdBroker);
            customerComboBox.SelectedIndex = findCustomerComboIndex(appointment.IdCustomer);
            DatePicker date = new DatePicker();
            date.DisplayDate = appointment.DateHour;
            appHour.Text = appointment.DateHour.Hour.ToString();
            appMinute.Text = appointment.DateHour.Minute.ToString();
            appSubject.Text = appointment.Subject;

        }
        //Au clique sur le bouton modifiez récupére les saisies du formaulaire, les verifies et modifie le rendez-vous dans la base de données.
        private void updateAppointment(object sender, RoutedEventArgs e)
        {
            double hour = InputCheck.checkHourInput(appHour.Text);
            double minute = InputCheck.checkMinuteInput(appMinute.Text);
            if (hour < 25 && minute < 60)
            {
                DateTime appDateTime = appointmentdate.DisplayDate;
                appDateTime = appDateTime.AddHours(hour);
                appDateTime = appDateTime.AddMinutes(minute);
                Appointment appointmentToUpdate = new Appointment();
                Broker broker = (Broker)brokerComboBox.SelectedItem;
                Customer customer = (Customer)customerComboBox.SelectedItem;
                appointmentToUpdate.IdBroker = broker.IdBroker;
                appointmentToUpdate.IdCustomer = customer.IdCustomer;
                appointmentToUpdate.DateHour = appDateTime;
                appointmentToUpdate.IdAppointment = Convert.ToInt32(id.Content);
                appointmentToUpdate.Subject = appSubject.Text;
                agendaContext _db2 = new agendaContext();
                _db2.Appointments.Update(appointmentToUpdate);
                if (_db2.SaveChanges() > 0)
                {
                    erreurMessage.Content = "Rendez-vous modifié.";
                    erreurMessage.Foreground = Brushes.Green;
                    refreshAppointmentList();
                }
                else
                {
                    erreurMessage.Content = "Une erreur c'est produit!";
                }
            }
        }
        //Met a jour la liste de rendez-vous.
        private void refreshAppointmentList()
        {
            agendaContext _db = new agendaContext();
            appointmentsDataGrid.ItemsSource = AppointmentListBuilder();
            appointmentsDataGrid.Items.Refresh();
        }
        //Au clique sur le bouton supprime le rendez-vous.
        private void deleteAppointment(object sender, RoutedEventArgs e)
        {
            agendaContext _db3 = new agendaContext();
            Appointment toDeletAppointment = new Appointment();
            toDeletAppointment.IdAppointment = Convert.ToInt32(id.Content);
            _db3.Appointments.Remove(toDeletAppointment);
            _db3.SaveChanges();
            refreshAppointmentList();
        }
        //Intégre les données des clients et courtiers dans la liste des rendez-vous
       private List<Appointment> AppointmentListBuilder()
        {
            agendaContext _db = new agendaContext();
            List<Appointment> appointments;
           appointments = _db.Appointments.ToList();
           foreach(Appointment appointment in appointments)
            {
                appointment.IdCustomerNavigation = _db.Customers.Find(appointment.IdCustomer);
                appointment.IdBrokerNavigation = _db.Brokers.Find(appointment.IdBroker);
            }
           return appointments;
        }
        //Retrouve l'index du client dans la comboBox customerComboBox;
        private int findCustomerComboIndex(int id)
        {
            int index = 0;
            foreach(Customer item in customerComboBox.Items)
            {
                if(item.IdCustomer == id)
                {
                    return index;
                }
                index++;
            }
            return 0;
        }
        //Retrouve l'index du courtier dans la comboBox brokerComboBox;
        private int findBrokerComboIndex(int id)
        {
            int index = 0;
            foreach (Broker item in brokerComboBox.Items)
            {
                if (item.IdBroker == id)
                {
                    return index;
                }
                index++;
            }
            return 0;
        }
    }
}
