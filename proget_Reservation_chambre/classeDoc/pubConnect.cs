using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using proget_Reservation_chambre.formulaire;

namespace proget_Reservation_chambre.classeDoc
{
    class pubConnect
    {

        public static string server;
        public static string database;
        public static string uid;
        public static string pwd;

        public static void testFile()
        {
            //test si dossier existe
            if (Directory.Exists("C:\\cheminReservation")== true)
            {

            }
            else
            {
                Directory.CreateDirectory("C:\\cheminReservation");
            }

            //text si le fichier existe
            if (File.Exists("C:\\cheminReservation\\monchemin.txt") == true)
            {

            }
            else
            {
                //sinon on appell la co
                frmConfigiration frm = new frmConfigiration();
                frm.ShowDialog(); 
            }
        }
    }
}
