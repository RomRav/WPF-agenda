using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Agenda.Models
{
    public class Customer
    {
        [Key]
        public int IdCustomer { get; set; }
        [Required(ErrorMessage ="Veuillez saisir un nom.")]
        [Display(Name ="Nom client")]
        public string Lastname { get; set; }
        [Required(ErrorMessage ="Veuillez saisir un prénom.")]
        [Display(Name ="Prénom client")]
        public string Firstname { get; set; }
        [Required(ErrorMessage ="Veuillez saisir un email.")]
        [Display (Name ="E-mail")]
        [EmailAddress(ErrorMessage = "La saisie n'est pas une adress mail.")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "Veuillez saisir un numéro de téléphone.")]
        [Display(Name ="Numéro de téléphone")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage ="Veuillez saisir un budget.")]
        [Display(Name ="Budget")]
        public int Budget { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
