using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Agenda.Models
{
    public class Appointment
    {
        [Key]
        public int IdAppointment { get; set; }
        [Required(ErrorMessage ="Veuillez saisir un horaire.")]
        [Display(Name ="Date/Heure du rendez-vous.")]
        public DateTime DateHour { get; set; }
        [Required(ErrorMessage ="Veuillez saisir un sujet.")]
        [Display(Name ="Sujet")]
        public string Subject { get; set; }
        [Required(ErrorMessage ="Veuillez sélectioner un courtier")]
        [Display(Name ="Courtier")]
        [ForeignKey("IdBroker")]
        public int IdBroker { get; set; }
        [Required(ErrorMessage = "Veuillez sélectioner un client")]
        [Display(Name = "Client")]
        [ForeignKey("IdCustomer")]
        public int IdCustomer { get; set; }
        
        public virtual Broker IdBrokerNavigation { get; set; } = null!;
      
        public virtual Customer IdCustomerNavigation { get; set; } = null!;
    }
}
