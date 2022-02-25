using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// <summary>
    /// Logique d'interaction pour addCustomer.xaml
    /// </summary>
    public partial class addCustomer : Page
    {
       private readonly AgendaContext _db;
        public addCustomer()
        {
           _db = new AgendaContext();
            InitializeComponent();
        }
        //Ajoute un nouveau client dans la base de données si les données saisie sont correct
        private void addCustomerToDb(object sender, RoutedEventArgs e)
        {
            
            Customer customer = new Customer();
            customer.Firstname = firstnameInput.Text;
            customer.Lastname = lastnameInput.Text;
            customer.Budget = InputCheck.checkBudget(budgetInput.Text);
            if(InputCheck.checkEmail(mailInput.Text) && InputCheck.checkPhone(phoneInput.Text) && customer.Budget != 0 )
            {
                customer.Mail = mailInput.Text;
                customer.PhoneNumber = phoneInput.Text;
                _db.Customers.Add(customer);
                if (_db.SaveChanges() > 0)
                {
                    erreurLabel.Content = "OK.";
                    erreurLabel.Foreground = Brushes.Green;
                }
                else
                {
                    erreurLabel.Content = "Une erreur c'est produit!";
                }  
            }
            else
            {
                erreurLabel.Content = "Erreur de saisie, merci de verifier les saisies.";
            } 
        }
        //Au clique sur le bouton annulez retourne a la liste des clients
        private void cancel(object sender, RoutedEventArgs e)
        {
           this.NavigationService.Navigate(new System.Uri("customersList.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
