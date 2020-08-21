using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proget_Reservation_chambre.classeDoc
{
    class ClsBase
    {
        string nomTable;
        string nomChamp;

        public string NomTable
        {
            get
            {
                return nomTable;
            }

            set
            {
                nomTable = value;
            }
        }

        public string NomChamp
        {
            get
            {
                return nomChamp;
            }

            set
            {
                nomChamp = value;
            }
        }
    }
}
