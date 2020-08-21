using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proget_Reservation_chambre.classeDoc;

namespace proget_Reservation_chambre.classeDoc
{
    class clcConnexion
    {
        public string chemin="";
        public void connect()
        {
            pubConnect.testFile();
            // chemin = "server=DESKTOP-M88QUSG;database=GESTION_RESERVATION_CHAMBRE;uid=sa;pwd=wifi;";
            chemin = File.ReadAllText(clsConstante.Table.chemin).Trim();

        }
    }
}
