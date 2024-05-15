//using Intents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MixMashter.Utilities.ToolBox.Checks
{
    public class CheckTools
    {
        //constantes ou variables (notamment pour les formats acceptés d'images)
        private static string[] ACCEPTED_PIC_EXT_FILES = { ".png", ".jpg" };

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

        /// <summary>
        /// méthode de vérification du MDP , 12 char min MAJ et min a-z 0-9 pas de caractères spéciaux ou accents
        /// </summary>
        /// <param name="tryPassword"></param>
        /// <returns></returns>
        public static bool CheckPassword(string tryPassword)
        {
            if (string.IsNullOrEmpty(tryPassword))
            {
                throw new ArgumentException("Le mot de passe ne peut pas être vide.");
            }
            // Expression régulière pour vérifier si le mot de passe contient uniquement des lettres (majuscules et minuscules) et des chiffres
            // et a une longueur minimale de 12 caractères
            if (!Regex.IsMatch(tryPassword, @"^[a-zA-Z0-9]{12,30}$"))
            {
                throw new ArgumentException("Le mot de passe ne correspond pas aux standards demandés. Il doit contenir au moins 12 caractères alphanumériques.");
            }
            return true;
        }
        /// <summary>
        /// Méthode de vérification du choix de genre ici choix sur base d'un int pour + de choix, possibilité actuelle étant de 0 (non spécifié) , 1(féminin) , 2(masculin)
        /// </summary>
        /// <param name="genderint"></param>
        /// <returns></returns>
        public static bool CheckGender(int genderint)
        {
            //set d'une constante d'un int max pour le choix de genre , pourra être modifié si besoin ajouter + de possibilité
            const int maxintchoice = 2;   
            if(int.IsNegative(genderint) || genderint > maxintchoice)
            {
                throw new ArgumentException($"le choix ne corresponds pas aux standars : soit un nombre non négatif allant de 0 à {maxintchoice}");
            }
            return true;
        }

        public static bool CheckGenderPlus(int genderinput)
        {
            // choix ici d'une constante fixée au maximum de choix de genres possible , ici 0 = non spécifié (qui englobe tout les autres choix) , 1 Féminin , 2 Masculin
            const int maxchoice = 2;

            if(int.IsNegative(genderinput) || genderinput > maxchoice)
            {
                throw new ArgumentException($"Le Nombre Saisie ne peut être négatif ou ne peut dépasser {maxchoice}");
            }

            return true;
        }

        /// <summary>
        /// Check Picture only admitted .png and .jpg files, minimum and maximum memory size, full file path must exist
        /// </summary>
        /// <param name="path"></param>
        /// <returns>true if file ok</returns>
        static public bool CheckPicture(string path)
        {
            string pattern = "";
            long fileLength;


            foreach (string ext in ACCEPTED_PIC_EXT_FILES)
            {
                pattern += ext + "|";
            }
            pattern = pattern.Substring(0, pattern.Length - 1) + "$";//remove last "|" unuseful

            //test File extension 
            if (!Regex.IsMatch(path, pattern)) //pattern = ".png|.jpg$" -> test if end of string like .png or .jpg
            {
                //MessageBox.Show($"L'extension du fichier photo {path} n'est pas valide", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }



            return true;
        }

        /// <summary>
        /// Check Name must be at least one char.
        /// </summary>
        /// <param name="tryAccount"></param>
        /// <returns></returns>
        public static bool CheckNameMin1Char(string tryName)
        {
            if (!string.IsNullOrEmpty(tryName))
            {
                if (tryName.Length >= 1)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Check Correct Website Format
        /// </summary>
        /// <param name="tryUrl"></param>
        /// <returns></returns>
        public static bool CheckUrl(string tryUrl)
        {
            if (!string.IsNullOrEmpty(tryUrl))
            {
                if (!Regex.IsMatch(tryUrl, @"(https?:\/\/(?:www\.|(?!www))[a-zA-Z0-9][a-zA-Z0-9-]+[a-zA-Z0-9]\.[^\s]{2,}|www\.[a-zA-Z0-9][a-zA-Z0-9-]+[a-zA-Z0-9]\.[^\s]{2,}|https?:\/\/(?:www\.|(?!www))[a-zA-Z0-9]+\.[^\s]{2,}|www\.[a-zA-Z0-9]+\.[^\s]{2,})"))
                {
                    return false;
                }
                return true;
            }
            //MessageBox.Show($"La saisie {tryUrl} ne correpond pas au format ", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
            return false;
        }

        /// <summary>
        ///Check address format typical "23, rue de la bénédiction 7000 Mons"
        ///"[N°](A,B,...), [nom de rue] [code postal] [Ville (Pays)]"
        /// </summary>
        /// <param name="tryAddress"></param>
        /// <returns></returns>
        public static bool CheckAddress(string tryAddress)
        {
            if (!string.IsNullOrEmpty(tryAddress))
            {
                if (!Regex.IsMatch(tryAddress, @"^[0-9]{1,}[a-zA-Z]?, [a-zA-Zéèêà ]{1,} [0-9]{2,} [a-zA-Zéèêà() ]{1,}$"))
                {
                    //MessageBox.Show($"La saisie {tryAddress} ne correpond pas au format [N°](A,B,...), [nom de rue] [code postal] [Ville (Pays)]", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Vat Code number for belgian company BE 0563.191.043
        /// </summary>
        /// <param name="tryAccount"></param>
        /// <returns></returns>
        public static bool CheckBelgianVatCode(string tryCode)
        {
            if (!string.IsNullOrEmpty(tryCode))
            {
                if (!Regex.IsMatch(tryCode, @"^BE\s?\d{4}\.\d{3}\.\d{3}$"))
                {
                    //MessageBox.Show($"La saisie {trytryCode} ne correpond pas au format ", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
                return true;
            }
            return false;
        }














    }
}
