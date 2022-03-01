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
    public partial class brokersList : Page
    {
        private readonly agendaContext _db;
        public brokersList()
        {
            _db = new agendaContext();
            InitializeComponent();
            List<Broker> brokers = _db.Brokers.ToList();
            brokerDataGrid.ItemsSource = brokers;
        }
        //Au double clique sur une ligne de la liste de courtiers, les informations du courtier son automatiquement complété dans le formulaire de modification.
        private void transferDataToForm_Click(object sender, MouseButtonEventArgs e)
        {
            Broker selected_row = (Broker)brokerDataGrid.SelectedItem;
            lastnameInput.Text = selected_row.Lastname;
            firstnameInput.Text = selected_row.Firstname;
            mailInput.Text = selected_row.Mail;
            phoneInput.Text = selected_row.PhoneNumber;
            id.Content = selected_row.IdBroker;
        }
        //Au clique sur le bouton modifiez, met à jour le contenu du courtier.
        private void updateBroker(object sender, RoutedEventArgs e)
        {
            Broker brokerToUpdate = new Broker();
            brokerToUpdate.IdBroker = Convert.ToInt32(id.Content);
            brokerToUpdate.Lastname = lastnameInput.Text;
            brokerToUpdate.Firstname = firstnameInput.Text;
            if (InputCheck.checkEmail(mailInput.Text) && InputCheck.checkPhone(phoneInput.Text) && brokerToUpdate.Lastname != "" && brokerToUpdate.Firstname != "")
            {
                agendaContext _db2 = new agendaContext();
                brokerToUpdate.Mail = mailInput.Text;
                brokerToUpdate.PhoneNumber = phoneInput.Text;
                _db2.Brokers.Update(brokerToUpdate);
                if (_db2.SaveChanges() > 0)
                {
                    MessageBox.Show("Courtier modifié.");
                    refreshBrokerList();
                }
                else
                {
                    MessageBox.Show("Une erreur c'est produit!");
                }
            }
            else
            {
                MessageBox.Show("Erreur de saisie, merci de verifier les saisies.");
            }
        }
        //Au clique sur le bouton modifiez, met à jour le contenu du courtier.
        private void deleteBroker(object sender, RoutedEventArgs e)
        {
            agendaContext _db3 = new agendaContext();
            Broker toDeletBroker = new Broker();
            toDeletBroker.IdBroker = Convert.ToInt32(id.Content);
            _db3.Brokers.Remove(toDeletBroker);
            _db3.SaveChanges();
            refreshBrokerList();
        }
        //Met a jour la liste de client
        private void refreshBrokerList()
        {
            agendaContext _db = new agendaContext();
            List<Broker> brokerList = _db.Brokers.ToList();
            brokerDataGrid.ItemsSource = brokerList;
        }
    }
}
