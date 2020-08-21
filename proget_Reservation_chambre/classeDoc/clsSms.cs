using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proget_Reservation_chambre.classeDoc
{
    class clsSms
    {
        int code;
        string numero_tutaire;
        string corps_message;
        DateTime date_envoie;
        int etats_sms;
        string utilisateur;

        public int Code
        {
            get
            {
                return code;
            }

            set
            {
                code = value;
            }
        }

        public string Numero_tutaire
        {
            get
            {
                return numero_tutaire;
            }

            set
            {
                numero_tutaire = value;
            }
        }

        public string Corps_message
        {
            get
            {
                return corps_message;
            }

            set
            {
                corps_message = value;
            }
        }

        public int Etats_sms
        {
            get
            {
                return etats_sms;
            }

            set
            {
                etats_sms = value;
            }
        }

        public string Utilisateur
        {
            get
            {
                return utilisateur;
            }

            set
            {
                utilisateur = value;
            }
        }

        public DateTime Date_envoie
        {
            get
            {
                return date_envoie;
            }

            set
            {
                date_envoie = value;
            }
        }
    }
}
