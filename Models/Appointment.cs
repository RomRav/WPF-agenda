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
        public DateTime DateHour { get; set; }
        [Required(ErrorMessage ="Veuillez saisir un sujet.")]
        public string Subject { get; set; }
        [Required(ErrorMessage ="Veuillez sélectioner un courtier")]
        
        [Column("idBroker")]
        public int IdBroker { get; set; }
        [Required(ErrorMessage = "Veuillez sélectioner un client")]
     
        [Column("idCustomer")]
        public int IdCustomer { get; set; }
        [NotMapped]
        public virtual Broker IdBrokerNavigation { get; set; } = null!;
        [NotMapped]
        public virtual Customer IdCustomerNavigation { get; set; } = null!;
    }
}
