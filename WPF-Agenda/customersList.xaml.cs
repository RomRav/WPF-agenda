using Microsoft.EntityFrameworkCore;
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
    public partial class customersList : Page
    {
        private readonly agendaContext _db;
        public customersList()
        {
            _db = new agendaContext();
            InitializeComponent();
            this.DataContext = new Customer();
            List<Customer> customerList = _db.Customers.ToList();
            customerDataGrid.ItemsSource = customerList;
        }
        //Au double clique sur une ligne de la liste de clients, les informations du client son automatiquement complété dans le formulaire de modification.
        private void transferDataToForm_Click(object sender, MouseButtonEventArgs e)
        {
            Customer selected_row = (Customer)customerDataGrid.SelectedItem;
            lastnameInput.Text = selected_row.Lastname;
            firstnameInput.Text = selected_row.Firstname;
            mailInput.Text = selected_row.Mail;
            phoneInput.Text = selected_row.PhoneNumber;
            budgetInput.Text = selected_row.Budget.ToString();
            id.Content = selected_row.IdCustomer;
        }
        //Au clique sur le bouton modifiez, met à jour le contenu du client.
        private void updateCustomer(object sender, RoutedEventArgs e)
        {
            Customer customerToUpdate = new Customer();
            customerToUpdate.IdCustomer = Convert.ToInt32(id.Content);
            customerToUpdate.Lastname = lastnameInput.Text;
            customerToUpdate.Firstname = firstnameInput.Text;
            customerToUpdate.Budget = InputCheck.checkBudget(budgetInput.Text);
            if (InputCheck.checkEmail(mailInput.Text) && InputCheck.checkPhone(phoneInput.Text) && customerToUpdate.Budget != 0 && customerToUpdate.Firstname != "" && customerToUpdate.Lastname != "")
            {
                agendaContext _db2 = new agendaContext();
                customerToUpdate.Mail = mailInput.Text;
                customerToUpdate.PhoneNumber = phoneInput.Text;
                _db.Customers.Update(customerToUpdate);
                if (_db.SaveChanges() > 0)
                {
                    MessageBox.Show("Client bien enregistré");
                    refreshCustomerList();
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
        //Au clique sur le bouton supprime le client.
        private void deleteCustomer(object sender, RoutedEventArgs e)
        {
            agendaContext _db3 = new agendaContext();
            Customer toDeletCustomer = new Customer();
            toDeletCustomer.IdCustomer = Convert.ToInt32(id.Content);
            _db3.Customers.Remove(toDeletCustomer);
            _db3.SaveChanges();
            refreshCustomerList();
        }
        //Met a jour la liste de client
        private void refreshCustomerList()
        {
            agendaContext _db = new agendaContext();
            List<Customer> customerList = _db.Customers.ToList();
            customerDataGrid.ItemsSource = customerList;
        }
    }
}
