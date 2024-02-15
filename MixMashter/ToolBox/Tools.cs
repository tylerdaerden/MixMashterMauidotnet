using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MixMashter.ToolBox
{
    public class Tools
    {

        public static bool CheckEntryName(string name)
        {
            //name = "P- Henri";
            //si le nom débute ou termine par un espace ou un tiret
            if (name.StartsWith(" ") || name.StartsWith("-") || name.EndsWith(" ") || name.EndsWith("-"))
            {
                //MessageBox.Show($"La saisie {name} ne peut commencer ou se terminer par un espace ou un tiret", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            //si le nom contient au moins un double espace.
            if (name.Contains(" ") || name.Contains("--"))
            {
                //MessageBox.Show($"La saisie {name} comporte au moins un double espace ou tiret non autorisé", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            //test s'il y a présence de caractère spéciaux (en dehors de l'alphabet) ou accentués sans tenir compte d'un espace ou un tiret (derrière le Z: Z -)
            if (!Regex.IsMatch(name, @"^[a-zA-Z -]*$"))
            {
                //MessageBox.Show($"La saisie {name} ne peut comporter de caractères spéciaux ou accentués", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            string[] nameParts = name.Split('-', ' ');
            foreach (string s in nameParts)
            {
                //test si la première lettre est une majuscule et les suivantes de a à z en minuscule et sans accent
                if (!Regex.IsMatch(s, @"^[A-Z][a-z]*$"))
                {
                    //MessageBox.Show($"La saisie {name} ne correpond pas aux critères. La première lettre de chaque élément qui compose la saisie doit être une majuscule et les suivantes des minuscules.", $"Erreur de saisie {name}", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
            }
            //tous les tests concluants, saisie valide.
            return true;
        }

        public static bool CheckEMail(string tryEmail)
        {
            /*format accepté semblable à "a@b.com";
            obligatoirement de 1 à 25 caractères de a z, 0 à 9 puis obligatoirement le @ puis
            obligatoirement de 1 à 20 caractère de a z, 0 à 9 puis un . puis 2 à 3 caractères (be, com, fr, ...*/
            if (!string.IsNullOrEmpty(tryEmail))
            {
                if (!Regex.IsMatch(tryEmail, @"^[a-z0-9]{1,25}@[a-z0-9]{1,20}\.[a-z]{2,3}$"))
                {
                    //MessageBox.Show($"L'adresse mail est incorrecte", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
                return true;
            }
            return false;
        }

    }
}
