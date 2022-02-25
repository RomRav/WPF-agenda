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
    /// <summary>
    /// Logique d'interaction pour addBroker.xaml
    /// </summary>
    public partial class addBroker : Page
    {
        private readonly AgendaContext _db;
        public addBroker()
        {
            _db = new AgendaContext();
            InitializeComponent();
        }
        //Ajoute un nouveau courtier dans la base de données si les données saisie sont correct
        private void addBrokerToDb(object sender, RoutedEventArgs e)
        {

            Broker broker = new Broker();
            broker.Firstname = firstnameInput.Text;
            broker.Lastname = lastnameInput.Text;
            if (InputCheck.checkEmail(mailInput.Text) && InputCheck.checkPhone(phoneInput.Text))
            {
                broker.Mail = mailInput.Text;
                broker.PhoneNumber = phoneInput.Text;
                _db.Brokers.Add(broker);
                if (_db.SaveChanges() > 0)
                {
                    erreurLabel.Content = "Courtier enregistré!";
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
        //Au clique sur le bouton annulez retourne a la liste des courtiers.
        private void cancel(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new System.Uri("brokersList.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
