using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proget_Reservation_chambre.classeDoc
{
    class clsPaiement
    {
        int codePaiement;
        DateTime datePayer;
        double montantPayer;
        int refReservation;
        string usersession;

        public int CodePaiement
        {
            get
            {
                return codePaiement;
            }

            set
            {
                codePaiement = value;
            }
        }

        public DateTime DatePayer
        {
            get
            {
                return datePayer;
            }

            set
            {
                datePayer = value;
            }
        }

        public double MontantPayer
        {
            get
            {
                return montantPayer;
            }

            set
            {
                montantPayer = value;
            }
        }

        public int RefReservation
        {
            get
            {
                return refReservation;
            }

            set
            {
                refReservation = value;
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
