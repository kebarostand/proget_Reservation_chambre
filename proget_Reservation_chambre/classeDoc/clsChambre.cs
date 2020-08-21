using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proget_Reservation_chambre.classeDoc
{
    class clsChambre
    {
        int codeChambre;
        string numChambre;
        int refChambre;
public int CodeChambre
        {
            get
            {
                return codeChambre;
            }

            set
            {
                codeChambre = value;
            }
        }

        public string NumChambre
        {
            get
            {
                return numChambre;
            }

            set
            {
                numChambre = value;
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
    }
}
