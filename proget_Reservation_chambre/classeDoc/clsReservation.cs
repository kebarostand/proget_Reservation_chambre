using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proget_Reservation_chambre.classeDoc
{
    class clsReservation
    {
        int codeReservation;
        DateTime dateDebut;
        DateTime dateFin;
        float prix;
        int refClient;
        int refChambre;
        DateTime dateEnregistrement;
        string usersession;

        public int CodeReservation
        {
            get
            {
                return codeReservation;
            }

            set
            {
                codeReservation = value;
            }
        }

        public DateTime DateDebut
        {
            get
            {
                return dateDebut;
            }

            set
            {
                dateDebut = value;
            }
        }

        public DateTime DateFin
        {
            get
            {
                return dateFin;
            }

            set
            {
                dateFin = value;
            }
        }

        public float Prix
        {
            get
            {
                return prix;
            }

            set
            {
                prix = value;
            }
        }

        public int RefClient
        {
            get
            {
                return refClient;
            }

            set
            {
                refClient = value;
            }
        }

        public int RefChambre
        {
            get
            {
                return refChambre;
            }

            set
            {
                refChambre = value;
            }
        }

        public DateTime DateEnregistrement
        {
            get
            {
                return dateEnregistrement;
            }

            set
            {
                dateEnregistrement = value;
            }
        }

        public string Usersession
        {
            get
            {
                return usersession;
            }

            set
            {
                usersession = value;
            }
        }
    }
}
