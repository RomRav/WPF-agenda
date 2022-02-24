using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WPF_Agenda.Models
{
    public class InputCheck
    {

        //Verifie que la string envoyé en paramétre est bien un email
        public static bool checkEmail(string email)
        {
            Regex emailRegex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            if (!emailRegex.IsMatch(email))
            {
                return false;
            }
            return true;
        }
        //Verifie que la string envoyé en paramétre est bien un numéro de téléphone français
        public static bool checkPhone(string phone)
        {
            Regex phoneRegex = new Regex(@"^(?:(?:\+|00)33[\s.-]{0,3}(?:\(0\)[\s.-]{0,3})?|0)[1-9](?:(?:[\s.-]?\d{2}){4}|\d{2}(?:[\s.-]?\d{3}){2})$");
            if (!phoneRegex.IsMatch(phone))
            {
                return false ;
            }
            return true;
        }
        //Verifie que la string envoyé en paramétre est bien un numérique
        public static int checkBudget(string budget)
        {
            int budgetNumber = 0;
            if (Int32.TryParse(budget, out budgetNumber))
            {
                return budgetNumber;
            }
            else
            {
               return budgetNumber;
            }
        }
    }
}
