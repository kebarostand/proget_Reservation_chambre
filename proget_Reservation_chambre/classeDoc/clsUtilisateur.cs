using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proget_Reservation_chambre.classeDoc
{
    class clsUtilisateur
    {
        int codeUser;
        string nom;
        string motPasse;
        string niveau;

        public int CodeUser
        {
            get
            {
                return codeUser;
            }

            set
            {
                codeUser = value;
            }
        }

        public string Nom
        {
            get
            {
                return nom;
            }

            set
            {
                nom = value;
            }
        }

        public string MotPasse
        {
            get
            {
                return motPasse;
            }

            set
            {
                motPasse = value;
            }
        }

        public string Niveau
        {
            get
            {
                return niveau;
            }

            set
            {
                niveau = value;
            }
        }
    }
}
