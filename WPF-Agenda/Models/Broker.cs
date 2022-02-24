using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WPF_Agenda.Models;

namespace WPF_Agenda.Models
{
    internal class Broker
    {
        [Key]
        public int IdBrokers { get; set; }
        [Required(ErrorMessage ="Veuillez saisir un nom.")]
        [Display(Name ="Nom du courtier")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "Veuillez saisir un prénom.")]
        [Display(Name = "Prénom du courtier")]
        public string Firstname { get; set; }
        [EmailAddress(ErrorMessage = "La saisie n'est pas une adress mail.")]
        [Required(ErrorMessage ="Veuillez saisir un e-mail.")]
        [Display(Name ="E-mail")]
        public string Mail { get; set; }
        [Required(ErrorMessage ="Veuillez saisir un numéro de téléphone.")]
        [Display(Name ="Numéro de téléphone")]
        public string PhoneNumber { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
