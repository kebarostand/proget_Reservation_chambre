using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proget_Reservation_chambre.classeDoc
{
    class clsClasse
    {
        int codeClasse;
        string designationClasse;

        public int CodeClasse
        {
            get
            {
                return codeClasse;
            }

            set
            {
                codeClasse = value;
            }
        }

        public string Designation
        {
            get
            {
                return designationClasse;
            }

            set
            {
                designationClasse = value;
            }
        }
    }
}
